/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Maps.Game;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Maps.Game;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Maps.Game;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Mvc.Models;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Constants.Maps.Game;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Scripts.Unity;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Objects.Maps.Game;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Scripts.Maps.Game
{
    /// <summary>
    /// Map Script Impl
    /// </summary>
    public class GameMapScriptImpl
    : UnityScript, IGameMapScript
    {
        // Provide logging capability
        private static readonly Common.Loggers.Logger logger = new Common.Loggers.Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private IGameMapConstructionReport gameMapConstructionReport;

        // Todo
        private IGameMapObject gameMapObject;

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IGameMapObject GetGameMapObject()
        {
            return this.gameMapObject;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mcvModelScript">
        /// </param>
        /// <param name="gameMapInformationReport">
        /// </param>
        public void Initialize(IMvcModelScript mcvModelScript, IGameMapConstructionReport gameMapInformationReport)
        {
            logger.Info("Initializing: ?.", this.GetType());
            if (!this.IsInitialized())
            {
                if (mcvModelScript != null &&
                gameMapInformationReport != null)
                {
                    this.gameMapConstructionReport = gameMapInformationReport;

                    this.BuildLayerLevelGameObjects();

                    this.gameMapObject = new GameMapObjectImpl(this, gameMapInformationReport);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. " +
                        "\n\t> ? is null: ?" +
                        "\n\t> ? is null: ?",
                        new StackFrame().GetMethod().Name,
                        typeof(IMvcModelScript), (mcvModelScript == null),
                        typeof(IGameMapConstructionReport), (gameMapInformationReport == null));
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
            return this.gameMapConstructionReport != null &&
                this.gameMapObject != null;
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void BuildLayerLevelGameObjects()
        {
            int maxDistanceFromCenter = 0;
            foreach (ICubeCoordinates cubeCoordinates in this.gameMapConstructionReport.GetCubeCoordinatesSet())
            {
                int distanceFromCenter = CubeCoordinatesCommonUtil.GetCubeCoordinatesDistanceFromCenter(cubeCoordinates);
                if (distanceFromCenter > maxDistanceFromCenter)
                {
                    maxDistanceFromCenter = distanceFromCenter;
                }
            }

            for (int i = 0; i < maxDistanceFromCenter + 1; ++i)
            {
                GameObject layerLevelGameObject = new GameObject(GameMapConstants.Script.GetGameMapLayerLevelGameObjectPrefix() + i);
                layerLevelGameObject.transform.SetParent(this.transform);
            }
        }
    }
}