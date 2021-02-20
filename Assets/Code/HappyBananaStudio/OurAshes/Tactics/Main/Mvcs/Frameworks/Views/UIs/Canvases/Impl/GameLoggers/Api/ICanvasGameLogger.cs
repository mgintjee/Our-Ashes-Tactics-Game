namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Impl.GameLoggers.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Api;

    /// <summary>
    /// Todo
    /// </summary>
    public interface ICanvasGameLogger
        : ICanvas
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="message"></param>
        void WriteToGameLogger(string message);
    }
}