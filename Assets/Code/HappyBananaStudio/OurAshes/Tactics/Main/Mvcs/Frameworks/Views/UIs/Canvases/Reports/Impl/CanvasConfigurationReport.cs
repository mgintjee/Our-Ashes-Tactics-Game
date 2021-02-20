namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Reports.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Canvas.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Canvas.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Reports.Api;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct CanvasConfigurationReport
        : ICanvasConfigurationReport
    {
        // Todo
        private readonly ICanvasGridCoordinates positionCanvasGridCoordinates;

        // Todo
        private readonly ICanvasGridCoordinates dimensionCanvasGridCoordinates;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="dimensionCanvasGridCoordinates"></param>
        /// <param name="positionCanvasGridCoordinates"></param>
        private CanvasConfigurationReport(ICanvasGridCoordinates dimensionCanvasGridCoordinates,
            ICanvasGridCoordinates positionCanvasGridCoordinates)
        {
            this.dimensionCanvasGridCoordinates = dimensionCanvasGridCoordinates;
            this.positionCanvasGridCoordinates = positionCanvasGridCoordinates;
        }

        /// <inheritdoc/>
        ICanvasGridCoordinates ICanvasConfigurationReport.GetDimensionCanvasGridCoordinates()
        {
            return this.dimensionCanvasGridCoordinates;
        }

        /// <inheritdoc/>
        ICanvasGridCoordinates ICanvasConfigurationReport.GetPositionCanvasGridCoordinates()
        {
            return this.positionCanvasGridCoordinates;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: " +
                "\n\t> Dimension {1}={2}" +
                "\n\t> Position {3}={4}",
                this.GetType().Name, typeof(ICanvasGridCoordinates).Name, this.dimensionCanvasGridCoordinates,
                typeof(ICanvasGridCoordinates).Name, this.positionCanvasGridCoordinates);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ICanvasGridCoordinates positionCanvasGridCoordinates = null;

            // Todo
            private ICanvasGridCoordinates dimensionCanvasGridCoordinates = null;

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
                    return new CanvasConfigurationReport(this.dimensionCanvasGridCoordinates,
                        this.positionCanvasGridCoordinates);
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
            /// <param name="positionCanvasGridCoordinates"></param>
            /// <returns></returns>
            public Builder SetPositionCanvasGridCoordinates(ICanvasGridCoordinates positionCanvasGridCoordinates)
            {
                this.positionCanvasGridCoordinates = positionCanvasGridCoordinates;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="dimensionCanvasGridCoordinates"></param>
            /// <returns></returns>
            public Builder SetDimensionCanvasGridCoordinates(ICanvasGridCoordinates dimensionCanvasGridCoordinates)
            {
                this.dimensionCanvasGridCoordinates = dimensionCanvasGridCoordinates;
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
                if (this.dimensionCanvasGridCoordinates == null)
                {
                    argumentExceptionSet.Add("Dimension " + typeof(ICanvasGridCoordinates).Name + " cannot be null.");
                }
                if (this.positionCanvasGridCoordinates == null)
                {
                    argumentExceptionSet.Add("Position " + typeof(ICanvasGridCoordinates).Name + " cannot be null.");
                }

                return argumentExceptionSet;
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static ICanvasConfigurationReport DefaultActionMenuConfigurationReport()
        {
            return new CanvasConfigurationReport(
                new CanvasGridCoordinates.Builder().SetX(2).SetY(5).Build(),
                new CanvasGridCoordinates.Builder().SetX(0).SetY(1).Build());
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static ICanvasConfigurationReport DefaultGameLoggerConfigurationReport()
        {
            return new CanvasConfigurationReport(
                new CanvasGridCoordinates.Builder().SetX(2).SetY(2).Build(),
                new CanvasGridCoordinates.Builder().SetX(0).SetY(9).Build());
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static ICanvasConfigurationReport DefaultInformationalConfigurationReport()
        {
            return new CanvasConfigurationReport(
                new CanvasGridCoordinates.Builder().SetX(2).SetY(6).Build(),
                new CanvasGridCoordinates.Builder().SetX(11).SetY(1).Build());
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static ICanvasConfigurationReport DefaultScoreBoardConfigurationReport()
        {
            return new CanvasConfigurationReport(
                new CanvasGridCoordinates.Builder().SetX(5).SetY(1).Build(),
                new CanvasGridCoordinates.Builder().SetX(3).SetY(9).Build());
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static ICanvasConfigurationReport DefaultSettingMenuConfigurationReport()
        {
            return new CanvasConfigurationReport(
                new CanvasGridCoordinates.Builder().SetX(2).SetY(1).Build(),
                new CanvasGridCoordinates.Builder().SetX(11).SetY(9).Build());
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static ICanvasConfigurationReport DefaultTurnScrollerConfigurationReport()
        {
            return new CanvasConfigurationReport(
                new CanvasGridCoordinates.Builder().SetX(7).SetY(2).Build(),
                new CanvasGridCoordinates.Builder().SetX(2).SetY(0).Build());
        }
    }
}