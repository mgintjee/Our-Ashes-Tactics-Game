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

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}: {1}" +
                "\n{2}",
                GetType().Name, _dateTime, this.GetContent());
        }

        /// <inheritdoc/>
        DateTime IReport.GetDateTime()
        {
            return _dateTime;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        protected abstract string GetContent();
    }
}