using System;
using NLog;

namespace ItLabs.FinkInformator.Core
{
    public class CoreLog
    {
        public static void LogError(string message)
        {
            var logger = LogManager.GetLogger("fileLog");
            logger.Error(message);
        }

        public static void LogError(Exception ex)
        {
            var logger = LogManager.GetLogger("fileLog");
            logger.Error(ex);
        }
    }
}
