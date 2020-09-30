/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Maps.Game;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Maps.Game;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Maps.Game;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Mvc.Models;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Constants.Maps.Game;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Unity;
using Assets.Code.HappyBananaStudio.OurAshesTactics.GameMap.Objects;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.GameMap.Scripts
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
        private IGameMapObject gameMapObject;

        // Todo
        private IGameMapConstructionReport mapConstructionReport;

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
                    this.mapConstructionReport = gameMapInformationReport;

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
            return this.mapConstructionReport != null &&
                this.gameMapObject != null;
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void BuildLayerLevelGameObjects()
        {
            for (int i = 0; i < this.gameMapObject.GetMaxDistanceFromCenter() + 1; ++i)
            {
                GameObject layerLevelGameObject = new GameObject(GameMapConstants.Script.GetGameMapLayerLevelGameObjectPrefix() + i);
                layerLevelGameObject.transform.SetParent(this.transform);
            }
        }
    }
}