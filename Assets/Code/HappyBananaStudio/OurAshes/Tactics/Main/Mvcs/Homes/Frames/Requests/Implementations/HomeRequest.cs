using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Homes.Requests.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Implementations.Abstracts;
using System;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Homes.Frames.Requests.Interfaces
{
    /// <summary>
    /// Home Request Interface
    /// </summary>
    public class HomeRequest : AbstractReport, IHomeRequest
    {
        // Todo
        private readonly HomeRequestType _homeRequestType;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="homeRequestType"></param>
        private HomeRequest(HomeRequestType homeRequestType)
        {
            _homeRequestType = homeRequestType;
        }

        /// <inheritdoc/>
        HomeRequestType IHomeRequest.GetHomeRequestType()
        {
            return _homeRequestType;
        }

        /// <inheritdoc/>
        protected override string GetContent()
        {
            return String.Format("_homeRequestType={0}", _homeRequestType);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<IHomeRequest>
            {
                IBuilder SetHomeRequestType(HomeRequestType homeRequestType);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static IBuilder GetBuilder()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Todo
            /// </summary>
            private class InternalBuilder : AbstractBuilder<IHomeRequest>, IBuilder
            {
                private HomeRequestType _homeRequestType;

                /// <inheritdoc/>
                IBuilder IBuilder.SetHomeRequestType(HomeRequestType homeRequestType)
                {
                    _homeRequestType = homeRequestType;
                    return this;
                }

                /// <inheritdoc/>
                protected override IHomeRequest BuildObj()
                {
                    return new HomeRequest(_homeRequestType);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _homeRequestType);
                }
            }
        }
    }
}