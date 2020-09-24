/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Cube;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Enums;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Api;

namespace HappyBananaStudio.OurAshesTactics.Talon.Visual.Api
{
    /// <summary>
    /// Talon Visual Api
    /// </summary>
    public interface ITalonVisual
    {
        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="index"></param>
        /// <param name="weaponObject"></param>
        void AddWeaponObject(int index, IWeaponObject weaponObject);

        /// <summary>
        /// Todo
        /// </summary>
        void ApplyPaintScheme();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="hexTileType"></param>
        void PaintBase(HexTileTypeEnum hexTileType);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        void SetCubeCoordinates(CubeCoordinates cubeCoordinates);

        #endregion Public Methods
    }
}