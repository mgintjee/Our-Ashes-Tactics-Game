using System.Diagnostics;
using UnityEngine;

/// <summary>
/// MechVisual implementation
/// </summary>
public class MechVisualImpl
    : MechVisual
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    // MechAnimator that tracks the MechAnimator aspects for this Mech
    private readonly MechAnimator mechAnimator;

    // MechCanvas that tracks the MechCanvas aspects for this Mech
    private readonly MechCanvas mechCanvas;

    // Todo
    private readonly GameObject mechGameObject;

    private readonly MechIdEnum mechId;

    // MechModel that tracks the MechModel aspects for this Mech
    private readonly MechModel mechModel;

    private readonly PaintSchemeReport paintSchemeReport;

    #endregion Private Fields

    #region Public Constructors

    public MechVisualImpl(MechScript mechScript, MechConstructionReport mechConstructionReport)
    {
        this.mechId = mechConstructionReport.GetMechId();
        this.mechGameObject = mechScript.GetGameObject();
        this.paintSchemeReport = mechConstructionReport.GetPaintSchemeReport();
        this.mechAnimator = new MechAnimator();
        this.mechCanvas = new MechCanvasImpl(mechScript, mechConstructionReport);
        this.mechModel = new MechModel(this.mechId, this.mechGameObject);
    }

    #endregion Public Constructors

    #region Public Methods

    public override void AddWeapon(WeaponVisual weaponVisual)
    {
        if (weaponVisual != null)
        {
            logger.Debug("Adding WeaponVisual: WeaponName=?, to MechVisual: MechId=?", weaponVisual.GetWeaponId(), this.GetMechId());
            GameObject weaponMountGameObject = this.mechModel.GetNextEmptyWeaponMountGameObject();
            // Todo Paint the weapon Here
            if (weaponMountGameObject != null)
            {
                GameObject weaponGameObject = weaponVisual.GetWeaponGameObject();
                weaponGameObject.transform.parent = weaponMountGameObject.transform;
                weaponGameObject.transform.localPosition = Vector3.zero;
                weaponGameObject.transform.localScale = Vector3.one;
            }
            else
            {
                logger.Warn("Unable to add WeaponVisual to Mech: MechName=?. MechModel has no more free WeaponMounts.", this.GetMechId());
            }
        }
        else
        {
            logger.Warn("Unable to add WeaponVisual to Mech: MechName=?. WeaponVisual is null.", this.GetMechId());
        }
    }

    public override MechIdEnum GetMechId()
    {
        return this.mechId;
    }

    public override void PaintBase(TileTypeEnum tileObjectType)
    {
        PainterUtil.PaintMechGameObjectBase(this.mechGameObject, tileObjectType);
    }

    public override void PaintMech()
    {
        PainterUtil.PaintMechGameObject(this.mechGameObject, this.paintSchemeReport);
    }

    public override void UpdateMechCanvas()
    {
        this.mechCanvas.UpdateCanvasDisplay();
    }

    #endregion Public Methods
}