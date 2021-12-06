using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Controllers.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Models.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Views.Inters;

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
        IMvcControllerReport GetMvcControllerReport();

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