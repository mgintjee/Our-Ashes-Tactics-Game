using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Reports.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Requests.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Requests.Impls
{
    public class MvcRequestImpl
        : AbstractReport, IMvcRequest
    {
        protected override string GetContent()
        {
            return "";
        }
    }
}