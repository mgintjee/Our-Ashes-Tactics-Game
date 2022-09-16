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
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Utils;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Views.Canvases.Panels.Details.Factions
{
    /// <summary>
    /// Panel Widget Impl
    /// </summary>
    public class FactionDetailsPanelImpl
        : AbstractPanelWidget, IPanelWidget
    {
        private IPopUpPanelWidget popUpWidget;
        private IButtonWidget idButton;
        private IButtonWidget phalanxAddButton;
        private IButtonWidget phalanxMinusButton;
        private IMultiTextPanelWidget phalanxIDList;
        private IFactionDetails selectedFactionDetails;
        private ICombatantsDetails combatantsDetails;
        private IFieldDetails fieldDetails;

        public override void Process(IMvcModelState modelState)
        {
            logger.Debug("Processing {}", modelState);
            Models.States.Inters.IMvcModelState mvcModelState = (Models.States.Inters.IMvcModelState)modelState;
            this.combatantsDetails = mvcModelState.GetCombatantsDetails();
            this.fieldDetails = mvcModelState.GetFieldDetails();
            FactionID id = mvcModelState.GetSelectedFactionID();
            this.selectedFactionDetails = this.combatantsDetails.GetFactionDetails(id).GetValue();
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
                this.BuildPhalanxText(),
                this.BuildAndSetPhalanxListText()
            };
        }

        private IList<ICanvasWidget> BuildButtons()
        {
            return new List<ICanvasWidget>
            {
                this.BuildAndSetIDButton(),
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

                case RequestType.FactionPhalanxIDMinusPopUp:
                    this.popUpWidget.UpdatePopupEntry(this.BuildPhalanxIDMinusPopUp());
                    break;

                case RequestType.FactionPhalanxIDAddPopUp:
                    this.popUpWidget.UpdatePopupEntry(this.BuildPhalanxIDAddPopUp());
                    break;

                case RequestType.PopUpDisable:
                case RequestType.FactionIDSelect:
                case RequestType.FactionPhalanxIDMinusSelect:
                case RequestType.FactionPhalanxIDAddSelect:
                    CanvasWidgetUtils.EnableWidget(popUpWidget, false);
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

        private IButtonWidget BuildAndSetIDButton()
        {
            IWidgetGridSpec widgetGridSpec = IDsConstants.BUTTON_SPEC;
            string textName = RequestType.FactionIDPopUp + ":Button";
            idButton = this.BuildButton(textName, widgetGridSpec, "null");
            return idButton;
        }

        private IButtonWidget BuildAndSetPhalanxMinusButton()
        {
            IWidgetGridSpec widgetGridSpec = PhalanxesConstants.MINUS_BUTTON_SPEC;
            string textName = RequestType.FactionPhalanxIDMinusPopUp + ":Button";
            phalanxMinusButton = this.BuildButton(textName, widgetGridSpec, "-");
            return phalanxMinusButton;
        }

        private IButtonWidget BuildAndSetPhalanxAddButton()
        {
            IWidgetGridSpec widgetGridSpec = PhalanxesConstants.ADD_BUTTON_SPEC;
            string textName = RequestType.FactionPhalanxIDAddPopUp + ":Button";
            phalanxAddButton = this.BuildButton(textName, widgetGridSpec, "+");
            return phalanxAddButton;
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
            string textName = typeof(FactionID).Name + ":Text";
            return this.BuildMultiText(textName, widgetGridSpec, textImageWidgetStructs, false);
        }

        private IMultiTextPanelWidget BuildPhalanxText()
        {
            IWidgetGridSpec widgetGridSpec = PhalanxesConstants.TEXT_SPEC;
            IList<TextImageWidgetStruct> textImageWidgetStructs = PhalanxesConstants.TEXT_TIWS;
            string textName = typeof(PhalanxID).Name + ":Text";
            return this.BuildMultiText(textName, widgetGridSpec, textImageWidgetStructs, false);
        }

        private IMultiTextPanelWidget BuildAndSetPhalanxListText()
        {
            IWidgetGridSpec widgetGridSpec = PhalanxesConstants.LIST_SPEC;
            IList<TextImageWidgetStruct> textImageWidgetStructs = PhalanxesConstants.LIST_TIWS;
            string textName = typeof(PhalanxID).Name + "List:Text";
            this.phalanxIDList = this.BuildMultiText(textName, widgetGridSpec, textImageWidgetStructs, false);
            return this.phalanxIDList;
        }

        private IPanelWidget BuildIDPopUp()
        {
            IList<FactionID> ids = EnumUtils.GetEnumListWithoutFirst<FactionID>();
            return IDPopUpImpl.Builder.Get()
                .SetFactionID(this.selectedFactionDetails.GetFactionID())
                .SetPanelGridSize(new Vector2(1, ids.Count))
                .SetWidgetGridSpec(WidgetConstants.POP_UP_WIDGET_GRID_SPEC)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(99)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetName(RequestType.FactionIDPopUp.ToString())
                .SetParent(this)
                .Build();
        }

        private IPanelWidget BuildPhalanxIDMinusPopUp()
        {
            IList<PhalanxID> ids = this.selectedFactionDetails.GetPhalanxIDs();
            return PhalanxIDMinusPopUpImpl.Builder.Get()
                .SetFactionID(this.selectedFactionDetails.GetFactionID())
                .SetPhalanxIDs(ids)
                .SetPanelGridSize(new Vector2(1, ids.Count))
                .SetWidgetGridSpec(WidgetConstants.POP_UP_WIDGET_GRID_SPEC)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(99)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetName(RequestType.FactionPhalanxIDMinusPopUp.ToString())
                .SetParent(this)
                .Build();
        }

        private IPanelWidget BuildPhalanxIDAddPopUp()
        {
            IList<IPhalanxDetails> unavailableDetails = this.combatantsDetails.GetPhalanxDetails();
            IList<PhalanxID> availableIDs = EnumUtils.GetEnumListWithoutFirst<PhalanxID>();
            foreach (IPhalanxDetails unavailableID in unavailableDetails)
            {
                availableIDs.Remove(unavailableID.GetPhalanxID());
            }
            return PhalanxIDAddPopUpImpl.Builder.Get()
                .SetFactionID(this.selectedFactionDetails.GetFactionID())
                .SetPhalanxIDs(availableIDs)
                .SetPanelGridSize(new Vector2(1, availableIDs.Count))
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
                    FactionDetailsPanelImpl widget = gameObject.AddComponent<FactionDetailsPanelImpl>();
                    widget.popUpWidget = popUpWidget;
                    this.ApplyPanelValues(widget);
                    return widget;
                }
            }
        }
    }
}