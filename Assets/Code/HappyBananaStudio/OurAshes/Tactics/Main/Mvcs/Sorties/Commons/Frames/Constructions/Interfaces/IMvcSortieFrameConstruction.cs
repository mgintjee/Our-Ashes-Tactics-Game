using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Simulations.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Engagements.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Rosters.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Constructions.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Interfaces
{
    /// <summary>
    /// Mvc Sortie Frame Construction Interface
    /// </summary>
    public interface IMvcSortieFrameConstruction
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IEngagementConstruction GetFormationConstruction();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IMapConstruction GetMapConstruction();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IRosterConstruction GetRosterConstruction();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IScoreConstruction GetScoreConstruction();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IUnityScript GetUnityScript();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        SimulationType GetSimulationType();
    }
}