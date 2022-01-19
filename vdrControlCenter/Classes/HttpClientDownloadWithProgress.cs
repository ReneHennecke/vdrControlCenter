namespace vdrControlCenterUI.Classes;

public class HttpClientDownloadWithProgress : IDisposable
{
    private readonly string _downloadUrl;
    private readonly string _destinationFilePath;
    private CancellationTokenSource _cts;
    private HttpClient _httpClient;
    private string _investigateExtension;

    public delegate void ProgressChangedHandler(long? totalFileSize, long totalBytesDownloaded, double? progressPercentage, double mbps);

    public event ProgressChangedHandler ProgressChanged;

    public string InvestigateExtension
    {
        get => _investigateExtension;
    }

    public void CancelDownload()
    {
        _cts?.Cancel();
    }

    public HttpClientDownloadWithProgress(string downloadUrl, string destinationFilePath)
    {
        _downloadUrl = downloadUrl;
        _destinationFilePath = destinationFilePath;
        _cts = new CancellationTokenSource();
    }

    public async Task StartDownload()
    {
        _httpClient = new HttpClient { Timeout = TimeSpan.FromDays(1) };
        _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

        using (var response = await _httpClient.GetAsync(_downloadUrl, HttpCompletionOption.ResponseHeadersRead))
            await DownloadFileFromHttpResponseMessage(response);
    }

    private async Task DownloadFileFromHttpResponseMessage(HttpResponseMessage response)
    {
        response.EnsureSuccessStatusCode();

        var totalBytes = response.Content.Headers.ContentLength;

        _investigateExtension = response.Content.Headers.ContentType?.MediaType switch
        {
            "video/vnd.dlna.mpeg-tts" => ".mpeg",
            _ => string.Empty
        };

        using (var contentStream = await response.Content.ReadAsStreamAsync())
            await ProcessContentStream(totalBytes, contentStream);
    }

    private async Task ProcessContentStream(long? totalDownloadSize, Stream contentStream)
    {
        var farBytes = 0L;
        var stopWatch = new Stopwatch();

        var totalBytesRead = 0L;
        var readCount = 0L;
        var buffer = new byte[8192];
        var isMoreToRead = true;


        if (File.Exists(_destinationFilePath))
            File.Delete(_destinationFilePath);

        stopWatch.Start();
        var mbps = 0D;
        using (var fileStream = new FileStream(_destinationFilePath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
        {
            do
            {
                if (_cts.IsCancellationRequested)
                    break;

                var bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length, _cts.Token);
                if (bytesRead == 0)
                {
                    isMoreToRead = false;
                    TriggerProgressChanged(totalDownloadSize, totalBytesRead, mbps);
                    continue;
                }

                await fileStream.WriteAsync(buffer, 0, bytesRead);

                totalBytesRead += bytesRead;
                readCount += 1;

                if (readCount % 100 == 0)
                {
                    var ellapsed = stopWatch.ElapsedMilliseconds;
                    if (ellapsed > 1000L)
                    {
                        var ts = (double)ellapsed / 1000;
                        mbps = (int)Math.Round((double)(totalBytesRead - farBytes) / ts);
                        mbps /= 1048576;

                        farBytes = totalBytesRead;
                        stopWatch.Restart();
                    }

                    TriggerProgressChanged(totalDownloadSize, totalBytesRead, mbps);
                }
            }
            while (isMoreToRead);

            stopWatch.Stop();
        }
    }

    private void TriggerProgressChanged(long? totalDownloadSize, long totalBytesRead, double mbps)
    {
        if (ProgressChanged == null)
            return;

        double? progressPercentage = null;
        if (totalDownloadSize.HasValue)
            progressPercentage = Math.Round((double)totalBytesRead / totalDownloadSize.Value * 100, 2);

        ProgressChanged(totalDownloadSize, totalBytesRead, progressPercentage, mbps);
    }

    public void Dispose()
    {
        _httpClient?.Dispose();
    }
}