namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Convertors.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Convertors.Api;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public class CanvasGridConvertor
        : ICanvasGridConvertor
    {
        // Todo
        private readonly ICanvasGridCoordinates canvasGridDimensions;

        // Todo
        private readonly float canvasHeight;

        // Todo
        private readonly float canvasWidth;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="canvasGridDimensions"></param>
        /// <param name="canvasHeight"></param>
        /// <param name="canvasWidth"></param>
        public CanvasGridConvertor(ICanvasGridCoordinates canvasGridDimensions, float canvasWidth, float canvasHeight)
        {
            this.canvasGridDimensions = canvasGridDimensions;
            this.canvasWidth = canvasWidth;
            this.canvasHeight = canvasHeight;
        }

        /// <inheritdoc/>
        Vector2 ICanvasGridConvertor.GetCanvasWorldDimensionsFrom(ICanvasGridCoordinates canvasGridDimensions)
        {
            return new Vector2(canvasGridDimensions.GetCol() * this.GetCanvasWidthStep(),
                canvasGridDimensions.GetRow() * this.GetCanvasHeightStep());
        }

        /// <inheritdoc/>
        Vector2 ICanvasGridConvertor.GetCanvasWorldPositionFrom(ICanvasGridCoordinates canvasGridPosition,
            ICanvasGridCoordinates canvasGridDimensions)
        {
            if (canvasGridPosition == null)
            {
                return Vector2.zero;
            }
            Vector2 canvasWorldPosition = new Vector2(
                    (canvasGridPosition.GetCol() * this.GetCanvasWidthStep()) - this.canvasWidth / 2,
                    (canvasGridPosition.GetRow() * this.GetCanvasHeightStep()) - this.canvasHeight / 2);
            Vector2 canvasWorldDimensions = this.GetCanvasWorldDimensionsFrom(canvasGridDimensions);
            if (canvasWorldPosition.x > 0)
            {
                canvasWorldPosition.x -= canvasWorldDimensions.x / 2;
            }
            else
            {
                canvasWorldPosition.x += canvasWorldDimensions.x / 2;
            }
            if (canvasWorldPosition.y > 0)
            {
                canvasWorldPosition.y -= canvasWorldDimensions.y / 2;
            }
            else
            {
                canvasWorldPosition.y += canvasWorldDimensions.y / 2;
            }
            return canvasWorldPosition;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private float GetCanvasWidthStep()
        {
            return this.canvasWidth / this.canvasGridDimensions.GetCol();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private float GetCanvasHeightStep()
        {
            return this.canvasHeight / this.canvasGridDimensions.GetRow();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="canvasGridDimensions"></param>
        /// <returns></returns>
        private Vector2 GetCanvasWorldDimensionsFrom(ICanvasGridCoordinates canvasGridDimensions)
        {
            return this.GetCanvasWorldDimensionsFrom(canvasGridDimensions);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ICanvasGridCoordinates canvasGridDimensions = null;

            // Todo
            private float canvasHeight = 0f;

            // Todo
            private float canvasWidth = 0f;

            /// <summary>
            /// Build the implementation of the object and return it
            /// </summary>
            /// <returns>The new object's interface</returns>
            public ICanvasGridConvertor Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new CanvasGridConvertor(this.canvasGridDimensions,
                        this.canvasWidth, this.canvasHeight);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="canvasGridDimensions"></param>
            /// <returns></returns>
            public Builder SetCanvasGridDimensions(ICanvasGridCoordinates canvasGridDimensions)
            {
                this.canvasGridDimensions = canvasGridDimensions;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="canvasWidth"></param>
            /// <returns></returns>
            public Builder SetCanvasWidth(float canvasWidth)
            {
                this.canvasWidth = canvasWidth;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="canvasHeight"></param>
            /// <returns></returns>
            public Builder SetCanvasHeight(float canvasHeight)
            {
                this.canvasHeight = canvasHeight;
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

                if (this.canvasGridDimensions == null)
                {
                    argumentExceptionSet.Add("Dimension " + typeof(ICanvasGridCoordinates) + " cannot be null.");
                }

                if (this.canvasHeight >= 0)
                {
                    argumentExceptionSet.Add("canvasHeight cannot be less than 0.");
                }

                if (this.canvasWidth >= int.MinValue)
                {
                    argumentExceptionSet.Add("canvasWidth cannot be less than 0.");
                }
                return argumentExceptionSet;
            }
        }
    }
}