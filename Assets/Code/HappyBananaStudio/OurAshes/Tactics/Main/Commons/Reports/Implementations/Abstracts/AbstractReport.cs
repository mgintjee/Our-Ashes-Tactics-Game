using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Interfaces;
using System;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Implementations.Abstracts
{
    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractReport
        : IReport
    {
        // Todo
        protected readonly DateTime _dateTime;

        /// <summary>
        /// Todo
        /// </summary>
        protected AbstractReport()
        {
            _dateTime = DateTime.Now;
        }

        /// <inheritdoc/>
        DateTime IReport.GetDateTime()
        {
            return _dateTime;
        }
    }
}