using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Models.Rosters.Combatants.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Reports.Models.Loadouts.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Models.Rosters.Combatants.Impls
{
    /// <summary>
    /// Combatant Model Construction Impl
    /// </summary>
    public struct CombatantModelConstruction : ICombatantModelConstruction
    {
        // Todo
        private readonly CombatantCallSign _combatantCallSign;

        // Todo
        private readonly CombatantID _combatantID;

        // Todo
        private readonly ILoadoutReport _loadoutReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantCallSign"></param>
        /// <param name="combatantID">      </param>
        /// <param name="loadoutReport">    </param>
        private CombatantModelConstruction(CombatantCallSign combatantCallSign,
            CombatantID combatantID, ILoadoutReport loadoutReport)
        {
            _combatantCallSign = combatantCallSign;
            _combatantID = combatantID;
            _loadoutReport = loadoutReport;
        }

        /// <inheritdoc/>
        CombatantID ICombatantModelConstruction.GetCombatantID()
        {
            return _combatantID;
        }

        /// <inheritdoc/>
        ILoadoutReport ICombatantModelConstruction.GetLoadoutReport()
        {
            return _loadoutReport;
        }

        /// <inheritdoc/>
        CombatantCallSign ICombatantModelConstruction.GetCombatantCallSign()
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
            public interface IBuilder : IBuilder<ICombatantModelConstruction>
            {
                IBuilder SetCombatantCallSign(CombatantCallSign combatantCallSign);

                IBuilder SetCombatantID(CombatantID combatantID);

                IBuilder SetLoadoutReport(ILoadoutReport loadoutReport);
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
            private class InternalBuilder : AbstractBuilder<ICombatantModelConstruction>, IBuilder
            {
                // Todo
                private CombatantCallSign _combatantCallSign;

                // Todo
                private CombatantID _combatantID;

                // Todo
                private ILoadoutReport _loadoutReport;

                /// <inheritdoc/>
                IBuilder IBuilder.SetCombatantCallSign(CombatantCallSign combatantCallSign)
                {
                    _combatantCallSign = combatantCallSign;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetCombatantID(CombatantID combatantID)
                {
                    _combatantID = combatantID;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetLoadoutReport(ILoadoutReport loadoutReport)
                {
                    _loadoutReport = loadoutReport;
                    return this;
                }

                /// <inheritdoc/>
                protected override ICombatantModelConstruction BuildObj()
                {
                    return new CombatantModelConstruction(_combatantCallSign, _combatantID, _loadoutReport);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _combatantCallSign);
                    this.Validate(invalidReasons, _combatantID);
                    this.Validate(invalidReasons, _loadoutReport);
                }
            }
        }
    }
}