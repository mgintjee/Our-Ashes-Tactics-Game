/// <summary>
/// Talon Visual Api
/// </summary>
public abstract class TalonVisual
{
    #region Public Methods

    public abstract void AddWeapon(WeaponVisual weaponVisual);

    public abstract void PaintBase(HexTileTypeEnum hexTileType);

    public abstract void SetCubeCoordinates(CubeCoordinates cubeCoordinates);

    public abstract void UpdateMechCanvas();

    #endregion Public Methods
}