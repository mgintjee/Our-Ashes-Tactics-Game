using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Screens.Loadings.Models.Constrs.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Screens.Loadings.Models.Constrs.Impls
{
    /// <summary>
    /// Loading Mvc Model Impl
    /// </summary>
    public class LoadingModelConstruction
        : ILoadingModelConstruction
    {
        private LoadingModelConstruction()
        {
        }

        public class Builder
        {
            public interface IInternalBuilder
                : IBuilder<ILoadingModelConstruction>
            {
            }

            public static IInternalBuilder Get()
            {
                return new InternalBuilderImpl();
            }

            private class InternalBuilderImpl
                : AbstractBuilder<ILoadingModelConstruction>, IInternalBuilder
            {
                /// <inheritdoc/>
                protected override ILoadingModelConstruction BuildObj()
                {
                    return new LoadingModelConstruction();
                }
            }
        }
    }
}