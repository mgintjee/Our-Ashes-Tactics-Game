using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Utils;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Factions;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Phalanxes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Sorties;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Units;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details
{
    public class DetailsPanelImpl
        : AbstractPanelWidget
    {
        private readonly IDictionary<RequestType, IPanelWidget> requestTypeDetailsPanels =
            new Dictionary<RequestType, IPanelWidget>();

        private RequestType lastDetailsRequest = RequestType.None;
        private IPopUpPanelWidget popUpWidget;

        public override void Process(Commons.Models.States.Inters.IMvcModelState mvcModelState)
        {
            QSorties.Models.States.Inters.IMvcModelState modelState = (QSorties.Models.States.Inters.IMvcModelState)mvcModelState;
            RequestType requestType = RequestType.None;
            modelState.GetPrevMvcRequest().IfPresent(
                request => requestType = ((IQSortieMenuMvcRequest)request).GetRequestType());
            this.UpdateDetailPanelsContent(requestType, modelState);
        }

        protected override void InitialBuild()
        {
            ISet<ICanvasWidget> panelWidgets = new HashSet<ICanvasWidget>() {
                this.BuildBackground(),
                this.BuildAndSetFieldDetailsPanel(),
                this.BuildAndSetFactionDetailsPanel(),
                this.BuildAndSetSortieDetailsPanel(),
                this.BuildAndSetUnitDetailsPanel(),
                this.BuildAndSetPhalanxDetailsPanel()
            };
            this.InternalAddWidgets(panelWidgets);
            this.EnableDetailPanels(RequestType.DetailsSortie);
        }

        private void UpdateDetailPanelsContent(RequestType requestType, QSorties.Models.States.Inters.IMvcModelState modelState)
        {
            this.EnableDetailPanels(requestType);
            if (this.requestTypeDetailsPanels.ContainsKey(lastDetailsRequest))
            {
                this.requestTypeDetailsPanels[lastDetailsRequest].Process(modelState);
            }
        }

        private void EnableDetailPanels(RequestType requestType)
        {
            if (requestType.ToString().Contains("Details"))
            {
                this.lastDetailsRequest = requestType;
                foreach (KeyValuePair<RequestType, IPanelWidget> requestTypeDetailsPanel in this.requestTypeDetailsPanels)
                {
                    IPanelWidget detailsPanelWidget = requestTypeDetailsPanel.Value;
                    bool isDetailsPanelEnabled = requestTypeDetailsPanel.Key == requestType;
                    CanvasWidgetUtils.EnableWidget(detailsPanelWidget, isDetailsPanelEnabled);
                }
            }
        }

        private ICanvasWidget BuildAndSetFieldDetailsPanel()
        {
            this.requestTypeDetailsPanels[RequestType.DetailsField] = Fields.FieldDetailsPanelImpl.Builder.Get()
                    .SetPopUpWidget(popUpWidget)
                    .SetPanelGridSize(DetailsPanelConstants.Fields.Vectors.SIZE)
                    .SetWidgetGridSpec(new WidgetGridSpecImpl()
                        .SetCanvasGridCoords(Vector2.Zero)
                        .SetCanvasGridSize(this.canvasGridConvertor.GetGridSize()))
                    .SetMvcType(this.mvcType)
                    .SetCanvasLevel(0)
                    .SetInteractable(true)
                    .SetEnabled(true)
                    .SetName(RequestType.DetailsField + ":" + CanvasWidgetType.Panel)
                    .SetParent(this)
                    .Build();
            return this.requestTypeDetailsPanels[RequestType.DetailsField];
        }

        private ICanvasWidget BuildAndSetFactionDetailsPanel()
        {
            this.requestTypeDetailsPanels[RequestType.DetailsFaction] = FactionDetailsPanelImpl.Builder.Get()
                    .SetPopUpWidget(popUpWidget)
                    .SetPanelGridSize(DetailsPanelConstants.Factions.Vectors.SIZE)
                    .SetWidgetGridSpec(new WidgetGridSpecImpl()
                        .SetCanvasGridCoords(Vector2.Zero)
                        .SetCanvasGridSize(this.canvasGridConvertor.GetGridSize()))
                    .SetMvcType(this.mvcType)
                    .SetCanvasLevel(0)
                    .SetInteractable(true)
                    .SetEnabled(true)
                    .SetName(RequestType.DetailsFaction + ":" + CanvasWidgetType.Panel)
                    .SetParent(this)
                    .Build();
            return this.requestTypeDetailsPanels[RequestType.DetailsFaction];
        }

        private ICanvasWidget BuildAndSetSortieDetailsPanel()
        {
            this.requestTypeDetailsPanels[RequestType.DetailsSortie] = SortieDetailsPanelImpl.Builder.Get()
                    .SetPopUpWidget(popUpWidget)
                    .SetPanelGridSize(DetailsPanelConstants.Sorties.Vectors.SIZE)
                    .SetWidgetGridSpec(new WidgetGridSpecImpl()
                        .SetCanvasGridCoords(Vector2.Zero)
                        .SetCanvasGridSize(this.canvasGridConvertor.GetGridSize()))
                    .SetMvcType(this.mvcType)
                    .SetCanvasLevel(0)
                    .SetInteractable(true)
                    .SetEnabled(true)
                    .SetName(RequestType.DetailsSortie + ":" + CanvasWidgetType.Panel)
                    .SetParent(this)
                    .Build();
            return this.requestTypeDetailsPanels[RequestType.DetailsSortie];
        }

        private ICanvasWidget BuildAndSetPhalanxDetailsPanel()
        {
            this.requestTypeDetailsPanels[RequestType.DetailsPhalanx] = PhalanxDetailsPanelImpl.Builder.Get()
                    .SetPopUpWidget(popUpWidget)
                    .SetPanelGridSize(DetailsPanelConstants.Phalanxes.Vectors.SIZE)
                    .SetWidgetGridSpec(new WidgetGridSpecImpl()
                        .SetCanvasGridCoords(Vector2.Zero)
                        .SetCanvasGridSize(this.canvasGridConvertor.GetGridSize()))
                    .SetMvcType(this.mvcType)
                    .SetCanvasLevel(0)
                    .SetInteractable(true)
                    .SetEnabled(true)
                    .SetName(RequestType.DetailsPhalanx + ":" + CanvasWidgetType.Panel)
                    .SetParent(this)
                    .Build();
            return this.requestTypeDetailsPanels[RequestType.DetailsPhalanx];
        }

        private ICanvasWidget BuildAndSetUnitDetailsPanel()
        {
            this.requestTypeDetailsPanels[RequestType.DetailsUnit] = UnitDetailsPanelImpl.Builder.Get()
                .SetPopUpWidget(popUpWidget)
                    .SetPanelGridSize(DetailsPanelConstants.Units.Vectors.SIZE)
                    .SetWidgetGridSpec(new WidgetGridSpecImpl()
                        .SetCanvasGridCoords(Vector2.Zero)
                        .SetCanvasGridSize(this.canvasGridConvertor.GetGridSize()))
                    .SetMvcType(this.mvcType)
                    .SetCanvasLevel(0)
                    .SetInteractable(true)
                    .SetEnabled(true)
                    .SetName(RequestType.DetailsUnit + ":" + CanvasWidgetType.Panel)
                    .SetParent(this)
                    .Build();
            return this.requestTypeDetailsPanels[RequestType.DetailsUnit];
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IInternalBuilder
                : PanelWidgetBuilders.IPanelWidgetBuilder
            {
                IInternalBuilder SetPopUpWidget(IPopUpPanelWidget widget);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static IInternalBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Todo
            /// </summary>
            private class InternalBuilder
                : PanelWidgetBuilders.InternalPanelWidgetBuilder, IInternalBuilder
            {
                private IPopUpPanelWidget popUpWidget;

                IInternalBuilder IInternalBuilder.SetPopUpWidget(IPopUpPanelWidget widget)
                {
                    this.popUpWidget = widget;
                    return this;
                }

                protected override IPanelWidget BuildScript(UnityEngine.GameObject gameObject)
                {
                    DetailsPanelImpl widget = gameObject.AddComponent<DetailsPanelImpl>();
                    widget.popUpWidget = popUpWidget;
                    this.ApplyPanelValues(widget);
                    return widget;
                }
            }
        }
    }
}