using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Phalanxes.CallSigns;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Phalanxes.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Models.Engagements.Phalanxes.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Models.Engagements.Phalanxes.Impls
{
    /// <summary>
    /// Phalanx Model Construction Implementation
    /// </summary>
    public struct PhalanxModelConstruction : IPhalanxModelConstruction
    {
        // Todo
        private readonly PhalanxCallSign _phalanxCallSign;

        // Todo
        private readonly PhalanxType _phalanxType;

        // Todo
        private readonly ISet<CombatantCallSign> _combatantCallSigns;

        // Todo
        private readonly ISet<PhalanxCallSign> _phalanxCallSigns;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="phalanxCallSign">   </param>
        /// <param name="combatantCallSigns"></param>
        /// <param name="phalanxCallSigns">  </param>
        private PhalanxModelConstruction(PhalanxCallSign phalanxCallSign, PhalanxType phalanxType,
            ISet<CombatantCallSign> combatantCallSigns, ISet<PhalanxCallSign> phalanxCallSigns)
        {
            _phalanxCallSign = phalanxCallSign;
            _phalanxType = phalanxType;
            _combatantCallSigns = combatantCallSigns;
            _phalanxCallSigns = phalanxCallSigns;
        }

        /// <inheritdoc/>
        PhalanxCallSign IPhalanxModelConstruction.GetPhalanxCallSign()
        {
            return _phalanxCallSign;
        }

        /// <inheritdoc/>
        ISet<CombatantCallSign> IPhalanxModelConstruction.GetCombatantCallSigns()
        {
            return new HashSet<CombatantCallSign>(_combatantCallSigns);
        }

        /// <inheritdoc/>
        ISet<PhalanxCallSign> IPhalanxModelConstruction.GetPhalanxCallSigns()
        {
            return new HashSet<PhalanxCallSign>(_phalanxCallSigns);
        }

        /// <inheritdoc/>
        PhalanxType IPhalanxModelConstruction.GetPhalanxType()
        {
            return _phalanxType;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<IPhalanxModelConstruction>
            {
                IBuilder SetPhalanxCallSign(PhalanxCallSign phalanxCallSign);

                IBuilder SetPhalanxType(PhalanxType insigniaReport);

                IBuilder SetPhalanxCallSigns(ISet<PhalanxCallSign> phalanxCallSigns);

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
            private class InternalBuilder : AbstractBuilder<IPhalanxModelConstruction>, IBuilder
            {
                private PhalanxCallSign _phalanxCallSign;
                private PhalanxType _phalanxType;
                private ISet<CombatantCallSign> _combatantCallSigns;
                private ISet<PhalanxCallSign> _phalanxCallSigns;

                /// <inheritdoc/>
                IBuilder IBuilder.SetPhalanxCallSign(PhalanxCallSign phalanxCallSign)
                {
                    _phalanxCallSign = phalanxCallSign;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetPhalanxType(PhalanxType phalanxType)
                {
                    _phalanxType = phalanxType;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetPhalanxCallSigns(ISet<PhalanxCallSign> phalanxCallSigns)
                {
                    if (phalanxCallSigns != null)
                    {
                        _phalanxCallSigns = new HashSet<PhalanxCallSign>(phalanxCallSigns);
                    }
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
                protected override IPhalanxModelConstruction BuildObj()
                {
                    return new PhalanxModelConstruction(_phalanxCallSign, _phalanxType, _combatantCallSigns, _phalanxCallSigns);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _phalanxCallSign);
                    this.Validate(invalidReasons, _phalanxType);
                    this.Validate(invalidReasons, _combatantCallSigns);
                    this.Validate(invalidReasons, _phalanxCallSigns);
                }
            }
        }
    }
}