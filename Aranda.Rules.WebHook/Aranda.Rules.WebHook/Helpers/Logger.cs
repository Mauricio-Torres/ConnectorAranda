using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Aranda.Rules.WebHook.Helpers
{
    public static class Logger
    {
        public static void Logguer(string FuncName, string typeError, string error)
        {
            try
            {
                string AppPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                AppPath = AppPath.Replace(@"file:\", "") + @"\";

                string fname = AppPath + "Log.txt";

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                sb.AppendLine(FuncName);
                sb.AppendLine("Tipo Error" + typeError);
                sb.AppendLine(error);
                sb.AppendLine("-------------------------------");

                File.AppendAllText(fname, sb.ToString());
            }
            catch
            {

            }
        }
    }
}