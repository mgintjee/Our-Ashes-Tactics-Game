using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Units.PopUps
{
    /// <summary>
    /// Unit ID PopUp Impl
    /// </summary>
    public class UnitIDPopUpImpl
        : AbstractDynamicEnumPopUp<UnitID>
    {
        private UnitID id;

        protected override string DetermineButtonName(UnitID tEnum)
        {
            return typeof(UnitID).Name + "Select:" + tEnum.ToString() + ":Button";
        }

        protected override bool IsInteractable(UnitID tEnum)
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
                IInternalBuilder SetUnitIDs(IList<UnitID> ids);

                IInternalBuilder SetUnitID(UnitID id);
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
                private IList<UnitID> ids;
                private UnitID id;

                IInternalBuilder IInternalBuilder.SetUnitIDs(IList<UnitID> ids)
                {
                    this.ids = ids;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetUnitID(UnitID id)
                {
                    this.id = id;
                    return this;
                }

                protected override IPanelWidget BuildScript(UnityEngine.GameObject gameObject)
                {
                    UnitIDPopUpImpl widget = gameObject.AddComponent<UnitIDPopUpImpl>();
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