using System;
namespace Contracts
{
	public interface ILoggerManager
	{
		void LogInfo(string message);
		void LogWarn(string mesage);
		void LogDebug(string mesage);
		void LogError(string mesage);
	}
}

