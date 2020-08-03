using UnityEngine;

/// <summary>
/// WeaponVisual Implementation
/// </summary>
public class WeaponVisualImpl
    : WeaponVisual
{
    #region Private Fields

    // Todo
    private readonly TalonPaintSchemeReport paintSchemeReport;

    // Todo
    private readonly WeaponAnimator weaponAnimator;

    // Todo
    private readonly GameObject weaponGameObject;

    // Todo
    private readonly WeaponIdEnum weaponId;

    // Todo
    private readonly WeaponModel weaponModel;

    #endregion Private Fields

    #region Public Constructors

    public WeaponVisualImpl(WeaponScript weaponScript, WeaponConstructionReport weaponConstructionReport)
    {
        this.weaponId = weaponConstructionReport.GetWeaponId();
        this.paintSchemeReport = weaponConstructionReport.GetPaintSchemeReport();
        this.weaponGameObject = weaponScript.GetGameObject();
        this.weaponAnimator = new WeaponAnimator();
        this.weaponModel = new WeaponModel(this.weaponId, this.weaponGameObject);
    }

    #endregion Public Constructors

    #region Public Methods

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override GameObject GetWeaponGameObject()
    {
        return this.weaponGameObject;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override WeaponIdEnum GetWeaponId()
    {
        return this.weaponId;
    }

    public override void PaintWeapon()
    {
        //TalonPainterUtil.PaintMechGameObject(this.weaponGameObject, this.paintSchemeReport);
    }

    #endregion Public Methods
}