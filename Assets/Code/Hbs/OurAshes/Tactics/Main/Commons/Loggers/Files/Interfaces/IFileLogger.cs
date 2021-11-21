namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Files.Interfaces
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IFileLogger
    {
        void WriteToFile(string message);

        void Shutdown();
    }
}