using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Frames.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Splashes.Frames.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Splashes.Models.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Splashes.Views.Implementations;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Splashes.Frames.Implementations
{
    /// <summary>
    /// Splash Frame Implementation
    /// </summary>
    public class SplashFrame : AbstractMvcFrame, ISplashFrame
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public SplashFrame(IMvcFrameConstruction mvcFrameConstruction, IMvcFrameConstruction returnMvcFrameConstruction)
            : base(mvcFrameConstruction, returnMvcFrameConstruction)
        {
        }

        /// <inheritdoc/>
        protected override IMvcController BuildMvcController(IMvcFrameConstruction mvcFrameConstruction)
        {
            return new SplashController(mvcFrameConstruction);
        }

        /// <inheritdoc/>
        protected override IMvcModel BuildMvcModel(IMvcFrameConstruction mvcFrameConstruction)
        {
            return new SplashModel(mvcFrameConstruction);
        }

        /// <inheritdoc/>
        protected override IMvcView BuildMvcView(IMvcFrameConstruction mvcFrameConstruction)
        {
            return new SplashMvcView(mvcFrameConstruction);
        }

        /// <inheritdoc/>
        protected override IMvcFrameConstruction BuildUpcomingMvcFrameConstruction(IMvcFrameReport mvcFrameReport)
        {
            return MvcFrameConstruction.Builder.Get()
                .SetMvcType(MvcType.Home)
                .SetRandom(RandomManager.GetRandom(MvcType.Home))
                .SetSimulationType(SimulationType.Interactive)
                .SetUnityScript(_mvcFrameConstruction.GetUnityScript())
                .Build();
        }
    }
}