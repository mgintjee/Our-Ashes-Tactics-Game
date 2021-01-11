namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Objects.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Weapons.Attributes.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Reports.Api;
    using System.Collections.Generic;

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