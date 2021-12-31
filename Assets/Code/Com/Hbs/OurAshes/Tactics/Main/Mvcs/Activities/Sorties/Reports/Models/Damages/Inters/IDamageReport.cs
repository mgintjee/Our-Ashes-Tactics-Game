using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Destructibles.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Fireables.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Reports.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Gears.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Damages.Inters
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