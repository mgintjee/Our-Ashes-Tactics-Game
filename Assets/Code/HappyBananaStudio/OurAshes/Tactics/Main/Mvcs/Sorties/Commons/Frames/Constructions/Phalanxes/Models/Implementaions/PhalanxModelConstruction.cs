using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Controllers.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Phalanxes.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Phalanxes.Formations.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Phalanxes.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Phalanxes.Models.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Phalanxes.Models.Implementaions
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct PhalanxModelConstruction
        : IPhalanxModelConstruction
    {
        // Todo
        private readonly PhalanxFormationType formationType;

        // Todo
        private readonly ISet<CombatantCallSign> _combatantCallSigns;

        // Todo
        private readonly ControllerType _controllerType;

        // Todo
        private readonly PhalanxCallSign _phalanxCallSign;

        // Todo
        private readonly ISet<PhalanxCallSign> _phalanxCallSigns;

        // Todo
        private readonly PhalanxType _phalanxType;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="phalanxCallSign">   </param>
        /// <param name="phalanxType">       </param>
        /// <param name="controllerType">    </param>
        /// <param name="phalanxCallSigns">  </param>
        /// <param name="combatantCallSigns"></param>
        private PhalanxModelConstruction(PhalanxCallSign phalanxCallSign,
            PhalanxFormationType formationType, PhalanxType phalanxType, ControllerType controllerType,
            ISet<PhalanxCallSign> phalanxCallSigns, ISet<CombatantCallSign> combatantCallSigns)
        {
            _phalanxCallSign = phalanxCallSign;
            this.formationType = formationType;
            _phalanxType = phalanxType;
            _controllerType = controllerType;
            _phalanxCallSigns = phalanxCallSigns;
            _combatantCallSigns = combatantCallSigns;
        }

        ISet<CombatantCallSign> IPhalanxModelConstruction.GetCombatantCallSigns()
        {
            throw new System.NotImplementedException();
        }

        ControllerType IPhalanxModelConstruction.GetControllerType()
        {
            throw new System.NotImplementedException();
        }

        PhalanxFormationType IPhalanxModelConstruction.GetFormationType()
        {
            throw new System.NotImplementedException();
        }

        PhalanxCallSign IPhalanxModelConstruction.GetPhalanxCallSign()
        {
            throw new System.NotImplementedException();
        }

        ISet<PhalanxCallSign> IPhalanxModelConstruction.GetPhalanxCallSigns()
        {
            throw new System.NotImplementedException();
        }

        PhalanxType IPhalanxModelConstruction.GetPhalanxType()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ISet<CombatantCallSign> _combatantCallSigns = null;

            // Todo
            private PhalanxFormationType _formationType = PhalanxFormationType.None;

            // Todo
            private ControllerType _controllerType = ControllerType.None;

            // Todo
            private PhalanxCallSign _phalanxCallSign = PhalanxCallSign.None;

            // Todo
            private ISet<PhalanxCallSign> _phalanxCallSigns = new HashSet<PhalanxCallSign>();

            // Todo
            private PhalanxType _phalanxType = PhalanxType.None;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IPhalanxModelConstruction Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new construction
                    return new PhalanxModelConstruction(_phalanxCallSign, _formationType,
                        _phalanxType, _controllerType, _phalanxCallSigns, _combatantCallSigns);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="combatantCallSigns"></param>
            /// <returns></returns>
            public Builder SetCombatantCallSigns(ISet<CombatantCallSign> combatantCallSigns)
            {
                _combatantCallSigns = new HashSet<CombatantCallSign>(combatantCallSigns);
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="controllerType"></param>
            /// <returns></returns>
            public Builder SetControllerType(ControllerType controllerType)
            {
                _controllerType = controllerType;
                return this;
            }

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
            /// <param name="phalanxCallSigns"></param>
            /// <returns></returns>
            public Builder SetPhalanxCallSigns(ISet<PhalanxCallSign> phalanxCallSigns)
            {
                _phalanxCallSigns = new HashSet<PhalanxCallSign>(phalanxCallSigns);
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
            /// <returns></returns>
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                // Check that _phalanxCallSign has been set
                if (_phalanxCallSign == PhalanxCallSign.None)
                {
                    argumentExceptionSet.Add(typeof(PhalanxCallSign).Name + " cannot be none.");
                }
                // Check that _phalanxType has been set
                if (_phalanxType == PhalanxType.None)
                {
                    argumentExceptionSet.Add(typeof(PhalanxType).Name + " cannot be none.");
                }
                // Check that _controllerType has been set
                if (_controllerType == ControllerType.None)
                {
                    argumentExceptionSet.Add(typeof(ControllerType).Name + " cannot be none.");
                }
                // Check that _combatantCallSigns has been set
                if (_combatantCallSigns == null)
                {
                    argumentExceptionSet.Add("Set: " + typeof(CombatantCallSign).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}