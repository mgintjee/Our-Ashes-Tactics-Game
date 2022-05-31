using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Structs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Constants;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Phalanxes.Constants;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Phalanxes
{
    /// <summary>
    /// Panel Widget Impl
    /// </summary>
    public class PhalanxDetailsPanelImpl
        : AbstractPanelWidget, IPanelWidget
    {
        private static readonly IList<CombatantID> combatantIDs = EnumUtils.GetEnumListWithoutFirst<CombatantID>();
        private static readonly IList<PhalanxID> phalanxIDs = EnumUtils.GetEnumListWithoutFirst<PhalanxID>();
        private static readonly IList<string> combatantIDStrings = EnumUtils.GetEnumsAsStrings(combatantIDs);
        private static readonly IList<string> phalanxIDStrings = EnumUtils.GetEnumsAsStrings(phalanxIDs);
        private int combatantIDIndex = 0;
        private int phalanxIDIndex = 0;
        private ICarouselPanelWidget phalanxIDCarouselWidget;
        private IMultiTextPanelWidget phalanxIDHeader;
        private IMultiTextPanelWidget phalanxIDList;
        private IMultiTextPanelWidget phalanxIDButtons;
        private ICarouselPanelWidget combatantIDCarouselWidget;

        public override void Process(IMvcModelState modelState)
        {
            Models.States.Inters.IMvcModelState mvcModelState = (Models.States.Inters.IMvcModelState)modelState;
        }

        protected override void InitialBuild()
        {
            ISet<ICanvasWidget> panelWidgets = new HashSet<ICanvasWidget>() {
                this.BuildAndSetIDCarousel(),
                this.BuildAndSetCombatantIDHeader(),
                this.BuildAndSetCombatantIDList(),
                this.BuildAndSetCombatantIDButtons(),
                this.BuildAndSetCombatantIDCarousel()
            };
            this.InternalAddWidgets(panelWidgets);
        }

        private ICarouselPanelWidget BuildAndSetIDCarousel()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.PhalanxSpinners.COORDS)
                    .SetCanvasGridSize(PanelConstants.SIZE);
            string textName = typeof(PhalanxID).Name;
            this.phalanxIDCarouselWidget = this.BuildCarousel(textName, widgetGridSpec);
            this.phalanxIDCarouselWidget.UpdateSpinnerText(this.phalanxIDIndex, phalanxIDStrings);
            return this.phalanxIDCarouselWidget;
        }

        private IMultiTextPanelWidget BuildAndSetCombatantIDHeader()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.CombatantIDLists.HEADER_COORDS)
                    .SetCanvasGridSize(PanelConstants.CombatantIDLists.HEADER_SIZE);
            IList<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>
            {
                new TextImageWidgetStruct("Combatants:",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR)
            };
            string textName = typeof(PhalanxID).Name + ":Header";
            this.phalanxIDHeader = this.BuildMultiText(textName, widgetGridSpec, textImageWidgetStructs, false);
            return this.phalanxIDHeader;
        }

        private IMultiTextPanelWidget BuildAndSetCombatantIDList()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.CombatantIDLists.LIST_COORDS)
                    .SetCanvasGridSize(PanelConstants.CombatantIDLists.LIST_SIZE);
            IList<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>
            {
                new TextImageWidgetStruct("[]",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR)
            };
            string textName = typeof(PhalanxID).Name + ":List";
            this.phalanxIDList = this.BuildMultiText(textName, widgetGridSpec, textImageWidgetStructs, false);
            return this.phalanxIDList;
        }

        private IMultiTextPanelWidget BuildAndSetCombatantIDButtons()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.CombatantIDLists.BUTTONS_COORDS)
                    .SetCanvasGridSize(PanelConstants.CombatantIDLists.BUTTONS_SIZE);
            IList<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>
            {
                new TextImageWidgetStruct("-",
                    WidgetConstants.BUTTON_INTERACTABLE_ENABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_ENABLED_IMAGE_COLOR),
                new TextImageWidgetStruct("+",
                    WidgetConstants.BUTTON_INTERACTABLE_ENABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_ENABLED_IMAGE_COLOR)
            };
            string textName = typeof(PhalanxID).Name + ":Buttons";
            this.phalanxIDButtons = this.BuildMultiText(textName, widgetGridSpec, textImageWidgetStructs, true);
            return this.phalanxIDButtons;
        }

        private ICarouselPanelWidget BuildAndSetCombatantIDCarousel()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.CombatantSpinners.COORDS)
                    .SetCanvasGridSize(PanelConstants.SIZE);
            string textName = typeof(CombatantID).Name;
            this.combatantIDCarouselWidget = this.BuildCarousel(textName, widgetGridSpec);
            this.combatantIDCarouselWidget.UpdateSpinnerText(this.combatantIDIndex, combatantIDStrings);
            return this.combatantIDCarouselWidget;
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
                    IPanelWidget widget = gameObject.AddComponent<PhalanxDetailsPanelImpl>();
                    this.ApplyPanelValues(widget);
                    return widget;
                }
            }
        }
    }
}