using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Reports.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inters
{
    /// <summary>
    /// Mvc Control Interface
    /// </summary>
    public interface IMvcControl
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
        IMvcControlReport GetReport();
    }
}