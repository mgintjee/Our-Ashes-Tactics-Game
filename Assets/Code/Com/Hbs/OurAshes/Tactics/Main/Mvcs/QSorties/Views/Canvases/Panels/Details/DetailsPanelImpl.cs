using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Utils;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Combatants;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Maps;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Phalanxes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Sorties;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details
{
    public class DetailsPanelImpl
        : AbstractPanelWidget
    {
        private readonly IDictionary<RequestType, IPanelWidget> requestTypeDetailsPanels =
            new Dictionary<RequestType, IPanelWidget>();

        public override void Process(Commons.Models.States.Inters.IMvcModelState mvcModelState)
        {
            Models.States.Inters.IMvcModelState modelState = (Models.States.Inters.IMvcModelState)mvcModelState;
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
                this.BuildAndSetSortieDetailsPanel(),
                this.BuildAndSetCombatantDetailsPanel(),
                this.BuildAndSetPhalanxDetailsPanel()
            };
            this.InternalAddWidgets(panelWidgets);
            this.EnableDetailPanels(RequestType.SortieDetails);
        }

        private void UpdateDetailPanelsContent(RequestType requestType, Models.States.Inters.IMvcModelState modelState)
        {
            logger.Debug("Updating {}s based off of {}", typeof(IPanelWidget), requestType);
            if (requestType != RequestType.None)
            {
                this.EnableDetailPanels(requestType);
            }
            if (this.requestTypeDetailsPanels.ContainsKey(requestType))
            {
                this.requestTypeDetailsPanels[requestType].Process(modelState);
            }
        }

        private void EnableDetailPanels(RequestType requestType)
        {
            logger.Debug("Enabling {}s based off of {}", typeof(IPanelWidget), requestType);
            foreach (KeyValuePair<RequestType, IPanelWidget> requestTypeDetailsPanel in this.requestTypeDetailsPanels)
            {
                IPanelWidget detailsPanelWidget = requestTypeDetailsPanel.Value;
                bool isDetailsPanelEnabled = requestTypeDetailsPanel.Key == requestType;
                CanvasWidgetUtils.EnableWidget(detailsPanelWidget, isDetailsPanelEnabled);
            }
        }

        private ICanvasWidget BuildAndSetFieldDetailsPanel()
        {
            this.requestTypeDetailsPanels[RequestType.FieldDetails] = FieldDetailsPanelImpl.Builder.Get()
                    .SetPanelGridSize(DetailsPanelConstants.FIELD_PANEL_DIMENSIONS)
                    .SetWidgetGridSpec(new WidgetGridSpecImpl()
                        .SetCanvasGridCoords(Vector2.Zero)
                        .SetCanvasGridSize(new Vector2(this.canvasGridConvertor.GetGridSize().X,
                            this.canvasGridConvertor.GetGridSize().Y)))
                    .SetMvcType(this.mvcType)
                    .SetCanvasLevel(0)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetName(this.mvcType + ":" + RequestType.FieldDetails + ":" + CanvasWidgetType.Panel)
                    .SetParent(this)
                    .Build();
            return this.requestTypeDetailsPanels[RequestType.FieldDetails];
        }

        private ICanvasWidget BuildAndSetSortieDetailsPanel()
        {
            this.requestTypeDetailsPanels[RequestType.SortieDetails] = SortieDetailsPanelImpl.Builder.Get()
                    .SetPanelGridSize(new Vector2(4, 5))
                    .SetWidgetGridSpec(new WidgetGridSpecImpl()
                        .SetCanvasGridCoords(Vector2.Zero)
                        .SetCanvasGridSize(new Vector2(this.canvasGridConvertor.GetGridSize().X,
                            this.canvasGridConvertor.GetGridSize().Y)))
                    .SetMvcType(this.mvcType)
                    .SetCanvasLevel(0)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetName(this.mvcType + ":" + RequestType.SortieDetails + ":" + CanvasWidgetType.Panel)
                    .SetParent(this)
                    .Build();
            return this.requestTypeDetailsPanels[RequestType.SortieDetails];
        }

        private ICanvasWidget BuildAndSetPhalanxDetailsPanel()
        {
            this.requestTypeDetailsPanels[RequestType.PhalanxDetails] = PhalanxDetailsPanelImpl.Builder.Get()
                    .SetPanelGridSize(new Vector2(4, 5))
                    .SetWidgetGridSpec(new WidgetGridSpecImpl()
                        .SetCanvasGridCoords(Vector2.Zero)
                        .SetCanvasGridSize(new Vector2(this.canvasGridConvertor.GetGridSize().X,
                            this.canvasGridConvertor.GetGridSize().Y)))
                    .SetMvcType(this.mvcType)
                    .SetCanvasLevel(0)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetName(this.mvcType + ":" + RequestType.PhalanxDetails + ":" + CanvasWidgetType.Panel)
                    .SetParent(this)
                    .Build();
            return this.requestTypeDetailsPanels[RequestType.PhalanxDetails];
        }

        private ICanvasWidget BuildAndSetCombatantDetailsPanel()
        {
            this.requestTypeDetailsPanels[RequestType.CombatantDetails] = CombatantDetailsPanelImpl.Builder.Get()
                    .SetPanelGridSize(new Vector2(4, 5))
                    .SetWidgetGridSpec(new WidgetGridSpecImpl()
                        .SetCanvasGridCoords(Vector2.Zero)
                        .SetCanvasGridSize(new Vector2(this.canvasGridConvertor.GetGridSize().X,
                            this.canvasGridConvertor.GetGridSize().Y)))
                    .SetMvcType(this.mvcType)
                    .SetCanvasLevel(0)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetName(this.mvcType + ":" + RequestType.CombatantDetails + ":" + CanvasWidgetType.Panel)
                    .SetParent(this)
                    .Build();
            return this.requestTypeDetailsPanels[RequestType.CombatantDetails];
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
                protected override IPanelWidget BuildScript(UnityEngine.GameObject gameObject)
                {
                    IPanelWidget widget = gameObject.AddComponent<DetailsPanelImpl>();
                    this.ApplyPanelValues(widget);
                    return widget;
                }
            }
        }
    }
}