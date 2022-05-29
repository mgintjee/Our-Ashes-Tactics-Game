using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Constants;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Impls;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Impls
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
                RequestType requestType = this.DetermineRequestType(widget.GetName());
                logger.Info("Widget to process: Name={}, Found={}",
                    widget.GetName(), StringUtils.Format(requestType));
                if (requestType != RequestType.None)
                {
                    IQSortieMenuMvcRequest qSortieMenuMvcRequest = this.BuildMvcRequestFrom(requestType, widget.GetName());
                    ((DefaultMvcViewStateImpl)this.mvcViewState)
                        .SetMvcModelRequest(qSortieMenuMvcRequest);
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

        private IQSortieMenuMvcRequest BuildMvcRequestFrom(RequestType requestType, string widgetName)
        {
            IQSortieMenuMvcRequest qSortieMenuMvcRequest = new MvcRequestImpl()
                        .SetRequestType(requestType);
            switch (requestType)
            {
                case RequestType.CombatantDetails:
                case RequestType.FactionDetails:
                case RequestType.FieldDetails:
                case RequestType.PhalanxDetails:
                case RequestType.SortieDetails:
                case RequestType.FactionRandomize:
                case RequestType.FieldRandomize:
                case RequestType.SortieRandomize:
                    qSortieMenuMvcRequest = new MvcRequestImpl()
                        .SetRequestType(requestType);
                    break;

                case RequestType.FieldMod:
                case RequestType.CombatantMod:
                case RequestType.PhalanxMod:
                case RequestType.FactionMod:
                case RequestType.None:

                default:
                    logger.Warn("Unable to build {}. {} is not currently supported.", typeof(IQSortieMenuMvcRequest), requestType);
                    qSortieMenuMvcRequest = new MvcRequestImpl();
                    break;
            }
            return qSortieMenuMvcRequest;
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