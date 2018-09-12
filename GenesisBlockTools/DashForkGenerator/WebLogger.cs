using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConsoleControl;

namespace DashForkGenerator
{
    public class LogPhrase
    {
        private string              Text    = "";
        private readonly string     Font    = "Consolas";
        private readonly Color      Color   = Color.White;
        private readonly FontStyle  Style = FontStyle.Regular;

        public int Length
        {
            get { return Text.Length; }
        }

        public LogPhrase(string text, Color color, FontStyle style = FontStyle.Regular)
        {
            Text    = text;
            Color   = color;
        }

        public void LogPhraseCut(int pos)
        {
            var firstPart = Text.Substring(0, pos);
            var secondPart = Text.Substring(pos + 1);
            Text = $"{firstPart}\n{secondPart}";
        }

        
        public void WritePhrase(ConsoleControl.ConsoleControl console, int size)
        {
            console.WriteOutput(Text, Color);
        }
    }

    public class LogLine
    {
        private int LineWidth = 0;
        private DateTime Dt = DateTime.Now;
        private List<LogPhrase> Phrases = new List<LogPhrase>();

        public LogLine(int lineWidth = 0)
        {
            LineWidth = lineWidth;
        }

        public void AddPhrase(LogPhrase ph)
        {
            if(LineWidth > 0)
            {
                int fullLength = Phrases.Sum(o => o.Length);
                int curLineLength = fullLength % LineWidth;

                if (curLineLength + ph.Length > LineWidth)
                    ph.LogPhraseCut(LineWidth - curLineLength);
                Phrases.Add(ph);
            }
            else
                Phrases.Add(ph);
        }

        public void WriteLine(ConsoleControl.ConsoleControl console, int size)
        {
            foreach(var ph in Phrases)
                ph.WritePhrase(console, size);
        }
    }

    public class WebLogger
    {
        private readonly Dictionary<int, char> FileProgressStr = new Dictionary<int, char>()
        {
            { 0, '|' },
            { 1, '/' },
            { 2, '-' },
            { 3, '\\' },

        };

        private readonly bool WithDates = false;
        private readonly int  LogDepth  = 0;
        private List<LogLine> Lines = new List<LogLine>();
        private bool    WithCursor = false;
        private bool    WithLoading = false;
        private char    CursorChar = '_';
        private int     LoadingCounter = 0;

        private readonly int     MainSize   = 12;
        private Color MainColor = Color.White;

        private Thread CursorThread;  
        private Thread LoadingThread;

        public WebLogger(Color color, int depth = 0, bool printDates = false, int mainSize = 12)
        {
            MainColor   = color;
            WithDates   = printDates;
            LogDepth    = depth;
            MainSize    = mainSize;
        }

        public void SetCursorMode(bool mode = true)
        {
            WithCursor = mode;

            if (WithCursor)
            {
                CursorThread = new Thread(() => { CursorProc(ref CursorChar); });
                CursorThread.Start();
            }
            else
                CursorThread.Abort();
        }

        public void SetloadingMode(bool mode = true)
        {
            WithLoading = mode;

            if (WithLoading)
            {
                LoadingThread = new Thread(() => { LoadingProc(ref LoadingCounter); });
                LoadingThread.Start();
            }
            else
                LoadingThread.Abort();
        }

        public void AddLine(LogLine line)
        {
            Lines.Add(line);

            if (LogDepth > 0 && Lines.Count > LogDepth)
                Lines.Remove(Lines.First());
        }

        public void WriteLog(ConsoleControl.ConsoleControl console)
        {
            foreach (var line in Lines)
                line.WriteLine(console, MainSize);
        }

        private void ParseStr()
        {
            /*
            foreach (var line in Lines)
                Log.AppendLine(WithDates ? line.GetStringLineDate() : line.GetStringLine());

            if (WithCursor || WithLoading)
                Log.AppendLine(DoFinalLine().GetStringLine());
                */
        }

        public void AddOnePhraseLine(string msg, int width, Color color, FontStyle style = FontStyle.Regular)
        {
            var line = new LogLine(width);
            line.AddPhrase(new LogPhrase( msg, color, style));
        }

        public void AddOnePhraseLine(string msg, int width, FontStyle style = FontStyle.Regular)
        {
            var line = new LogLine(width);
            line.AddPhrase(new LogPhrase(msg, MainColor, style));
            Lines.Add(line);
        }

        private LogLine DoFinalLine()
        {
            var line = new LogLine();

            if(WithLoading)
            {
                line.AddPhrase(new LogPhrase($"{FileProgressStr[LoadingCounter]}", MainColor, FontStyle.Regular));
            }

            if(WithCursor)
            {
                line.AddPhrase(new LogPhrase($"{CursorChar}", MainColor, FontStyle.Regular));
            }

            return line;
        }

        private static void LoadingProc(ref int load)
        {
            while(true)
            {
                load++;

                if (load > 3)
                    load = 0;

                Thread.Sleep(100);
            }
        }

        private static void CursorProc(ref char cursor)
        {
            while (true)
            {
                if (cursor == '_')
                    cursor = ' ';
                else
                    cursor = '_';

                Thread.Sleep(500);
            }
        }
    }
}
