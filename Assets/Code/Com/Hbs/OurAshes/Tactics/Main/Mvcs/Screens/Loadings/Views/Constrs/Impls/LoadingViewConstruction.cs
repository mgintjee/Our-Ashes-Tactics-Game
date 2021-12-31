using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Screens.Loadings.Views.Constrs.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Screens.Loadings.Views.Constrs.Impls
{
    /// <summary>
    /// Loading View Construction Impl
    /// </summary>
    public class LoadingViewConstruction
        : ILoadingViewConstruction
    {
        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IInternalBuilder
                : IBuilder<ILoadingViewConstruction>
            {
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static IInternalBuilder Get()
            {
                return new InternalBuilderImpl();
            }

            /// <summary>
            /// Todo
            /// </summary>
            private class InternalBuilderImpl
                : AbstractBuilder<ILoadingViewConstruction>, IInternalBuilder
            {
                /// <inheritdoc/>
                protected override ILoadingViewConstruction BuildObj()
                {
                    return new LoadingViewConstruction();
                }
            }
        }
    }
}