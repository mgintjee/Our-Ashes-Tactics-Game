using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Sizes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Weapons.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Views.Canvases.Panels.Details.Units.PopUps
{
    /// <summary>
    /// s WeaponGear ID Mod PopUp Impl
    /// </summary>
    public class WeaponGearIDModPopUpImpl
        : AbstractDynamicEnumPopUp<WeaponGearID>
    {
        private UnitID unitID;
        private int index;
        private GearSize gearSize;
        private WeaponGearID gearID;

        protected override string DetermineButtonName(WeaponGearID tEnum)
        {
            return RequestType.UnitWeaponGearIDSelect + ":" + unitID.ToString() + ":" + index + ":" + tEnum.ToString() + ":Button";
        }

        protected override bool IsInteractable(WeaponGearID tEnum)
        {
            return gearID != tEnum;
        }

        protected override string DeterimineButtonText(WeaponGearID tEnum)
        {
            return tEnum.ToString() + gearSize.GetAbbr();
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
                IInternalBuilder SetGearIDs(IList<WeaponGearID> ids);

                IInternalBuilder SetUnitID(UnitID id);

                IInternalBuilder SetIndex(int index);

                IInternalBuilder SetGearSize(GearSize gearSize);

                IInternalBuilder SetGearID(WeaponGearID id);
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
                private GearSize gearSize;
                private IList<WeaponGearID> gearIDs;
                private UnitID unitID;
                private int index;
                private WeaponGearID gearID;

                IInternalBuilder IInternalBuilder.SetIndex(int index)
                {
                    this.index = index;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetGearIDs(IList<WeaponGearID> ids)
                {
                    this.gearIDs = ids;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetUnitID(UnitID id)
                {
                    this.unitID = id;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetGearSize(GearSize gearSize)
                {
                    this.gearSize = gearSize;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetGearID(WeaponGearID gearID)
                {
                    this.gearID = gearID;
                    return this;
                }

                protected override IPanelWidget BuildScript(UnityEngine.GameObject gameObject)
                {
                    WeaponGearIDModPopUpImpl widget = gameObject.AddComponent<WeaponGearIDModPopUpImpl>();
                    widget.tEnums = gearIDs;
                    widget.unitID = unitID;
                    widget.index = index;
                    widget.gearSize = gearSize;
                    widget.gearID = gearID;
                    this.ApplyPanelValues(widget);
                    return widget;
                }

                /// <inheritdoc/>
                protected override void Validate(IList<string> invalidReasons)
                {
                    this.Validate(invalidReasons, gearIDs);
                    this.Validate(invalidReasons, unitID);
                    this.Validate(invalidReasons, gearID);
                }
            }
        }
    }
}