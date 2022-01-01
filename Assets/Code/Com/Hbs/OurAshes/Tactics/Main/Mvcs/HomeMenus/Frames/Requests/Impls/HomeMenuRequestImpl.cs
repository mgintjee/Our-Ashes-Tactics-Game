using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Reports.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.HomeMenus.Models.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.HomeMenus.Models.Requests.Types;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.HomeMenus.Models.Requests.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class HomeMenuRequestImpl
        : AbstractReport, IHomeMenuRequest
    {
        // Todo
        private HomeRequestType homeRequestType = HomeRequestType.None;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="homeRequestType"></param>
        public IHomeMenuRequest SetHomeRequestType(HomeRequestType homeRequestType)
        {
            this.homeRequestType = homeRequestType;
            return this;
        }

        /// <inheritdoc/>
        HomeRequestType IHomeMenuRequest.GetHomeRequestType()
        {
            return this.homeRequestType;
        }

        /// <inheritdoc/>
        protected override string GetContent()
        {
            return string.Format("{0}:{1}",
                typeof(HomeRequestType).Name, this.homeRequestType);
        }
    }
}