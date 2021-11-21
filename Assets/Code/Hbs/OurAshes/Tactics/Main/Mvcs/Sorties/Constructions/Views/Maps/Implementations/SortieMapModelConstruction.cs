using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Views.Maps.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Views.Maps.Tiles.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Views.Maps.Implementations
{
    /// <summary>
    /// Sortie Map View Construction Implementation
    /// </summary>
    public struct SortieMapViewConstruction : ISortieMapViewConstruction
    {
        // Todo
        private readonly ICollection<ISortieTileViewConstruction> _sortieTileViewConstructions;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="sortieTileViewConstructions"></param>
        private SortieMapViewConstruction(ICollection<ISortieTileViewConstruction> sortieTileViewConstructions)
        {
            _sortieTileViewConstructions = sortieTileViewConstructions;
        }

        /// <inheritdoc/>
        ISet<ISortieTileViewConstruction> ISortieMapViewConstruction.GetSortieTileViewConstructions()
        {
            return new HashSet<ISortieTileViewConstruction>(_sortieTileViewConstructions);
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
                IBuilder SetSortieTileViewConstruction(ICollection<ISortieTileViewConstruction> sortieTileViewConstructions);
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
                private ICollection<ISortieTileViewConstruction> _sortieTileViewConstructions;

                /// <inheritdoc/>
                IBuilder IBuilder.SetSortieTileViewConstruction(ICollection<ISortieTileViewConstruction> sortieTileViewConstructions)
                {
                    _sortieTileViewConstructions = new HashSet<ISortieTileViewConstruction>(sortieTileViewConstructions);
                    return this;
                }

                protected override ISortieMapViewConstruction BuildObj()
                {
                    return new SortieMapViewConstruction(_sortieTileViewConstructions);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _sortieTileViewConstructions);
                }
            }
        }
    }
}