namespace vdrControlCenterUI.Classes
{
    using System.IO;
    using System.Linq;
    using System;
    using System.Text;

    public class SvdrpBuffer
    {
        /*
        214 Hilfetext
        215 EPG Eintrag
        216 Image grab data (base 64)
        220 VDR-Service bereit
        221 VDR-Service schließt Sende-Kanal
        250 Angeforderte Aktion okay, beendet
        354 Start senden von EPG-Daten
        451 Angeforderte Aktion abgebrochen: lokaler Fehler bei der Bearbeitung
        500 Syntax-Fehler, unbekannter Befehl
        501 Syntax-Fehler in Parameter oder Argument
        502 Befehl nicht implementiert
        504 Befehls-Parameter nicht implementiert
        550 Angeforderte Aktion nicht ausgeführt
        554 Transaktion fehlgeschlagen

        <Antwort Code><-|Leerzeichen><Text><newline>
        */

        private StringBuilder _buffer;
        private System.Text.Encoding _utf8EncoderNoBOM = new System.Text.UTF8Encoding(false);
        private const char EOL = '\n';
        private bool _enableDebug = false;

        public bool EnableDebug
        {
            get { return _enableDebug; }
            set { _enableDebug = value; }
        }

        public SvdrpBuffer()
        {
            _buffer = new StringBuilder();
            Clear();

            _enableDebug = true;
        }

        public void Clear()
        {
            _buffer.Clear();
        }

        public void Add(string s)
        {
            _buffer.Append(s);
        }

        public int Length
        {
            get { return _buffer.Length; }
        }

        public string Content
        {
            get { return _buffer.ToString(); }
            set 
            {
                Clear();
                _buffer.Append(value); 
            }
        }

        public int RowCount
        {
            get { return _buffer.ToString().Count(c => c == EOL); }
        }

        public string[] Splitter
        {
            get { return Content.Split(EOL); }
        }

        public string Save2File()
        {
            string fileName = string.Empty;
            if (_enableDebug && _buffer.Length > 0)
            {
                try
                {
                    string path = $"{AppDomain.CurrentDomain.BaseDirectory}temp";

                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);

                    fileName = $"{path}\\{Guid.NewGuid()}";
                    using (StreamWriter sw = new StreamWriter(fileName, false, _utf8EncoderNoBOM))
                    {
                        sw.Write(_buffer);
                        sw.Flush();
                        sw.Close();
                    }
                }
                catch (IOException)
                {
                    fileName = string.Empty;
                }
            }

            return fileName;
        }
    }

}
