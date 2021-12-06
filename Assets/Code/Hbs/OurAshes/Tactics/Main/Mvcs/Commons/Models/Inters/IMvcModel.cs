using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Controllers.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Models.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Inters
{
    /// <summary>
    /// Mvc Model Interface
    /// </summary>
    public interface IMvcModel
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcControllerReport"></param>
        /// <returns></returns>
        void Process(IMvcControllerReport mvcControllerReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IMvcModelReport GetReport();
    }
}