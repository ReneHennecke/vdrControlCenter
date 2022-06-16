namespace vdrControlCenterUI.Classes;

public class SvdrpStatusInfo
{
    public int Total { get; private set; }
    public int Free { get; private set; }
    public decimal Percent { get; private set; }

    public SvdrpStatusInfo()
    {

    }

    public void ParseMessage(string[] response)
    {
        if (response.Length > 0 && response[0].Length > 0)
        {
            string[] prm = response[0].Substring(4).Split(' ');
            if (prm.Length > 0)
            {
                Total = Convert.ToInt32(prm[0].Replace("MB", string.Empty));
            }
            if (prm.Length > 1)
            {
                Free = Convert.ToInt32(prm[1].Replace("MB", string.Empty));
            }

            Percent = Math.Round((decimal)(Total - Free) / (decimal)Total * 100, 1);
        }
    }

}

