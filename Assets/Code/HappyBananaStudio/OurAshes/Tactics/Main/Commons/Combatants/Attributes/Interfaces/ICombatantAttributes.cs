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
        IDestructibleAttributes GetDestructibleAttributes();

        IFireableAttributes GetFireableAttributes();

        ILoadoutAttributes GetLoadoutAttributes();

        IMovableAttributes GetMovableAttributes();
    }
}