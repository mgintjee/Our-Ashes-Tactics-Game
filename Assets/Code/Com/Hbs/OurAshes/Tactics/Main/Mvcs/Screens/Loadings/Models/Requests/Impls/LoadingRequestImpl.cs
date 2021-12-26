using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Reports.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Requests.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Screens.Loadings.Models.Requests.Impls
{
    /// <summary>
    /// Loading Request Implementation
    /// </summary>
    public class LoadingRequestImpl
        : AbstractReport, IMvcModelRequest
    {
        /// <inheritdoc/>
        protected override string GetContent()
        {
            return "";
        }
    }
}