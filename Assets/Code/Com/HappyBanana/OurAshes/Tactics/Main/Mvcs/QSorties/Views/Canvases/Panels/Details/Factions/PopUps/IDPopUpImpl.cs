using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Factions.PopUps
{
    /// <summary>
    /// Faction ID PopUp Impl
    /// </summary>
    public class IDPopUpImpl
        : AbstractStaticEnumPopUp<FactionID>
    {
        private ICombatantsDetails details;

        protected override bool IsButtonInteractable(FactionID tEnum)
        {
            return tEnum != details.GetFactionDetails()[0].GetFactionID();
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
                IInternalBuilder SetDetails(ICombatantsDetails details);
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
                private ICombatantsDetails details;

                IInternalBuilder IInternalBuilder.SetDetails(ICombatantsDetails details)
                {
                    this.details = details;
                    return this;
                }

                protected override IPanelWidget BuildScript(UnityEngine.GameObject gameObject)
                {
                    IDPopUpImpl widget = gameObject.AddComponent<IDPopUpImpl>();
                    widget.details = details;
                    this.ApplyPanelValues(widget);
                    return widget;
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, details);
                }
            }
        }
    }
}