/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Cube;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Api;
using HappyBananaStudio.OurAshesTactics.Pathing.Object.Api;
using HappyBananaStudio.OurAshesTactics.Pathing.Object.Impl;
using HappyBananaStudio.OurAshesTactics.Talon.Attributes.Reports;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Talon.Behavior.Api
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ITalonBehaviorFireable
    {
        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="index">         </param>
        /// <param name="weaponBehavior"></param>
        void AddWeapon(int index, IWeaponBehavior weaponBehavior);

        /// <summary>
        /// Todo
        /// </summary>
        void BeginPathFinding();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        FireableAttributesReport GetFireableAttributesReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="targetRange"></param>
        /// <returns></returns>
        int GetMaxAccuracyPenalty(int targetRange);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        HashSet<IPathObject> GetPathObjectFireSet();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObjectFire"></param>
        /// <returns></returns>
        TalonCombatOrderReport GetTalonCombatOrderReport(PathObjectFire pathObjectFire);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        void SetCubeCoodinates(CubeCoordinates cubeCoordinates);

        #endregion Public Methods
    }
}