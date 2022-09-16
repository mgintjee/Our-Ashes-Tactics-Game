using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Impls;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Homes.Menus.Views.Impls
{
    /// <summary>
    /// Home View Impl
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
                RequestType requestType = this.DetermineRequestType(widget.GetName());
                logger.Info("Widget to process: Name={}, Found={}",
                    widget.GetName(), StringUtils.Format(requestType));
                IHomeMenuRequest homeMenuRequest = new MvcRequestImpl()
                    .SetRequestType(requestType);
                ((DefaultMvcViewStateImpl)this.mvcViewState)
                    .SetMvcModelRequest(homeMenuRequest);
            });
        }

        /// <inheritdoc/>
        protected override IMvcViewCanvas BuildInitialMvcViewCanvas()
        {
            return MvcViewCanvasImpl.Builder.Get()
                .SetMvcType(MvcType.HomeMenu)
                .SetGridSize(CanvasGridConstants.GetMvcTypeGridSize(MvcType.HomeMenu))
                .SetName(typeof(MvcViewCanvasImpl).Name)
                .SetParent(this.mvcFrameConstruction.GetUnityScript())
                .Build();
        }

        private RequestType DetermineRequestType(string widgetName)
        {
            IList<RequestType> requestTypes = EnumUtils.GetEnumListWithoutFirst<RequestType>();
            foreach (RequestType requestType in requestTypes)
            {
                if (widgetName.Contains(requestType.ToString()))
                {
                    return requestType;
                }
            }
            return RequestType.None;
        }
    }
}