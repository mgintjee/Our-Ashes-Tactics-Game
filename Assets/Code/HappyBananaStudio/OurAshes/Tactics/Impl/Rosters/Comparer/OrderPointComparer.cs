

namespace HappyBananaStudio.OurAshes.Tactics.Impl.Rosters.Comparer
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Rosters.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class OrderPointComparer<T>
        : IComparer<ITalonIdentificationReport>
    {
        // Todo
        private readonly IRosterObject rosterObject = null;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="rosterObject">
        /// </param>
        public OrderPointComparer(IRosterObject rosterObject)
        {
            this.rosterObject = rosterObject;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="xTalonIdentificationReport">
        /// </param>
        /// <param name="yTalonIdentificationReport">
        /// </param>
        /// <returns>
        /// </returns>
        int IComparer<ITalonIdentificationReport>.Compare(
            ITalonIdentificationReport xTalonIdentificationReport,
            ITalonIdentificationReport yTalonIdentificationReport)
        {
            if (this.rosterObject.IsTalonIdentificationReportActive(xTalonIdentificationReport) &&
                this.rosterObject.IsTalonIdentificationReportActive(yTalonIdentificationReport))
            {
                ITalonObject talonObjectX = this.rosterObject.GetTalonObject(xTalonIdentificationReport);
                ITalonObject talonObjectY = this.rosterObject.GetTalonObject(yTalonIdentificationReport);
                ITalonAttributesReport talonAttributesReportX = talonObjectX.GetTalonInformationReport().GetTalonAttributesReport();
                ITalonAttributesReport talonAttributesReportY = talonObjectY.GetTalonInformationReport().GetTalonAttributesReport();
                int orderPointsX = talonAttributesReportX.GetMovableAttributesReport().GetCurrentMovePoints();
                int orderPointsY = talonAttributesReportY.GetMovableAttributesReport().GetCurrentMovePoints();
                if (orderPointsX > orderPointsY)
                {
                    return -1;
                }
                else if (orderPointsX < orderPointsY)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                if (this.rosterObject.IsTalonIdentificationReportActive(xTalonIdentificationReport) &&
                !this.rosterObject.IsTalonIdentificationReportActive(yTalonIdentificationReport))
                {
                    return 1;
                }
                else if (!this.rosterObject.IsTalonIdentificationReportActive(xTalonIdentificationReport) &&
                this.rosterObject.IsTalonIdentificationReportActive(yTalonIdentificationReport))
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
