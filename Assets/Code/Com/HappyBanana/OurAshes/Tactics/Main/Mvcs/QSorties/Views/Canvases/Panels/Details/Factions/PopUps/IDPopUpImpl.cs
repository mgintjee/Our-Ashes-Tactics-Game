using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Factions.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Factions.IDs;
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
        private IList<IFactionDetails> details;

        protected override bool IsButtonInteractable(FactionID tEnum)
        {
            return tEnum != details[0].GetFactionID();
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
                IInternalBuilder SetFactionDetails(IList<IFactionDetails> details);
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
                private IList<IFactionDetails> details = new List<IFactionDetails>();

                IInternalBuilder IInternalBuilder.SetFactionDetails(IList<IFactionDetails> details)
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
            }
        }
    }
}