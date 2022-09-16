using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Games.Views.Impls
{
    /// <summary>
    /// QSortieMenu View Impl
    /// </summary>
    public class MvcViewImpl
        : AbstractMvcView, IMvcView
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public MvcViewImpl(IMvcFrameConstruction mvcFrameConstruction)
            : base(mvcFrameConstruction)
        {
        }

        /// <inheritdoc/>
        protected override void InternalProcess(IMvcControlInput mvcControlInput)
        {
            logger.Info("Processing {}...", mvcControlInput);
            this.mvcViewCanvas.GetWidget(mvcControlInput).IfPresent(widget =>
            {
                RequestType requestType = EnumUtils.DetermineEnumFrom<RequestType>(widget.GetName());
                logger.Info("Widget to process: Name={}, Found RequestType={}",
                    widget.GetName(), StringUtils.Format(requestType));
                if (requestType != RequestType.None)
                {
                }
            });
        }

        /// <inheritdoc/>
        protected override IMvcViewCanvas BuildInitialMvcViewCanvas()
        {
            return MvcViewCanvasImpl.Builder.Get()
                .SetMvcType(MvcType.QSortieMenu)
                .SetGridSize(CanvasGridConstants.GetMvcTypeGridSize(MvcType.QSortieMenu))
                .SetName(typeof(MvcViewCanvasImpl).Name)
                .SetParent(this.mvcFrameConstruction.GetUnityScript())
                .Build();
        }
    }
}