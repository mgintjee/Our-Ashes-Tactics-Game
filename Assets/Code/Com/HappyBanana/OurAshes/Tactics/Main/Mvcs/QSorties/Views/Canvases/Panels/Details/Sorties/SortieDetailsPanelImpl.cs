using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Structs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Sorties.Constants;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Sorties
{
    /// <summary>
    /// Sortie Details Panel Widget Impl
    /// </summary>
    public class SortieDetailsPanelImpl
        : AbstractPanelWidget, IPanelWidget
    {
        private IPopUpPanelWidget popUpWidget;
        private IMultiTextPanelWidget factionCountWidget;
        private IMultiTextPanelWidget phalanxCountWidget;
        private IMultiTextPanelWidget unitCountWidget;
        private IMultiTextPanelWidget fieldIDWidget;

        public override void Process(IMvcModelState modelState)
        {
            Models.States.Inters.IMvcModelState mvcModelState = (Models.States.Inters.IMvcModelState)modelState;
        }

        protected override void InitialBuild()
        {
            ISet<ICanvasWidget> panelWidgets = new HashSet<ICanvasWidget>() {
                this.BuildAndSetFactionCount(),
                this.BuildAndSetPhalanxCount(),
                this.BuildAndSetUnitCount(),
                this.BuildAndSetFieldID()
            };
            this.InternalAddWidgets(panelWidgets);
        }

        private IMultiTextPanelWidget BuildAndSetFactionCount()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.Factions.COORDS)
                    .SetCanvasGridSize(PanelConstants.COUNTER_SIZE);
            IList<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>
            {
                new TextImageWidgetStruct("Faction Count:",
                    WidgetConstants.BUTTON_INTERACTABLE_ENABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_ENABLED_IMAGE_COLOR),
                new TextImageWidgetStruct("0",
                    WidgetConstants.BUTTON_INTERACTABLE_ENABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_ENABLED_IMAGE_COLOR)
            };
            string textName = typeof(FactionID).Name + ":Counter";
            this.factionCountWidget = this.BuildMultiText(textName, widgetGridSpec,
                textImageWidgetStructs, false);
            return this.factionCountWidget;
        }

        private IMultiTextPanelWidget BuildAndSetPhalanxCount()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.Phalanxes.COORDS)
                    .SetCanvasGridSize(PanelConstants.COUNTER_SIZE);
            IList<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>
            {
                new TextImageWidgetStruct("Phalanx Count",
                    WidgetConstants.BUTTON_INTERACTABLE_ENABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_ENABLED_IMAGE_COLOR),
                new TextImageWidgetStruct("0",
                    WidgetConstants.BUTTON_INTERACTABLE_ENABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_ENABLED_IMAGE_COLOR)
            };
            string textName = typeof(PhalanxID).Name + ":Counter";
            this.phalanxCountWidget = this.BuildMultiText(textName, widgetGridSpec,
                textImageWidgetStructs, false);
            return this.phalanxCountWidget;
        }

        private IMultiTextPanelWidget BuildAndSetUnitCount()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.Units.COORDS)
                    .SetCanvasGridSize(PanelConstants.COUNTER_SIZE);
            IList<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>
            {
                new TextImageWidgetStruct("Unit Count",
                    WidgetConstants.BUTTON_INTERACTABLE_ENABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_ENABLED_IMAGE_COLOR),
                new TextImageWidgetStruct("0",
                    WidgetConstants.BUTTON_INTERACTABLE_ENABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_ENABLED_IMAGE_COLOR)
            };
            string textName = typeof(UnitID).Name + ":Counter";
            this.unitCountWidget = this.BuildMultiText(textName, widgetGridSpec,
                textImageWidgetStructs, false);
            return this.unitCountWidget;
        }

        private IMultiTextPanelWidget BuildAndSetFieldID()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.Fields.COORDS)
                    .SetCanvasGridSize(PanelConstants.COUNTER_SIZE);
            IList<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>
            {
                new TextImageWidgetStruct("Field ID:",
                    WidgetConstants.BUTTON_INTERACTABLE_ENABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_ENABLED_IMAGE_COLOR),
                new TextImageWidgetStruct("null",
                    WidgetConstants.BUTTON_INTERACTABLE_ENABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_ENABLED_IMAGE_COLOR)
            };
            string textName = typeof(FactionID).Name + ":Header";
            this.fieldIDWidget = this.BuildMultiText(textName, widgetGridSpec,
                textImageWidgetStructs, true);
            return this.fieldIDWidget;
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
                    SortieDetailsPanelImpl widget = gameObject.AddComponent<SortieDetailsPanelImpl>();
                    widget.popUpWidget = popUpWidget;
                    this.ApplyPanelValues(widget);
                    return widget;
                }
            }
        }
    }
}