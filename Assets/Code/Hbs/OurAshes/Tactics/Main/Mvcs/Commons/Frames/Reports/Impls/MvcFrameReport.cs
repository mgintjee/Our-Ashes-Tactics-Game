using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Reports.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Controllers.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Frames.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Models.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Views.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Reports.Impls
{
    /// <summary>
    /// Mvc Frame Report Implementation
    /// </summary>
    public class MvcFrameReport : AbstractReport, IMvcFrameReport
    {
        // Todo
        private readonly IMvcControllerReport _mvcControllerReport;

        // Todo
        private readonly IMvcModelReport _mvcModelReport;

        // Todo
        private readonly IMvcViewReport _mvcViewReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcControllerReport"></param>
        /// <param name="mvcModelReport">     </param>
        /// <param name="mvcViewReport">      </param>
        private MvcFrameReport(IMvcControllerReport mvcControllerReport,
            IMvcModelReport mvcModelReport, IMvcViewReport mvcViewReport)
        {
            _mvcControllerReport = mvcControllerReport;
            _mvcModelReport = mvcModelReport;
            _mvcViewReport = mvcViewReport;
        }

        /// <inheritdoc/>
        IMvcControllerReport IMvcFrameReport.GetMvcControllerReport()
        {
            return _mvcControllerReport;
        }

        /// <inheritdoc/>
        IMvcModelReport IMvcFrameReport.GetMvcModelReport()
        {
            return _mvcModelReport;
        }

        /// <inheritdoc/>
        IMvcViewReport IMvcFrameReport.GetMvcViewReport()
        {
            return _mvcViewReport;
        }

        /// <inheritdoc/>
        protected override string GetContent()
        {
            return string.Format("{0}, {1}, {2}",
                _mvcControllerReport, _mvcModelReport, _mvcViewReport);
        }

        /// <summary>
        /// Builder class for this object
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Builder Interface for this object
            /// </summary>
            public interface IBuilder : IBuilder<IMvcFrameReport>
            {
                IBuilder SetMvcControllerReport(IMvcControllerReport mvcControllerReport);

                IBuilder SetMvcModelReport(IMvcModelReport mvcModelReport);

                IBuilder SetMvcViewReport(IMvcViewReport mvcViewReport);
            }

            /// <summary>
            /// Get the Builder for this object
            /// </summary>
            /// <returns></returns>
            public static IBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Builder Implementation for this object
            /// </summary>
            private class InternalBuilder : AbstractBuilder<IMvcFrameReport>, IBuilder
            {
                // Todo
                private IMvcControllerReport _mvcControllerReport;

                // Todo
                private IMvcModelReport _mvcModelReport;

                // Todo
                private IMvcViewReport _mvcViewReport;

                /// <inheritdoc/>
                IBuilder IBuilder.SetMvcControllerReport(IMvcControllerReport mvcControllerReport)
                {
                    _mvcControllerReport = mvcControllerReport;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetMvcModelReport(IMvcModelReport mvcModelReport)
                {
                    _mvcModelReport = mvcModelReport;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetMvcViewReport(IMvcViewReport mvcViewReport)
                {
                    _mvcViewReport = mvcViewReport;
                    return this;
                }

                /// <inheritdoc/>
                protected override IMvcFrameReport BuildObj()
                {
                    // Instantiate a new attributes
                    return new MvcFrameReport(_mvcControllerReport, _mvcModelReport, _mvcViewReport);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _mvcControllerReport);
                    this.Validate(invalidReasons, _mvcModelReport);
                    this.Validate(invalidReasons, _mvcViewReport);
                }
            }
        }
    }
}