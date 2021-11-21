using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Reports.Implementations.Abstracts;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Implementations
{
    /// <summary>
    /// Empty Mvc Request Implementation
    /// </summary>
    public class EmptyMvcRequest : AbstractReport, IMvcRequest
    {
        /// <summary>
        /// Todo
        /// </summary>
        private EmptyMvcRequest()
        {
        }

        /// <inheritdoc/>
        protected override string GetContent()
        {
            return "";
        }

        /// <summary>
        /// Builder class for this object
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Builder Interface for this object
            /// </summary>
            public interface IBuilder : IBuilder<IMvcRequest>
            {
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
            private class InternalBuilder : AbstractBuilder<IMvcRequest>, IBuilder
            {
                /// <inheritdoc/>
                protected override IMvcRequest BuildObj()
                {
                    // Instantiate a new attributes
                    return new EmptyMvcRequest();
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                }
            }
        }
    }
}