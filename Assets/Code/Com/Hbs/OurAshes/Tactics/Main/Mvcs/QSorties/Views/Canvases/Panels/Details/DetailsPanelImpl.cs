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
        private readonly IDictionary<RequestType, IDetailsPanelWidget> requestTypeDetailsPanels =
            new Dictionary<RequestType, IDetailsPanelWidget>();

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
            this.InternalAddWidget(this.BuildBackground());
            this.InternalAddWidget(this.BuildAndCacheMapDetailsPanel());
            this.InternalAddWidget(this.BuildAndCacheSortieDetailsPanel());
            this.InternalAddWidget(this.BuildAndCacheCombatantDetailsPanel());
            this.InternalAddWidget(this.BuildAndCachePhalanxDetailsPanel());
            this.EnableDetailPanels(RequestType.SortieDetails);
        }

        private void UpdateDetailPanelsContent(RequestType requestType, Models.States.Inters.IMvcModelState modelState)
        {
            logger.Debug("Updating {}s based off of {}", typeof(IDetailsPanelWidget), requestType);
            if (requestType != RequestType.None)
            {
                this.EnableDetailPanels(requestType);
            }
            if (this.requestTypeDetailsPanels.ContainsKey(requestType))
            {
                this.requestTypeDetailsPanels[requestType].ProcessState(modelState);
            }
        }

        private void EnableDetailPanels(RequestType requestType)
        {
            logger.Debug("Enabling {}s based off of {}", typeof(IDetailsPanelWidget), requestType);
            foreach (KeyValuePair<RequestType, IDetailsPanelWidget> requestTypeDetailsPanel in this.requestTypeDetailsPanels)
            {
                IDetailsPanelWidget detailsPanelWidget = requestTypeDetailsPanel.Value;
                bool isDetailsPanelEnabled = requestTypeDetailsPanel.Key == requestType;
                CanvasWidgetUtils.EnableWidget(detailsPanelWidget, isDetailsPanelEnabled);
            }
        }

        private ICanvasWidget BuildAndCacheMapDetailsPanel()
        {
            IDetailsPanelWidget detailsPanelWidget = (IDetailsPanelWidget)MapDetailsPanelImpl.Builder.Get()
                    .SetPanelGridSize(new Vector2(4, 5))
                    .SetWidgetGridSpec(new WidgetGridSpecImpl()
                        .SetCanvasGridCoords(new Vector2(0, 0))
                        .SetCanvasGridSize(new Vector2(this.canvasGridConvertor.GetGridSize().X,
                            this.canvasGridConvertor.GetGridSize().Y)))
                    .SetMvcType(this.mvcType)
                    .SetCanvasLevel(0)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetName(this.mvcType + ":" + RequestType.FieldDetails + ":" + CanvasWidgetType.Panel)
                    .SetParent(this)
                    .Build();
            this.requestTypeDetailsPanels[RequestType.FieldDetails] = detailsPanelWidget;
            return detailsPanelWidget;
        }

        private ICanvasWidget BuildAndCacheSortieDetailsPanel()
        {
            IDetailsPanelWidget detailsPanelWidget = (IDetailsPanelWidget)SortieDetailsPanelImpl.Builder.Get()
                    .SetPanelGridSize(new Vector2(4, 5))
                    .SetWidgetGridSpec(new WidgetGridSpecImpl()
                        .SetCanvasGridCoords(new Vector2(0, 0))
                        .SetCanvasGridSize(new Vector2(this.canvasGridConvertor.GetGridSize().X,
                            this.canvasGridConvertor.GetGridSize().Y)))
                    .SetMvcType(this.mvcType)
                    .SetCanvasLevel(0)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetName(this.mvcType + ":" + RequestType.SortieDetails + ":" + CanvasWidgetType.Panel)
                    .SetParent(this)
                    .Build();
            this.requestTypeDetailsPanels[RequestType.SortieDetails] = detailsPanelWidget;
            return detailsPanelWidget;
        }

        private ICanvasWidget BuildAndCachePhalanxDetailsPanel()
        {
            IDetailsPanelWidget detailsPanelWidget = (IDetailsPanelWidget)PhalanxDetailsPanelImpl.Builder.Get()
                    .SetPanelGridSize(new Vector2(4, 5))
                    .SetWidgetGridSpec(new WidgetGridSpecImpl()
                        .SetCanvasGridCoords(new Vector2(0, 0))
                        .SetCanvasGridSize(new Vector2(this.canvasGridConvertor.GetGridSize().X,
                            this.canvasGridConvertor.GetGridSize().Y)))
                    .SetMvcType(this.mvcType)
                    .SetCanvasLevel(0)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetName(this.mvcType + ":" + RequestType.PhalanxDetails + ":" + CanvasWidgetType.Panel)
                    .SetParent(this)
                    .Build();
            this.requestTypeDetailsPanels[RequestType.PhalanxDetails] = detailsPanelWidget;
            return detailsPanelWidget;
        }

        private ICanvasWidget BuildAndCacheCombatantDetailsPanel()
        {
            IDetailsPanelWidget detailsPanelWidget = (IDetailsPanelWidget)CombatantDetailsPanelImpl.Builder.Get()
                    .SetPanelGridSize(new Vector2(4, 5))
                    .SetWidgetGridSpec(new WidgetGridSpecImpl()
                        .SetCanvasGridCoords(new Vector2(0, 0))
                        .SetCanvasGridSize(new Vector2(this.canvasGridConvertor.GetGridSize().X,
                            this.canvasGridConvertor.GetGridSize().Y)))
                    .SetMvcType(this.mvcType)
                    .SetCanvasLevel(0)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetName(this.mvcType + ":" + RequestType.CombatantDetails + ":" + CanvasWidgetType.Panel)
                    .SetParent(this)
                    .Build();
            this.requestTypeDetailsPanels[RequestType.CombatantDetails] = detailsPanelWidget;
            return detailsPanelWidget;
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