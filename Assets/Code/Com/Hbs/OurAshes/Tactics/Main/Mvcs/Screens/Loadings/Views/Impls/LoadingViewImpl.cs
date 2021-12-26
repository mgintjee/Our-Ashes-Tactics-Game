using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Constants;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Screens.Loadings.Views.Canvases;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Screens.Loadings.Views.Impls
{
    /// <summary>
    /// Loading View Impl
    /// </summary>
    public class LoadingViewImpl
        : AbstractMvcView, IMvcView
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public LoadingViewImpl(IMvcFrameConstruction mvcFrameConstruction)
            : base(mvcFrameConstruction)
        {
        }

        /// <inheritdoc/>
        protected override void InternalProcess(IMvcControlInput mvcControlInput)
        {
            logger.Info("Processing {}...", mvcControlInput);
            this.mvcViewCanvas.GetWidget(mvcControlInput).IfPresent(widget =>
            {
                logger.Info("Widget to process: Name={}", widget.GetName());
                if (widget.GetName().Contains("Image"))
                {
                    ((MvcViewStateImpl)this.mvcViewState)
                        .SetMvcControlInputTypes(new HashSet<MvcControlInputType>())
                        .SetMvcModelRequest(new List<IMvcModelRequest>(
                            this.mvcModelState.GetMvcModelRequests())[0]);
                }
            });
        }

        /// <inheritdoc/>
        protected override IMvcViewCanvas BuildInitialMvcViewCanvas()
        {
            return LoadingViewCanvasImpl.Builder.Get()
                .SetGridSize(CanvasGridConstants.GetMvcTypeGridSize(MvcType.ScreenLoading))
                .SetName(typeof(LoadingViewCanvasImpl).Name)
                .SetParent(this.mvcFrameConstruction.GetUnityScript())
                .Build();
        }
    }
}