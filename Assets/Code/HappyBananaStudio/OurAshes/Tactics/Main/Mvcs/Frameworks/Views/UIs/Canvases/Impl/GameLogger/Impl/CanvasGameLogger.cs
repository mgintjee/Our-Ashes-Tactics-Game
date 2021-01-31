namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Impl.GameLogger.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Abs;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Canvas.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Impl.GameLogger.Api;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public class CanvasGameLogger
        : CanvasAbstractImpl, ICanvasGameLogger
    {
        /// <summary>
        /// Todo
        /// </summary>
        private void LoadCanvasEntryWidgets()
        {
            this.UpdateCanvasEntryWidgets();
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ICanvasGridCoordinates canvasGridPosition = null;

            // Todo
            private ICanvasGridCoordinates canvasGridDimensions = null;

            // Todo
            private Transform parentTransform = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ICanvasGameLogger Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    CanvasGameLogger canvasGameLogger = new GameObject(typeof(CanvasGameLogger).Name)
                        .AddComponent<CanvasGameLogger>();
                    canvasGameLogger.GetTransform().SetParent(this.parentTransform);
                    canvasGameLogger.GetTransform().localPosition = Vector3.zero;
                    canvasGameLogger.GetTransform().localScale = Vector3.one;
                    canvasGameLogger.SetCanvasGridDimensions(this.canvasGridDimensions);
                    canvasGameLogger.SetCanvasGridPosition(this.canvasGridPosition);
                    canvasGameLogger.LoadCanvasEntryWidgets();
                    return canvasGameLogger;
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
            /// <param name="canvasGridCoordinates"></param>
            /// <returns></returns>
            public Builder SetCanvasGridPosition(ICanvasGridCoordinates canvasGridCoordinates)
            {
                this.canvasGridPosition = canvasGridCoordinates;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="canvasGridCoordinates"></param>
            /// <returns></returns>
            public Builder SetCanvasGridDimensions(ICanvasGridCoordinates canvasGridCoordinates)
            {
                this.canvasGridDimensions = canvasGridCoordinates;
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
                if (this.canvasGridDimensions == null)
                {
                    argumentExceptionSet.Add("Dimension " + typeof(ICanvasGridCoordinates).Name + " cannot be null.");
                }
                if (this.canvasGridPosition == null)
                {
                    argumentExceptionSet.Add("Position " + typeof(ICanvasGridCoordinates).Name + " cannot be null.");
                }
                if (this.parentTransform == null)
                {
                    argumentExceptionSet.Add("Parent " + typeof(Canvas).Name + " cannot be null.");
                }

                return argumentExceptionSet;
            }
        }
    }
}