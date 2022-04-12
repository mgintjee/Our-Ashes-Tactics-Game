using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Constants;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Types;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Combatants
{
    /// <summary>
    /// Panel Widget Impl
    /// </summary>
    public class CombatantDetailsPanelImpl
        : AbstractPanelWidget, IDetailsPanelWidget
    {
        private IDualTextPanelWidget tileCountDualTextPanelWidget;

        public override void Process(Commons.Models.States.Inters.IMvcModelState mvcModelState)
        {
            Models.States.Inters.IMvcModelState qSortieMenuModelState = (Models.States.Inters.IMvcModelState)mvcModelState;
        }

        void IDetailsPanelWidget.ProcessState(Commons.Models.States.Inters.IMvcModelState mvcModelState)
        {
            Models.States.Inters.IMvcModelState qSortieMenuModelState = (Models.States.Inters.IMvcModelState)mvcModelState;
        }

        protected override void InitialBuild()
        {
            Vector2 widgetSize = new Vector2(this.canvasGridConvertor.GetGridSize().X / 2,
                this.canvasGridConvertor.GetGridSize().Y / 6);
            this.InternalAddWidget(this.BuildBannerWidget());
        }

        private IPanelWidget BuildBannerWidget()
        {
            return BannerPanelImpl.Builder.Get()
                .SetText(RequestType.CombatantDetails.ToString())
                .SetPanelGridSize(new Vector2(2, 1))
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(0, this.canvasGridConvertor.GetGridSize().Y * (1 - PanelWidgetConstants.GetBannerPanelRatio())))
                    .SetCanvasGridSize(new Vector2(this.canvasGridConvertor.GetGridSize().X,
                        this.canvasGridConvertor.GetGridSize().Y * PanelWidgetConstants.GetBannerPanelRatio())))
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(0)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetName(this.mvcType + ":" + RequestType.SortieDetails + ":Header:" + CanvasWidgetType.Panel)
                .SetParent(this)
                .Build();
        }

        private IDualTextPanelWidget BuildMapShapeWidget(Vector2 widgetSize)
        {
            return (IDualTextPanelWidget)DualTextPanelImpl.Builder.Get()
                .SetLeftText("Map Shape")
                .SetRightText("N/A")
                .SetPanelGridSize(new Vector2(2, 1))
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(0, 0))
                    .SetCanvasGridSize(widgetSize))
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(0)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetName(this.mvcType + ":" + RequestType.MapDetails + ":MapShape:DualText:" + CanvasWidgetType.Panel)
                .SetParent(this)
                .Build();
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
                    IPanelWidget widget = gameObject.AddComponent<CombatantDetailsPanelImpl>();
                    this.ApplyPanelValues(widget);
                    return widget;
                }
            }
        }
    }
}