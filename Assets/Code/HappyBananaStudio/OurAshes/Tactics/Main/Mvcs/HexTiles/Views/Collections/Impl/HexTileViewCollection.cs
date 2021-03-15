using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Cube.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Scripts.Unity.Abs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.HexTiles.Models.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.HexTiles.Views.Collections.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.HexTiles.Views.Views.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.HexTiles.Views.Views.Impl;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.HexTiles.Views.Collections.Impl
{
    /// <summary>
    /// Todo
    /// </summary>
    public class HexTileViewCollection
        : AbstractUnityScript, IHexTileViewCollection
    {
        // Todo
        private IDictionary<ICubeCoordinates, IHexTileView> cubeCoordinatesHexTileViewDictionary =
            new Dictionary<ICubeCoordinates, IHexTileView>();

        /// <inheritdoc/>
        IHexTileView IHexTileViewCollection.GetHexTileView(ICubeCoordinates cubeCoordinates)
        {
            if (this.cubeCoordinatesHexTileViewDictionary.ContainsKey(cubeCoordinates))
            {
                return this.cubeCoordinatesHexTileViewDictionary[cubeCoordinates];
            }
            throw ExceptionUtil.Arguments.Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gameBoardReport"></param>
        private void SetGameBoardReport(IGameBoardReport gameBoardReport)
        {
            this.cubeCoordinatesHexTileViewDictionary = new Dictionary<ICubeCoordinates, IHexTileView>();
            foreach (IHexTileReport hexTileReport in gameBoardReport.GetHexTileReportSet())
            {
                IHexTileView hexTileView = new HexTileView.Builder()
                    .SetCubeCoordinates(hexTileReport.GetCubeCoordinates())
                    .SetHexTileType(hexTileReport.GetHexTileType())
                    .SetParentTransform(this.GetTransform())
                    .Build();
                this.cubeCoordinatesHexTileViewDictionary.Add(hexTileReport.GetCubeCoordinates(), hexTileView);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private Transform parentTransform = null;

            // Todo
            private IGameBoardReport gameBoardReport = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IHexTileViewCollection Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    HexTileViewCollection hexTileViewCollection = new GameObject(typeof(HexTileViewCollection).Name)
                        .AddComponent<HexTileViewCollection>();
                    hexTileViewCollection.GetTransform().SetParent(this.parentTransform);
                    hexTileViewCollection.SetGameBoardReport(this.gameBoardReport);
                    return hexTileViewCollection;
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
                if (this.parentTransform == null)
                {
                    argumentExceptionSet.Add("Parent " + typeof(Transform).Name + " cannot be null.");
                }

                return argumentExceptionSet;
            }
        }
    }
}