using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Controllers.AIs.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Controllers.Types;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combatants.Constructions.Controllers.Interfaces
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ICombatantControllerConstruction
    {
        CombatantCallSign GetCombatantCallSign();

        ControllerID GetControllerType();

        AIType GetAIType();
    }
}