/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Paths.Object;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Weapons.Objects;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Action;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Combat;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Turn;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Talons;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Talons.Objects
{
    /// <summary>
    /// Talon Object Api
    /// </summary>
    public interface ITalonObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="index">
        /// </param>
        /// <param name="weaponObject">
        /// </param>
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
        /// <returns>
        /// </returns>
        ICubeCoordinates GetCubeCoordinates();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonTurnInformationReport GetTalonActionInformationReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObjectFire">
        /// </param>
        /// <returns>
        /// </returns>
        ITalonCombatOrderReport GetTalonCombatOrderReport(IPathObject pathObject);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonInformationReport GetTalonInformationReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonScript GetTalonScript();

        /// <summary>
        /// Todo
        /// </summary>
        void Initialize();

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
        /// <returns>
        /// </returns>
        bool IsInitialized();

        /// <summary>
        /// Todo
        /// </summary>
        void ResetTalonBehaviorMoveable();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        void SetCubeCoordinates(ICubeCoordinates cubeCoordinates);
    }
}