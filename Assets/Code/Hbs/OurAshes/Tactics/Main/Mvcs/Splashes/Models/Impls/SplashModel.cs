using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Frames.Requests.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Frames.Requests.Types;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Models.Impls
{
    /// <summary>
    /// Splash Model Implementation
    /// </summary>
    public class SplashModel : AbstractMvcModel, IMvcModel
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public SplashModel(IMvcFrameConstruction mvcFrameConstruction) : base(mvcFrameConstruction)
        {
        }

        /// <inheritdoc/>
        protected override void BuildInitialRequests()
        {
            _mvcRequests.Add(SplashRequest.Builder.Get()
                .SetSplashRequestType(SplashRequestType.Continue)
                .Build());
        }

        /// <inheritdoc/>
        protected override void ProcessConfirmedRequest(IMvcRequest mvcRequest)
        {
            throw new System.NotImplementedException();
        }
    }
}