/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Model.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Map.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Map.Constants;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Map.Reports;
using System;
using System.Diagnostics;
using UnityEngine;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Map.Impl
{
    /// <summary>
    /// Map Script Impl
    /// </summary>
    public class MapScriptImpl
    : MapScript
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Common.Logging.Logger logger = new Common.Logging.Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private MapConstructionReport mapConstructionReport;

        // Todo
        private IMapObject mapObject;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override IMapObject GetMapObject()
        {
            return this.mapObject;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mcvModelScript">      </param>
        /// <param name="mapInformationReport"></param>
        public override void Initialize(MvcModelScript mcvModelScript, MapConstructionReport mapInformationReport)
        {
            logger.Info("Initializing: ?.", this.GetType());
            if (!this.IsInitialized())
            {
                if (mcvModelScript != null &&
                mapInformationReport != null)
                {
                    this.mapConstructionReport = mapInformationReport;

                    this.BuildLayerLevelGameObjects();

                    this.mapObject = new MapObjectImpl(this, mapInformationReport);
                }
                else
                {
                    throw new ArgumentException("Unable to initialize " + this.GetType() + ". Invalid Parameters." +
                        "\n\t>" + typeof(MvcModelScript) + "=" + mcvModelScript +
                        "\n\t>" + typeof(MapConstructionReport) + "=" + mapInformationReport);
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
            return this.mapConstructionReport != null &&
                this.mapObject != null;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Todo
        /// </summary>
        private void BuildLayerLevelGameObjects()
        {
            for (int i = 0; i < this.mapConstructionReport.GetMapRadius() + 1; ++i)
            {
                GameObject layerLevelGameObject = new GameObject(MapConstants.Script.GetMapLayerLevelGameObjectPrefix() + i);
                layerLevelGameObject.transform.SetParent(this.transform);
            }
        }

        #endregion Private Methods
    }
}