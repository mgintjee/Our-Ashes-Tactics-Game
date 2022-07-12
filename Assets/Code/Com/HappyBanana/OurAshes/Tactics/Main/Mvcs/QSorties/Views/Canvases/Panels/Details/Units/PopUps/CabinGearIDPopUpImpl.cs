using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Cabins.Gears.Attrs.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Cabins.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Sizes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Units.PopUps
{
    /// <summary>
    /// CabinGear ID PopUp Impl
    /// </summary>
    public class CabinGearIDPopUpImpl
        : AbstractDynamicEnumPopUp<CabinGearID>
    {
        private CabinGearID id;
        private GearSize gearSize;

        protected override string DetermineButtonName(CabinGearID tEnum)
        {
            return "Unit" + typeof(CabinGearID).Name + "Select:" + tEnum.ToString() + ":Button";
        }

        protected override bool IsInteractable(CabinGearID tEnum)
        {
            return tEnum != id;
        }
        protected override string DeterimineButtonText(CabinGearID tEnum)
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
                IInternalBuilder SetCabinGearIDs(IList<CabinGearID> ids);

                IInternalBuilder SetCabinGearID(CabinGearID id);

                IInternalBuilder SetGearSize(GearSize gearSize);
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
                private IList<CabinGearID> ids;
                private CabinGearID id;

                private GearSize gearSize;

                IInternalBuilder IInternalBuilder.SetGearSize(GearSize gearSize)
                {
                    this.gearSize = gearSize;
                    return this;
                }
                IInternalBuilder IInternalBuilder.SetCabinGearIDs(IList<CabinGearID> ids)
                {
                    this.ids = ids;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetCabinGearID(CabinGearID id)
                {
                    this.id = id;
                    return this;
                }

                protected override IPanelWidget BuildScript(UnityEngine.GameObject gameObject)
                {
                    CabinGearIDPopUpImpl widget = gameObject.AddComponent<CabinGearIDPopUpImpl>();
                    widget.tEnums = ids;
                    widget.id = id;
                    widget.gearSize = gearSize;
                    this.ApplyPanelValues(widget);
                    return widget;
                }

                /// <inheritdoc/>
                protected override void Validate(IList<string> invalidReasons)
                {
                    this.Validate(invalidReasons, ids);
                }
            }
        }
    }
}