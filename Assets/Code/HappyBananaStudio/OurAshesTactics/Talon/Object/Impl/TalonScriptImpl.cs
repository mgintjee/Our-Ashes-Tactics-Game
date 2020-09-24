/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using HappyBananaStudio.OurAshesTactics.Common.Logging;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Api;
using HappyBananaStudio.OurAshesTactics.Talon.Object.Api;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace HappyBananaStudio.OurAshesTactics.Talon.Object.Impl
{
    /// <summary>
    /// Talon Script Impl
    /// </summary>
    public class TalonScriptImpl
    : TalonScript
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);
        // Todo
        private TalonConstructionReport talonConstructionReport = null;
        // Todo
        private ITalonObject talonObject = null;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override ITalonObject GetTalonObject()
        {
            return this.talonObject;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonConstructionReport"></param>
        /// <param name="weaponObjectList">       </param>
        public override void Initialize(TalonConstructionReport talonConstructionReport, List<IWeaponObject> weaponObjectList)
        {
            // Check that this has not already been initialized
            if (!this.IsInitialized())
            {
                // Check that the parameters are non-null
                if (talonConstructionReport != null)
                {
                    logger.Info("Initializing: ?.", this.GetType());
                    this.name = talonConstructionReport.GetTalonIdentificationReport().GetTalonId().ToString();
                    this.talonConstructionReport = talonConstructionReport;
                    logger.Debug("?", talonConstructionReport.GetTalonPaintSchemeReport());
                    this.talonObject = new TalonObjectImpl(this, this.talonConstructionReport);
                    this.talonObject.Initialize();
                    for(int i = 0; i < weaponObjectList.Count; ++i)
                    {
                        logger.Debug("Adding ?[?]=?", typeof(IWeaponObject), i, weaponObjectList[i].GetWeaponId());
                        this.talonObject.AddWeapon(i, weaponObjectList[i]);
                    }
                    this.talonObject.ApplyPaintScheme();
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to initialize ?. Invalid Parameters. " +
                        "\n\t> ? is null.", this.GetType(), typeof(TalonConstructionReport));
                }
            }
            else
            {
                logger.Warn("Unable to Initialize: ?. Already initialized.", this.GetType());
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override bool IsInitialized()
        {
            return this.talonConstructionReport != null &&
                this.talonObject != null;
        }

        #endregion Public Methods
    }
}