using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Reports.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Frames.Requests.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Frames.Requests.Types;
using System;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Frames.Requests.Impls
{
    /// <summary>
    /// Splash Request Interface
    /// </summary>
    public class SplashRequest : AbstractReport, IMvcControlSplashRequest
    {
        // Todo
        private readonly SplashRequestType _SplashRequestType;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="SplashRequestType"></param>
        private SplashRequest(SplashRequestType SplashRequestType)
        {
            _SplashRequestType = SplashRequestType;
        }

        /// <inheritdoc/>
        SplashRequestType IMvcControlSplashRequest.GetSplashRequestType()
        {
            return _SplashRequestType;
        }

        /// <inheritdoc/>
        protected override string GetContent()
        {
            return String.Format("_SplashRequestType={0}", _SplashRequestType);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<IMvcControlSplashRequest>
            {
                IBuilder SetSplashRequestType(SplashRequestType SplashRequestType);
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
            private class InternalBuilder : AbstractBuilder<IMvcControlSplashRequest>, IBuilder
            {
                private SplashRequestType _SplashRequestType;

                /// <inheritdoc/>
                IBuilder IBuilder.SetSplashRequestType(SplashRequestType SplashRequestType)
                {
                    _SplashRequestType = SplashRequestType;
                    return this;
                }

                /// <inheritdoc/>
                protected override IMvcControlSplashRequest BuildObj()
                {
                    return new SplashRequest(_SplashRequestType);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _SplashRequestType);
                }
            }
        }
    }
}