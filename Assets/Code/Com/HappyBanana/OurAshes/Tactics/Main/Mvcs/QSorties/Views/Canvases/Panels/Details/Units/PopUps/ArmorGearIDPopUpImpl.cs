using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Armors.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Units.PopUps
{
    /// <summary>
    /// ArmorGear ID PopUp Impl
    /// </summary>
    public class ArmorGearIDPopUpImpl
        : AbstractDynamicEnumPopUp<ArmorGearID>
    {
        private ArmorGearID id;

        protected override string DetermineButtonName(ArmorGearID tEnum)
        {
            return "Unit" + typeof(ArmorGearID).Name + "Select:" + tEnum.ToString() + ":Button";
        }

        protected override bool IsInteractable(ArmorGearID tEnum)
        {
            return tEnum != id;
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
                IInternalBuilder SetArmorGearIDs(IList<ArmorGearID> ids);

                IInternalBuilder SetArmorGearID(ArmorGearID id);
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
                private IList<ArmorGearID> ids;
                private ArmorGearID id;

                IInternalBuilder IInternalBuilder.SetArmorGearIDs(IList<ArmorGearID> ids)
                {
                    this.ids = ids;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetArmorGearID(ArmorGearID id)
                {
                    this.id = id;
                    return this;
                }

                protected override IPanelWidget BuildScript(UnityEngine.GameObject gameObject)
                {
                    ArmorGearIDPopUpImpl widget = gameObject.AddComponent<ArmorGearIDPopUpImpl>();
                    widget.tEnums = ids;
                    widget.id = id;
                    this.ApplyPanelValues(widget);
                    return widget;
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, ids);
                }
            }
        }
    }
}