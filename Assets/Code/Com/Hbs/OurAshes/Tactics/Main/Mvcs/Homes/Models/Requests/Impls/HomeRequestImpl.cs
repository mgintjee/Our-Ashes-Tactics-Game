using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Reports.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Homes.Models.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Homes.Models.Requests.Types;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Homes.Models.Requests.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class HomeRequestImpl
        : AbstractReport, IHomeRequest
    {
        // Todo
        private HomeRequestType homeRequestType = HomeRequestType.None;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="homeRequestType"></param>
        public IHomeRequest SetHomeRequestType(HomeRequestType homeRequestType)
        {
            this.homeRequestType = homeRequestType;
            return this;
        }

        /// <inheritdoc/>
        HomeRequestType IHomeRequest.GetHomeRequestType()
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