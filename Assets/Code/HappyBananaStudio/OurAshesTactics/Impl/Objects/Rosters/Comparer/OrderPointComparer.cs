/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Rosters;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Talons.Objects;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Attributes;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Objects.Rosters.Comparer
{
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
        public int Compare(ITalonIdentificationReport xTalonIdentificationReport,
            ITalonIdentificationReport yTalonIdentificationReport)
        {
            if (this.rosterObject.IsTalonIdentificationReportActive(xTalonIdentificationReport) &&
                this.rosterObject.IsTalonIdentificationReportActive(yTalonIdentificationReport))
            {
                ITalonObject talonObjectX = this.rosterObject.GetTalonObject(xTalonIdentificationReport);
                ITalonObject talonObjectY = this.rosterObject.GetTalonObject(yTalonIdentificationReport);
                ITalonAttributesReport talonAttributesReportX = talonObjectX.GetTalonInformationReport().GetTalonAttributesReport();
                ITalonAttributesReport talonAttributesReportY = talonObjectY.GetTalonInformationReport().GetTalonAttributesReport();
                int orderPointsX = talonAttributesReportX.GetMovableReport().GetCurrentOrderPoints();
                int orderPointsY = talonAttributesReportY.GetMovableReport().GetCurrentOrderPoints();
                if (orderPointsX > orderPointsY)
                {
                    return 1;
                }
                else if (orderPointsX < orderPointsY)
                {
                    return -1;
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