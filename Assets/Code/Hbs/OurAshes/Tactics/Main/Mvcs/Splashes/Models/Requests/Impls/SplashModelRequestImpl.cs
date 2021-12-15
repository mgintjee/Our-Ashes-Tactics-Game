using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Reports.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Requests.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Models.Requests.Impls
{
    public class SplashModelRequestImpl
        : AbstractReport, IMvcModelRequest
    {
        protected override string GetContent()
        {
            return "";
        }
    }
}