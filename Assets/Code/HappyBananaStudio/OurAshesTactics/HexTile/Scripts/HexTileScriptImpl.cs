/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.HexTile;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.HexTiles;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.HexTiles;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Constants.HexTiles;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Unity;
using Assets.Code.HappyBananaStudio.OurAshesTactics.HexTile.Objects;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.HexTile.Scripts
{
    /// <summary>
    /// HexTile Script Impl
    /// </summary>
    public class HexTileScriptImpl
    : UnityScript, IHexTileScript
    {
        // Provide logging capability
        private static readonly Common.Loggers.Logger logger = new Common.Loggers.Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private IHexTileConstructionReport hexTileConstructionReport = null;

        // Todo
        private IHexTileObject hexTileObject = null;

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IHexTileObject GetHexTileObject()
        {
            return this.hexTileObject;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="hexTileConstructionReport">
        /// </param>
        public void Initialize(IHexTileConstructionReport hexTileConstructionReport)
        {
            if (!this.IsInitialized())
            {
                if (hexTileConstructionReport != null)
                {
                    this.hexTileConstructionReport = hexTileConstructionReport;

                    this.hexTileObject = new HexTileObjectImpl(this, this.hexTileConstructionReport);
                    this.UpdateTilePosition();
                    this.SetGameObjectName();
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is null",
                        new StackFrame().GetMethod().Name, typeof(IHexTileConstructionReport));
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
            return this.hexTileConstructionReport != null &&
                this.hexTileObject != null;
        }

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
    }
}