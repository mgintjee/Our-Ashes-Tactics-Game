using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Responses.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Responses.IDs.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Responses.Interfaces
{
    /// <summary>
    /// Model Response Interface
    /// </summary>
    public interface ISortieModelResponse
        : IMvcModelResponse
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