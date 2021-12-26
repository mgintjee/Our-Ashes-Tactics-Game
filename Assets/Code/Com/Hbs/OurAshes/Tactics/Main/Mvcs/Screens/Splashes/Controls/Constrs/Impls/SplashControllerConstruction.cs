using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Screens.Splashes.Controls.Constrs.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Screens.Splashes.Controls.Constrs.Impls
{
    /// <summary>
    /// Splash Control Interface
    /// </summary>
    public class SplashControlConstruction
        : ISplashControlConstruction
    {
        /// <summary>
        /// Todo
        /// </summary>
        private SplashControlConstruction()
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
            public interface IBuilder : IBuilder<ISplashControlConstruction>
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
            private class InternalBuilder : AbstractBuilder<ISplashControlConstruction>, IBuilder
            {
                /// <inheritdoc/>
                protected override ISplashControlConstruction BuildObj()
                {
                    return new SplashControlConstruction();
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                }
            }
        }
    }
}