using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Cube.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Orders.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Mounts.Weapons.Attributes.Api;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Objects.Subs.Fireables.Api
{
    /// <summary>
    /// Fireable Object Api
    /// </summary>
    public interface IFireableObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IList<IWeaponAttributes> GetWeaponAttributesList();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        /// <returns>
        /// </returns>
        ISet<ITalonOrderFireReport> GetTalonOrderFireReportSet(ICubeCoordinates cubeCoordinates);

        /// <summary>
        /// Todo
        /// </summary>
        void ResetForNewPhase();
    }
}