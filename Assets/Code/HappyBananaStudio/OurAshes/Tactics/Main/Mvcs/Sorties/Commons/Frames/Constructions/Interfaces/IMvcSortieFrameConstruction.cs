using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Simulations.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Formations.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Maps.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Rosters.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Scores.Interfaces;

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
        IFormationConstruction GetFormationConstruction();

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