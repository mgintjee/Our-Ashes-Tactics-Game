using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Models.Maps.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Models.Maps.Tiles.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Models.Maps.Impls
{
    /// <summary>
    /// Sortie Map Model Construction Impl
    /// </summary>
    public struct SortieMapModelConstruction : ISortieMapModelConstruction
    {
        // Todo
        private readonly ICollection<ISortieTileModelConstruction> _sortieTileModelConstrs;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="sortieTileModelConstrs"></param>
        private SortieMapModelConstruction(ICollection<ISortieTileModelConstruction> sortieTileModelConstrs)
        {
            _sortieTileModelConstrs = sortieTileModelConstrs;
        }

        /// <inheritdoc/>
        ISet<ISortieTileModelConstruction> ISortieMapModelConstruction.GetSortieTileModelConstrs()
        {
            return new HashSet<ISortieTileModelConstruction>(_sortieTileModelConstrs);
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
                IBuilder SetSortieTileModelConstruction(ICollection<ISortieTileModelConstruction> sortieTileModelConstrs);
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
                private ICollection<ISortieTileModelConstruction> _sortieTileModelConstrs;

                /// <inheritdoc/>
                IBuilder IBuilder.SetSortieTileModelConstruction(ICollection<ISortieTileModelConstruction> sortieTileModelConstrs)
                {
                    _sortieTileModelConstrs = new HashSet<ISortieTileModelConstruction>(sortieTileModelConstrs);
                    return this;
                }

                /// <inheritdoc/>
                protected override ISortieMapModelConstruction BuildObj()
                {
                    return new SortieMapModelConstruction(_sortieTileModelConstrs);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _sortieTileModelConstrs);
                }
            }
        }
    }
}