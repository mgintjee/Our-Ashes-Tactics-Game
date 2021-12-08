using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Reports.Inters;

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
        /// <param name="mvcControlReport"></param>
        /// <returns></returns>
        void Process(IMvcControlReport mvcControlReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IMvcModelReport GetReport();
    }
}