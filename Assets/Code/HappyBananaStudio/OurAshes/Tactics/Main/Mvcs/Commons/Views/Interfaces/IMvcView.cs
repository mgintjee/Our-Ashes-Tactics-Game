using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Responses.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Reports.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Interfaces
{
    /// <summary>
    /// Mvc View Interface
    /// </summary>
    public interface IMvcView
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcResponse"></param>
        void Process(IMvcResponse mvcResponse);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcRequest"></param>
        void ProcessSelected(IMvcRequest mvcRequest);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcRequest"></param>
        void ProcessConfirmed(IMvcRequest mvcRequest);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IMvcViewReport GetMvcViewReport();
    }
}