using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Engines.Gears.Attrs.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Engines.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Sizes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Units.PopUps
{
    /// <summary>
    /// EngineGear ID PopUp Impl
    /// </summary>
    public class EngineGearIDPopUpImpl
        : AbstractDynamicEnumPopUp<EngineGearID>
    {
        private EngineGearID id;
        private GearSize gearSize;

        protected override string DetermineButtonName(EngineGearID tEnum)
        {
            return "Unit" + typeof(EngineGearID).Name + "Select:" + tEnum.ToString() + ":Button";
        }

        protected override bool IsInteractable(EngineGearID tEnum)
        {
            return tEnum != id;
        }
        protected override string DeterimineButtonText(EngineGearID tEnum)
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
                IInternalBuilder SetEngineGearIDs(IList<EngineGearID> ids);

                IInternalBuilder SetEngineGearID(EngineGearID id);

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
                private IList<EngineGearID> ids;
                private EngineGearID id;
                private GearSize gearSize;

                IInternalBuilder IInternalBuilder.SetGearSize(GearSize gearSize)
                {
                    this.gearSize = gearSize;
                    return this;
                }
                IInternalBuilder IInternalBuilder.SetEngineGearIDs(IList<EngineGearID> ids)
                {
                    this.ids = ids;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetEngineGearID(EngineGearID id)
                {
                    this.id = id;
                    return this;
                }

                protected override IPanelWidget BuildScript(UnityEngine.GameObject gameObject)
                {
                    EngineGearIDPopUpImpl widget = gameObject.AddComponent<EngineGearIDPopUpImpl>();
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