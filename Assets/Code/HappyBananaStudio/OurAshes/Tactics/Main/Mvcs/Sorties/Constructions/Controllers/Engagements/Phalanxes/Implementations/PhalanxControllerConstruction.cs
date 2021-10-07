using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Controllers.AIs.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Controllers.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Controllers.Engagements.Phalanxes.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Controllers.Engagements.Phalanxes.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct PhalanxControllerConstruction : IPhalanxControllerConstruction
    {
        // Todo
        private readonly PhalanxCallSign _phalanxCallSign;

        private readonly AIType _aiType;

        // Todo
        private readonly ControllerID _controllerID;

        // Todo
        private readonly ISet<CombatantCallSign> _combatantCallSigns;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="phalanxCallSign">   </param>
        /// <param name="controllerType">    </param>
        /// <param name="aiType">            </param>
        /// <param name="combatantCallSigns"></param>
        private PhalanxControllerConstruction(PhalanxCallSign phalanxCallSign,
            ControllerID controllerType, AIType aiType,
            ISet<CombatantCallSign> combatantCallSigns)
        {
            _phalanxCallSign = phalanxCallSign;
            _controllerID = controllerType;
            _aiType = aiType;
            _combatantCallSigns = combatantCallSigns;
        }

        /// <inheritdoc/>
        PhalanxCallSign IPhalanxControllerConstruction.GetPhalanxCallSign()
        {
            return _phalanxCallSign;
        }

        /// <inheritdoc/>
        ISet<CombatantCallSign> IPhalanxControllerConstruction.GetCombatantCallSigns()
        {
            return new HashSet<CombatantCallSign>(_combatantCallSigns);
        }

        /// <inheritdoc/>
        ControllerID IPhalanxControllerConstruction.GetControllerType()
        {
            return _controllerID;
        }

        /// <inheritdoc/>
        AIType IPhalanxControllerConstruction.GetAIType()
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
            public interface IBuilder : IBuilder<IPhalanxControllerConstruction>
            {
                IBuilder SetPhalanxCallSign(PhalanxCallSign phalanxCallSign);

                IBuilder SetAIType(AIType aIType);

                IBuilder SetControllerID(ControllerID controllerID);

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
            private class InternalBuilder : AbstractBuilder<IPhalanxControllerConstruction>, IBuilder
            {
                // Todo
                private PhalanxCallSign _phalanxCallSign;

                private AIType _aiType;

                // Todo
                private ControllerID _controllerID;

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
                IBuilder IBuilder.SetControllerID(ControllerID controllerID)
                {
                    _controllerID = controllerID;
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
                protected override IPhalanxControllerConstruction BuildObj()
                {
                    return new PhalanxControllerConstruction(_phalanxCallSign, _controllerID, _aiType, _combatantCallSigns);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _phalanxCallSign);
                    this.Validate(invalidReasons, _aiType);
                    this.Validate(invalidReasons, _controllerID);
                    this.Validate(invalidReasons, _combatantCallSigns);
                }
            }
        }
    }
}