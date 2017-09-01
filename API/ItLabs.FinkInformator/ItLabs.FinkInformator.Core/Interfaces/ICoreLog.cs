using System;

namespace ItLabs.FinkInformator.Core.Interfaces
{
    public interface ICoreLog
    {
        void LogException(Exception ex);
        void LogMessage(string msg);
    }
}
