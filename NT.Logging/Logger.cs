using System;
using System.IO;
using NT.Utilities;

namespace NT.Logging
{
    public static class Logger
    {
        /// <summary>
        /// Path to the logging file
        /// </summary>
        private static string logFilePath;

        /// <summary>
        /// Calls configure to load <see cref="logFilePath"/>
        /// </summary>
        static Logger()
        {
            Configure();
        }

        /// <summary>
        /// Loads the path from the config file,
        /// and assigns it to <see cref="logFilePath"/>
        /// </summary>
        private static void Configure()
        {
            logFilePath = $"{Directory.GetCurrentDirectory()}/log.txt";
        }

        /// <summary>
        /// Logs a message
        /// </summary>
        /// <param name="message"></param>
        public static void Log(string message)
        {
            WriteLog(message);
        }

        /// <summary>
        /// Logs an exception
        /// </summary>
        /// <param name="ex"></param>
        public static void Log(Exception ex)
        {
            // Get original Exception
            Exception original = ex.GetOriginalException();

            WriteLog(
                $"Exception: {ex.Message}\n" +
                $"Stacktrace:\n{ex.StackTrace}\n" +
                $"Source: {ex.Source}\n" +
                $"InnerException: {original.Message} \n" +
                $"Stracktrace\n{original.StackTrace}\n" +
                $"Source: {original.Source}\n");
        }

        /// <summary>
        /// Logs the <see cref="string"/> parameter value
        /// to the logging file in <see cref="logFilePath"/>
        /// </summary>
        /// <param name="logMessage"></param>
        private static void WriteLog(string logMessage)
        {
            // Write error to a logging file, which will be created if it doesn't already exist.
            using StreamWriter writer = File.AppendText(logFilePath);
            {
                // Write message to file
                writer.Write(
                    $"\n[{DateTime.UtcNow}]\n" +
                    $"{logMessage}");
            }
        }
    }
}