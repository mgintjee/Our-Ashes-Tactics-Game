using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Splashes.Views.Constructions.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Splashes.Views.Constructions.Implementations
{
    /// <summary>
    /// Splash View Construction Implementation
    /// </summary>
    public class SplashViewConstruction : ISplashViewConstruction
    {
        /// <summary>
        /// Todo
        /// </summary>
        private SplashViewConstruction()
        {
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<ISplashViewConstruction>
            {
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
            private class InternalBuilder : AbstractBuilder<ISplashViewConstruction>, IBuilder
            {
                /// <inheritdoc/>
                protected override ISplashViewConstruction BuildObj()
                {
                    return new SplashViewConstruction();
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                }
            }
        }
    }
}