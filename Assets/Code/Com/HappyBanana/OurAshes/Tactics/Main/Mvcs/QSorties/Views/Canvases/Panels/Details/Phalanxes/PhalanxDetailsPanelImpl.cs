using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
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
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Phalanxes.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Phalanxes.PopUps;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Phalanxes
{
    /// <summary>
    /// Panel Widget Impl
    /// </summary>
    public class PhalanxDetailsPanelImpl
        : AbstractPanelWidget, IPanelWidget
    {
        private IPopUpPanelWidget popUpWidget;
        private IButtonPanelWidget idButton;
        private IButtonPanelWidget iconButton;
        private IButtonPanelWidget unitAddButton;
        private IButtonPanelWidget unitMinusButton;
        private IMultiTextPanelWidget unitIDList;
        private IMultiTextPanelWidget powerText;
        private IPhalanxDetails selectedDetails;
        private ICombatantsDetails combatantsDetails;
        private IFieldDetails fieldDetails;

        public override void Process(IMvcModelState modelState)
        {
            Models.States.Inters.IMvcModelState mvcModelState = (Models.States.Inters.IMvcModelState)modelState;
            this.combatantsDetails = mvcModelState.GetCombatantsDetails();
            this.fieldDetails = mvcModelState.GetFieldDetails();
            this.selectedDetails = this.combatantsDetails.GetPhalanxDetails()[0];
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
                this.BuildAndSetUnitListText(),
                this.BuildPowersText()
            };
        }

        private ISet<ICanvasWidget> BuildButtons()
        {
            return new HashSet<ICanvasWidget>() {
                this.BuildAndSetIDButton(),
                this.BuildAndSetIconButton(),
                this.BuildAndSetUnitMinusButton(),
                this.BuildAndSetUnitAddButton()
            };
        }

        private void ProcessPrevRequest(IQSortieMenuMvcRequest mvcRequest)
        {
            RequestType requestType = mvcRequest.GetRequestType();
            switch (requestType)
            {
                case RequestType.PhalanxIDPopUp:
                    this.popUpWidget.UpdatePopupEntry(this.BuildIDPopUp());
                    break;

                case RequestType.UnitIDMinusPopUp:
                    this.popUpWidget.UpdatePopupEntry(this.BuildUnitIDMinusPopUp());
                    break;

                case RequestType.UnitIDAddPopUp:
                    this.popUpWidget.UpdatePopupEntry(this.BuildUnitIDAddPopUp());
                    break;

                case RequestType.PopUpDisable:
                case RequestType.PhalanxIDSelect:
                case RequestType.UnitIDMinusMod:
                case RequestType.UnitIDAddMod:
                    this.popUpWidget.SetEnabled(false);
                    break;

                default:
                    logger.Debug("Unsupported {}", requestType);
                    break;
            }
        }

        private void UpdateWidgets()
        {
            this.idButton.GetTextWidget().SetText(this.selectedDetails.GetPhalanxID().ToString());

            IList<UnitID> ids = this.selectedDetails.GetUnitIDs();
            string idsString = "[" + string.Join(", ", ids) + "]";
            this.unitIDList.GetTextWidget(0).GetValue().SetText(idsString);

            logger.Debug("Setting MINUS Interactable: {}", ids.Count != 0);
            CanvasWidgetUtils.SetButtonInteractable(this.unitMinusButton, ids.Count != 0);

            IList<IUnitDetails> details = this.combatantsDetails.GetUnitDetails();
            int maxCount = UnitCountConstants.GetMaxCount(this.fieldDetails.GetFieldSize(), this.combatantsDetails.GetPhalanxDetails().Count);
            logger.Debug("Setting ADD Interactable: {}", details.Count < maxCount);
            CanvasWidgetUtils.SetButtonInteractable(this.unitAddButton, details.Count < maxCount);
        }

        private IButtonPanelWidget BuildAndSetIDButton()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.IDs.BUTTON_COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            string buttonType = RequestType.PhalanxIDPopUp.ToString();
            string textName = this.mvcType + ":" + buttonType + ":Button";
            string buttonText = PhalanxID.None.ToString();
            idButton = this.BuildButton(textName, widgetGridSpec, buttonText, buttonType);
            return idButton;
        }

        private IButtonPanelWidget BuildAndSetIconButton()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.Icons.BUTTON_COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            string buttonType = typeof(IconID).Name;
            string textName = typeof(PhalanxID).Name + ":" + buttonType + "PopUp:Button";
            string buttonText = IconID.None.ToString();
            iconButton = this.BuildButton(textName, widgetGridSpec, buttonText, buttonType);
            return iconButton;
        }

        private IButtonPanelWidget BuildAndSetUnitMinusButton()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.UnitHeader.MINUS_BUTTON_COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            string buttonType = RequestType.UnitIDMinusPopUp.ToString();
            string textName = buttonType + "PopUp:Button";
            string buttonText = "-";
            unitMinusButton = this.BuildButton(textName, widgetGridSpec, buttonText, buttonType);
            return unitMinusButton;
        }

        private IButtonPanelWidget BuildAndSetUnitAddButton()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.UnitHeader.ADD_BUTTON_COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            string buttonType = RequestType.UnitIDAddPopUp.ToString();
            string textName = this.mvcType + ":" + buttonType + "PopUp:Button";
            string buttonText = "+";
            unitAddButton = this.BuildButton(textName, widgetGridSpec, buttonText, buttonType);
            return unitAddButton;
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
            string textName = typeof(PhalanxID).Name + ":Text";
            return this.BuildMultiText(textName, widgetGridSpec, textImageWidgetStructs, false);
        }

        private IMultiTextPanelWidget BuildPhalanxText()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.UnitHeader.TEXT_COORDS)
                    .SetCanvasGridSize(PanelConstants.UnitHeader.TEXT_SIZE);
            IList<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>
            {
                new TextImageWidgetStruct("Units:",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR)
            };
            string textName = typeof(UnitID).Name + ":Text";
            return this.BuildMultiText(textName, widgetGridSpec, textImageWidgetStructs, false);
        }

        private IMultiTextPanelWidget BuildAndSetUnitListText()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.UnitList.COORDS)
                    .SetCanvasGridSize(PanelConstants.UnitList.SIZE);
            IList<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>
            {
                new TextImageWidgetStruct("[]",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR)
            };
            string textName = typeof(PhalanxID).Name + "List:Text";
            this.unitIDList = this.BuildMultiText(textName, widgetGridSpec, textImageWidgetStructs, false);
            return this.unitIDList;
        }

        private IMultiTextPanelWidget BuildPowersText()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.Powers.COORDS)
                    .SetCanvasGridSize(PanelConstants.Powers.SIZE);
            IList<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>
            {
                new TextImageWidgetStruct("Phalanx Power:",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR),
                new TextImageWidgetStruct("0",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR)
            };
            string textName = typeof(PhalanxID).Name + ":Power:Text";
            return this.BuildMultiText(textName, widgetGridSpec, textImageWidgetStructs, false);
        }

        private IPanelWidget BuildIDPopUp()
        {
            string widgetName = RequestType.FactionIDPopUp.ToString();
            IList<PhalanxID> ids = new List<PhalanxID>();
            foreach (IPhalanxDetails phalanxDetails in this.combatantsDetails.GetPhalanxDetails())
            {
                ids.Add(phalanxDetails.GetPhalanxID());
            }
            return IDPopUpImpl.Builder.Get()
                .SetPhalanxID(this.combatantsDetails.GetPhalanxDetails()[0].GetPhalanxID())
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

        private IPanelWidget BuildUnitIDMinusPopUp()
        {
            string widgetName = RequestType.PhalanxIDMinusPopUp.ToString();
            PhalanxID id = this.selectedDetails.GetPhalanxID();
            IList<UnitID> vals = this.selectedDetails.GetUnitIDs();
            int maxRows = (int)((vals.Count + 1) / 2f);
            return UnitIDMinusPopUpImpl.Builder.Get()
                .SetPhalanxID(id)
                .SetUnitIDs(vals)
                .SetPanelGridSize(new Vector2(2, maxRows))
                .SetWidgetGridSpec(WidgetConstants.POP_UP_WIDGET_GRID_SPEC)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(99)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetName(widgetName)
                .SetParent(this)
                .Build();
        }

        private IPanelWidget BuildUnitIDAddPopUp()
        {
            string widgetName = RequestType.PhalanxIDAddPopUp.ToString();
            PhalanxID id = this.selectedDetails.GetPhalanxID();
            IList<IUnitDetails> unavailableDetails = this.combatantsDetails.GetUnitDetails();
            IList<UnitID> availableIDs = EnumUtils.GetEnumListWithoutFirst<UnitID>();
            foreach (IUnitDetails unavailableVal in unavailableDetails)
            {
                availableIDs.Remove(unavailableVal.GetUnitID());
            }
            int maxRows = (int)((availableIDs.Count + 1) / 2f);
            return UnitIDAddPopUpImpl.Builder.Get()
                .SetPhalanxID(id)
                .SetUnitIDs(availableIDs)
                .SetPanelGridSize(new Vector2(2, maxRows))
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
                    PhalanxDetailsPanelImpl widget = gameObject.AddComponent<PhalanxDetailsPanelImpl>();
                    widget.popUpWidget = popUpWidget;
                    this.ApplyPanelValues(widget);
                    return widget;
                }
            }
        }
    }
}