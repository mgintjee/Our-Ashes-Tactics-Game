/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Framework.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Constants;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Map.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Map.Constants;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Map.Impl;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Map.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Roster.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Roster.Constants;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Roster.Impl;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Roster.Reports;
using System;
using System.Diagnostics;
using UnityEngine;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Impl
{
    /// <summary>
    /// MvcModel Script Impl
    /// </summary>
    public class MvcModelScriptImpl
    : MvcModelScript
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Common.Logging.Logger logger = new Common.Logging.Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private MapScript mapScript;

        // Todo
        private MvcFrameworkScript mvcFrameworkScript;

        // Todo
        private IMvcModelObject mvcModelObject;

        // Todo
        private RosterScript rosterScript;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override IMvcModelObject GetMvcModelObject()
        {
            return this.mvcModelObject;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameworkScript">      </param>
        /// <param name="mapInformationReport">    </param>
        /// <param name="rosterConstructionReport"></param>
        public override void Initialize(MvcFrameworkScript mvcFrameworkScript,
            MapConstructionReport mapInformationReport,
            RosterConstructionReport rosterConstructionReport)
        {
            logger.Info("Initializing: ?", this.GetType());
            if (!this.IsInitialized())
            {
                if (mvcFrameworkScript != null &&
                mapInformationReport != null &&
                rosterConstructionReport != null)
                {
                    logger.Info("Setting: ?", typeof(MvcFrameworkScript));
                    this.mvcFrameworkScript = mvcFrameworkScript;

                    this.BuildMechCollectionGameObject();

                    this.mapScript = this.BuildMap();
                    this.mapScript.Initialize(this, mapInformationReport);

                    this.rosterScript = this.BuildRoster();
                    this.rosterScript.Initialize(this, rosterConstructionReport);

                    this.mvcModelObject = new MvcModelObjectImpl(this,
                        this.mapScript.GetMapObject(), this.rosterScript.GetRosterObject());
                }
                else
                {
                    throw new ArgumentException("Unable to initialize ?" + this.GetType() + ". Invalid Parameters." +
                        "\n\t>" + typeof(MvcFrameworkScript) + " is null: " + (mvcFrameworkScript == null) +
                        "\n\t>" + typeof(MapConstructionReport) + " is null: " + (mapInformationReport == null) +
                        "\n\t>" + typeof(RosterConstructionReport) + " is null: " + (rosterConstructionReport == null));
                }
            }
            else
            {
                logger.Warn("Unable to Initialize: ?. Already initialized.", this.GetType());
            }
        }

        /// <summary>
        /// Tod
        /// </summary>
        /// <returns></returns>
        public override bool IsInitialized()
        {
            return this.mvcFrameworkScript != null &&
                this.mvcModelObject != null;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private MapScript BuildMap()
        {
            logger.Info("Building: ?", typeof(MapScript));
            GameObject mapGameObject = new GameObject(MapConstants.Script.GetMapGameObjectName());
            MapScript mapScript = mapGameObject.AddComponent<MapScriptImpl>();
            mapGameObject.transform.SetParent(this.transform);
            return mapScript;
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void BuildMechCollectionGameObject()
        {
            GameObject mechCollectionGameObject = new GameObject(MvcModelConstants.Script.GetTalonCollectionGameObjectName());
            mechCollectionGameObject.transform.SetParent(this.transform);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private RosterScript BuildRoster()
        {
            logger.Info("Building: ?", typeof(RosterScript));
            GameObject rosterGameObject = new GameObject(RosterConstants.Script.GetRosterGameObjectName());
            RosterScript rosterScript = rosterGameObject.AddComponent<RosterScriptImpl>();
            rosterGameObject.transform.SetParent(this.transform);
            return rosterScript;
        }

        #endregion Private Methods
    }
}