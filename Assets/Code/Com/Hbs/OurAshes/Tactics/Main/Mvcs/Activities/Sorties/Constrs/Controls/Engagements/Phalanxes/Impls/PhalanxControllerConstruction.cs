using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Phalanxes.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Controls.Engagements.Phalanxes.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.AIs.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.IDs;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Controls.Engagements.Phalanxes.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct PhalanxControlConstruction : IPhalanxControlConstruction
    {
        // Todo
        private readonly PhalanxCallSign _phalanxCallSign;

        // Todo
        private readonly AIType _aiType;

        // Todo
        private readonly ControlID _ControlID;

        // Todo
        private readonly ISet<CombatantCallSign> _combatantCallSigns;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="phalanxCallSign">   </param>
        /// <param name="ControlType">       </param>
        /// <param name="aiType">            </param>
        /// <param name="combatantCallSigns"></param>
        private PhalanxControlConstruction(PhalanxCallSign phalanxCallSign,
            ControlID ControlType, AIType aiType,
            ISet<CombatantCallSign> combatantCallSigns)
        {
            _phalanxCallSign = phalanxCallSign;
            _ControlID = ControlType;
            _aiType = aiType;
            _combatantCallSigns = combatantCallSigns;
        }

        /// <inheritdoc/>
        PhalanxCallSign IPhalanxControlConstruction.GetPhalanxCallSign()
        {
            return _phalanxCallSign;
        }

        /// <inheritdoc/>
        ISet<CombatantCallSign> IPhalanxControlConstruction.GetCombatantCallSigns()
        {
            return new HashSet<CombatantCallSign>(_combatantCallSigns);
        }

        /// <inheritdoc/>
        ControlID IPhalanxControlConstruction.GetControlID()
        {
            return _ControlID;
        }

        /// <inheritdoc/>
        AIType IPhalanxControlConstruction.GetAIType()
        {
            return _aiType;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<IPhalanxControlConstruction>
            {
                IBuilder SetPhalanxCallSign(PhalanxCallSign phalanxCallSign);

                IBuilder SetAIType(AIType aIType);

                IBuilder SetControlID(ControlID ControlID);

                IBuilder SetCombatantCallSigns(ISet<CombatantCallSign> combatantCallSigns);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static IBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Todo
            /// </summary>
            private class InternalBuilder : AbstractBuilder<IPhalanxControlConstruction>, IBuilder
            {
                // Todo
                private PhalanxCallSign _phalanxCallSign;

                private AIType _aiType;

                // Todo
                private ControlID _ControlID;

                // Todo
                private ISet<CombatantCallSign> _combatantCallSigns;

                /// <inheritdoc/>
                IBuilder IBuilder.SetPhalanxCallSign(PhalanxCallSign phalanxCallSign)
                {
                    _phalanxCallSign = phalanxCallSign;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetAIType(AIType aIType)
                {
                    _aiType = aIType;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetControlID(ControlID ControlID)
                {
                    _ControlID = ControlID;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetCombatantCallSigns(ISet<CombatantCallSign> combatantCallSigns)
                {
                    if (combatantCallSigns != null)
                    {
                        _combatantCallSigns = new HashSet<CombatantCallSign>(combatantCallSigns);
                    }
                    return this;
                }

                /// <inheritdoc/>
                protected override IPhalanxControlConstruction BuildObj()
                {
                    return new PhalanxControlConstruction(_phalanxCallSign, _ControlID, _aiType, _combatantCallSigns);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _phalanxCallSign);
                    this.Validate(invalidReasons, _aiType);
                    this.Validate(invalidReasons, _ControlID);
                    this.Validate(invalidReasons, _combatantCallSigns);
                }
            }
        }
    }
}