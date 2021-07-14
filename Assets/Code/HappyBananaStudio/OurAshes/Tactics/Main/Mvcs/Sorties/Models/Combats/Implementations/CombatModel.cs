﻿using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Attributes.Destructibles.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Attributes.Fireables.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Attributes.Fireables.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Weapons.Attributes.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Maps.Coordinates.Cube.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Sorties.Maps.Paths.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Reports.Gears.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Combats.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Combats.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public class CombatModel
        : ICombatModel
    {
        // Provides logging capability to the SORTIE logs
        private readonly ILogger _logger = LoggerManager.GetLogger(MvcType.Sortie, new StackFrame().GetMethod().DeclaringType);

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
            IRosterReport rosterReport, ISortieMapReport mapReport)
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
            // Merge the combatant's FireableAttributes with the weapon's FireableAttributes
            IFireableAttributes fireableAttributes = FireableAttributesUtil.Build(
                new HashSet<IFireableAttributes>() {
                    combatantFireableAttributes, gearReport.GetCombatantAttributes().GetFireableAttributes() });
            IWeaponAttributes weaponAttributes;
            // Default 0 for the actualSalvoHits
            float actualSalvoHits = 0.0f;
            // Default 0 for the expectedSalvoHits
            float expectedSalvoHits = 0.0f;
            float armorDamageInflictedPerHit = fireableAttributes.GetArmorDamage();
            float remainingArmorPoints = destructibleAttributes.GetArmor() - fireableAttributes.GetArmorPenetration();
            if (remainingArmorPoints < 0)
            {
                remainingArmorPoints = 0;
            }
            float healthDamageInflictedPerHit = fireableAttributes.GetHealthDamage() - remainingArmorPoints;
            if (healthDamageInflictedPerHit < 0)
            {
                healthDamageInflictedPerHit = 0;
            }
            float healthDamageMitigatedPerHit = fireableAttributes.GetHealthDamage() - healthDamageInflictedPerHit;

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
                    actualSalvoHits = fireableAttributes.GetSalvo();
                    expectedSalvoHits = fireableAttributes.GetSalvo();
                }
                else if (accuracyRemaining > 0f)
                {
                    expectedSalvoHits = fireableAttributes.GetSalvo() * accuracyRemaining;
                    for (int i = 0; i < fireableAttributes.GetSalvo(); ++i)
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