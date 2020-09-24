/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Util;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Constants;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Reports;
using System;
using System.Diagnostics;
using UnityEngine;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Impl
{
    /// <summary>
    /// HexTile Script Impl
    /// </summary>
    public class HexTileScriptImpl
    : HexTileScript
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Common.Logging.Logger logger = new Common.Logging.Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private HexTileConstructionReport hexTileConstructionReport = null;

        // Todo
        private IHexTileObject hexTileObject = null;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override IHexTileObject GetHexTileObject()
        {
            return this.hexTileObject;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="hexTileConstructionReport"></param>
        public override void Initialize(HexTileConstructionReport hexTileConstructionReport)
        {
            if (!this.IsInitialized())
            {
                if (hexTileConstructionReport != null)
                {
                    logger.Info("Initializing: ?", this.GetType());
                    this.hexTileConstructionReport = hexTileConstructionReport;

                    this.hexTileObject = new HexTileObjectImpl(this, this.hexTileConstructionReport);
                    this.UpdateTilePosition();
                    this.SetGameObjectName();
                }
                else
                {
                    throw new ArgumentException("Unable to initialize " + this.GetType() + ". Invalid Parameters." +
                        "\n\t>" + typeof(HexTileConstructionReport) + "=" + hexTileConstructionReport);
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
            return this.hexTileConstructionReport != null &&
                this.hexTileObject != null;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Todo
        /// </summary>
        private void SetGameObjectName()
        {
            this.name = HexTileScriptConstants.GetHexTileGameObjectNamePrefix() +
                this.hexTileConstructionReport.GetCubeCoordinates().ToString();
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void UpdateTilePosition()
        {
            Vector3 tileGameObjectWorldPosition = CubeCoordinatesPositionUtil.CubeCoordinatesToWorldVector(
                this.hexTileConstructionReport.GetCubeCoordinates());
            this.transform.position = tileGameObjectWorldPosition;
        }

        #endregion Private Methods
    }
}