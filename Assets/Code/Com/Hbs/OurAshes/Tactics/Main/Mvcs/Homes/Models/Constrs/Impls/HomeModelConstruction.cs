using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Homes.Models.Constrs.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Homes.Models.Constrs.Impls
{
    /// <summary>
    /// Home Mvc Model Impl
    /// </summary>
    public class HomeModelConstruction
        : IHomeModelConstruction
    {
        /// <summary>
        /// Todo
        /// </summary>
        private HomeModelConstruction()
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
            public interface IBuilder
                : IBuilder<IHomeModelConstruction>
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
            private class InternalBuilder
                : AbstractBuilder<IHomeModelConstruction>, IBuilder
            {
                /// <inheritdoc/>
                protected override IHomeModelConstruction BuildObj()
                {
                    return new HomeModelConstruction();
                }
            }
        }
    }
}