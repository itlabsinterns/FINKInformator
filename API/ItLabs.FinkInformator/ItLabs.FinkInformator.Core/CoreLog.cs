using System;
using NLog;
using ItLabs.FinkInformator.Core.Interfaces;

namespace ItLabs.FinkInformator.Core
{
    public class CoreLog:ICoreLog
    {
        public Logger _logger;
        public CoreLog()
        {
            _logger = LogManager.GetLogger("fileLog");
        }
        public void LogException(Exception ex)
        {
            _logger.Error(ex);
        }
    }
}
