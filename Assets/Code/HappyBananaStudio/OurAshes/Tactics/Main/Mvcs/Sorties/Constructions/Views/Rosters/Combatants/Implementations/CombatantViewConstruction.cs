using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Views.Rosters.Combatants.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Views.Insignias.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Views.Rosters.Combatants.Implementations
{
    /// <summary>
    /// Combatant View Construction Implementation
    /// </summary>
    public struct CombatantViewConstruction : ICombatantViewConstruction
    {
        // Todo
        private readonly CombatantCallSign _combatantCallSign;

        // Todo
        private readonly CombatantSkin _combatantSkin;

        // Todo
        private readonly IList<GearSkin> _gearSkins;

        // Todo
        private readonly IInsigniaReport _insigniaReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantCallSign"></param>
        /// <param name="combatantSkin">    </param>
        /// <param name="gearSkins">        </param>
        /// <param name="insigniaScheme">   </param>
        private CombatantViewConstruction(CombatantCallSign combatantCallSign, CombatantSkin combatantSkin,
            IList<GearSkin> gearSkins, IInsigniaReport insigniaScheme)
        {
            _combatantCallSign = combatantCallSign;
            _combatantSkin = combatantSkin;
            _gearSkins = gearSkins;
            _insigniaReport = insigniaScheme;
        }

        /// <inheritdoc/>
        CombatantSkin ICombatantViewConstruction.GetCombatantSkin()
        {
            return _combatantSkin;
        }

        /// <inheritdoc/>
        IInsigniaReport ICombatantViewConstruction.GetInsigniaReport()
        {
            return _insigniaReport;
        }

        /// <inheritdoc/>
        IList<GearSkin> ICombatantViewConstruction.GetGearSkins()
        {
            return new List<GearSkin>(_gearSkins);
        }

        /// <inheritdoc/>
        CombatantCallSign ICombatantViewConstruction.GetCombatantCallSign()
        {
            return _combatantCallSign;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<ICombatantViewConstruction>
            {
                IBuilder SetCombatantCallSign(CombatantCallSign combatantCallSign);

                IBuilder SetCombatantSkin(CombatantSkin combatantSkin);

                IBuilder SetInsigniaReport(IInsigniaReport insigniaReport);

                IBuilder SetGearSkins(IList<GearSkin> gearSkins);
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
            private class InternalBuilder : AbstractBuilder<ICombatantViewConstruction>, IBuilder
            {
                // Todo
                private CombatantCallSign _combatantCallSign = CombatantCallSign.None;

                // Todo
                private CombatantSkin _combatantSkin = CombatantSkin.None;

                // Todo
                private IList<GearSkin> _gearSkins = new List<GearSkin>();

                // Todo
                private IInsigniaReport _insigniaReport;

                /// <inheritdoc/>
                IBuilder IBuilder.SetCombatantCallSign(CombatantCallSign combatantCallSign)
                {
                    _combatantCallSign = combatantCallSign;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetCombatantSkin(CombatantSkin combatantSkin)
                {
                    _combatantSkin = combatantSkin;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetGearSkins(IList<GearSkin> gearSkins)
                {
                    _gearSkins = new List<GearSkin>(gearSkins);
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetInsigniaReport(IInsigniaReport insigniaReport)
                {
                    _insigniaReport = insigniaReport;
                    return this;
                }

                /// <inheritdoc/>
                protected override ICombatantViewConstruction BuildObj()
                {
                    return new CombatantViewConstruction(_combatantCallSign, _combatantSkin, _gearSkins, _insigniaReport);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _combatantCallSign);
                    this.Validate(invalidReasons, _combatantSkin);
                    this.Validate(invalidReasons, _insigniaReport);
                }
            }
        }
    }
}