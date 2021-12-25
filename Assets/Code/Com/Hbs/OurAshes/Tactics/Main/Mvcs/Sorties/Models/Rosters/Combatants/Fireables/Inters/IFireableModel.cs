using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Fireables.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Combatants.Characteristics.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Combatants.Fireables.Inters
{
    /// <summary>
    /// Fireable Model Interface
    /// </summary>
    public interface IFireableModel : ICharacteristicModel
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IFireableAttributes GetCurrentAttributes();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IFireableAttributes GetMaximumAttributes();
    }
}