using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Controllers.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Phalanxes.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Phalanxes.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public class PhalanxReport : AbstractReport, IPhalanxReport
    {
        // Todo
        private readonly ISet<CombatantCallSign> _combatantCallSigns;

        // Todo
        private readonly ControllerID _controllerType;

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
        /// <param name="phalanxCallSigns">  </param>
        /// <param name="combatantCallSigns"></param>
        private PhalanxReport(PhalanxCallSign phalanxCallSign, PhalanxType phalanxType, ControllerID controllerType,
            ISet<PhalanxCallSign> phalanxCallSigns, ISet<CombatantCallSign> combatantCallSigns)
        {
            _phalanxCallSign = phalanxCallSign;
            _phalanxType = phalanxType;
            _controllerType = controllerType;
            _phalanxCallSigns = phalanxCallSigns;
            _combatantCallSigns = combatantCallSigns;
        }

        /// <inheritdoc/>
        ISet<CombatantCallSign> IPhalanxReport.GetCombatantCallSigns()
        {
            return new HashSet<CombatantCallSign>(_combatantCallSigns);
        }

        /// <inheritdoc/>
        ControllerID IPhalanxReport.GetControllerType()
        {
            return _controllerType;
        }

        /// <inheritdoc/>
        PhalanxCallSign IPhalanxReport.GetPhalanxCallSign()
        {
            return _phalanxCallSign;
        }

        /// <inheritdoc/>
        ISet<PhalanxCallSign> IPhalanxReport.GetPhalanxCallSigns()
        {
            return new HashSet<PhalanxCallSign>(_phalanxCallSigns);
        }

        /// <inheritdoc/>
        PhalanxType IPhalanxReport.GetPhalanxType()
        {
            return _phalanxType;
        }

        protected override string GetContent()
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
            private ControllerID _controllerType = ControllerID.None;

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
            public IPhalanxReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new construction
                    return new PhalanxReport(_phalanxCallSign, _phalanxType,
                        _controllerType, _phalanxCallSigns, _combatantCallSigns);
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
            public Builder SetControllerType(ControllerID controllerType)
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
                if (_controllerType == ControllerID.None)
                {
                    argumentExceptionSet.Add(typeof(ControllerID).Name + " cannot be none.");
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