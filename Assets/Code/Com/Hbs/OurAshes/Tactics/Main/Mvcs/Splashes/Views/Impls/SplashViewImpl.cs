using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Views.Canvases;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Views.Impls
{
    /// <summary>
    /// Splash View Impl
    /// </summary>
    public class SplashViewImpl
        : AbstractMvcView, IMvcView
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public SplashViewImpl(IMvcFrameConstruction mvcFrameConstruction)
            : base(mvcFrameConstruction)
        {
        }

        /// <inheritdoc/>
        public override void Process(IMvcModelState mvcModelState)
        {
            _logger.Info("Processing {}...", mvcModelState);
            this.mvcModelState = mvcModelState;
        }

        /// <inheritdoc/>
        public override IMvcViewState Process(IMvcControlInput mvcControlInput)
        {
            _logger.Info("Processing {}...", mvcControlInput);
            Optional<ICanvasWidget> canvasWidget = this.mvcViewCanvas.GetWidget(mvcControlInput);

            // Todo Fix this so that it actually uses the canvas
            ((MvcViewStateImpl)this.mvcViewState)
                .SetMvcControlInputTypes(new HashSet<MvcControlInputType>())
                .SetMvcModelRequest(new List<IMvcModelRequest>(
                    this.mvcModelState.GetMvcModelRequests())[0]);
            return this.mvcViewState;
        }

        /// <inheritdoc/>
        protected override IMvcViewCanvas BuildInitialMvcViewCanvas()
        {
            return SplashViewCanvasImpl.Builder.Get()
                // Todo: Store in a const file or something
                .SetGridSize(new Vector2(7, 5))
                .SetName(typeof(SplashViewCanvasImpl).Name)
                .SetParent(this.mvcFrameConstruction.GetUnityScript())
                .Build();
        }

        /// <inheritdoc/>
        protected override IMvcViewState BuildInitialMvcViewState()
        {
            return new MvcViewStateImpl();
        }
    }
}