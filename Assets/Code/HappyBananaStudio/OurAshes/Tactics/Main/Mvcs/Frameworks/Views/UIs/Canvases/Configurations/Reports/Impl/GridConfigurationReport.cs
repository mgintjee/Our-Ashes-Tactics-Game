using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Dimensions.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Positions.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Reports.Api;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Reports.Impl
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct GridConfigurationReport
        : IGridConfigurationReport
    {
        // Todo
        private readonly IGridPosition gridPosition;

        // Todo
        private readonly IGridDimensions gridDimensions;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gridDimensions"></param>
        /// <param name="gridPosition"></param>
        private GridConfigurationReport(IGridDimensions gridDimensions,
            IGridPosition gridPosition)
        {
            this.gridDimensions = gridDimensions;
            this.gridPosition = gridPosition;
        }

        /// <inheritdoc/>
        IGridDimensions IGridConfigurationReport.GetGridDimensions()
        {
            return this.gridDimensions;
        }

        /// <inheritdoc/>
        IGridPosition IGridConfigurationReport.GetGridPosition()
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
            private IGridPosition gridPosition = null;

            // Todo
            private IGridDimensions gridDimensions = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IGridConfigurationReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    return new GridConfigurationReport(this.gridDimensions,
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
            public Builder SetGridPosition(IGridPosition gridPosition)
            {
                this.gridPosition = gridPosition;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="gridDimensions"></param>
            /// <returns></returns>
            public Builder SetGridDimensions(IGridDimensions gridDimensions)
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
                    argumentExceptionSet.Add(typeof(IGridDimensions).Name + " cannot be null.");
                }

                return argumentExceptionSet;
            }
        }
    }
}