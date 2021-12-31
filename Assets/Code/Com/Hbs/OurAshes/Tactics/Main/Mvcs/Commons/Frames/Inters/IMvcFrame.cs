using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Reports.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Inters
{
    /// <summary>
    /// Mvc Frame Interface
    /// </summary>
    public interface IMvcFrame
    {
        /// <summary>
        /// Todo
        /// </summary>
        void Continue();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        bool IsProcessing();

        /// <summary>
        /// Todo
        /// </summary>
        void Destroy();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IMvcFrameResult GetMvcFrameResult();

        /// <summary>
        /// Todo
        /// </summary>
        IMvcFrameConstruction GetCurrMvcFrameConstruction();

        /// <summary>
        /// Todo
        /// </summary>
        IMvcFrameConstruction GetNextMvcFrameConstruction();
    }
}