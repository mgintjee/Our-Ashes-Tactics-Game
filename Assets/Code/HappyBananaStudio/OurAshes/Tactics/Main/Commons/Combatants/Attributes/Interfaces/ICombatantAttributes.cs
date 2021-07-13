using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Attributes.Destructibles.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Attributes.Fireables.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Attributes.Loadouts.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Attributes.Movables.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Attributes.Interfaces
{
    /// <summary>
    /// Combatant Attributes Interface
    /// </summary>
    public interface ICombatantAttributes
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IDestructibleAttributes GetDestructibleAttributes();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IFireableAttributes GetFireableAttributes();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ILoadoutAttributes GetLoadoutAttributes();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IMovableAttributes GetMovableAttributes();
    }
}