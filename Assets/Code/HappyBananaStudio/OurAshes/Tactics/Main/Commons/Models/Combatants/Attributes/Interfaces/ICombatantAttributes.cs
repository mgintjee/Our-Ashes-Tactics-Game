namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Interfaces
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