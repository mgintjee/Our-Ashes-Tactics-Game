using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Controllers.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Phalanxes.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Phalanxes.Types;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Views.Engagements.Phalanxes.Constructions.Implementaions
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct PhalanxConstruction : IPhalanxConstruction
    {
        // Todo
        private readonly PhalanxCallSign _phalanxCallSign;

        // Todo
        private readonly PhalanxType _phalanxType;

        // Todo
        private readonly ControllerID _controllerType;

        // Todo
        private readonly AIType _aiType;

        // Todo
        private readonly IInsigniaReport _insigniaScheme;

        // Todo
        private readonly ISet<CombatantCallSign> _combatantCallSigns;

        // Todo
        private readonly ISet<PhalanxCallSign> _phalanxCallSigns;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="phalanxCallSign">   </param>
        /// <param name="controllerType">    </param>
        /// <param name="aiType">            </param>
        /// <param name="insigniaScheme">    </param>
        /// <param name="combatantCallSigns"></param>
        /// <param name="phalanxCallSigns">  </param>
        private PhalanxConstruction(PhalanxCallSign phalanxCallSign, PhalanxType phalanxType,
            ControllerID controllerType, AIType aiType, IInsigniaReport insigniaScheme,
            ISet<CombatantCallSign> combatantCallSigns, ISet<PhalanxCallSign> phalanxCallSigns)
        {
            _phalanxCallSign = phalanxCallSign;
            _phalanxType = phalanxType;
            _controllerType = controllerType;
            _aiType = aiType;
            _insigniaScheme = insigniaScheme;
            _combatantCallSigns = combatantCallSigns;
            _phalanxCallSigns = phalanxCallSigns;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}={1}," +
                "\n{2}={3}" +
                "\n{4}={5}" +
                "\n{6}={7}" +
                "\n{8}" +
                "\n{9}:[{10}]" +
                "\n{11}:[{12}]",
                typeof(PhalanxCallSign).Name, _phalanxCallSign,
                typeof(PhalanxType).Name, _phalanxType,
                typeof(ControllerID).Name, _controllerType,
                typeof(AIType).Name, _aiType,
                _insigniaScheme,
                typeof(CombatantCallSign).Name, string.Join(",", _combatantCallSigns),
                typeof(PhalanxCallSign).Name, string.Join(",", _phalanxCallSigns));
        }

        /// <inheritdoc/>
        PhalanxCallSign IPhalanxConstruction.GetPhalanxCallSign()
        {
            return _phalanxCallSign;
        }

        /// <inheritdoc/>
        ISet<CombatantCallSign> IPhalanxConstruction.GetCombatantCallSigns()
        {
            return new HashSet<CombatantCallSign>(_combatantCallSigns);
        }

        /// <inheritdoc/>
        ControllerID IPhalanxConstruction.GetControllerType()
        {
            return _controllerType;
        }

        /// <inheritdoc/>
        ISet<PhalanxCallSign> IPhalanxConstruction.GetPhalanxCallSigns()
        {
            return new HashSet<PhalanxCallSign>(_phalanxCallSigns);
        }

        /// <inheritdoc/>
        PhalanxType IPhalanxConstruction.GetPhalanxType()
        {
            return _phalanxType;
        }

        /// <inheritdoc/>
        Optional<IInsigniaReport> IPhalanxConstruction.GetInsigniaScheme()
        {
            return Optional<IInsigniaReport>.Of(_insigniaScheme);
        }

        /// <inheritdoc/>
        AIType IPhalanxConstruction.GetAIType()
        {
            return _aiType;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
            : AbstractBuilder<IPhalanxConstruction>
        {
            // Todo
            private PhalanxCallSign _phalanxCallSign;

            // Todo
            private PhalanxType _phalanxType;

            // Todo
            private ControllerID _controllerType;

            // Todo
            private AIType _aiType;

            // Todo
            private IInsigniaReport _insigniaScheme;

            // Todo
            private ISet<CombatantCallSign> _combatantCallSigns;

            // Todo
            private ISet<PhalanxCallSign> _phalanxCallSigns;

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="phalanxCallSign"></param>
            /// <returns></returns>
            public Builder SetPhalanxCallSign(PhalanxCallSign phalanxCallSign)
            {
                _phalanxCallSign = phalanxCallSign;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="phalanxType"></param>
            /// <returns></returns>
            public Builder SetPhalanxType(PhalanxType phalanxType)
            {
                _phalanxType = phalanxType;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="controllerType"></param>
            /// <returns></returns>
            public Builder SetControllerType(ControllerID controllerType)
            {
                _controllerType = controllerType;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="aiType"></param>
            /// <returns></returns>
            public Builder SetAIType(AIType aiType)
            {
                _aiType = aiType;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="insigniaScheme"></param>
            /// <returns></returns>
            public Builder SetInsigniaScheme(IInsigniaReport insigniaScheme)
            {
                _insigniaScheme = insigniaScheme;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="combatantCallSigns"></param>
            /// <returns></returns>
            public Builder SetCombatantCallSigns(ISet<CombatantCallSign> combatantCallSigns)
            {
                if (combatantCallSigns != null)
                {
                    _combatantCallSigns = new HashSet<CombatantCallSign>(combatantCallSigns);
                }
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="phalanxCallSigns"></param>
            /// <returns></returns>
            public Builder SetPhalanxCallSigns(ISet<PhalanxCallSign> phalanxCallSigns)
            {
                if (phalanxCallSigns != null)
                {
                    _phalanxCallSigns = new HashSet<PhalanxCallSign>(phalanxCallSigns);
                }
                return this;
            }

            /// <inheritdoc/>
            protected override IPhalanxConstruction BuildObj()
            {
                return new PhalanxConstruction(_phalanxCallSign, _phalanxType, _controllerType,
                    _aiType, _insigniaScheme, _combatantCallSigns, _phalanxCallSigns);
            }

            /// <inheritdoc/>
            protected override void Validate(ISet<string> invalidReasons)
            {
                Validate(invalidReasons, _phalanxCallSign);
                Validate(invalidReasons, _controllerType);
                // Check that _aiType has been set
                if (_controllerType == ControllerID.Human && _aiType != AIType.None ||
                    _controllerType != ControllerID.Human && _aiType == AIType.None)
                {
                    invalidReasons.Add(typeof(AIType).Name + " cannot be " + _aiType + " while " +
                        typeof(ControllerID).Name + " is " + _controllerType + ".");
                }
                Validate(invalidReasons, _combatantCallSigns);
                Validate(invalidReasons, _phalanxCallSigns);
            }
        }
    }
}