namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Reports.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Api;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct CanvasConfigurationReport
        : ICanvasConfigurationReport
    {
        // Todo
        private readonly ICanvasGridCoordinates gridPosition;

        // Todo
        private readonly ICanvasGridCoordinates gridDimensions;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gridDimensions"></param>
        /// <param name="gridPosition"></param>
        private CanvasConfigurationReport(ICanvasGridCoordinates gridDimensions,
            ICanvasGridCoordinates gridPosition)
        {
            this.gridDimensions = gridDimensions;
            this.gridPosition = gridPosition;
        }

        /// <inheritdoc/>
        ICanvasGridCoordinates ICanvasConfigurationReport.GetGridDimensions()
        {
            return this.gridDimensions;
        }

        /// <inheritdoc/>
        ICanvasGridCoordinates ICanvasConfigurationReport.GetGridPosition()
        {
            return this.gridPosition;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: " +
                "\n\t> Dimension {2}" +
                "\n\t> Position {4}",
                this.GetType().Name, this.gridDimensions, this.gridPosition);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ICanvasGridCoordinates gridPosition = null;

            // Todo
            private ICanvasGridCoordinates gridDimensions = null;

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
                    return new CanvasConfigurationReport(this.gridDimensions,
                        this.gridPosition);
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
            /// <param name="gridPosition"></param>
            /// <returns></returns>
            public Builder SetGridPosition(ICanvasGridCoordinates gridPosition)
            {
                this.gridPosition = gridPosition;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="gridDimensions"></param>
            /// <returns></returns>
            public Builder SetGridDimensions(ICanvasGridCoordinates gridDimensions)
            {
                this.gridDimensions = gridDimensions;
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
                if (this.gridDimensions == null)
                {
                    argumentExceptionSet.Add("Dimension " + typeof(ICanvasGridCoordinates).Name + " cannot be null.");
                }

                return argumentExceptionSet;
            }
        }
    }
}