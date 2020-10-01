/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Rosters;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Rosters;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Mvc.Models;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Rosters;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Constants.Rosters;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Unity;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Objects.Rosters;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Scripts.Rosters
{
    /// <summary>
    /// Roster Script Impl
    /// </summary>
    public class RosterScriptImpl
    : UnityScript, IRosterScript
    {
        // Provide logging capability
        private static readonly Common.Loggers.Logger logger = new Common.Loggers.Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private IRosterConstructionReport rosterConstructionReport;

        // Todo
        private IRosterObject rosterObject;

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IRosterObject GetRosterObject()
        {
            return this.rosterObject;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mcvModelScript">
        /// </param>
        /// <param name="rosterConstructionReport">
        /// </param>
        public void Initialize(IMvcModelScript mcvModelScript, IRosterConstructionReport rosterConstructionReport)
        {
            logger.Info("Initializing: ?.", this.GetType());
            if (!this.IsInitialized())
            {
                if (mcvModelScript != null &&
                rosterConstructionReport != null)
                {
                    this.rosterConstructionReport = rosterConstructionReport;

                    this.BuildFactionPhalanxGameObjects();

                    this.rosterObject = new RosterObjectImpl(this, rosterConstructionReport);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters." +
                        "\n\t> ? is null: ?" +
                        "\n\t> ? is null: ?", this.GetType(),
                        typeof(IMvcModelScript), (mcvModelScript == null),
                        typeof(IRosterConstructionReport), (rosterConstructionReport == null));
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
            return this.rosterConstructionReport != null &&
                this.rosterObject != null;
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void BuildFactionPhalanxGameObjects()
        {
            foreach (FactionIdEnum talonFactionId in this.rosterConstructionReport.GetFactionIdPhalanxIdSetDictionary().Keys)
            {
                GameObject factionGameObject = new GameObject(RosterConstants.Script.GetFactionIdGameObjectPrefix() + talonFactionId);
                factionGameObject.transform.SetParent(this.transform);

                foreach (PhalanxIdEnum talonPhalanxId in this.rosterConstructionReport.GetFactionIdPhalanxIdSetDictionary()[talonFactionId])
                {
                    GameObject phalanxGameObject = new GameObject(RosterConstants.Script.GetPhalanxIdGameObjectPrefix() + talonPhalanxId);
                    phalanxGameObject.transform.SetParent(factionGameObject.transform);
                }
            }
        }
    }
}