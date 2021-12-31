using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Views.Maps.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Views.Maps.Tiles.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Views.Maps.Impls
{
    /// <summary>
    /// Sortie Map View Construction Impl
    /// </summary>
    public struct SortieMapViewConstruction : ISortieMapViewConstruction
    {
        // Todo
        private readonly ICollection<ISortieTileViewConstruction> _sortieTileViewConstrs;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="sortieTileViewConstrs"></param>
        private SortieMapViewConstruction(ICollection<ISortieTileViewConstruction> sortieTileViewConstrs)
        {
            _sortieTileViewConstrs = sortieTileViewConstrs;
        }

        /// <inheritdoc/>
        ISet<ISortieTileViewConstruction> ISortieMapViewConstruction.GetSortieTileViewConstrs()
        {
            return new HashSet<ISortieTileViewConstruction>(_sortieTileViewConstrs);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<ISortieMapViewConstruction>
            {
                IBuilder SetSortieTileViewConstruction(ICollection<ISortieTileViewConstruction> sortieTileViewConstrs);
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
            private class InternalBuilder : AbstractBuilder<ISortieMapViewConstruction>, IBuilder
            {
                // Todo
                private ICollection<ISortieTileViewConstruction> _sortieTileViewConstrs;

                /// <inheritdoc/>
                IBuilder IBuilder.SetSortieTileViewConstruction(ICollection<ISortieTileViewConstruction> sortieTileViewConstrs)
                {
                    _sortieTileViewConstrs = new HashSet<ISortieTileViewConstruction>(sortieTileViewConstrs);
                    return this;
                }

                protected override ISortieMapViewConstruction BuildObj()
                {
                    return new SortieMapViewConstruction(_sortieTileViewConstrs);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _sortieTileViewConstrs);
                }
            }
        }
    }
}