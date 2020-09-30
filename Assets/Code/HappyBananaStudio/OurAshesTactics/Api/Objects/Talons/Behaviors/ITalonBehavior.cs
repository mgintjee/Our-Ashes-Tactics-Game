/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Paths.Object;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Weapons.Behaviors;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Action;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Attributes;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Combat;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Talons.Behaviors
{
    /// <summary>
    /// Talon Behavior Api
    /// </summary>
    public interface ITalonBehavior
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="index">
        /// </param>
        /// <param name="weaponBehavior">
        /// </param>
        void AddWeaponBehavior(int index, IWeaponBehavior weaponBehavior);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ICubeCoordinates GetCubeCoordinates();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        HashSet<ITalonActionOrderReport> GetPossibleTalonActionOrderReportSet();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonAttributesReport GetTalonAttributesReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObjectFire">
        /// </param>
        /// <returns>
        /// </returns>
        ITalonCombatOrderReport GetTalonCombatOrderReport(IPathObject pathObjectFire);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonActionOrderReport">
        /// </param>
        /// <returns>
        /// </returns>
        ITalonActionResultReport InputTalonActionOrderReport(ITalonActionOrderReport talonActionOrderReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCombatOrderReport">
        /// </param>
        /// <returns>
        /// </returns>
        ITalonCombatResultReport InputTalonCombatOrderReport(ITalonCombatOrderReport talonCombatOrderReport);

        /// <summary>
        /// Todo
        /// </summary>
        void ResetForNewTurn();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        void SetCubeCoordinates(ICubeCoordinates cubeCoordinates);
    }
}