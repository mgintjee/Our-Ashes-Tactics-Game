using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Reports.Interfaces;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Views.Interfaces
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