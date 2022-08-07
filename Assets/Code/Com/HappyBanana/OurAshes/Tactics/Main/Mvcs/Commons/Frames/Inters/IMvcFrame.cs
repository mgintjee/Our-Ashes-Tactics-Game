using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Results.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Inters
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
    }
}