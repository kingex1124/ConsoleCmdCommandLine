using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCmdCommandLine
{
    class Program
    {
        static void Main(string[] args)
        {
            Program pg = new Program();
            pg.CmdCommanLine("ipconfig");
        }

        public void CmdCommanLine(string commandLine)
        {
            Process p = new Process();
            String str = null;

            p.StartInfo.FileName = "cmd.exe";

            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true; // 輸入是否從RedirectStandardInput資料流讀取。
            p.StartInfo.RedirectStandardOutput = true; // 是否將應用程式輸出寫入RedirectStandardOuput。
            p.StartInfo.RedirectStandardError = true; // 是否將錯誤訊息寫入RedirectStandardError。
            //p.StartInfo.CreateNoWindow = true; //不跳出cmd視窗

            p.Start();
            p.StandardInput.WriteLine(commandLine);
            p.StandardInput.WriteLine("exit");

            str = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            p.Close();


            Console.WriteLine(str);
            Console.ReadKey();
        }
    }
}
