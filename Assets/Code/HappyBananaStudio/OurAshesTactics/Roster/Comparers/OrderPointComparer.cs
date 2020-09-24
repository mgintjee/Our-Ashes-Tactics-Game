/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Roster.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;
using HappyBananaStudio.OurAshesTactics.Talon.Attributes.Reports;
using HappyBananaStudio.OurAshesTactics.Talon.Object.Api;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Roster.Comparers
{
    /// <summary>
    /// Todo
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OrderPointComparer<T>
        : IComparer<TalonIdentificationReport>
    {
        #region Private Fields

        // Todo
        private readonly IRosterObject rosterObject = null;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="rosterObject"></param>
        public OrderPointComparer(IRosterObject rosterObject)
        {
            this.rosterObject = rosterObject;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// /Todo
        /// </summary>
        /// <param name="xTalonIdentificationReport"></param>
        /// <param name="yTalonIdentificationReport"></param>
        /// <returns></returns>
        public int Compare(TalonIdentificationReport xTalonIdentificationReport, TalonIdentificationReport yTalonIdentificationReport)
        {
            if (this.rosterObject.IsTalonIdentificationReportActive(xTalonIdentificationReport) &&
                this.rosterObject.IsTalonIdentificationReportActive(yTalonIdentificationReport))
            {
                ITalonObject talonObjectX = this.rosterObject.GetTalonObject(xTalonIdentificationReport);
                ITalonObject talonObjectY = this.rosterObject.GetTalonObject(yTalonIdentificationReport);
                TalonAttributesReport talonAttributesReportX = talonObjectX.GetTalonInformationReport().GetTalonAttributesReport();
                TalonAttributesReport talonAttributesReportY = talonObjectY.GetTalonInformationReport().GetTalonAttributesReport();
                int orderPointsX = talonAttributesReportX.GetMovableAttributesReport().GetCurrentOrderPoints();
                int orderPointsY = talonAttributesReportY.GetMovableAttributesReport().GetCurrentOrderPoints();
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

        #endregion Public Methods
    }
}