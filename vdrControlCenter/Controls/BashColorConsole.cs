namespace vdrControlCenterUI.Controls
{
	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using System.Linq;
	using System.Text.RegularExpressions;
	using System.Windows.Forms;
	using vdrControlCenterUI.Classes;

	public class BashColorConsole : RichTextBox
	{
		public void AppendText(string text, Color color, bool addNewLine = false)
		{
			SuspendLayout();
			SelectionStart = TextLength;
			SelectionLength = 0;

			SelectionColor = color;
			AppendText(addNewLine ? $"{text}{Environment.NewLine}" : text);
			SelectionColor = ForeColor;
			ScrollToCaret();
			// ScrollToEnd();
			ResumeLayout();
		}

		public void AppendText(string text, Color color, Font font, bool addNewLine = false)
		{
			SuspendLayout();
			SelectionStart = TextLength;
			SelectionLength = 0;

			SelectionColor = color;
			SelectionFont = font;
			AppendText(addNewLine ? $"{text}{Environment.NewLine}" : text);
			SelectionColor = ForeColor;
			ScrollToCaret();
			// ScrollToEnd();
			ResumeLayout();
		}

		public List<BashColorConsoleTextRaX> PrepareConsoleString(string s)
		{
			var map = new List<KeyValuePair<string, string>>();
			map.Add(new KeyValuePair<string, string>(@"\x1b\[", ""));
			map.Add(new KeyValuePair<string, string>(@"m", ""));

			// \x1b\[.*m
			//string s = ">>>" +
			//            "\u001b[0;34mBlue\u001b[0m" +
			//            "\u001b[0;32mGreen\u001b[0m" +
			//            "\u001b[0;36mCyan\u001b[0m" +
			//            "\u001b[0;31mRed\u001b[0m" +
			//            "\u001b[0;35mPurple\u001b[0m" +
			//            "\u001b[0;33mBrown\u001b[0m" +
			//            "\u001b[0;37mLightGray\u001b[0m" +
			//            "\u001b[1;30mDarkGray\u001b[0m" +
			//            "\u001b[1;34mLightBlue\u001b[0m" +
			//            "\u001b[1;32mLightGreen\u001b[0m" +
			//            "\u001b[1;36mLightCyan\u001b[0m" +
			//            "\u001b[1;31mOrangeRed\u001b[0m" +
			//            "\u001b[1;35mMediumPurple\u001b[0m" +
			//            "\u001b[1;33mYellow\u001b[0m" +
			//            "\u001b[1;37mWhite\u001b[0m" +
			//           "<<<";

			string pattern = @"\x1b\[[0-9;]*m";
			Regex find = new Regex(pattern, RegexOptions.IgnoreCase);
			// Von Escape-Zeichen (\u001b) bis zum m lesen

			pattern = String.Join("|", map.Select(k => "(" + k.Key + ")"));
			Regex replace = new Regex(pattern, RegexOptions.Compiled);
			// Replace

			List<BashColorConsoleTextRaX> bccts = new List<BashColorConsoleTextRaX>();
			BashColorConsoleTextRaX bcct;

			bool firstLoop = true;
			Match match = find.Match(s);
			while (match.Success)
			{
				if (firstLoop && match.Index > 0)
				{
					bcct = new BashColorConsoleTextRaX()
					{
						Color = Color.Transparent,
						Text = s.Substring(0, match.Index)
					};
					bccts.Add(bcct);
				}
				firstLoop = false;

				// Console.WriteLine("Value  = " + match.Value);
				// Console.WriteLine("Length = " + match.Length);
				// Console.WriteLine("Index  = " + match.Index);
				// Console.WriteLine();

				string s1 = match.Value;
				string sequence = replace.Replace(s1, m => Evaluator(map, m));
				Color color = BashConsoleColorListRaX.GetColor(sequence);
				string text = s.Substring(match.Index + match.Length);
				int index = text.IndexOf("\u001b[");
				if (index > -1)
					text = text.Substring(0, index);

				bcct = new BashColorConsoleTextRaX()
				{
					Color = color,
					Text = text
				};
				bccts.Add(bcct);

				//Console.WriteLine($"{sequence} - {text} - {color.ToString()}");
				//Console.WriteLine();

				match = match.NextMatch();
			}

			//foreach (BashColorConsoleTextRaX bashColorConsoleText in bccts)
			//{
			//    AppendText(bashColorConsoleText.Text, bashColorConsoleText.Color, false);
			//}

			if (bccts.Count == 0 && s.Length > 0)
			{
				bcct = new BashColorConsoleTextRaX()
				{
					Color = Color.Transparent,
					Text = s
				};
				bccts.Add(bcct);
			}

			return bccts;
		}

		private static string Evaluator(List<KeyValuePair<string, string>> map, Match match)
		{
			for (int i = 0; i < match.Groups.Count; i++)
			{
				var group = match.Groups[i];
				if (group.Success)
				{
					return map[i].Value;
				}
			}

			//shouldn't happen
			throw new ArgumentException("Match found that doesn't have any successful groups");
		}

	}
}
