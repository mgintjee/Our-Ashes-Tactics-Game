namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Reports.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Reports.Api;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct CanvasConfigurationReport
        : ICanvasConfigurationReport
    {
        // Todo
        private readonly ICanvasGridCoordinates canvasGridPosition;

        // Todo
        private readonly ICanvasGridCoordinates canvasGridDimensions;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="canvasGridDimensions"></param>
        /// <param name="canvasGridPosition"></param>
        private CanvasConfigurationReport(ICanvasGridCoordinates canvasGridDimensions,
            ICanvasGridCoordinates canvasGridPosition)
        {
            this.canvasGridDimensions = canvasGridDimensions;
            this.canvasGridPosition = canvasGridPosition;
        }

        /// <inheritdoc/>
        ICanvasGridCoordinates ICanvasConfigurationReport.GetCanvasGridDimensions()
        {
            return this.canvasGridDimensions;
        }

        /// <inheritdoc/>
        ICanvasGridCoordinates ICanvasConfigurationReport.GetCanvasGridPosition()
        {
            return this.canvasGridPosition;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: " +
                "\n\t> Dimension {2}" +
                "\n\t> Position {4}",
                this.GetType().Name, this.canvasGridDimensions, this.canvasGridPosition);
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

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ICanvasConfigurationReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    return new CanvasConfigurationReport(this.canvasGridDimensions,
                        this.canvasGridPosition);
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
            /// <param name="canvasGridPosition"></param>
            /// <returns></returns>
            public Builder SetCanvasGridPosition(ICanvasGridCoordinates canvasGridPosition)
            {
                this.canvasGridPosition = canvasGridPosition;
                return this;
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

                return argumentExceptionSet;
            }
        }
    }
}