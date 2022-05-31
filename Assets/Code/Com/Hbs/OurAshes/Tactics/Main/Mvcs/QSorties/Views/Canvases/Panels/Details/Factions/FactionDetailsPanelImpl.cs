using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Factions.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Structs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Constants;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Factions.Constants;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Factions
{
    /// <summary>
    /// Panel Widget Impl
    /// </summary>
    public class FactionDetailsPanelImpl
        : AbstractPanelWidget, IPanelWidget
    {
        private static readonly IList<FactionID> factionIDs = EnumUtils.GetEnumListWithoutFirst<FactionID>();
        private static readonly IList<PhalanxID> phalanxIDs = EnumUtils.GetEnumListWithoutFirst<PhalanxID>();
        private static readonly IList<string> factionIDStrings = EnumUtils.GetEnumsAsStrings(factionIDs);
        private static readonly IList<string> phalanxIDStrings = EnumUtils.GetEnumsAsStrings(phalanxIDs);
        private int factionIdIndex = 0;
        private int phalanxIDIndex = 0;
        private ICarouselPanelWidget factionIDCarouselWidget;
        private IMultiTextPanelWidget phalanxIDHeader;
        private IMultiTextPanelWidget phalanxIDList;
        private IMultiTextPanelWidget phalanxIDButtons;
        private ICarouselPanelWidget phalanxIDCarouselWidget;

        public override void Process(IMvcModelState modelState)
        {
            Models.States.Inters.IMvcModelState mvcModelState = (Models.States.Inters.IMvcModelState)modelState;
        }

        protected override void InitialBuild()
        {
            ISet<ICanvasWidget> panelWidgets = new HashSet<ICanvasWidget>() {
                this.BuildAndSetFactionIDCarousel(),
                this.BuildAndSetPhalanxIDHeader(),
                this.BuildAndSetPhalanxIDList(),
                this.BuildAndSetPhalanxIDButtons(),
                this.BuildAndSetPhalanxIDCarousel()
            };
            this.InternalAddWidgets(panelWidgets);
        }

        private ICarouselPanelWidget BuildAndSetFactionIDCarousel()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.FactionID.COORDS)
                    .SetCanvasGridSize(PanelConstants.SIZE);
            string textName = typeof(FactionID).Name;
            this.factionIDCarouselWidget = this.BuildCarousel(textName, widgetGridSpec);
            this.factionIDCarouselWidget.UpdateSpinnerText(this.factionIdIndex, factionIDStrings);
            return this.factionIDCarouselWidget;
        }

        private IMultiTextPanelWidget BuildAndSetPhalanxIDHeader()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.PhalanxIDList.HEADER_COORDS)
                    .SetCanvasGridSize(PanelConstants.PhalanxIDList.HEADER_SIZE);
            IList<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>
            {
                new TextImageWidgetStruct(typeof(PhalanxID).Name,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR)
            };
            string textName = typeof(PhalanxID).Name + ":Header";
            this.phalanxIDHeader = this.BuildMultiText(textName, widgetGridSpec,
                textImageWidgetStructs, false);
            return this.phalanxIDHeader;
        }

        private IMultiTextPanelWidget BuildAndSetPhalanxIDList()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.PhalanxIDList.LIST_COORDS)
                    .SetCanvasGridSize(PanelConstants.PhalanxIDList.LIST_SIZE);
            IList<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>
            {
                new TextImageWidgetStruct("[]",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR)
            };
            string textName = typeof(PhalanxID).Name + ":List";
            this.phalanxIDList = this.BuildMultiText(textName, widgetGridSpec,
                textImageWidgetStructs, false);
            return this.phalanxIDList;
        }

        private IMultiTextPanelWidget BuildAndSetPhalanxIDButtons()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.PhalanxIDList.BUTTONS_COORDS)
                    .SetCanvasGridSize(PanelConstants.PhalanxIDList.BUTTONS_SIZE);
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
            this.phalanxIDButtons = this.BuildMultiText(textName, widgetGridSpec,
                textImageWidgetStructs, true);
            return this.phalanxIDButtons;
        }

        private ICarouselPanelWidget BuildAndSetPhalanxIDCarousel()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.PhalanxIDSpinner.COORDS)
                    .SetCanvasGridSize(PanelConstants.SIZE);
            string textName = typeof(PhalanxID).Name;
            this.phalanxIDCarouselWidget = this.BuildCarousel(textName, widgetGridSpec);
            this.phalanxIDCarouselWidget.UpdateSpinnerText(this.phalanxIDIndex, phalanxIDStrings);
            return this.phalanxIDCarouselWidget;
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
                    IPanelWidget widget = gameObject.AddComponent<FactionDetailsPanelImpl>();
                    this.ApplyPanelValues(widget);
                    return widget;
                }
            }
        }
    }
}