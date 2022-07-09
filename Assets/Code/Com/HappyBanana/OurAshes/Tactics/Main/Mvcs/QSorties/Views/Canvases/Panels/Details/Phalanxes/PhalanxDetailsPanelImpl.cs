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
        private IButtonPanelWidget unitAddButton;
        private IButtonPanelWidget unitMinusButton;
        private IMultiTextPanelWidget unitIDList;
        private IPhalanxDetails selectedDetails;
        private ICombatantsDetails combatantsDetails;
        private IFieldDetails fieldDetails;

        public override void Process(IMvcModelState modelState)
        {
            Models.States.Inters.IMvcModelState mvcModelState = (Models.States.Inters.IMvcModelState)modelState;
            this.combatantsDetails = mvcModelState.GetCombatantsDetails();
            this.fieldDetails = mvcModelState.GetFieldDetails();
            PhalanxID id = mvcModelState.GetSelectedPhalanxID();
            this.selectedDetails = this.combatantsDetails.GetDetails(id).GetValue();
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

        private IList<ICanvasWidget> BuildTexts()
        {
            return new List<ICanvasWidget>
            {
                this.BuildIDText(),
                this.BuildIconText(),
                this.BuildUnitsText(),
                this.BuildAndSetUnitsListText()
            };
        }

        private IList<ICanvasWidget> BuildButtons()
        {
            return new List<ICanvasWidget>() {
                this.BuildAndSetIDButton(),
                this.BuildAndSetUnitsMinusButton(),
                this.BuildAndSetUnitsAddButton()
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

                case RequestType.PhalanxUnitIDMinusPopUp:
                    this.popUpWidget.UpdatePopupEntry(this.BuildUnitIDMinusPopUp());
                    break;

                case RequestType.PhalanxUnitIDAddPopUp:
                    this.popUpWidget.UpdatePopupEntry(this.BuildUnitIDAddPopUp());
                    break;

                case RequestType.PopUpDisable:
                case RequestType.PhalanxIDSelect:
                case RequestType.PhalanxUnitIDMinusSelect:
                case RequestType.PhalanxUnitIDAddSelect:
                    CanvasWidgetUtils.EnableWidget(popUpWidget, false);
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
            IWidgetGridSpec widgetGridSpec = IDsConstants.BUTTON_SPEC;
            string textName = RequestType.PhalanxIDPopUp + ":Button";
            idButton = this.BuildButton(textName, widgetGridSpec, "null");
            return idButton;
        }

        private IButtonPanelWidget BuildAndSetUnitsMinusButton()
        {
            IWidgetGridSpec widgetGridSpec = UnitsConstants.MINUS_BUTTON_SPEC;
            string textName = RequestType.PhalanxUnitIDMinusPopUp + "PopUp:Button";
            unitMinusButton = this.BuildButton(textName, widgetGridSpec, "-");
            return unitMinusButton;
        }

        private IButtonPanelWidget BuildAndSetUnitsAddButton()
        {
            IWidgetGridSpec widgetGridSpec = UnitsConstants.ADD_BUTTON_SPEC;
            string textName = RequestType.PhalanxUnitIDAddPopUp + "PopUp:Button";
            unitAddButton = this.BuildButton(textName, widgetGridSpec, "+");
            return unitAddButton;
        }

        private IMultiTextPanelWidget BuildIconText()
        {
            IWidgetGridSpec widgetGridSpec = IconsConstants.TEXT_SPEC;
            IList<TextImageWidgetStruct> textImageWidgetStructs = IconsConstants.TEXT_TIWS;
            string textName = typeof(IconID).Name + ":Text";
            return this.BuildMultiText(textName, widgetGridSpec, textImageWidgetStructs, false);
        }

        private IMultiTextPanelWidget BuildIDText()
        {
            IWidgetGridSpec widgetGridSpec = IDsConstants.TEXT_SPEC;
            IList<TextImageWidgetStruct> textImageWidgetStructs = IDsConstants.TEXT_TIWS;
            string textName = typeof(PhalanxID).Name + ":Text";
            return this.BuildMultiText(textName, widgetGridSpec, textImageWidgetStructs, false);
        }

        private IMultiTextPanelWidget BuildUnitsText()
        {
            IWidgetGridSpec widgetGridSpec = UnitsConstants.TEXT_SPEC;
            IList<TextImageWidgetStruct> textImageWidgetStructs = UnitsConstants.TEXT_TIWS;
            string textName = typeof(UnitID).Name + ":Text";
            return this.BuildMultiText(textName, widgetGridSpec, textImageWidgetStructs, false);
        }

        private IMultiTextPanelWidget BuildAndSetUnitsListText()
        {
            IWidgetGridSpec widgetGridSpec = UnitsConstants.LIST_SPEC;
            IList<TextImageWidgetStruct> textImageWidgetStructs = UnitsConstants.LIST_TIWS;
            string textName = typeof(UnitID).Name + "List:Text";
            this.unitIDList = this.BuildMultiText(textName, widgetGridSpec, textImageWidgetStructs, false);
            return this.unitIDList;
        }

        private IPanelWidget BuildIDPopUp()
        {
            IList<PhalanxID> ids = new List<PhalanxID>();
            foreach (IPhalanxDetails phalanxDetails in this.combatantsDetails.GetPhalanxDetails())
            {
                ids.Add(phalanxDetails.GetPhalanxID());
            }
            return IDPopUpImpl.Builder.Get()
                .SetPhalanxID(this.selectedDetails.GetPhalanxID())
                .SetPhalanxIDs(ids)
                .SetPanelGridSize(new Vector2(1, ids.Count))
                .SetWidgetGridSpec(WidgetConstants.POP_UP_WIDGET_GRID_SPEC)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(99)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetName(RequestType.PhalanxIDPopUp.ToString())
                .SetParent(this)
                .Build();
        }

        private IPanelWidget BuildUnitIDMinusPopUp()
        {
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
                .SetName(RequestType.FactionPhalanxIDMinusPopUp.ToString())
                .SetParent(this)
                .Build();
        }

        private IPanelWidget BuildUnitIDAddPopUp()
        {
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
                .SetName(RequestType.FactionPhalanxIDAddPopUp.ToString())
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