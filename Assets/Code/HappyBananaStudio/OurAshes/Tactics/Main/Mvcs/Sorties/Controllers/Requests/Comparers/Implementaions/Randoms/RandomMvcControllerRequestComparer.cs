using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Requests.Comparers.Implementaions.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Randoms;

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
            return (float)SortieRandom.GetInstance().NextDouble();
        }
    }
}