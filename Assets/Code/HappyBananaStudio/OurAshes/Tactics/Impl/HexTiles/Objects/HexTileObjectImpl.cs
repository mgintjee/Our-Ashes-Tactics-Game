/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>

namespace HappyBananaStudio.OurAshesTactics.Impl.Objects.HexTiles
{
    using HappyBananaStudio.OurAshes.Tactics.Api.HexTiles.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.HexTiles.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
    using HappyBananaStudio.OurAshesTactics.Impl.Reports.HexTiles;
    using System.Diagnostics;

    /// <summary>
    /// HexTile Object Impl
    /// </summary>
    public class HexTileObjectImpl
    : IHexTileObject
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly IHexTileConstructionReport hexTileConstructionReport = null;

        // Todo
        private ITalonIdentificationReport occupyingTalonIdentificationReport = null;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="hexTileConstructionReport">
        /// </param>
        public HexTileObjectImpl(IHexTileConstructionReport hexTileConstructionReport)
        {
            if (hexTileConstructionReport != null)
            {
                logger.Info("Constructing: ? with ?", this.GetType(), hexTileConstructionReport);
                this.hexTileConstructionReport = hexTileConstructionReport;
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. " +
                    "\n\t> ? is null: ?", this.GetType(),
                    typeof(IHexTileConstructionReport), (hexTileConstructionReport == null));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public void ClearOccupyingTalonIdentificationReport()
        {
            this.occupyingTalonIdentificationReport = null;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IHexTileInformationReport GetHexTileInformationReport()
        {
            return new HexTileInformationReportImpl.Builder()
                .SetHexTileType(this.hexTileConstructionReport.GetHexTileType())
                .SetCubeCoordinates(this.hexTileConstructionReport.GetCubeCoordinates())
                .SetTalonIdentificationReport(this.occupyingTalonIdentificationReport)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport">
        /// </param>
        public void SetOccupyingTalonIdentificationReport(ITalonIdentificationReport talonIdentificationReport)
        {
            if (talonIdentificationReport != null)
            {
                this.occupyingTalonIdentificationReport = talonIdentificationReport;
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. " +
                    "\n\t> ? is null.", this.GetType(),
                    new StackFrame().GetMethod().Name, typeof(ITalonIdentificationReport));
            }
        }
    }
}
