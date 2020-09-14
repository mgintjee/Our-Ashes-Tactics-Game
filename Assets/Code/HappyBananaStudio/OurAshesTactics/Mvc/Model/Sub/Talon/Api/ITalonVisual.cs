/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/


using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Cube;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Enums;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Api;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Api
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
        /// <param name="weaponObject"></param>
        void AddWeaponObject(IWeaponObject weaponObject);
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