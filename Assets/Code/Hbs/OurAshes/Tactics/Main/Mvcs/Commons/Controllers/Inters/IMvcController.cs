using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Controllers.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Models.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Inters
{
    /// <summary>
    /// Mvc Controller Interface
    /// </summary>
    public interface IMvcController
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcModelReport"></param>
        void Process(IMvcModelReport mvcModelReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IMvcControllerReport GetReport();
    }
}