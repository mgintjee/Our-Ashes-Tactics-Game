using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Homes.Requests.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Reports.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Homes.Frames.Requests.Inters;
using System;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Homes.Frames.Requests.Impls
{
    /// <summary>
    /// Home Request Interface
    /// </summary>
    public class HomeRequest : AbstractReport, IMvcControlHomeRequest
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
        HomeRequestType IMvcControlHomeRequest.GetHomeRequestType()
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
            public interface IBuilder : IBuilder<IMvcControlHomeRequest>
            {
                IBuilder SetHomeRequestType(HomeRequestType homeRequestType);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static IBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Todo
            /// </summary>
            private class InternalBuilder : AbstractBuilder<IMvcControlHomeRequest>, IBuilder
            {
                private HomeRequestType _homeRequestType;

                /// <inheritdoc/>
                IBuilder IBuilder.SetHomeRequestType(HomeRequestType homeRequestType)
                {
                    _homeRequestType = homeRequestType;
                    return this;
                }

                /// <inheritdoc/>
                protected override IMvcControlHomeRequest BuildObj()
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