using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Weapons.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Types;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Phalanxes.PopUps
{
    /// <summary>s
    /// WeaponGear ID Mod PopUp Entry
    /// </summary>
    public class WeaponGearIDModPopUpEntry
        : AbstractDynamicEnumPopUp<WeaponGearID>
    {
        private UnitID id;
        private int index;

        protected override string DetermineButtonName(WeaponGearID tEnum)
        {
            return RequestType.UnitWeaponGearIDModSelect + ":" + id.ToString() + ":" + index + ":" + tEnum.ToString() + ":Button";
        }

        protected override bool IsInteractable(WeaponGearID tEnum)
        {
            return true;
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
                IInternalBuilder SetWeaponGearIDs(IList<WeaponGearID> ids);

                IInternalBuilder SetUnitID(UnitID id);
                IInternalBuilder SetIndex(int index);
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
                private IList<WeaponGearID> gearIDs;
                private UnitID id;
                private int index;

                IInternalBuilder IInternalBuilder.SetIndex(int index)
                {
                    this.index = index;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetWeaponGearIDs(IList<WeaponGearID> ids)
                {
                    this.gearIDs = ids;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetUnitID(UnitID id)
                {
                    this.id = id;
                    return this;
                }

                protected override IPanelWidget BuildScript(UnityEngine.GameObject gameObject)
                {
                    WeaponGearIDModPopUpEntry widget = gameObject.AddComponent<WeaponGearIDModPopUpEntry>();
                    widget.tEnums = gearIDs;
                    widget.id = id;
                    widget.index = index;
                    this.ApplyPanelValues(widget);
                    return widget;
                }

                /// <inheritdoc/>
                protected override void Validate(IList<string> invalidReasons)
                {
                    this.Validate(invalidReasons, gearIDs);
                    this.Validate(invalidReasons, id);
                }
            }
        }
    }
}