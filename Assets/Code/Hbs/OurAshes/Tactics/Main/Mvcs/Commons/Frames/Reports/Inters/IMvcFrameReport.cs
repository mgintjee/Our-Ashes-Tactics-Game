using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Reports.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Reports.Inters
{
    /// <summary>
    /// Mvc Frame Report Interface
    /// </summary>
    public interface IMvcFrameReport : IReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IMvcControlReport GetMvcControlReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IMvcModelReport GetMvcModelReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IMvcViewReport GetMvcViewReport();
    }
}