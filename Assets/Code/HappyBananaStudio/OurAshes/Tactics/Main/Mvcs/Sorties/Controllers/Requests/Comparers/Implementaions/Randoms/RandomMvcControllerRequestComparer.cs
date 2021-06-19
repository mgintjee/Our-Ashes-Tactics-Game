using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Requests.Comparers.Implementaions.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Requests.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.Requests.Comparers.Implementaions.Randoms
{
    /// <summary>
    /// Todo
    /// </summary>
    public class RandomMvcControllerRequestComparer
        : AbstractMvcControllerRequestComparer
    {
        /// <inheritdoc/>
        protected override float GetValue(IMvcControllerRequest mvcControllerRequest)
        {
            return (float)RandomManager.GetSortieRandom().NextDouble();
        }
    }
}