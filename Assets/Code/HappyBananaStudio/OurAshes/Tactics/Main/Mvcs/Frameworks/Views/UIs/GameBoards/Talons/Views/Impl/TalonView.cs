namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.Talons.Views.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Phalanxes.Mangers;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.HexTiles.Utils;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.Talons.Utils;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.Talons.Views.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Scripts.Unity.Abs;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public class TalonView
        : AbstractUnityScript, ITalonView
    {
        // Todo
        [SerializeField] private ICubeCoordinates cubeCoordinates;

        // Todo
        [SerializeField] private TalonCallSign talonCallSign;

        // Todo
        [SerializeField] private PhalanxCallSign phalanxCallSign;

        /// <inheritdoc/>
        ICubeCoordinates ITalonView.GetCubeCoordinates()
        {
            return this.cubeCoordinates;
        }

        /// <inheritdoc/>
        TalonCallSign ITalonView.GetTalonCallSign()
        {
            return this.talonCallSign;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        private void SetCubeCoordinates(ICubeCoordinates cubeCoordinates)
        {
            this.cubeCoordinates = cubeCoordinates;
            Vector3 worldPosition = HexTileViewWorldPositionUtil
                .CubeCoordinatesToWorldVector(this.cubeCoordinates);
            worldPosition.y = 0;
            this.transform.localPosition = worldPosition;
            // Todo: Move the Talon gameObject to the proper location here
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCallSign"></param>
        private void SetTalonCallSign(TalonCallSign talonCallSign)
        {
            this.talonCallSign = talonCallSign;
            this.phalanxCallSign = PhalanxRosterManager.GetPhalanxCallSign(talonCallSign);
            // Todo: Update the aethstetics here
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ICubeCoordinates cubeCoordinates = null;

            // Todo
            private TalonCallSign talonCallSign = TalonCallSign.None;

            // Todo
            private Transform parentTransform = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ITalonView Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    TalonView talonView = TalonViewConstructorUtil.ConstructGameObject(this.talonCallSign)
                        .AddComponent<TalonView>();
                    talonView.GetTransform().SetParent(this.parentTransform);
                    talonView.SetTalonCallSign(this.talonCallSign);
                    talonView.SetCubeCoordinates(this.cubeCoordinates);
                    return talonView;
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
            /// <param name="cubeCoordinates"></param>
            /// <returns></returns>
            public Builder SetCubeCoordinates(ICubeCoordinates cubeCoordinates)
            {
                this.cubeCoordinates = cubeCoordinates;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="talonCallSign"></param>
            /// <returns></returns>
            public Builder SetTalonCallSign(TalonCallSign talonCallSign)
            {
                this.talonCallSign = talonCallSign;
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
                if (this.cubeCoordinates == null)
                {
                    argumentExceptionSet.Add(typeof(ICubeCoordinates).Name + " cannot be null.");
                }
                if (this.talonCallSign == TalonCallSign.None)
                {
                    argumentExceptionSet.Add(typeof(TalonCallSign).Name + " cannot be null.");
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