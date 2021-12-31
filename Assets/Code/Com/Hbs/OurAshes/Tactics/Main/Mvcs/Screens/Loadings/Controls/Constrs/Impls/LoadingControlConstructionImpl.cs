using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Screens.Loadings.Controls.Constrs.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Screens.Loadings.Controls.Constrs.Impls
{
    /// <summary>
    /// Loading Control Construction Implementation
    /// </summary>
    public class LoadingControlConstructionImpl
        : ILoadingControlConstruction
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcControlConstruction"></param>
        private LoadingControlConstructionImpl()
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
            public interface IInternalBuilder
                : IBuilder<ILoadingControlConstruction>
            {
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static IInternalBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Todo
            /// </summary>
            private class InternalBuilder
                : AbstractBuilder<ILoadingControlConstruction>, IInternalBuilder
            {
                /// <inheritdoc/>
                protected override ILoadingControlConstruction BuildObj()
                {
                    return new LoadingControlConstructionImpl();
                }
            }
        }
    }
}