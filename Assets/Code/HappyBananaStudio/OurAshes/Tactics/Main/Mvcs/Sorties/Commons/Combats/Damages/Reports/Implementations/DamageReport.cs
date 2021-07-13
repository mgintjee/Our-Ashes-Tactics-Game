using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Attributes.Destructibles.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Attributes.Fireables.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Reports.Gears.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combats.Damages.Reports.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combats.Damages.Reports.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public class DamageReport : AbstractReport, IDamageReport
    {
        // Todo
        private readonly IFireableAttributes _fireableAttributes;

        // Todo
        private readonly IGearReport _weaponGearReport;

        // Todo
        private readonly IDestructibleAttributes _destructibleAttributes;

        // Todo
        private readonly float _actualSalvoHits;

        // Todo
        private readonly float _expectedSalvoHits;

        // Todo
        private readonly float _armorDamageInflictedPerHit;

        // Todo
        private readonly float _healthDamageInflictedPerHit;

        // Todo
        private readonly float _healthDamageMitigatedPerHit;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="fireableAttributes">         </param>
        /// <param name="gearReport">                 </param>
        /// <param name="destructibleAttributes">     </param>
        /// <param name="actualSalvoHits">            </param>
        /// <param name="armorDamageInflictedPerHit"> </param>
        /// <param name="expectedSalvoHits">          </param>
        /// <param name="healthDamageInflictedPerHit"></param>
        /// <param name="healthDamageMitigatedPerHit"></param>
        private DamageReport(IFireableAttributes fireableAttributes, IGearReport gearReport,
            IDestructibleAttributes destructibleAttributes, float actualSalvoHits, float armorDamageInflictedPerHit,
            float expectedSalvoHits, float healthDamageInflictedPerHit, float healthDamageMitigatedPerHit)
        {
            _fireableAttributes = fireableAttributes;
            _weaponGearReport = gearReport;
            _destructibleAttributes = destructibleAttributes;
            _actualSalvoHits = actualSalvoHits;
            _expectedSalvoHits = expectedSalvoHits;
            _armorDamageInflictedPerHit = armorDamageInflictedPerHit;
            _healthDamageInflictedPerHit = healthDamageInflictedPerHit;
            _healthDamageMitigatedPerHit = healthDamageMitigatedPerHit;
        }

        /// <inheritdoc/>
        float IDamageReport.GetActualSalvoHits()
        {
            return _actualSalvoHits;
        }

        /// <inheritdoc/>
        float IDamageReport.GetArmorDamageInflictedPerHit()
        {
            return _armorDamageInflictedPerHit;
        }

        /// <inheritdoc/>
        IDestructibleAttributes IDamageReport.GetDestructibleAttributes()
        {
            return _destructibleAttributes;
        }

        /// <inheritdoc/>
        float IDamageReport.GetExpectedSalvoHits()
        {
            return _expectedSalvoHits;
        }

        /// <inheritdoc/>
        IFireableAttributes IDamageReport.GetFireableAttributes()
        {
            return _fireableAttributes;
        }

        /// <inheritdoc/>
        float IDamageReport.GetHealthDamageInflictedPerHit()
        {
            return _healthDamageInflictedPerHit;
        }

        /// <inheritdoc/>
        float IDamageReport.GetHealthDamageMitigatedPerHit()
        {
            return _healthDamageMitigatedPerHit;
        }

        /// <inheritdoc/>
        IGearReport IDamageReport.GetGearReport()
        {
            return _weaponGearReport;
        }

        /// <inheritdoc/>
        protected override string GetContent()
        {
            return string.Format("{0}, _actualSalvoHits={1}, _expectedSalvoHits={2}, " +
                "_armorDamageInflictedPerHit={3}, _healthDamageInflictedPerHit={4}, _healthDamageMitigatedPerHit={5}",
                _weaponGearReport, _actualSalvoHits, _expectedSalvoHits, _armorDamageInflictedPerHit,
                _healthDamageInflictedPerHit, _healthDamageMitigatedPerHit);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private IFireableAttributes _fireableAttributes;

            // Todo
            private IGearReport _gearReport;

            // Todo
            private IDestructibleAttributes _destructibleAttributes;

            // Todo
            private float _actualSalvoHits;

            // Todo
            private float _expectedSalvoHits;

            // Todo
            private float _armorDamageInflictedPerHit;

            // Todo
            private float _healthDamageInflictedPerHit;

            // Todo
            private float _healthDamageMitigatedPerHit;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IDamageReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new report
                    return new DamageReport(_fireableAttributes, _gearReport, _destructibleAttributes,
                        _actualSalvoHits, _armorDamageInflictedPerHit, _expectedSalvoHits,
                        _healthDamageInflictedPerHit, _healthDamageMitigatedPerHit);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="fireableAttributes"></param>
            public Builder SetFireableAttributes(IFireableAttributes fireableAttributes)
            {
                _fireableAttributes = fireableAttributes;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="gearReport"></param>
            public Builder SetGearReport(IGearReport gearReport)
            {
                _gearReport = gearReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="destructibleAttributes"></param>
            public Builder SetDestructibleAttributes(IDestructibleAttributes destructibleAttributes)
            {
                _destructibleAttributes = destructibleAttributes;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="apMitigatedPerHit"></param>
            public Builder SetActualSalvoHits(float apMitigatedPerHit)
            {
                _actualSalvoHits = apMitigatedPerHit;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="expectedSalvoHits"></param>
            public Builder SetExpectedSalvoHits(float expectedSalvoHits)
            {
                _expectedSalvoHits = expectedSalvoHits;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="armorDamageInflictedPerHit"></param>
            public Builder SetArmorDamageInflictedPerHit(float armorDamageInflictedPerHit)
            {
                _armorDamageInflictedPerHit = armorDamageInflictedPerHit;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="healthDamageInflictedPerHit"></param>
            public Builder SetHealthDamageInflictedPerHit(float healthDamageInflictedPerHit)
            {
                _healthDamageInflictedPerHit = healthDamageInflictedPerHit;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="healthDamageMitigatedPerHit"></param>
            public Builder SetHealthDamageMitigatedPerHit(float healthDamageMitigatedPerHit)
            {
                _healthDamageMitigatedPerHit = healthDamageMitigatedPerHit;
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
                // Check that _fireableAttributes has been set
                if (_fireableAttributes == null)
                {
                    argumentExceptionSet.Add(typeof(IFireableAttributes).Name + " cannot be null.");
                }
                // Check that _gearReport has been set
                if (_gearReport == null)
                {
                    argumentExceptionSet.Add(typeof(IGearReport).Name + " cannot be null.");
                }
                // Check that _destructibleAttributes has been set
                if (_destructibleAttributes == null)
                {
                    argumentExceptionSet.Add(typeof(IDestructibleAttributes).Name + " cannot be null.");
                }
                // Check that _actualSalvoHits has been set
                if (_actualSalvoHits < 0)
                {
                    argumentExceptionSet.Add("_actualSalvoHits cannot be less than 0.");
                }
                // Check that _expectedSalvoHits has been set
                if (_expectedSalvoHits < 0)
                {
                    argumentExceptionSet.Add("_expectedSalvoHits cannot be less than 0.");
                }
                // Check that _armorDamageInflictedPerHit has been set
                if (_armorDamageInflictedPerHit < 0)
                {
                    argumentExceptionSet.Add("_armorDamageInflictedPerHit cannot be less than 0.");
                }
                // Check that _healthDamageInflictedPerHit has been set
                if (_healthDamageInflictedPerHit < 0)
                {
                    argumentExceptionSet.Add("_healthDamageInflictedPerHit cannot be less than 0.");
                }
                // Check that _healthDamageMitigatedPerHit has been set
                if (_healthDamageMitigatedPerHit < 0)
                {
                    argumentExceptionSet.Add("_healthDamageMitigatedPerHit cannot be less than 0.");
                }
                return argumentExceptionSet;
            }
        }
    }
}