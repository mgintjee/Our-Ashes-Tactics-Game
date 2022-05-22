using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Factions.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Factions.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Constants;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Utils.Queries;
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
        private readonly IList<FactionID> factionIDs = EnumUtils.GetEnumListWithoutFirst<FactionID>();
        private IMultiTextPanelWidget factionIDCarouselText;
        private IMultiTextPanelWidget factionIDCarouselButtons;
        private IMultiTextPanelWidget selectedFactionIDText;
        private IMultiTextPanelWidget phalanxCallSignsHeader;
        private IMultiTextPanelWidget phalanxCallSignsList;
        private IMultiTextPanelWidget selectedFactionIDButtons;
        private int currentFactionIndex = 0;

        public override void Process(IMvcModelState modelState)
        {
            Models.States.Inters.IMvcModelState mvcModelState = (Models.States.Inters.IMvcModelState)modelState;
            this.UpdateCurrentFactionID(mvcModelState);
            this.UpdateFactionInfo(mvcModelState);
            this.UpdateCarouselText(mvcModelState);
        }

        protected override void InitialBuild()
        {
            ISet<ICanvasWidget> panelWidgets = new HashSet<ICanvasWidget>() {
                this.BuildAndSetFactionCarouselTexts(),
                this.BuildAndSetFactionCarouselButtons(),
                this.BuildAndSetSelectedFactionIDText(),
                this.BuildAndSetSelectedFactionIDButtons(),
                this.BuildAndSetPhalanxCallSignsHeader(),
                this.BuildAndSetPhalanxCallSignsList()
            };
            this.InternalAddWidgets(panelWidgets);
        }

        private void UpdateCurrentFactionID(Models.States.Inters.IMvcModelState mvcModelState)
        {
        }

        private void UpdateFactionInfo(Models.States.Inters.IMvcModelState mvcModelState)
        {
            FactionID factionID = factionIDs[this.currentFactionIndex];
            this.selectedFactionIDText.GetTextWidget(1).IfPresent(widget => widget.SetText(factionID.ToString()));

            IList<IFactionDetails> factionDetails = mvcModelState.GetFactionDetails();
            MvcModelStateQueryUtil.GetFactionDetails(mvcModelState, factionID).IfPresent(factionDetails =>
            {
                IList<IPhalanxDetails> phalanxDetails = factionDetails.GetPhalanxDetails();
                IList<PhalanxCallSign> phalanxCallSigns = new List<PhalanxCallSign>();
                foreach (IPhalanxDetails details in phalanxDetails)
                {
                    phalanxCallSigns.Add(details.GetCallSign());
                }
                this.phalanxCallSignsList.GetTextWidget(1).IfPresent(widget => widget.SetText(StringUtils.Format(phalanxCallSigns)));
            });
        }

        private void UpdateCarouselText(Models.States.Inters.IMvcModelState mvcModelState)
        {
            int leftFactionIndex = (this.currentFactionIndex > 0) ? this.currentFactionIndex - 1 : factionIDs.Count - 1;
            int rightFactionIndex = (this.currentFactionIndex < factionIDs.Count - 1) ? this.currentFactionIndex + 1 : 0;
            FactionID leftFactionID = factionIDs[leftFactionIndex];
            FactionID centerFactionID = factionIDs[this.currentFactionIndex];
            FactionID rightFactionID = factionIDs[rightFactionIndex];
            this.factionIDCarouselText.GetTextWidget(0).IfPresent(widget => widget.SetText(leftFactionID.ToString()));
            this.factionIDCarouselText.GetTextWidget(1).IfPresent(widget => widget.SetText(centerFactionID.ToString()));
            this.factionIDCarouselText.GetTextWidget(2).IfPresent(widget => widget.SetText(rightFactionID.ToString()));
        }

        private IMultiTextPanelWidget BuildAndSetFactionCarouselTexts()
        {
            List<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>();
            textImageWidgetStructs.Add(new TextImageWidgetStruct(FactionID.None.ToString(),
                WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR, WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR));
            textImageWidgetStructs.Add(new TextImageWidgetStruct(FactionID.None.ToString(),
                WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR, WidgetConstants.SECONDARY_COLOR_ID));
            textImageWidgetStructs.Add(new TextImageWidgetStruct(FactionID.None.ToString(),
                WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR, WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR));
            string textName = "FactionIDCarouselTexts";
            Vector2 canvasGridSize = PanelConstants.Carousel.Vectors.TEXT_SIZE;
            Vector2 canvasGridCoords = PanelConstants.Carousel.Vectors.TEXT_COORDS;
            this.factionIDCarouselText = this.BuildMultiText(textName, canvasGridCoords, canvasGridSize, textImageWidgetStructs, false);
            return this.factionIDCarouselText;
        }

        private IMultiTextPanelWidget BuildAndSetFactionCarouselButtons()
        {
            List<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>();
            textImageWidgetStructs.Add(new TextImageWidgetStruct("<",
                WidgetConstants.BUTTON_INTERACTABLE_ENABLED_TEXT_COLOR, WidgetConstants.BUTTON_INTERACTABLE_ENABLED_IMAGE_COLOR));
            textImageWidgetStructs.Add(new TextImageWidgetStruct(">",
                WidgetConstants.BUTTON_INTERACTABLE_ENABLED_TEXT_COLOR, WidgetConstants.BUTTON_INTERACTABLE_ENABLED_IMAGE_COLOR));
            string textName = "FactionIDCarouselButtons";
            Vector2 canvasGridSize = PanelConstants.Carousel.Vectors.BUTTONS_SIZE;
            Vector2 canvasGridCoords = PanelConstants.Carousel.Vectors.BUTTONS_COORDS;
            this.factionIDCarouselButtons = this.BuildMultiText(textName, canvasGridCoords, canvasGridSize, textImageWidgetStructs, true);
            return this.factionIDCarouselButtons;
        }

        private IMultiTextPanelWidget BuildAndSetSelectedFactionIDText()
        {
            List<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>();
            textImageWidgetStructs.Add(new TextImageWidgetStruct(typeof(FactionID).Name,
                WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR, WidgetConstants.SECONDARY_COLOR_ID));
            textImageWidgetStructs.Add(new TextImageWidgetStruct(FactionID.None.ToString(),
                WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR, WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR));
            string textName = "SelectedFactionIDText";
            Vector2 canvasGridSize = PanelConstants.SelectedFaction.Vectors.TEXTS_SIZE;
            Vector2 canvasGridCoords = PanelConstants.SelectedFaction.Vectors.TEXTS_COORDS;
            this.selectedFactionIDText = this.BuildMultiText(textName, canvasGridCoords, canvasGridSize, textImageWidgetStructs, false);
            return this.selectedFactionIDText;
        }

        private IMultiTextPanelWidget BuildAndSetSelectedFactionIDButtons()
        {
            List<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>();
            textImageWidgetStructs.Add(new TextImageWidgetStruct("-",
                WidgetConstants.BUTTON_INTERACTABLE_ENABLED_TEXT_COLOR, WidgetConstants.BUTTON_INTERACTABLE_ENABLED_IMAGE_COLOR));
            textImageWidgetStructs.Add(new TextImageWidgetStruct("+",
                WidgetConstants.BUTTON_INTERACTABLE_ENABLED_TEXT_COLOR, WidgetConstants.BUTTON_INTERACTABLE_ENABLED_IMAGE_COLOR));
            string textName = "SelectedFactionIDText";
            Vector2 canvasGridSize = PanelConstants.SelectedFaction.Vectors.BUTTONS_SIZE;
            Vector2 canvasGridCoords = PanelConstants.SelectedFaction.Vectors.BUTTONS_COORDS;
            this.selectedFactionIDButtons = this.BuildMultiText(textName, canvasGridCoords, canvasGridSize, textImageWidgetStructs, true);
            return this.selectedFactionIDButtons;
        }

        private IMultiTextPanelWidget BuildAndSetPhalanxCallSignsHeader()
        {
            List<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>();
            textImageWidgetStructs.Add(new TextImageWidgetStruct(typeof(PhalanxCallSign).Name + "s",
                WidgetConstants.BUTTON_INTERACTABLE_ENABLED_TEXT_COLOR, WidgetConstants.BUTTON_INTERACTABLE_ENABLED_IMAGE_COLOR));
            string textName = "PhalanxCallSignsHeader";
            Vector2 canvasGridSize = PanelConstants.PhalanxCallSigns.Vectors.HEADER_SIZE;
            Vector2 canvasGridCoords = PanelConstants.PhalanxCallSigns.Vectors.HEADER_COORDS;
            this.phalanxCallSignsHeader = this.BuildMultiText(textName, canvasGridCoords, canvasGridSize, textImageWidgetStructs, false);
            return this.phalanxCallSignsHeader;
        }

        private IMultiTextPanelWidget BuildAndSetPhalanxCallSignsList()
        {
            List<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>();
            textImageWidgetStructs.Add(new TextImageWidgetStruct("[]",
                WidgetConstants.BUTTON_INTERACTABLE_ENABLED_TEXT_COLOR, WidgetConstants.BUTTON_INTERACTABLE_ENABLED_IMAGE_COLOR));
            string textName = "PhalanxCallSignsList";
            Vector2 canvasGridSize = PanelConstants.PhalanxCallSigns.Vectors.LIST_SIZE;
            Vector2 canvasGridCoords = PanelConstants.PhalanxCallSigns.Vectors.LIST_COORDS;
            this.phalanxCallSignsList = this.BuildMultiText(textName, canvasGridCoords, canvasGridSize, textImageWidgetStructs, false);
            return this.phalanxCallSignsList;
        }

        private IMultiTextPanelWidget BuildMultiText(string widgetName, Vector2 canvasGridCoords,
            Vector2 canvasGridSize, List<TextImageWidgetStruct> textImageWidgetStructs, bool interactable)
        {
            Vector2 panelGridSize = new Vector2(textImageWidgetStructs.Count, 1);
            IDictionary<int, TextImageWidgetStruct> indexTextImageWidgetStructs = new Dictionary<int, TextImageWidgetStruct>();
            for (int i = 0; i < textImageWidgetStructs.Count; ++i)
            {
                indexTextImageWidgetStructs.Add(i, textImageWidgetStructs[i]);
            }
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(canvasGridCoords)
                    .SetCanvasGridSize(canvasGridSize);
            return (IMultiTextPanelWidget)MultiTextPanelImpl.Builder.Get()
                .SetTextImageWidgetStructs(indexTextImageWidgetStructs)
                .SetBackgroundColor(WidgetConstants.PRIMARY_COLOR_ID)
                .SetPanelGridSize(panelGridSize)
                .SetWidgetGridSpec(widgetGridSpec)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(1)
                .SetInteractable(interactable)
                .SetEnabled(true)
                .SetName(this.mvcType + ":" + this.GetType().Name + ":" + CanvasWidgetType.Panel + ":" + widgetName)
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
                    IPanelWidget widget = gameObject.AddComponent<FactionDetailsPanelImpl>();
                    this.ApplyPanelValues(widget);
                    return widget;
                }
            }
        }
    }
}