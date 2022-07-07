using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Armors.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Cabins.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Engines.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Weapons.Gears.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Weapons.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Models;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Structs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Units.Constants;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Units
{
    /// <summary>
    /// Panel Widget Impl
    /// </summary>
    public class UnitDetailsPanelImpl
        : AbstractPanelWidget, IPanelWidget
    {
        private IPopUpPanelWidget popUpWidget;
        private IMultiTextPanelWidget weaponIDList;
        private IMultiTextPanelWidget powerText;
        private IButtonPanelWidget idButton;
        private IButtonPanelWidget modelButton;
        private IButtonPanelWidget armorButton;
        private IButtonPanelWidget cabinButton;
        private IButtonPanelWidget engineButton;
        private IButtonPanelWidget weaponAddButton;
        private IButtonPanelWidget weaponMinusButton;
        private IButtonPanelWidget statsButton;
        private IUnitDetails selectedDetails;
        private ICombatantsDetails combatantsDetails;

        public override void Process(IMvcModelState modelState)
        {
            Models.States.Inters.IMvcModelState mvcModelState = (Models.States.Inters.IMvcModelState)modelState;
            this.combatantsDetails = mvcModelState.GetCombatantsDetails();
            this.selectedDetails = this.combatantsDetails.GetUnitDetails()[0];
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
                this.BuildArmorText(),
                this.BuildEngineText(),
                this.BuildCabinText(),
                this.BuildWeaponHeaderText(),
                this.BuildWeaponListText(),
                this.BuildPowersText()
            };
        }

        private ISet<ICanvasWidget> BuildButtons()
        {
            return new HashSet<ICanvasWidget>() {
                this.BuildAndSetIDButton(),
                this.BuildAndSetModelButton(),
                this.BuildAndSetArmorButton(),
                this.BuildAndSetEngineButton(),
                this.BuildAndSetCabinButton(),
                this.BuildAndSetMinusButton(),
                this.BuildAndSetAddButton(),
                this.BuildAndSetStatsButton()
            };
        }

        private void ProcessPrevRequest(IQSortieMenuMvcRequest mvcRequest)
        {
            RequestType requestType = mvcRequest.GetRequestType();
            switch (requestType)
            {
                case RequestType.PhalanxIDPopUp:
                    break;

                case RequestType.UnitIDMinusPopUp:
                    break;

                case RequestType.UnitIDAddPopUp:
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
            this.idButton.GetTextWidget().SetText(this.selectedDetails.GetUnitID().ToString());

            this.modelButton.GetTextWidget().SetText(this.selectedDetails.GetModelID().ToString());

            this.cabinButton.GetTextWidget().SetText(this.selectedDetails.GetLoadoutDetails()
                .GetEngineGearDetails().GetGearID().ToString());

            this.armorButton.GetTextWidget().SetText(this.selectedDetails.GetLoadoutDetails()
                .GetArmorGearDetails().GetGearID().ToString());

            this.cabinButton.GetTextWidget().SetText(this.selectedDetails.GetLoadoutDetails()
                .GetCabinGearDetails().GetCabinGearID().ToString());

            IList<IWeaponGearDetails> weaponGearDetails = this.selectedDetails.GetLoadoutDetails().GetWeaponGearDetails();
            IList<WeaponGearID> ids = new List<WeaponGearID>();
            foreach (IWeaponGearDetails details in weaponGearDetails)
            {
                ids.Add(details.GetWeaponGearID());
            }
            string idsString = "[" + string.Join(", ", ids) + "]";
            this.weaponIDList.GetTextWidget(0).GetValue().SetText(idsString);
        }

        private IButtonPanelWidget BuildAndSetIDButton()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.IDs.BUTTON_COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            string buttonType = typeof(UnitID).Name;
            string textName = this.mvcType + ":" + buttonType + "PopUp:Button";
            string buttonText = UnitID.None.ToString();
            idButton = this.BuildButton(textName, widgetGridSpec, buttonText, buttonType);
            return idButton;
        }

        private IButtonPanelWidget BuildAndSetModelButton()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.Models.BUTTON_COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            string buttonType = typeof(ModelID).Name;
            string textName = this.mvcType + ":" + buttonType + "PopUp:Button";
            string buttonText = ModelID.None.ToString();
            modelButton = this.BuildButton(textName, widgetGridSpec, buttonText, buttonType);
            return modelButton;
        }

        private IButtonPanelWidget BuildAndSetArmorButton()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.Armors.BUTTON_COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            string buttonType = typeof(ArmorGearID).Name;
            string textName = this.mvcType + ":" + buttonType + "PopUp:Button";
            string buttonText = ArmorGearID.None.ToString();
            armorButton = this.BuildButton(textName, widgetGridSpec, buttonText, buttonType);
            return armorButton;
        }

        private IButtonPanelWidget BuildAndSetEngineButton()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.Engines.BUTTON_COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            string buttonType = typeof(EngineGearID).Name;
            string textName = this.mvcType + ":" + buttonType + "PopUp:Button";
            string buttonText = EngineGearID.None.ToString();
            cabinButton = this.BuildButton(textName, widgetGridSpec, buttonText, buttonType);
            return cabinButton;
        }

        private IButtonPanelWidget BuildAndSetCabinButton()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.Cabins.BUTTON_COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            string buttonType = typeof(EngineGearID).Name;
            string textName = this.mvcType + ":" + buttonType + "PopUp:Button";
            string buttonText = CabinGearID.None.ToString();
            cabinButton = this.BuildButton(textName, widgetGridSpec, buttonText, buttonType);
            return cabinButton;
        }

        private IButtonPanelWidget BuildAndSetMinusButton()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.WeaponHeader.MINUS_BUTTON_COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            string buttonType = typeof(WeaponGearID).Name + ":Minus";
            string textName = this.mvcType + ":" + buttonType + "PopUp:Button";
            string buttonText = "-";
            weaponMinusButton = this.BuildButton(textName, widgetGridSpec, buttonText, buttonType);
            return weaponMinusButton;
        }

        private IButtonPanelWidget BuildAndSetAddButton()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.WeaponHeader.ADD_BUTTON_COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            string buttonType = typeof(WeaponGearID).Name + ":Add";
            string textName = this.mvcType + ":" + buttonType + "PopUp:Button";
            string buttonText = "+";
            weaponAddButton = this.BuildButton(textName, widgetGridSpec, buttonText, buttonType);
            return weaponAddButton;
        }

        private IButtonPanelWidget BuildAndSetStatsButton()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.Stats.COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            string buttonType = typeof(UnitID).Name + ":Stats";
            string textName = this.mvcType + ":" + buttonType + "PopUp:Button";
            string buttonText = "Stats";
            statsButton = this.BuildButton(textName, widgetGridSpec, buttonText, buttonType);
            return statsButton;
        }

        private IMultiTextPanelWidget BuildIconText()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.Models.TEXT_COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            IList<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>
            {
                new TextImageWidgetStruct("Model:",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR)
            };
            string textName = typeof(ModelID).Name + ":Text";
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
            string textName = typeof(UnitID).Name + ":Text";
            return this.BuildMultiText(textName, widgetGridSpec, textImageWidgetStructs, false);
        }

        private IMultiTextPanelWidget BuildEngineText()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.Engines.TEXT_COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            IList<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>
            {
                new TextImageWidgetStruct("Engine:",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR)
            };
            string textName = typeof(EngineGearID).Name + ":Text";
            return this.BuildMultiText(textName, widgetGridSpec, textImageWidgetStructs, false);
        }

        private IMultiTextPanelWidget BuildArmorText()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.Armors.TEXT_COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            IList<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>
            {
                new TextImageWidgetStruct("Armor:",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR)
            };
            string textName = typeof(ArmorGearID).Name + ":Text";
            return this.BuildMultiText(textName, widgetGridSpec, textImageWidgetStructs, false);
        }

        private IMultiTextPanelWidget BuildCabinText()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.Cabins.TEXT_COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            IList<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>
            {
                new TextImageWidgetStruct("Cabin:",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR)
            };
            string textName = typeof(CabinGearID).Name + ":Text";
            return this.BuildMultiText(textName, widgetGridSpec, textImageWidgetStructs, false);
        }

        private IMultiTextPanelWidget BuildWeaponHeaderText()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.WeaponHeader.TEXT_COORDS)
                    .SetCanvasGridSize(PanelConstants.WeaponHeader.TEXT_SIZE);
            IList<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>
            {
                new TextImageWidgetStruct("Weapons:",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR)
            };
            string textName = typeof(WeaponGearID).Name + ":Text";
            return this.BuildMultiText(textName, widgetGridSpec, textImageWidgetStructs, false);
        }

        private IMultiTextPanelWidget BuildWeaponListText()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.WeaponList.COORDS)
                    .SetCanvasGridSize(PanelConstants.WeaponList.SIZE);
            IList<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>
            {
                new TextImageWidgetStruct("[null]",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR)
            };
            string textName = typeof(WeaponGearID).Name + "List:Text";
            this.weaponIDList = this.BuildMultiText(textName, widgetGridSpec, textImageWidgetStructs, false);
            return this.weaponIDList;
        }

        private IMultiTextPanelWidget BuildPowersText()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.Powers.COORDS)
                    .SetCanvasGridSize(PanelConstants.Powers.SIZE);
            IList<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>
            {
                new TextImageWidgetStruct("Unit Power:",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR),
                new TextImageWidgetStruct("0",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR)
            };
            string textName = typeof(UnitID).Name + ":Power:Text";
            return this.BuildMultiText(textName, widgetGridSpec, textImageWidgetStructs, false);
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
                    UnitDetailsPanelImpl widget = gameObject.AddComponent<UnitDetailsPanelImpl>();
                    widget.popUpWidget = this.popUpWidget;
                    this.ApplyPanelValues(widget);
                    return widget;
                }
            }
        }
    }
}