using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Destructibles.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Fireables.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Loadouts.Reports.Gears.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combats.Damages.Reports.Interfaces
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IDamageReport
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