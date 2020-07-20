/// <summary>
/// Todo
/// </summary>
public abstract class MechVisual
{
    #region Public Methods

    public abstract void AddWeapon(WeaponVisual weaponVisual);

    public abstract MechIdEnum GetMechId();

    public abstract void PaintBase(TileTypeEnum tileObjectType);

    public abstract void PaintMech();

    public abstract void UpdateMechCanvas();

    #endregion Public Methods
}