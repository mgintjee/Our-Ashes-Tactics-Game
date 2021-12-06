using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Homes.Controllers.Constrs.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Homes.Controllers.Constrs.Impls
{
    /// <summary>
    /// Home Controller Interface
    /// </summary>
    public class HomeControllerConstruction : IHomeControllerConstruction
    {
        /// <summary>
        /// Todo
        /// </summary>
        private HomeControllerConstruction()
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
            public interface IBuilder : IBuilder<IHomeControllerConstruction>
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
            private class InternalBuilder : AbstractBuilder<IHomeControllerConstruction>, IBuilder
            {
                /// <inheritdoc/>
                protected override IHomeControllerConstruction BuildObj()
                {
                    return new HomeControllerConstruction();
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                }
            }
        }
    }
}