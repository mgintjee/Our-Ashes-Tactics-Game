using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Controllers.Splashes.Constrs.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Controllers.Splashes.Constrs.Impls
{
    /// <summary>
    /// Splash Controller Interface
    /// </summary>
    public class SplashControllerConstruction : ISplashControllerConstruction
    {
        /// <summary>
        /// Todo
        /// </summary>
        private SplashControllerConstruction()
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
            public interface IBuilder : IBuilder<ISplashControllerConstruction>
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
            private class InternalBuilder : AbstractBuilder<ISplashControllerConstruction>, IBuilder
            {
                /// <inheritdoc/>
                protected override ISplashControllerConstruction BuildObj()
                {
                    return new SplashControllerConstruction();
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                }
            }
        }
    }
}