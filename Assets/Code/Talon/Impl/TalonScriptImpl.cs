using System;
using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// Talon Script Impl
/// </summary>
public class TalonScriptImpl
    : TalonScript
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private TalonConstructionReport talonConstructionReport = null;
    private TalonObject talonObject = null;

    #endregion Private Fields

    #region Public Methods

    public override TalonObject GetTalonObject()
    {
        return this.talonObject;
    }

    public override void Initialize(TalonConstructionReport talonConstructionReport, List<WeaponObject> weaponObjectList)
    {
        // Check that this has not already been initialized
        if (!this.IsInitialized())
        {
            // Check that the parameters are non-null
            if (talonConstructionReport != null)
            {
                logger.Info("Initializing: ?.", this.GetType());
                this.name = talonConstructionReport.GetTalonIdentificationReport().GetTalonName();
                this.talonConstructionReport = talonConstructionReport;
                logger.Debug("?", talonConstructionReport.GetTalonPaintSchemeReport());
                this.talonObject = new TalonObjectImpl(this, this.talonConstructionReport);
                this.talonObject.Initialize();
                foreach(WeaponObject weaponObject in weaponObjectList)
                {
                    this.talonObject.AddWeapon(weaponObject);
                }
            }
            else
            {
                throw new ArgumentException("Unable to initialize " + this.GetType() + ". Invalid Parameters." +
                    "\n\t>" + typeof(TalonConstructionReport) + " is null.");
            }
        }
        else
        {
            logger.Warn("Unable to Initialize: ?. Already initialized.", this.GetType());
        }
    }


    public override bool IsInitialized()
    {
        return this.talonConstructionReport != null &&
            this.talonObject != null;
    }

    #endregion Public Methods
}