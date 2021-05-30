using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Formations.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Phalanxes.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Formations.Interfaces
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IFormationConstruction
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        FormationType GetFormationType();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<IPhalanxConstruction> GetPhalanxConstructions();
    }
}