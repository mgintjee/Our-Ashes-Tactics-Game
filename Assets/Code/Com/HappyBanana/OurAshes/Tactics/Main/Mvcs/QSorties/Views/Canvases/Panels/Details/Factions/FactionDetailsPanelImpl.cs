using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Icons.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Structs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Utils;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Factions.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Factions.PopUps;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Factions
{
    /// <summary>
    /// Panel Widget Impl
    /// </summary>
    public class FactionDetailsPanelImpl
        : AbstractPanelWidget, IPanelWidget
    {
        private IPopUpPanelWidget popUpWidget;
        private IButtonPanelWidget idButton;
        private IButtonPanelWidget iconButton;
        private IButtonPanelWidget phalanxAddButton;
        private IButtonPanelWidget phalanxMinusButton;
        private IMultiTextPanelWidget phalanxIDList;
        private IMultiTextPanelWidget powerText;
        private IFactionDetails selectedFactionDetails;
        private ICombatantsDetails combatantsDetails;
        private IFieldDetails fieldDetails;

        public override void Process(IMvcModelState modelState)
        {
            logger.Debug("Processing {}", modelState);
            Models.States.Inters.IMvcModelState mvcModelState = (Models.States.Inters.IMvcModelState)modelState;
            this.combatantsDetails = mvcModelState.GetCombatantsDetails();
            this.fieldDetails = mvcModelState.GetFieldDetails();
            this.selectedFactionDetails = this.combatantsDetails.GetFactionDetails()[0];
            this.UpdateWidgets();
            mvcModelState.GetPrevMvcRequest().IfPresent(request =>
            {
                this.ProcessPrevRequest((IQSortieMenuMvcRequest)request);
            });
        }

        protected override void InitialBuild()
        {
            this.InternalAddWidgets(this.BuildTexts());
            this.InternalAddWidgets(this.BuildButtons());
        }

        private ISet<ICanvasWidget> BuildTexts()
        {
            return new HashSet<ICanvasWidget>
            {
                this.BuildIDText(),
                this.BuildIconText(),
                this.BuildPhalanxText(),
                this.BuildAndSetPhalanxListText(),
                this.BuildPowersText()
            };
        }

        private ISet<ICanvasWidget> BuildButtons()
        {
            return new HashSet<ICanvasWidget>
            {
                this.BuildAndSetIDButton(),
                this.BuildAndSetIconButton(),
                this.BuildAndSetPhalanxMinusButton(),
                this.BuildAndSetPhalanxAddButton(),
            };
        }

        private void ProcessPrevRequest(IQSortieMenuMvcRequest mvcRequest)
        {
            RequestType requestType = mvcRequest.GetRequestType();
            switch (requestType)
            {
                case RequestType.FactionIDPopUp:
                    this.popUpWidget.UpdatePopupEntry(this.BuildIDPopUp());
                    break;

                case RequestType.PhalanxIDMinusPopUp:
                    this.popUpWidget.UpdatePopupEntry(this.BuildPhalanxIDMinusPopUp());
                    break;

                case RequestType.PhalanxIDAddPopUp:
                    this.popUpWidget.UpdatePopupEntry(this.BuildPhalanxIDAddPopUp());
                    break;

                case RequestType.PopUpDisable:
                case RequestType.FactionIDSelect:
                case RequestType.PhalanxIDMinusMod:
                case RequestType.PhalanxIDAddMod:
                    this.popUpWidget.SetEnabled(false);
                    break;

                default:
                    logger.Debug("Unsupported {}", requestType);
                    break;
            }
        }

        private void UpdateWidgets()
        {
            this.idButton.GetTextWidget().SetText(this.selectedFactionDetails.GetFactionID().ToString());
            IList<PhalanxID> ids = this.selectedFactionDetails.GetPhalanxIDs();
            string idsString = "[" + string.Join(",", ids) + "]";
            this.phalanxIDList.GetTextWidget(0).GetValue().SetText(idsString);

            logger.Debug("Setting MINUS Interactable: {}", ids.Count != 0);
            CanvasWidgetUtils.SetButtonInteractable(this.phalanxMinusButton, ids.Count != 0);

            IList<IPhalanxDetails> details = this.combatantsDetails.GetPhalanxDetails();
            int maxCount = PhalanxCountConstants.GetMaxCount(this.fieldDetails.GetFieldSize());
            logger.Debug("Setting ADD Interactable: {}", details.Count < maxCount);
            CanvasWidgetUtils.SetButtonInteractable(this.phalanxAddButton, details.Count < maxCount);
        }

        private IButtonPanelWidget BuildAndSetIDButton()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.IDs.BUTTON_COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            string buttonType = RequestType.FactionIDPopUp.ToString();
            string textName = buttonType + ":Button";
            string buttonText = FactionID.None.ToString();
            idButton = this.BuildButton(textName, widgetGridSpec, buttonText, buttonType);
            return idButton;
        }

        private IButtonPanelWidget BuildAndSetIconButton()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.Icons.BUTTON_COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            string buttonType = typeof(IconID).Name;
            string textName = typeof(FactionID).Name + ":" + buttonType + "PopUp:Button";
            string buttonText = IconID.None.ToString();
            iconButton = this.BuildButton(textName, widgetGridSpec, buttonText, buttonType);
            return iconButton;
        }

        private IButtonPanelWidget BuildAndSetPhalanxMinusButton()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.PhalanxHeader.MINUS_BUTTON_COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            string buttonType = RequestType.PhalanxIDMinusPopUp.ToString();
            string textName = buttonType + ":Button";
            string buttonText = "-";
            phalanxMinusButton = this.BuildButton(textName, widgetGridSpec, buttonText, buttonType);
            return phalanxMinusButton;
        }

        private IButtonPanelWidget BuildAndSetPhalanxAddButton()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.PhalanxHeader.ADD_BUTTON_COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            string buttonType = RequestType.PhalanxIDAddPopUp.ToString();
            string textName = buttonType + ":Button";
            string buttonText = "+";
            phalanxAddButton = this.BuildButton(textName, widgetGridSpec, buttonText, buttonType);
            return phalanxAddButton;
        }

        private IMultiTextPanelWidget BuildIconText()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.Icons.TEXT_COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            IList<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>
            {
                new TextImageWidgetStruct("Icon:",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR)
            };
            string textName = "Icon:Text";
            return this.BuildMultiText(textName, widgetGridSpec, textImageWidgetStructs, false);
        }

        private IMultiTextPanelWidget BuildIDText()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.IDs.TEXT_COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            IList<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>
            {
                new TextImageWidgetStruct("ID:",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR)
            };
            string textName = typeof(FactionID).Name + ":Text";
            return this.BuildMultiText(textName, widgetGridSpec, textImageWidgetStructs, false);
        }

        private IMultiTextPanelWidget BuildPhalanxText()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.PhalanxHeader.TEXT_COORDS)
                    .SetCanvasGridSize(PanelConstants.PhalanxHeader.TEXT_SIZE);
            IList<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>
            {
                new TextImageWidgetStruct("Phalanxes:",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR)
            };
            string textName = typeof(PhalanxID).Name + ":Text";
            return this.BuildMultiText(textName, widgetGridSpec, textImageWidgetStructs, false);
        }

        private IMultiTextPanelWidget BuildAndSetPhalanxListText()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.PhalanxList.COORDS)
                    .SetCanvasGridSize(PanelConstants.PhalanxList.SIZE);
            IList<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>
            {
                new TextImageWidgetStruct("[]",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR)
            };
            string textName = typeof(PhalanxID).Name + "List:Text";
            this.phalanxIDList = this.BuildMultiText(textName, widgetGridSpec, textImageWidgetStructs, false);
            return this.phalanxIDList;
        }

        private IMultiTextPanelWidget BuildPowersText()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.Powers.COORDS)
                    .SetCanvasGridSize(PanelConstants.Powers.SIZE);
            IList<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>
            {
                new TextImageWidgetStruct("Faction Power:",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR),
                new TextImageWidgetStruct("0",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR)
            };
            string textName = typeof(FactionID).Name + ":Power:Text";
            return this.BuildMultiText(textName, widgetGridSpec, textImageWidgetStructs, false);
        }

        private IPanelWidget BuildIDPopUp()
        {
            string widgetName = RequestType.FactionIDPopUp.ToString();
            IList<FactionID> vals = EnumUtils.GetEnumListWithoutFirst<FactionID>();
            return IDPopUpImpl.Builder.Get()
                .SetDetails(this.combatantsDetails)
                .SetPanelGridSize(new Vector2(1, vals.Count))
                .SetWidgetGridSpec(WidgetConstants.POP_UP_WIDGET_GRID_SPEC)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(99)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetName(widgetName)
                .SetParent(this)
                .Build();
        }

        private IPanelWidget BuildPhalanxIDMinusPopUp()
        {
            string widgetName = RequestType.PhalanxIDMinusPopUp.ToString();
            FactionID factionID = this.selectedFactionDetails.GetFactionID();
            IList<PhalanxID> ids = this.selectedFactionDetails.GetPhalanxIDs();
            return PhalanxIDMinusPopUpImpl.Builder.Get()
                .SetFactionID(factionID)
                .SetPhalanxIDs(ids)
                .SetPanelGridSize(new Vector2(1, ids.Count))
                .SetWidgetGridSpec(WidgetConstants.POP_UP_WIDGET_GRID_SPEC)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(99)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetName(widgetName)
                .SetParent(this)
                .Build();
        }

        private IPanelWidget BuildPhalanxIDAddPopUp()
        {
            string widgetName = RequestType.PhalanxIDAddPopUp.ToString();
            FactionID id = this.selectedFactionDetails.GetFactionID();
            IList<IPhalanxDetails> unavailableDetails = this.combatantsDetails.GetPhalanxDetails();
            IList<PhalanxID> availableIDs = EnumUtils.GetEnumListWithoutFirst<PhalanxID>();
            foreach (IPhalanxDetails unavailableID in unavailableDetails)
            {
                availableIDs.Remove(unavailableID.GetPhalanxID());
            }
            return PhalanxIDAddPopUpImpl.Builder.Get()
                .SetFactionID(id)
                .SetPhalanxIDs(availableIDs)
                .SetPanelGridSize(new Vector2(1, availableIDs.Count))
                .SetWidgetGridSpec(WidgetConstants.POP_UP_WIDGET_GRID_SPEC)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(99)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetName(widgetName)
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
                    FactionDetailsPanelImpl widget = gameObject.AddComponent<FactionDetailsPanelImpl>();
                    widget.popUpWidget = popUpWidget;
                    this.ApplyPanelValues(widget);
                    return widget;
                }
            }
        }
    }
}