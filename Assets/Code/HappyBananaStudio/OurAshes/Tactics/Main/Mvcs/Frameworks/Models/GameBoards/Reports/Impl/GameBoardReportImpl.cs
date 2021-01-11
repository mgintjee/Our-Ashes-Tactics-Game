namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Reports.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Reports.Api;
    using HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// GameBoard Report Impl
    /// </summary>
    public struct GameBoardReportImpl
        : IGameBoardReport
    {
        // Todo
        private readonly ISet<IHexTileReport> hexTileReportSet;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="hexTileReportSet"></param>
        private GameBoardReportImpl(ISet<IHexTileReport> hexTileReportSet)
        {
            this.hexTileReportSet = new HashSet<IHexTileReport>(hexTileReportSet);
        }

        /// <inheritdoc/>
        ISet<IHexTileReport> IGameBoardReport.GetHexTileReportSet()
        {
            return new HashSet<IHexTileReport>(this.hexTileReportSet);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ISet<IHexTileReport> hexTileReportSet = new HashSet<IHexTileReport>();

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IGameBoardReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new GameBoardReportImpl(this.hexTileReportSet);
                }
                else
                {
                    throw ExceptionUtil.Argument.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="hexTileReportSet"></param>
            /// <returns></returns>
            public Builder SetHexTileReportSet(ISet<IHexTileReport> hexTileReportSet)
            {
                this.hexTileReportSet = new HashSet<IHexTileReport>(hexTileReportSet);
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
                // Check that hexTileReportSet has been set
                if (this.hexTileReportSet == null)
                {
                    argumentExceptionSet.Add("Set: " + typeof(IHexTileReport) + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}