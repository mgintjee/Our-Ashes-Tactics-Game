using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Destructibles.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Fireables.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Reports.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Gears.Interfaces;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Damages.Interfaces
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IDamageReport : IReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IFireableAttributes GetFireableAttributes();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IGearReport GetGearReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IDestructibleAttributes GetDestructibleAttributes();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        float GetActualSalvoHits();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        float GetExpectedSalvoHits();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        float GetArmorDamageInflictedPerHit();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        float GetHealthDamageInflictedPerHit();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        float GetHealthDamageMitigatedPerHit();
    }
}