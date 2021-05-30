using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Requests.Comparers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Requests.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Requests.Comparers.Implementaions.Abstracts
{
    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractMvcControllerRequestComparer
        : IControllerRequestComparer
    {
        /// <inheritdoc/>
        int IComparer<IMvcControllerRequest>.Compare(IMvcControllerRequest left, IMvcControllerRequest right)
        {
            // Collect their comparing values
            float leftValue = this.GetValue(left);
            float rightValue = this.GetValue(right);
            if (leftValue > rightValue)
            {
                return -1;
            }
            else if (leftValue < rightValue)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcControllerRequest"></param>
        /// <returns></returns>
        protected abstract float GetValue(IMvcControllerRequest mvcControllerRequest);
    }
}