namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Loggers.Consoles.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IConsoleLogger
    {
        void Debug(string message);

        void Error(string message);

        void Info(string message);

        void Warn(string message);
    }
}