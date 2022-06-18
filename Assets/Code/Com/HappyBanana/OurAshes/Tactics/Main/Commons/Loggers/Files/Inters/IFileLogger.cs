namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Loggers.Files.Inters
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