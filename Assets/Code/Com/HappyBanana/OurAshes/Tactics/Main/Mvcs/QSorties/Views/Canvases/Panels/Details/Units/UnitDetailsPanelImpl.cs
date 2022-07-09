using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Armors.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Cabins.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Engines.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Sizes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Weapons.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Attrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Attrs.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Attrs.Mountables.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Models;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Utils;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Phalanxes.PopUps;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Units.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Units.PopUps;
using System.Collections.Generic;
using System.Numerics;

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
        private IButtonPanelWidget weaponModButton;
        private IButtonPanelWidget weaponMinusButton;
        private IButtonPanelWidget statsButton;
        private IUnitDetails selectedDetails;
        private ICombatantsDetails combatantsDetails;

        public override void Process(IMvcModelState modelState)
        {
            QSorties.Models.States.Inters.IMvcModelState mvcModelState = (QSorties.Models.States.Inters.IMvcModelState)modelState;
            this.combatantsDetails = mvcModelState.GetCombatantsDetails();
            UnitID id = mvcModelState.GetSelectedUnitID();
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
                this.BuildModelText(),
                this.BuildArmorText(),
                this.BuildEngineText(),
                this.BuildCabinText(),
                this.BuildWeaponHeaderText(),
                this.BuildWeaponListText()
            };
        }

        private IList<ICanvasWidget> BuildButtons()
        {
            return new List<ICanvasWidget>() {
                this.BuildAndSetIDButton(),
                this.BuildAndSetModelButton(),
                this.BuildAndSetArmorButton(),
                this.BuildAndSetEngineButton(),
                this.BuildAndSetCabinButton(),
                this.BuildAndSetWeaponModButton(),
                this.BuildAndSetStatsButton()
            };
        }

        private void ProcessPrevRequest(IQSortieMenuMvcRequest mvcRequest)
        {
            RequestType requestType = mvcRequest.GetRequestType();
            switch (requestType)
            {
                case RequestType.UnitIDPopUp:
                    this.popUpWidget.UpdatePopupEntry(this.BuildUnitIDPopUp());
                    break;

                case RequestType.UnitModelIDPopUp:
                    this.popUpWidget.UpdatePopupEntry(this.BuildModelIDPopUp());
                    break;

                case RequestType.UnitArmorGearIDPopUp:
                    this.popUpWidget.UpdatePopupEntry(this.BuildArmorGearIDPopUp());
                    break;

                case RequestType.UnitCabinGearIDPopUp:
                    this.popUpWidget.UpdatePopupEntry(this.BuildCabinGearIDPopUp());
                    break;

                case RequestType.UnitEngineGearIDPopUp:
                    this.popUpWidget.UpdatePopupEntry(this.BuildEngineGearIDPopUp());
                    break;

                case RequestType.UnitWeaponGearIDModPopUp:
                    this.popUpWidget.UpdatePopupEntry(this.BuildWeaponGearIDModPopUp());
                    break;

                case RequestType.PopUpDisable:
                case RequestType.UnitIDSelect:
                case RequestType.UnitModelIDSelect:
                case RequestType.UnitArmorGearIDSelect:
                case RequestType.UnitCabinGearIDSelect:
                case RequestType.UnitEngineGearIDSelect:
                case RequestType.UnitWeaponGearIDModSelect:
                    CanvasWidgetUtils.EnableWidget(popUpWidget, false);
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

            UpdateLoadoutWidgets(this.selectedDetails.GetLoadoutDetails());
        }

        private void UpdateLoadoutWidgets(ILoadoutDetails loadoutDetails)
        {
            IUnitAttributes unitAttributes = ModelAttributesManager.GetUnitAttributes(selectedDetails.GetModelID()).GetValue();
            IMountableAttributes mountableAttributes = unitAttributes.GetMountableAttributes();
            this.armorButton.GetTextWidget().SetText(loadoutDetails
                .GetArmorGearID().ToString() + mountableAttributes.GetArmorGearSize().GetAbbr());

            this.cabinButton.GetTextWidget().SetText(loadoutDetails
                .GetCabinGearID().ToString() + mountableAttributes.GetCabinGearSize().GetAbbr());

            this.engineButton.GetTextWidget().SetText(loadoutDetails
                .GetEngineGearID().ToString() + mountableAttributes.GetEngineGearSize().GetAbbr());

            IList<WeaponGearID> ids = loadoutDetails.GetWeaponGearIDs();
            IList<GearSize> gearSizes = ModelAttributesManager.GetUnitAttributes(selectedDetails.GetModelID())
                .GetValue().GetMountableAttributes().GetWeaponGearSizes();
            string weaponString = "[";
            for(int i = 0; i < gearSizes.Count; ++i)
            {
                WeaponGearID gearID = ids[i];
                GearSize gearSize = gearSizes[i];
                weaponString += gearID.ToString() + gearSize.GetAbbr();
                if(i < gearSizes.Count - 1)
                {
                    weaponString += ", ";
                }
            }
            weaponString += "]";
            this.weaponIDList.GetTextWidget(0).GetValue().SetText(weaponString);
        }

        private IButtonPanelWidget BuildAndSetIDButton()
        {
            string textName = RequestType.UnitIDPopUp + ":Button";
            idButton = this.BuildButton(textName, IDsConstants.BUTTON_SPEC, "null");
            return idButton;
        }

        private IButtonPanelWidget BuildAndSetModelButton()
        {
            string textName = RequestType.UnitModelIDPopUp + ":Button";
            modelButton = this.BuildButton(textName, ModelsConstants.BUTTON_SPEC, "null");
            return modelButton;
        }

        private IButtonPanelWidget BuildAndSetArmorButton()
        {
            string textName = RequestType.UnitArmorGearIDPopUp + ":Button";
            armorButton = this.BuildButton(textName, ArmorsConstants.BUTTON_SPEC, "null");
            return armorButton;
        }

        private IButtonPanelWidget BuildAndSetEngineButton()
        {
            string textName = RequestType.UnitEngineGearIDPopUp + ":Button";
            engineButton = this.BuildButton(textName, EnginesConstants.BUTTON_SPEC, "null");
            return engineButton;
        }

        private IButtonPanelWidget BuildAndSetCabinButton()
        {
            string textName = RequestType.UnitCabinGearIDPopUp + ":Button";
            cabinButton = this.BuildButton(textName, CabinsConstants.BUTTON_SPEC, "null");
            return cabinButton;
        }

        private IButtonPanelWidget BuildAndSetWeaponModButton()
        {
            string textName = RequestType.UnitWeaponGearIDModPopUp + ":Button";
            weaponModButton = this.BuildButton(textName, WeaponsConstants.MOD_BUTTON_SPEC, "Mod");
            return weaponModButton;
        }

        private IButtonPanelWidget BuildAndSetStatsButton()
        {
            string textName = typeof(UnitID).Name + "StatsPopUp:Button";
            statsButton = this.BuildButton(textName, StatsConstants.BUTTON_SPEC, "Stats");
            return statsButton;
        }

        private IMultiTextPanelWidget BuildModelText()
        {
            string textName = typeof(ModelID).Name + ":Text";
            return this.BuildMultiText(textName, ModelsConstants.TEXT_SPEC,
                ModelsConstants.TEXT_TIWS, false);
        }

        private IMultiTextPanelWidget BuildIDText()
        {
            string textName = typeof(UnitID).Name + ":Text";
            return this.BuildMultiText(textName, IDsConstants.TEXT_SPEC,
                IDsConstants.TEXT_TIWS, false);
        }

        private IMultiTextPanelWidget BuildEngineText()
        {
            string textName = typeof(EngineGearID).Name + ":Text";
            return this.BuildMultiText(textName, EnginesConstants.TEXT_SPEC,
                EnginesConstants.TEXT_TIWS, false);
        }

        private IMultiTextPanelWidget BuildArmorText()
        {
            string textName = typeof(ArmorGearID).Name + ":Text";
            return this.BuildMultiText(textName, ArmorsConstants.TEXT_SPEC,
                ArmorsConstants.TEXT_TIWS, false);
        }

        private IMultiTextPanelWidget BuildCabinText()
        {
            string textName = typeof(CabinGearID).Name + ":Text";
            return this.BuildMultiText(textName, CabinsConstants.TEXT_SPEC,
                CabinsConstants.TEXT_TIWS, false);
        }

        private IMultiTextPanelWidget BuildWeaponHeaderText()
        {
            string textName = typeof(WeaponGearID).Name + ":Text";
            return this.BuildMultiText(textName, WeaponsConstants.TEXT_SPEC,
                WeaponsConstants.TEXT_TIWS, false);
        }

        private IMultiTextPanelWidget BuildWeaponListText()
        {
            string textName = typeof(WeaponGearID).Name + "List:Text";
            this.weaponIDList = this.BuildMultiText(textName, WeaponsConstants.LIST_SPEC,
                WeaponsConstants.LIST_TIWS, false);
            return this.weaponIDList;
        }

        private IPanelWidget BuildUnitIDPopUp()
        {
            UnitID id = this.selectedDetails.GetUnitID();
            IList<UnitID> ids = new List<UnitID>();
            foreach (IUnitDetails details in this.combatantsDetails.GetUnitDetails())
            {
                ids.Add(details.GetUnitID());
            }
            return UnitIDPopUpImpl.Builder.Get()
                .SetUnitID(id)
                .SetUnitIDs(ids)
                .SetPanelGridSize(GetIDPopUpGridSize(ids.Count))
                .SetWidgetGridSpec(WidgetConstants.POP_UP_WIDGET_GRID_SPEC)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(99)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetName(RequestType.UnitIDPopUp.ToString())
                .SetParent(this)
                .Build();
        }

        private IPanelWidget BuildModelIDPopUp()
        {
            ModelID id = this.selectedDetails.GetModelID();
            IList<ModelID> ids = EnumUtils.GetEnumListWithoutFirst<ModelID>();
            return ModelIDPopUpImpl.Builder.Get()
                .SetModelID(id)
                .SetModelIDs(ids)
                .SetPanelGridSize(GetIDPopUpGridSize(ids.Count))
                .SetWidgetGridSpec(WidgetConstants.POP_UP_WIDGET_GRID_SPEC)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(99)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetName(RequestType.UnitModelIDPopUp.ToString())
                .SetParent(this)
                .Build();
        }

        private IPanelWidget BuildArmorGearIDPopUp()
        {
            ArmorGearID id = this.selectedDetails.GetLoadoutDetails().GetArmorGearID();
            ModelID modelID = this.selectedDetails.GetModelID();
            IList<ArmorGearID> ids = UnitGearIDConstants.Armors.GetGearIDs(modelID);
            return ArmorGearIDPopUpImpl.Builder.Get()
                .SetArmorGearID(id)
                .SetArmorGearIDs(ids)
                .SetPanelGridSize(GetIDPopUpGridSize(ids.Count))
                .SetWidgetGridSpec(WidgetConstants.POP_UP_WIDGET_GRID_SPEC)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(99)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetName(RequestType.UnitArmorGearIDPopUp.ToString())
                .SetParent(this)
                .Build();
        }

        private IPanelWidget BuildEngineGearIDPopUp()
        {
            EngineGearID id = this.selectedDetails.GetLoadoutDetails().GetEngineGearID();
            ModelID modelID = this.selectedDetails.GetModelID();
            IList<EngineGearID> ids = UnitGearIDConstants.Engines.GetGearIDs(modelID);
            return EngineGearIDPopUpImpl.Builder.Get()
                .SetEngineGearID(id)
                .SetEngineGearIDs(ids)
                .SetPanelGridSize(GetIDPopUpGridSize(ids.Count))
                .SetWidgetGridSpec(WidgetConstants.POP_UP_WIDGET_GRID_SPEC)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(99)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetName(RequestType.UnitEngineGearIDPopUp.ToString())
                .SetParent(this)
                .Build();
        }

        private IPanelWidget BuildCabinGearIDPopUp()
        {
            CabinGearID id = this.selectedDetails.GetLoadoutDetails().GetCabinGearID();
            ModelID modelID = this.selectedDetails.GetModelID();
            IList<CabinGearID> ids = UnitGearIDConstants.Cabins.GetGearIDs(modelID);
            return CabinGearIDPopUpImpl.Builder.Get()
                .SetCabinGearID(id)
                .SetCabinGearIDs(ids)
                .SetPanelGridSize(GetIDPopUpGridSize(ids.Count))
                .SetWidgetGridSpec(WidgetConstants.POP_UP_WIDGET_GRID_SPEC)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(99)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetName(RequestType.UnitCabinGearIDPopUp.ToString())
                .SetParent(this)
                .Build();
        }


        private IPanelWidget BuildWeaponGearIDModPopUp()
        {
            int x = this.selectedDetails.GetLoadoutDetails().GetWeaponGearIDs().Count;
            return WeaponGearIDModPopUpImpl.Builder.Get()
                .SetUnitDetails(this.selectedDetails)
                .SetPanelGridSize(new Vector2(x, 1))
                .SetWidgetGridSpec(WidgetConstants.POP_UP_WIDGET_GRID_SPEC)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(99)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetName(RequestType.UnitWeaponGearIDModPopUp.ToString())
                .SetParent(this)
                .Build();
        }

        private Vector2 GetIDPopUpGridSize(int idCount)
        {
            int rows = (idCount > 6) ? 6 : idCount;
            int cols = (rows == 6) ? 1 + (idCount / rows) : 1;
            logger.Debug("ID count: {}, rows: {}, cols: {}", idCount, rows, cols);
            return new Vector2(cols, rows);
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