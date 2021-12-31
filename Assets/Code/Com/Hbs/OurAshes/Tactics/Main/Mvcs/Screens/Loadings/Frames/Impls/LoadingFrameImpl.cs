using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Reports.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Sims.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Screens.Loadings.Controls.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Screens.Loadings.Models.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Screens.Loadings.Views.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Screens.Splashes.Controls.Constrs.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Screens.Splashes.Models.Constrs.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Screens.Splashes.Views.Constrs.Impls;
using System.Diagnostics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Screens.Loadings.Frames.Impls
{
    /// <summary>
    /// Loading Frame Impl
    /// </summary>
    public class LoadingFrameImpl
        : AbstractMvcFrame
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public LoadingFrameImpl(IMvcFrameConstruction mvcFrameConstruction, IMvcFrameResult prevMvcFrameResult)
            : base(mvcFrameConstruction, prevMvcFrameResult)
        {
            if (prevMvcFrameResult != null)
            {
                this.nextMvcFrameConstruction = prevMvcFrameResult.GetNextMvcFrameConstruction();
            }
            else
            {
                this.nextMvcFrameConstruction = MvcFrameConstruction.Builder.Get()
                    .SetUnityScript(mvcFrameConstruction.GetUnityScript())
                    .SetSimulationType(SimsType.Interactive)
                    .SetMvcType(MvcType.ScreenSplash)
                    .SetMvcControlConstruction(SplashControlConstruction.Builder.Get().Build())
                    .SetMvcModelConstruction(SplashModelConstruction.Builder.Get().Build())
                    .SetMvcViewConstruction(SplashViewConstruction.Builder.Get().Build())
                    .SetRandom(RandomManager.GetRandom(MvcType.ScreenSplash))
                    .Build();
            }
            // Todo: Maybe have this as a thread or something?
            this.Process(nextMvcFrameConstruction);
        }

        /// <inheritdoc/>
        protected override IMvcControl BuildMvcControl(IMvcFrameConstruction mvcFrameConstruction)
        {
            return new LoadingControlImpl(mvcFrameConstruction);
        }

        /// <inheritdoc/>
        protected override IMvcModel BuildMvcModel(IMvcFrameConstruction mvcFrameConstruction)
        {
            return new LoadingModelImpl(mvcFrameConstruction);
        }

        /// <inheritdoc/>
        protected override IMvcView BuildMvcView(IMvcFrameConstruction mvcFrameConstruction)
        {
            return new LoadingViewImpl(mvcFrameConstruction);
        }

        /// <inheritdoc/>
        protected override IClassLogger GetClassLogger()
        {
            return LoggerManager.GetLogger(this.currMvcFrameConstruction.GetMvcType())
                .GetClassLogger(new StackFrame().GetMethod().DeclaringType);
        }

        private void Process(IMvcFrameConstruction mvcFrameConstruction)
        {
            MvcType mvcType = mvcFrameConstruction.GetMvcType();
            logger.Info("Loading resources for MvcType: {}", mvcType);
        }
    }
}