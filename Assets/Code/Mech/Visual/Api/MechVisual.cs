/// <summary>
/// Todo
/// </summary>
public abstract class MechVisual
{
    #region Public Methods

    public abstract void AddWeapon(WeaponVisual weaponVisual);

    public abstract MechIdEnum GetMechId();

    public abstract void PaintBase(TileObjectTypeEnum tileObjectType);

    public abstract void PaintMech();

    #endregion Public Methods
}