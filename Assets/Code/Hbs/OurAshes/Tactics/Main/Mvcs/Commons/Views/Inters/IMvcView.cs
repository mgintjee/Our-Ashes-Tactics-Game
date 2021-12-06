using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Controllers.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Models.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Views.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters
{
    /// <summary>
    /// Mvc View Interface
    /// </summary>
    public interface IMvcView
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcModelReport"></param>
        void Process(IMvcModelReport mvcModelReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcControllerReport"></param>
        void Process(IMvcControllerReport mvcControllerReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IMvcViewReport GetReport();
    }
}