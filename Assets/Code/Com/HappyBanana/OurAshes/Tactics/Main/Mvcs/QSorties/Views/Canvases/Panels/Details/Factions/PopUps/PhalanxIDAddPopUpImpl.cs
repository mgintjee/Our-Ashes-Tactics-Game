using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Types;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Factions.PopUps
{
    /// <summary>
    /// Phalanx ID Add PopUp Impl
    /// </summary>
    public class PhalanxIDAddPopUpImpl
        : AbstractDynamicEnumPopUp<PhalanxID>
    {
        private FactionID factionID;

        protected override string DetermineButtonName(PhalanxID id)
        {
            return RequestType.FactionPhalanxIDAddSelect + ":" + factionID.ToString() + ":" + id.ToString() + ":Button";
        }

        protected override bool IsInteractable(PhalanxID id)
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
                IInternalBuilder SetPhalanxIDs(IList<PhalanxID> ids);

                IInternalBuilder SetFactionID(FactionID id);
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
                private IList<PhalanxID> phalanxIDs;
                private FactionID factionID;

                IInternalBuilder IInternalBuilder.SetPhalanxIDs(IList<PhalanxID> ids)
                {
                    this.phalanxIDs = ids;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetFactionID(FactionID id)
                {
                    this.factionID = id;
                    return this;
                }

                protected override IPanelWidget BuildScript(UnityEngine.GameObject gameObject)
                {
                    PhalanxIDAddPopUpImpl widget = gameObject.AddComponent<PhalanxIDAddPopUpImpl>();
                    widget.tEnums = phalanxIDs;
                    widget.factionID = factionID;
                    this.ApplyPanelValues(widget);
                    return widget;
                }

                /// <inheritdoc/>
                protected override void Validate(IList<string> invalidReasons)
                {
                    this.Validate(invalidReasons, phalanxIDs);
                    this.Validate(invalidReasons, factionID);
                }
            }
        }
    }
}