using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Reports.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Reports.Implementations.Abstracts
{
    /// <summary>
    /// Abstract Mvc View Report Implementation
    /// </summary>
    public abstract class AbstractMvcViewReport
        : AbstractReport, IMvcViewReport
    {
        // Todo
        private readonly bool _isProcessing;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="isProcessing"></param>
        protected AbstractMvcViewReport(bool isProcessing)
        {
            _isProcessing = isProcessing;
        }

        /// <inheritdoc/>
        bool IMvcViewReport.IsProcessing()
        {
            return _isProcessing;
        }

        /// <inheritdoc/>
        protected override string GetContent()
        {
            return string.Format("_isProcessing={0}", _isProcessing);
        }
    }
}