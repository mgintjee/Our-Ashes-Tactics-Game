using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Sorties.Maps.Paths.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Destructibles.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Fireables.Implementations;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Fireables.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Fireables.Utils;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Weapons.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Loadouts.Gears.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Maps.Coordinates.Cube.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Frames.Requests.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Combats.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Combatants.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Combats.Implementations;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Combats.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Damages.Implementations;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Damages.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Gears.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Maps.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Rosters.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Combats.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public class CombatModel : ICombatModel
    {
        // Provides logging capability to the SORTIE logs
        private readonly IClassLogger _logger = LoggerManager.GetLogger(MvcType.Sortie)
            .GetClassLogger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private ICombatReport _report;

        // Todo
        private ISet<IDamageReport> damageReports = new HashSet<IDamageReport>();

        // Todo
        private CombatantCallSign actingCombatant = CombatantCallSign.None;

        // Todo
        private CombatantCallSign targetCombatant = CombatantCallSign.None;

        /// <summary>
        /// Todo
        /// </summary>
        public CombatModel()
        {
            _logger.Info("Instantiating");
        }

        /// <inheritdoc/>
        ICombatReport ICombatModel.GetReport()
        {
            if (_report == null)
            {
                this.BuildReport();
            }
            return _report;
        }

        /// <inheritdoc/>
        void ICombatModel.Process(ISortieRequest controllerRequest,
            IRosterModelReport rosterReport, ISortieMapReport mapReport)
        {
            if (controllerRequest != null)
            {
                ISortieMapPath path = controllerRequest.GetPath();
                this.damageReports.Clear();
                if (path.GetPathType() == PathType.Fire)
                {
                    ICubeCoordinates targetCubeCoordinates = path.GetEnd();
                    mapReport.GetTileReport(targetCubeCoordinates).IfPresent((tileReport) =>
                    {
                        Optional<ICombatantReport> actingCombatantReport = rosterReport
                            .GetCombatantReport(controllerRequest.GetCallSign());
                        Optional<ICombatantReport> targetCombatantReport = rosterReport
                            .GetCombatantReport(tileReport.GetCombatantCallSign());
                        if (actingCombatantReport.IsPresent() && targetCombatantReport.IsPresent())
                        {
                            actingCombatant = actingCombatantReport.GetValue().GetCombatantCallSign();
                            targetCombatant = targetCombatantReport.GetValue().GetCombatantCallSign();
                            IDestructibleAttributes destructibleAttributes = targetCombatantReport.GetValue()
                                .GetCurrentAttributes().GetDestructibleAttributes();
                            IFireableAttributes combatantFireableAttributes = actingCombatantReport.GetValue()
                                .GetCurrentAttributes().GetFireableAttributes();
                            foreach (IGearReport weaponGearReport in
                                actingCombatantReport.GetValue().GetLoadoutReport().GetGearReports(GearType.Weapon))
                            {
                                this.damageReports.Add(this.GetDamageReport(
                                    combatantFireableAttributes, weaponGearReport, destructibleAttributes, path));
                            }
                        }
                    });
                }
            }
            this.BuildReport();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantFireableAttributes"></param>
        /// <param name="gearReport">                 </param>
        /// <param name="destructibleAttributes">     </param>
        /// <param name="path">                       </param>
        /// <returns></returns>
        private IDamageReport GetDamageReport(IFireableAttributes combatantFireableAttributes,
            IGearReport gearReport, IDestructibleAttributes destructibleAttributes, ISortieMapPath path)
        {
            IWeaponAttributes weaponAttributes = gearReport.GetWeaponAttributes();
            // Merge the combatant's FireableAttributes with the weapon's FireableAttributes
            ISet<IFireableAttributes> fireableAttributesSet = new HashSet<IFireableAttributes>() {
                combatantFireableAttributes,
                gearReport.GetCombatantAttributes().GetFireableAttributes(),
                FireableAttributes.Builder.Get()
                    .SetAccuracy(weaponAttributes.GetAccuracy())
                    .SetRange(weaponAttributes.GetRange())
                    .Build()
                };
            IFireableAttributes fireableAttributes = FireableAttributesUtil.Build(fireableAttributesSet);
            // Default 0 for the actualSalvoHits
            float actualSalvoHits = 0.0f;
            // Default 0 for the expectedSalvoHits
            float expectedSalvoHits = 0.0f;
            float armorDamageInflictedPerHit = weaponAttributes.GetArmorDamage();
            float remainingArmorPoints = destructibleAttributes.GetArmor() - weaponAttributes.GetArmorPenetration();
            if (remainingArmorPoints < 0)
            {
                remainingArmorPoints = 0;
            }
            float healthDamageInflictedPerHit = weaponAttributes.GetHealthDamage() - remainingArmorPoints;
            if (healthDamageInflictedPerHit < 0)
            {
                healthDamageInflictedPerHit = 0;
            }
            float healthDamageMitigatedPerHit = weaponAttributes.GetHealthDamage() - healthDamageInflictedPerHit;

            // Get the range for this fireable
            float range = fireableAttributes.GetRange();
            if (range >= path.GetLength())
            {
                // Get the accuracy for this fireable
                float accuracy = fireableAttributes.GetAccuracy();
                // Calculate the remaining accuracy after path cost
                float accuracyRemaining = accuracy - path.GetPathCost();
                if (accuracyRemaining >= 100f)
                {
                    actualSalvoHits = weaponAttributes.GetSalvo();
                    expectedSalvoHits = weaponAttributes.GetSalvo();
                }
                else if (accuracyRemaining > 0f)
                {
                    expectedSalvoHits = weaponAttributes.GetSalvo() * accuracyRemaining;
                    for (int i = 0; i < weaponAttributes.GetSalvo(); ++i)
                    {
                        double randomRoll = RandomManager.GetRandom(MvcType.Sortie).NextDouble();
                        if (randomRoll < accuracyRemaining)
                        {
                            actualSalvoHits++;
                        }
                    }
                }
            }

            return new DamageReport.Builder()
                .SetFireableAttributes(combatantFireableAttributes)
                .SetGearReport(gearReport)
                .SetDestructibleAttributes(destructibleAttributes)
                .SetActualSalvoHits(actualSalvoHits)
                .SetExpectedSalvoHits(expectedSalvoHits)
                .SetArmorDamageInflictedPerHit(armorDamageInflictedPerHit)
                .SetHealthDamageInflictedPerHit(healthDamageInflictedPerHit)
                .SetHealthDamageMitigatedPerHit(healthDamageMitigatedPerHit)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void BuildReport()
        {
            _report = new CombatReport.Builder()
                .SetDamageReports(damageReports)
                .SetActingCallSign(actingCombatant)
                .SetTargetCallSign(targetCombatant)
                .Build();
        }
    }
}