using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Cube.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Scripts.Unity.Abs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Talons.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.Animators.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.Animators.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.Paths.Renderer.Object.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.Paths.Renderer.Object.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.Views.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.HexTiles.Views.Collections.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.HexTiles.Views.Collections.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.HexTiles.Views.Collections.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.HexTiles.Views.Views.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Orders.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Pathing.Objects.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Views.Collections.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Views.Collections.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Views.Collections.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Views.Views.Api;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.Views.Impl
{
    /// <summary>
    /// Todo
    /// </summary>
    public class GameBoardView
        : AbstractUnityScript, IGameBoardView
    {
        // Todo
        private IHexTileViewCollection hexTileViewCollection;

        // Todo
        private ITalonViewCollection talonViewCollection;

        // Todo
        private IPathRendererObject pathRendererObject;

        // Todo
        private IAnimatorScript animatorObject;

        // Todo: Maybe have a script for the HexTileViewCollection and a script for th4e TileView collection

        /// <summary>
        /// Todo
        /// </summary>
        public void Awake()
        {
            this.pathRendererObject = new PathRendererObject.Builder()
                .SetParentTransform(this.GetTransform())
                .Build();
            this.animatorObject = new AnimatorScript.Builder()
                .SetParentTransform(this.GetTransform())
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gameBoardReport"></param>
        private void SetGameBoardReport(IGameBoardReport gameBoardReport)
        {
            this.hexTileViewCollection = new HexTileViewCollection.Builder()
                .SetParentTransform(this.GetTransform())
                .SetGameBoardReport(gameBoardReport)
                .Build();
            HexTileViewCollectionManager.SetHexTileViewCollection(this.hexTileViewCollection);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonRosterReport"></param>
        private void SetTalonRosterReport(ITalonRosterReport talonRosterReport)
        {
            this.talonViewCollection = new TalonViewCollection.Builder()
                .SetParentTransform(this.GetTransform())
                .SetTalonRosterReport(talonRosterReport)
                .Build();
            TalonViewCollectionManager.SetTalonViewCollection(this.talonViewCollection);
        }

        /// <inheritdoc/>
        void IGameBoardView.BeginAnimating(ITalonOrderReport talonOrderReport)
        {
            if (!this.animatorObject.IsAnimating())
            {
                this.animatorObject.BeginAnimating(talonOrderReport);
            }
            else
            {
                throw ExceptionUtil.Arguments.Build();
            }
        }

        /// <inheritdoc/>
        bool IGameBoardView.IsAnimating()
        {
            return this.animatorObject.IsAnimating();
        }

        /// <inheritdoc/>
        void IGameBoardView.ShowPathObject(IPathObject pathObject)
        {
            this.pathRendererObject.ShowPathObject(pathObject);
        }

        /// <inheritdoc/>
        IHexTileView IGameBoardView.GetHexTileView(ICubeCoordinates cubeCoordinates)
        {
            return this.hexTileViewCollection.GetHexTileView(cubeCoordinates);
        }

        /// <inheritdoc/>
        ITalonView IGameBoardView.GetTalonView(TalonCallSign talonCallSign)
        {
            return this.talonViewCollection.GetTalonView(talonCallSign);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private IGameBoardReport gameBoardReport = null;

            // Todo
            private ITalonRosterReport talonRosterReport = null;

            // Todo
            private Transform parentTransform = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IGameBoardView Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    GameBoardView gameBoard = new GameObject(typeof(GameBoardView).Name)
                        .AddComponent<GameBoardView>();
                    gameBoard.GetTransform().SetParent(this.parentTransform);
                    gameBoard.SetGameBoardReport(gameBoardReport);
                    gameBoard.SetTalonRosterReport(talonRosterReport);
                    return gameBoard;
                }
                else
                {
                    throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="gameBoardReport"></param>
            /// <returns></returns>
            public Builder SetGameBoardReport(IGameBoardReport gameBoardReport)
            {
                this.gameBoardReport = gameBoardReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="talonRosterReport"></param>
            /// <returns></returns>
            public Builder SetTalonRosterReport(ITalonRosterReport talonRosterReport)
            {
                this.talonRosterReport = talonRosterReport;

                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="parentTransform"></param>
            /// <returns></returns>
            public Builder SetParentTransform(Transform parentTransform)
            {
                this.parentTransform = parentTransform;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                if (this.gameBoardReport == null)
                {
                    argumentExceptionSet.Add(typeof(IGameBoardReport).Name + " cannot be null.");
                }
                if (this.talonRosterReport == null)
                {
                    argumentExceptionSet.Add(typeof(ITalonRosterReport).Name + " cannot be null.");
                }
                if (this.parentTransform == null)
                {
                    argumentExceptionSet.Add("Parent " + typeof(Transform).Name + " cannot be null.");
                }

                return argumentExceptionSet;
            }
        }
    }
}