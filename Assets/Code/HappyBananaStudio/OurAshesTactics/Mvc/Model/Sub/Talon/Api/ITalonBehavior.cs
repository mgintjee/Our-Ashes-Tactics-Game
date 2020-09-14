/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Cube;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Api;
using HappyBananaStudio.OurAshesTactics.Pathing.Object.Impl;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Api
{
    /// <summary>
    /// Talon Behavior Api
    /// </summary>
    public interface ITalonBehavior
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponBehavior"></param>
        void AddWeaponBehavior(IWeaponBehavior weaponBehavior);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        CubeCoordinates GetCubeCoordinates();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        HashSet<TalonActionOrderReport> GetPossibleTalonActionOrderReportSet();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        TalonAttributesReport GetTalonAttributesReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObjectFire"></param>
        /// <returns></returns>
        TalonCombatOrderReport GetTalonCombatOrderReport(PathObjectFire pathObjectFire);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonActionOrderReport"></param>
        /// <returns></returns>
        TalonActionResultReport InputTalonActionOrderReport(TalonActionOrderReport talonActionOrderReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCombatOrderReport"></param>
        /// <returns></returns>
        TalonCombatResultReport InputTalonCombatOrderReport(TalonCombatOrderReport talonCombatOrderReport);

        /// <summary>
        /// Todo
        /// </summary>
        void ResetForNewTurn();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        void SetCubeCoordinates(CubeCoordinates cubeCoordinates);
    }
}