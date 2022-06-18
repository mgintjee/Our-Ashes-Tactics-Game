using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Impls;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Impls
{
    /// <summary>
    /// Loading View Impl
    /// </summary>
    public class DefaultMvcViewImpl
        : AbstractMvcView, IMvcView
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public DefaultMvcViewImpl(IMvcFrameConstruction mvcFrameConstruction)
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
                    ((DefaultMvcViewStateImpl)this.mvcViewState)
                        .SetMvcControlInputTypes(new HashSet<MvcControlInputType>())
                        .SetMvcModelRequest(new MvcRequestImpl());
                }
            });
        }

        /// <inheritdoc/>
        protected override IMvcViewCanvas BuildInitialMvcViewCanvas()
        {
            return DefaultMvcViewCanvasImpl.Builder.Get()
                .SetMvcType(MvcType.None)
                .SetGridSize(CanvasGridConstants.GetMvcTypeGridSize(MvcType.LoadingScreen))
                .SetName(typeof(DefaultMvcViewCanvasImpl).Name)
                .SetParent(this.mvcFrameConstruction.GetUnityScript())
                .Build();
        }
    }
}