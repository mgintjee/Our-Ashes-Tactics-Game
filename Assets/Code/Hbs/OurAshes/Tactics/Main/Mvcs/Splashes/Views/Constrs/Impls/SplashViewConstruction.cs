using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Views.Constrs.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Views.Constrs.Impls
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
            public static IBuilder Get()
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