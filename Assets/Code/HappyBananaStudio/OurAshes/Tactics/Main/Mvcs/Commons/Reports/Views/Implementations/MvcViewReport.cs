﻿using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Views.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Views.Implementations
{
    /// <summary>
    /// Mvc View Report Implementation
    /// </summary>
    public class MvcViewReport : AbstractReport, IMvcViewReport
    {
        // Todo
        private readonly bool _isProcessing;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="isProcessing"></param>
        private MvcViewReport(bool isProcessing)
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

        /// <summary>
        /// Builder class for this object
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Builder Interface for this object
            /// </summary>
            public interface IBuilder : IBuilder<IMvcViewReport>
            {
                public IBuilder SetIsProcessing(bool isProcessing);
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
            private class InternalBuilder : AbstractBuilder<IMvcViewReport>, IBuilder
            {
                private bool _isProcessing;

                /// <inheritdoc/>
                IBuilder IBuilder.SetIsProcessing(bool isProcessing)
                {
                    _isProcessing = isProcessing;
                    return this;
                }

                /// <inheritdoc/>
                protected override IMvcViewReport BuildObj()
                {
                    return new MvcViewReport(_isProcessing);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                }
            }
        }
    }
}