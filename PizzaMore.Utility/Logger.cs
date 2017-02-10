using System.IO;


namespace PizzaMore.Utility
{
    public static class Logger
    {
        public static void Log(string log)
        {
            log += "\n\r";
            File.AppendAllText("log.txt", log);
        }

    }
}
