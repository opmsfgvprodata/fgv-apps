using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVGApps.Common
{
    public class Log
    {
        private static readonly object _lock = new object();
        private static string _logFilePath = "application.log";

        public static void Write(string message)
        {
            lock (_lock)
            {
                File.AppendAllText(_logFilePath, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} - {message}{Environment.NewLine}");
            }
        }

        public static void SetLogFilePath(string path)
        {
            _logFilePath = path;
        }
        /// <summary>
        /// Sets the log file path to a server location.
        /// </summary>
        /// <param name="serverPath">The absolute path on the server where the log file will be saved.</param>
        public static void SetServerLogFilePath(string serverPath)
        {
            if (string.IsNullOrWhiteSpace(serverPath))
                throw new ArgumentException("Server path cannot be null or empty.", nameof(serverPath));

            _logFilePath = serverPath;
        }
    }
}
