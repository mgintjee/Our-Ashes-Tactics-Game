using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Responses.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Responses.IDs.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Reports.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Responses.Interfaces
{
    /// <summary>
    /// Model Response Interface
    /// </summary>
    public interface ISortieResponse
        : IMvcResponse
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IMvcSortieModelReport GetMvcSortieModelReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISortieResponseID GetSortieResponseID();
    }
}