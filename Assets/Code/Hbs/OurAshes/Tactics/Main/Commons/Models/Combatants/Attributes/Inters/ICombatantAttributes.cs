using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Destructibles.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Fireables.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Loadouts.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Movables.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Inters
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