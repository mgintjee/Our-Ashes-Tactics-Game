using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Reports.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Reports.Inters
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