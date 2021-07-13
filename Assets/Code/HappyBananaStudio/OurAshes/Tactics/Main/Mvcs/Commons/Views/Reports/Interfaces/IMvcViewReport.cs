using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Reports.Interfaces
{
    /// <summary>
    /// Mvc View Report Interface
    /// </summary>
    public interface IMvcViewReport
        : IReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        bool IsProcessing();
    }
}