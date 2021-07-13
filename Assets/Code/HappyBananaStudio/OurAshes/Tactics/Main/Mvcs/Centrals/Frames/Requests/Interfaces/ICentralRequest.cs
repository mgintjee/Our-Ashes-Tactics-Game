using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Frames.Requests.Interfaces
{
    /// <summary>
    /// Central Request Interface
    /// </summary>
    public interface ICentralRequest
        : IMvcRequest
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        MvcType GetMvcType();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IMvcFrameConstruction GetMvcFrameConstruction();
    }
}