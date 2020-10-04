/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Talons.Objects;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Weapons.Objects;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Scripts.Unity;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Objects.Talons;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Scripts.Talons
{
    /// <summary>
    /// Talon Script Impl
    /// </summary>
    public class TalonScriptImpl
    : UnityScript, ITalonScript
    {
        // Provide logging capability
        private static readonly Common.Loggers.Logger logger = new Common.Loggers.Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private FactionIdEnum factionId = FactionIdEnum.None;

        // Todo
        private PhalanxIdEnum phalanxId = PhalanxIdEnum.None;

        // Todo
        private ITalonCanvasScript talonCanvasScript = null;

        // Todo
        private ITalonConstructionReport talonConstructionReport = null;

        // Todo
        private ITalonObject talonObject = null;

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public ITalonObject GetTalonObject()
        {
            return this.talonObject;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonConstructionReport">
        /// </param>
        /// <param name="weaponObjectList">
        /// </param>
        public void Initialize(FactionIdEnum factionId, PhalanxIdEnum phalanxId,
            ITalonConstructionReport talonConstructionReport, List<IWeaponObject> weaponObjectList)
        {
            // Check that this has not already been initialized
            if (!this.IsInitialized())
            {
                // Check that the parameters are non-null
                if (talonConstructionReport != null)
                {
                    this.factionId = factionId;
                    this.phalanxId = phalanxId;
                    // this.name = talonConstructionReport.GetTalonIdentificationReport().GetTalonId().ToString();
                    this.talonConstructionReport = talonConstructionReport;
                    this.talonObject = new TalonObjectImpl(this, this.talonConstructionReport);
                    this.talonObject.Initialize();
                    for (int i = 0; i < weaponObjectList.Count; ++i)
                    {
                        logger.Debug("Adding ?[?]=?", typeof(IWeaponObject), i, weaponObjectList[i].GetWeaponId());
                        this.talonObject.AddWeapon(i, weaponObjectList[i]);
                    }
                    this.talonObject.ApplyPaintScheme();
                    this.talonCanvasScript = this.transform.Find("talonCanvasGameObject").GetComponent<ITalonCanvasScript>();
                    this.talonCanvasScript.Initialize(this.talonObject);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to initialize ?. Invalid Parameters. " +
                        "\n\t> ? is null.", this.GetType(), typeof(ITalonConstructionReport));
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
        /// <returns>
        /// </returns>
        public bool IsInitialized()
        {
            return this.talonConstructionReport != null &&
                this.talonObject != null;
        }
    }
}