/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Cube;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Api;
using HappyBananaStudio.OurAshesTactics.Pathing.Object.Impl;

namespace HappyBananaStudio.OurAshesTactics.Talon.Object.Api
{
    /// <summary>
    /// Talon Object Api
    /// </summary>
    public interface ITalonObject
    {
        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="index"></param>
        /// <param name="weaponObject"></param>
        void AddWeapon(int index, IWeaponObject weaponObject);

        /// <summary>
        /// Todo
        /// </summary>
        void ApplyPaintScheme();

        /// <summary>
        /// Todo
        /// </summary>
        void Deactivate();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        CubeCoordinates GetCubeCoordinates();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        TalonActionInformationReport GetTalonActionInformationReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObjectFire"></param>
        /// <returns></returns>
        TalonCombatOrderReport GetTalonCombatOrderReport(PathObjectFire pathObjectFire);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        TalonInformationReport GetTalonInformationReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        TalonScript GetTalonScript();

        /// <summary>
        /// Todo
        /// </summary>
        void Initialize();

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
        /// <returns></returns>
        bool IsInitialized();

        /// <summary>
        /// Todo
        /// </summary>
        void ResetTalonBehaviorMoveable();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        void SetCubeCoordinates(CubeCoordinates cubeCoordinates);

        #endregion Public Methods
    }
}