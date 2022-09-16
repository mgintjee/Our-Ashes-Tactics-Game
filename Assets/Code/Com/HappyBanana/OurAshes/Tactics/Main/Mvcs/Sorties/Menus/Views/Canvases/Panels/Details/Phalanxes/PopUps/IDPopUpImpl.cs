using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Views.Canvases.Panels.Details.Phalanxes.PopUps
{
    /// <summary>
    /// Phalanx ID PopUp Impl
    /// </summary>
    public class IDPopUpImpl
        : AbstractDynamicEnumPopUp<PhalanxID>
    {
        private PhalanxID id;

        protected override string DetermineButtonName(PhalanxID tEnum)
        {
            return RequestType.PhalanxIDSelect + ":" + tEnum.ToString() + ":Button";
        }

        protected override bool IsInteractable(PhalanxID tEnum)
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
                IInternalBuilder SetPhalanxIDs(IList<PhalanxID> ids);

                IInternalBuilder SetPhalanxID(PhalanxID id);
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
                private IList<PhalanxID> ids;
                private PhalanxID id;

                IInternalBuilder IInternalBuilder.SetPhalanxIDs(IList<PhalanxID> ids)
                {
                    this.ids = ids;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetPhalanxID(PhalanxID id)
                {
                    this.id = id;
                    return this;
                }

                protected override IPanelWidget BuildScript(UnityEngine.GameObject gameObject)
                {
                    IDPopUpImpl widget = gameObject.AddComponent<IDPopUpImpl>();
                    widget.tEnums = ids;
                    widget.id = id;
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