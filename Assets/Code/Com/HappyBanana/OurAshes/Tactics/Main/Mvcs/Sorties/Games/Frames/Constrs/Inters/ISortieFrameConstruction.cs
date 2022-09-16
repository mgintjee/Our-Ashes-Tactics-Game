using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Games.Frames.Constrs.Inters
{
    /// <summary>
    /// Sortie Frame Construction Interface
    /// </summary>
    public interface ISortieFrameConstruction : IMvcFrameConstruction
    {
        IFieldDetails GetFieldDetails();

        ICombatantsDetails GetCombatantsDetails();
    }
}