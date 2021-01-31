namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.Animators.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Talons.Managers;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.Animators.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.HexTiles.Utils;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.Talons.Collections.Managers;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Scripts.Unity.Abs;
    using System.Collections.Generic;
    using System.Diagnostics;
    using UnityEngine;

    /// <summary>
    /// Animator Script Move Impl
    /// </summary>
    public class AnimatorScript
        : AbstractUnityScript, IAnimatorScript
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLogger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private ITalonOrderReport talonOrderReport;

        // Todo
        private ICubeCoordinates currentCubeCoordinates;

        // Todo
        private IList<ICubeCoordinates> cubeCoordinatesList;

        // Todo
        private float timePassed = 0.0f;

        /// <inheritdoc/>
        void IAnimatorScript.BeginAnimating(ITalonOrderReport talonOrderReport)
        {
            if (this.talonOrderReport == null)
            {
                this.talonOrderReport = talonOrderReport;
            }
        }

        /// <inheritdoc/>
        bool IAnimatorScript.IsAnimating()
        {
            return this.talonOrderReport != null;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public void FixedUpdate()
        {
            this.Animate();
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void Animate()
        {
            if (this.talonOrderReport != null)
            {
                OrderType orderType = this.talonOrderReport.GetOrderType();
                switch(orderType)
                {
                    case OrderType.Fire:
                        logger.Debug("Todo: Animate Fire");
                        TalonCallSign targetTalonCallSign = ((ITalonOrderFireReport)this.talonOrderReport).GetTargetTalonCallSign();
                        if(!TalonRosterManager.GetActiveTalonCallSignSet().Contains(targetTalonCallSign))
                        {
                            TalonViewCollectionManager.DestroyTalonView(targetTalonCallSign);
                        }
                        this.talonOrderReport = null;
                        break;
                    case OrderType.Move:
                        this.AnimateMove();
                        break;
                    case OrderType.Wait:
                        logger.Debug("Todo: Animate Wait");
                        this.talonOrderReport = null;
                        break;
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void AnimateMove()
        {
            if (this.cubeCoordinatesList == null)
            {
                this.cubeCoordinatesList = this.talonOrderReport.GetPathObject().GetCubeCoordinatesStepList();
            }
            if (this.currentCubeCoordinates == null)
            {
                this.timePassed = 0.0f;
                this.currentCubeCoordinates = this.cubeCoordinatesList[0];
            }
            Vector3 currentCubeCoordinatesWorldPosition = HexTileViewWorldPositionUtil
                .CubeCoordinatesToWorldVector(this.currentCubeCoordinates);
            currentCubeCoordinatesWorldPosition.y = 0;
            Vector3 currentTalonWorldPosition = TalonViewCollectionManager.GetTalonView(
                this.talonOrderReport.GetActingTalonCallSign()).GetTransform().position;
            if ((currentCubeCoordinatesWorldPosition - currentTalonWorldPosition).sqrMagnitude > 0.0001f)
            {
                this.timePassed += Time.fixedDeltaTime;
                Vector3 directionVector = Vector3.Lerp(currentTalonWorldPosition, currentCubeCoordinatesWorldPosition, this.timePassed);
                directionVector.y = 0;
                TalonViewCollectionManager.GetTalonView(this.talonOrderReport.GetActingTalonCallSign())
                    .GetTransform().position = directionVector;
            }
            else
            {
                this.cubeCoordinatesList.Remove(this.currentCubeCoordinates);
                if (this.cubeCoordinatesList.Count == 0)
                {
                    logger.Debug("Completed animation");
                    this.talonOrderReport = null;
                    this.cubeCoordinatesList = null;
                }
                this.currentCubeCoordinates = null;
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private Transform parentTransform = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IAnimatorScript Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    IAnimatorScript animatorScript = new GameObject(typeof(AnimatorScript).Name)
                        .AddComponent<AnimatorScript>();
                    animatorScript.GetTransform().SetParent(this.parentTransform);
                    return animatorScript;
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
            /// <returns>
            /// </returns>
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();

                return argumentExceptionSet;
            }
        }
    }
}