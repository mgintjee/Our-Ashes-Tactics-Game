/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Weapons.Objects;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Talons.Visuals
{
    /// <summary>
    /// Talon Visual Api
    /// </summary>
    public interface ITalonVisual
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="index">
        /// </param>
        /// <param name="weaponObject">
        /// </param>
        void AddWeaponObject(int index, IWeaponObject weaponObject);

        /// <summary>
        /// Todo
        /// </summary>
        void ApplyPaintScheme();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="hexTileType">
        /// </param>
        void PaintBase(HexTileTypeEnum hexTileType);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        void SetCubeCoordinates(ICubeCoordinates cubeCoordinates);
    }
}