using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Factions.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Factions.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Phalanxes.PopUps
{
    /// <summary>
    /// Faction ID PopUp Impl
    /// </summary>
    public class IDPopUpImpl
        : AbstractStaticEnumPopUp<PhalanxID>
    {
        private IList<IPhalanxDetails> details;

        protected override bool IsButtonInteractable(PhalanxID tEnum)
        {
            return tEnum != details[0].GetID();
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
                IInternalBuilder SetPhalanxDetails(IList<IPhalanxDetails> details);
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
                private IList<IPhalanxDetails> details = new List<IPhalanxDetails>();

                IInternalBuilder IInternalBuilder.SetPhalanxDetails(IList<IPhalanxDetails> details)
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