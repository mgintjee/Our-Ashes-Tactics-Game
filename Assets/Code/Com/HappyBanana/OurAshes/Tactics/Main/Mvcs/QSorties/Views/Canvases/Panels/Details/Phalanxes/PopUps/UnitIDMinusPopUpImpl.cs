﻿using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Phalanxes.PopUps
{
    /// <summary>
    /// Unit ID Minus PopUp Impl
    /// </summary>
    public class UnitIDMinusPopUpImpl
        : AbstractDynamicEnumPopUp<UnitID>
    {
        private static readonly string EFFECT = "MinusMod";
        private PhalanxID id;

        protected override string DetermineButtonName(UnitID tEnum)
        {
            return typeof(UnitID).Name + EFFECT + ":" + id.ToString() + ":" + tEnum.ToString() + ":Button";
        }
        protected override bool IsInteractable(UnitID tEnum)
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
                IInternalBuilder SetUnitIDs(IList<UnitID> ids);

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
                private IList<UnitID> unitIDs;
                private PhalanxID id;

                IInternalBuilder IInternalBuilder.SetUnitIDs(IList<UnitID> ids)
                {
                    this.unitIDs = ids;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetPhalanxID(PhalanxID id)
                {
                    this.id = id;
                    return this;
                }

                protected override IPanelWidget BuildScript(UnityEngine.GameObject gameObject)
                {
                    UnitIDMinusPopUpImpl widget = gameObject.AddComponent<UnitIDMinusPopUpImpl>();
                    widget.tEnums = unitIDs;
                    widget.id = id;
                    this.ApplyPanelValues(widget);
                    return widget;
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, unitIDs
                        );
                    this.Validate(invalidReasons, id);
                }
            }
        }
    }
}