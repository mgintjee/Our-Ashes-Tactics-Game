using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Constants;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.HomeMenus.Frames.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.HomeMenus.Views.Canvases.Impls;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.HomeMenus.Views.Impls
{
    /// <summary>
    /// Home View Impl
    /// </summary>
    public class HomeMenuViewImpl
        : AbstractMvcView, IMvcView
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public HomeMenuViewImpl(IMvcFrameConstruction mvcFrameConstruction)
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
                foreach (IMvcRequest request in this.mvcModelState.GetMvcRequests())
                {
                    IHomeMenuRequest homeMenuRequest = (IHomeMenuRequest)request;
                    if (widget.GetName().Contains(homeMenuRequest.GetHomeRequestType().ToString()))
                    {
                        logger.Info("Setting {}:{}", typeof(IHomeMenuRequest), homeMenuRequest.GetHomeRequestType());
                        ((MvcViewStateImpl)this.mvcViewState).SetMvcModelRequest(request);
                        break;
                    }
                }
                if (this.mvcViewState.GetMvcModelRequest().IsPresent())
                {
                    ((MvcViewStateImpl)this.mvcViewState).SetMvcControlInputTypes(new HashSet<MvcControlInputType>());
                }
            });
        }

        /// <inheritdoc/>
        protected override IMvcViewCanvas BuildInitialMvcViewCanvas()
        {
            return HomeMenuViewCanvasImpl.Builder.Get()
                .SetMvcType(MvcType.HomeMenu)
                .SetGridSize(CanvasGridConstants.GetMvcTypeGridSize(MvcType.HomeMenu))
                .SetName(typeof(HomeMenuViewCanvasImpl).Name)
                .SetParent(this.mvcFrameConstruction.GetUnityScript())
                .Build();
        }
    }
}