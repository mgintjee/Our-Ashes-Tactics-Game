using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Models.Maps.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Models.Maps.Tiles.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Models.Maps.Implementations
{
    /// <summary>
    /// Sortie Map Model Construction Implementation
    /// </summary>
    public struct SortieMapModelConstruction : ISortieMapModelConstruction
    {
        // Todo
        private readonly ICollection<ISortieTileModelConstruction> _sortieTileModelConstructions;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="sortieTileModelConstructions"></param>
        private SortieMapModelConstruction(ICollection<ISortieTileModelConstruction> sortieTileModelConstructions)
        {
            _sortieTileModelConstructions = sortieTileModelConstructions;
        }

        /// <inheritdoc/>
        ISet<ISortieTileModelConstruction> ISortieMapModelConstruction.GetSortieTileModelConstructions()
        {
            return new HashSet<ISortieTileModelConstruction>(_sortieTileModelConstructions);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<ISortieMapModelConstruction>
            {
                IBuilder SetSortieTileModelConstruction(ICollection<ISortieTileModelConstruction> sortieTileModelConstructions);
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
            private class InternalBuilder : AbstractBuilder<ISortieMapModelConstruction>, IBuilder
            {
                // Todo
                private ICollection<ISortieTileModelConstruction> _sortieTileModelConstructions;

                /// <inheritdoc/>
                IBuilder IBuilder.SetSortieTileModelConstruction(ICollection<ISortieTileModelConstruction> sortieTileModelConstructions)
                {
                    _sortieTileModelConstructions = new HashSet<ISortieTileModelConstruction>(sortieTileModelConstructions);
                    return this;
                }

                /// <inheritdoc/>
                protected override ISortieMapModelConstruction BuildObj()
                {
                    return new SortieMapModelConstruction(_sortieTileModelConstructions);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _sortieTileModelConstructions);
                }
            }
        }
    }
}