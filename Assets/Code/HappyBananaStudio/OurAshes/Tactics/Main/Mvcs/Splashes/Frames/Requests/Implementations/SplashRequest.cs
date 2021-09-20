using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Splashes.Frames.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Splashes.Frames.Requests.Types;
using System;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Splashes.Frames.Requests.Implementations
{
    /// <summary>
    /// Splash Request Interface
    /// </summary>
    public class SplashRequest : AbstractReport, ISplashRequest
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
        SplashRequestType ISplashRequest.GetSplashRequestType()
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
            public interface IBuilder : IBuilder<ISplashRequest>
            {
                IBuilder SetSplashRequestType(SplashRequestType SplashRequestType);
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
            private class InternalBuilder : AbstractBuilder<ISplashRequest>, IBuilder
            {
                private SplashRequestType _SplashRequestType;

                /// <inheritdoc/>
                IBuilder IBuilder.SetSplashRequestType(SplashRequestType SplashRequestType)
                {
                    _SplashRequestType = SplashRequestType;
                    return this;
                }

                /// <inheritdoc/>
                protected override ISplashRequest BuildObj()
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