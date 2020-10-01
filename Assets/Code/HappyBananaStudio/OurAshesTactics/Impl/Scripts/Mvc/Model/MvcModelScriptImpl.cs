/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Mvc.Models;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Maps.Game;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Rosters;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Maps.Game;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Mvc.Frameworks;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Mvc.Models;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Rosters;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Constants.Maps.Game;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Constants.Mvc.Models;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Constants.Rosters;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Unity;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Objects.Mvc.Models;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Scripts.Maps.Game;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Scripts.Rosters;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Scripts.Mvc.Model
{
    /// <summary>
    /// MvcModel Script Impl
    /// </summary>
    public class MvcModelScriptImpl
    : UnityScript, IMvcModelScript
    {
        // Provide logging capability
        private static readonly Common.Loggers.Logger logger = new Common.Loggers.Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private IGameMapScript mapScript;

        // Todo
        private IMvcFrameworkScript mvcFrameworkScript;

        // Todo
        private IMvcModelObject mvcModelObject;

        // Todo
        private IRosterScript rosterScript;

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IMvcModelObject GetMvcModelObject()
        {
            return this.mvcModelObject;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameworkScript">
        /// </param>
        /// <param name="gameMapInformationReport">
        /// </param>
        /// <param name="rosterConstructionReport">
        /// </param>
        public void Initialize(IMvcFrameworkScript mvcFrameworkScript,
            IGameMapConstructionReport gameMapInformationReport,
            IRosterConstructionReport rosterConstructionReport)
        {
            logger.Info("Initializing: ?", this.GetType());
            if (!this.IsInitialized())
            {
                if (mvcFrameworkScript != null &&
                gameMapInformationReport != null &&
                rosterConstructionReport != null)
                {
                    logger.Info("Setting: ?", typeof(IMvcFrameworkScript));
                    this.mvcFrameworkScript = mvcFrameworkScript;

                    this.BuildMechCollectionGameObject();

                    this.mapScript = this.BuildMap();
                    this.mapScript.Initialize(this, gameMapInformationReport);

                    this.rosterScript = this.BuildRoster();
                    this.rosterScript.Initialize(this, rosterConstructionReport);

                    this.mvcModelObject = new MvcModelObjectImpl(this,
                        this.mapScript.GetGameMapObject(), this.rosterScript.GetRosterObject());
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. " +
                        "\n\t> ? is null: ?" +
                        "\n\t> ? is null: ?" +
                        "\n\t> ? is null: ?", new StackFrame().GetMethod().Name,
                        typeof(IMvcFrameworkScript), (mvcFrameworkScript == null),
                        typeof(IGameMapConstructionReport), (gameMapInformationReport == null),
                        typeof(IRosterConstructionReport), (rosterConstructionReport == null));
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
        /// <returns>
        /// </returns>
        public bool IsInitialized()
        {
            return this.mvcFrameworkScript != null &&
                this.mvcModelObject != null;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        private IGameMapScript BuildMap()
        {
            logger.Info("Building: ?", typeof(IGameMapScript));
            GameObject mapGameObject = new GameObject(GameMapConstants.Script.GetGameMapGameObjectName());
            IGameMapScript mapScript = mapGameObject.AddComponent<GameMapScriptImpl>();
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
        /// <returns>
        /// </returns>
        private IRosterScript BuildRoster()
        {
            logger.Info("Building: ?", typeof(IRosterScript));
            GameObject rosterGameObject = new GameObject(RosterConstants.Script.GetRosterGameObjectName());
            IRosterScript rosterScript = rosterGameObject.AddComponent<RosterScriptImpl>();
            rosterGameObject.transform.SetParent(this.transform);
            return rosterScript;
        }
    }
}