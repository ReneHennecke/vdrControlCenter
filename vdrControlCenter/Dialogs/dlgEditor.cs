namespace vdrControlCenterUI.Dialogs
{
    using System;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using vdrControlCenterUI.Controls;
    using vdrControlService.Models;

    public partial class dlgEditor : Form
    {
        private Regex _splitter = new Regex("\\n");
        

        private string[] _keywords = { "public", "void", "using", "static", "class", "True" };

        public string Content
        {
            get { return rtbEditor.Text; }
            set { rtbEditor.Text = value; }
        }

        public dlgEditor()
        {
            InitializeComponent();
        }

        private int GetWidth()
        {
            int w = 25;
            // get total lines of richTextBox1    
            int line = rtbEditor.Lines.Length;

            if (line <= 99)
            {
                w = 20 + (int)rtbEditor.Font.Size;
            }
            else if (line <= 999)
            {
                w = 30 + (int)rtbEditor.Font.Size;
            }
            else
            {
                w = 50 + (int)rtbEditor.Font.Size;
            }

            return w;
        }

        public void AddLineNumbers()
        {
            // create & set Point pt to (0,0)    
            Point pt = new Point(0, 0);
            // get First Index & First Line from richTextBox1    
            int firstIndex = rtbEditor.GetCharIndexFromPosition(pt);
            int firstLine = rtbEditor.GetLineFromCharIndex(firstIndex);
            // set X & Y coordinates of Point pt to ClientRectangle Width & Height respectively    
            pt.X = ClientRectangle.Width;
            pt.Y = ClientRectangle.Height;
            // get Last Index & Last Line from richTextBox1    
            int Last_Index = rtbEditor.GetCharIndexFromPosition(pt);
            int Last_Line = rtbEditor.GetLineFromCharIndex(Last_Index);
            // set Center alignment to LineNumberTextBox    
            rtbLineNumbers.SelectionAlignment = HorizontalAlignment.Center;
            // set LineNumberTextBox text to null & width to getWidth() function value    
            rtbLineNumbers.Text = "";
            rtbLineNumbers.Width = GetWidth();
            // now add each line number to LineNumberTextBox upto last line    
            for (int i = firstLine; i <= Last_Line + 2; i++)
            {
                rtbLineNumbers.Text += i + 1 + "\n";
            }
        }

        public void PostInit(CommanderView view, FileSystemEntry fse, string content, bool readOnly = true)
        {
            string text = readOnly ? "View" : "Edit";
            Text = $"{readOnly} ¤ [{fse.FullPath}]";
            rtbEditor.Text = content;
            rtbEditor.Select(0, 0);
            rtbEditor.ReadOnly = readOnly;

            Parser();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dlgEditor_Load(object sender, EventArgs e)
        {
            rtbLineNumbers.Font = rtbEditor.Font;
            rtbEditor.Select();
            AddLineNumbers();
        }

        private void rtEditor_Resize(object sender, EventArgs e)
        {
            AddLineNumbers();
        }

        private void rtbEditor_SelectionChanged(object sender, EventArgs e)
        {
            Point pt = rtbEditor.GetPositionFromCharIndex(rtbEditor.SelectionStart);
            if (pt.X == 1)
                AddLineNumbers();
        }

        private void rtbEditor_VScroll(object sender, EventArgs e)
        {
            rtbLineNumbers.Text = "";
            AddLineNumbers();
            rtbLineNumbers.Invalidate();
        }

        private void rtbEditor_TextChanged(object sender, EventArgs e)
        {
            if (rtbEditor.Text == "")
                AddLineNumbers();

            
        }

        private void rtbEditor_FontChanged(object sender, EventArgs e)
        {
            rtbLineNumbers.Font = rtbEditor.Font;
            rtbEditor.Select();
            AddLineNumbers();
        }

        private void rtbEditor_MouseDown(object sender, MouseEventArgs e)
        {
            rtbEditor.Select();
            rtbLineNumbers.DeselectAll();
        }

        private void Parser()
        {
            string[] lines = _splitter.Split(Text);
            foreach (string l in lines)
            {
                ParseLine(l);
            }
        }
        
        private void ParseLine(string line)
        {
            Regex r = new Regex("([ \\t{}():;])");
            String[] tokens = r.Split(line);
            foreach (string token in tokens)
            {
                // Set the tokens default color and font.  
                rtbEditor.SelectionColor = Color.Black;
                rtbEditor.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
                // Check whether the token is a keyword.   
                
                for (int i = 0; i < _keywords.Length; i++)
                {
                    if (_keywords[i] == token)
                    {
                        // Apply alternative color and font to highlight keyword.  
                        rtbEditor.SelectionColor = Color.Blue;
                        rtbEditor.SelectionFont = new Font("Courier New", 10, FontStyle.Bold);
                        break;
                    }
                }
                rtbEditor.SelectedText = token;
            }
            rtbEditor.SelectedText = "\n";
        }

    }
}
