/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Paths.Object;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Weapons.Behaviors;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Attributes;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Combat;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Talons.Behaviors
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ITalonBehaviorFireable
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="index">
        /// </param>
        /// <param name="weaponBehavior">
        /// </param>
        void AddWeapon(int index, IWeaponBehavior weaponBehavior);

        /// <summary>
        /// Todo
        /// </summary>
        void BeginPathFinding();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IFireableReport GetFireableAttributesReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="targetRange">
        /// </param>
        /// <returns>
        /// </returns>
        int GetMaxAccuracyPenalty(int targetRange);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        HashSet<IPathObject> GetPathObjectFireSet();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObject">
        /// </param>
        /// <returns>
        /// </returns>
        ITalonCombatOrderReport GetTalonCombatOrderReport(IPathObject pathObject);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        void SetCubeCoodinates(ICubeCoordinates cubeCoordinates);
    }
}