using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Reports.Inters;

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
        /// <param name="mvcControlReport"></param>
        void Process(IMvcControlReport mvcControlReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IMvcViewReport GetReport();
    }
}