using System;
using System.IO;

public class LoggerUtil
{
    #region Private Fields

    private static readonly string LOG_FILE_DIRECTORY = "gameLogs";

    private static readonly string LOG_FILE_INDEX = DateTime.Now.ToLongTimeString().Replace(':', '_');

    // Todo: Think about having multiples of these based off of the time
    private static readonly string LOG_FILE_NAME = LOG_FILE_DIRECTORY + "/ourAshesTacticsLog-" + LOG_FILE_INDEX + ".txt";

    #endregion Private Fields

    #region Public Methods

    public static void WriteToLogFile(string message)
    {
        if (!Directory.Exists(LOG_FILE_DIRECTORY))
        {
            Directory.CreateDirectory(LOG_FILE_DIRECTORY);
        }
        StreamWriter logFileStream;
        if (!File.Exists(LOG_FILE_NAME))
        {
            logFileStream = File.CreateText(LOG_FILE_NAME);
        }
        else
        {
            logFileStream = File.AppendText(LOG_FILE_NAME);
        }
        logFileStream.Write(DateTime.Now.ToLongTimeString() + " " + message + "\n");
        logFileStream.Close();
    }

    #endregion Public Methods
}