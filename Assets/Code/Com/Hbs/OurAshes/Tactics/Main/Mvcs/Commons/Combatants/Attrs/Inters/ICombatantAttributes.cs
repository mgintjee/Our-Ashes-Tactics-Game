using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attrs.Destructibles.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attrs.Fireables.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attrs.Mountables.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attrs.Movables.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attrs.Inters
{
    /// <summary>
    /// Combatant Attributes Interface
    /// </summary>
    public interface ICombatantAttributes
    {
        IDestructibleAttributes GetDestructibleAttributes();

        IFireableAttributes GetFireableAttributes();

        IMountableAttributes GetMountableAttributes();

        IMovableAttributes GetMovableAttributes();
    }
}