using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Sorties.Maps.Tiles.IDs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Sorties.Maps.Tiles.Skins;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Constants.Sorties.Tiles.Views.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Constants.Sorties.Tiles.Views.Impls
{
    /// <summary>
    /// Sortie Tile View Constants Impl
    /// </summary>
    public struct SortieTileViewConstants : ISortieTileViewConstants
    {
        private readonly SortieTileID _sortieTileID;
        private readonly ICollection<SortieTileSkin> _sortieTileSkins;

        private SortieTileViewConstants(SortieTileID sortieSortieTileID, ICollection<SortieTileSkin> sortieTileSkins)
        {
            _sortieTileSkins = sortieTileSkins;
            _sortieTileID = sortieSortieTileID;
        }

        /// <inheritdoc/>
        ISet<SortieTileSkin> ISortieTileViewConstants.GetSortieTileSkins()
        {
            return new HashSet<SortieTileSkin>(_sortieTileSkins);
        }

        /// <inheritdoc/>
        SortieTileID ISortieTileViewConstants.GetSortieTileID()
        {
            return _sortieTileID;
        }

        /// <summary>
        /// Builder class for this object
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Builder Interface for this object
            /// </summary>
            public interface IBuilder : IBuilder<ISortieTileViewConstants>
            {
                IBuilder SetSortieTileID(SortieTileID sortieTileID);

                IBuilder SetSortieTileSkins(ICollection<SortieTileSkin> sortieTileSkins);
            }

            /// <summary>
            /// Get the Builder for this object
            /// </summary>
            /// <returns></returns>
            public static IBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Builder Impl for this object
            /// </summary>
            private class InternalBuilder : AbstractBuilder<ISortieTileViewConstants>, IBuilder
            {
                private ICollection<SortieTileSkin> _sortieTileSkins;
                private SortieTileID _sortieSortieTileID;

                /// <inheritdoc/>
                IBuilder IBuilder.SetSortieTileID(SortieTileID sortieSortieTileID)
                {
                    _sortieSortieTileID = sortieSortieTileID;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetSortieTileSkins(ICollection<SortieTileSkin> sortieTileSkins)
                {
                    _sortieTileSkins = new HashSet<SortieTileSkin>(sortieTileSkins);
                    return this;
                }

                /// <inheritdoc/>
                protected override ISortieTileViewConstants BuildObj()
                {
                    return new SortieTileViewConstants(_sortieSortieTileID, _sortieTileSkins);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _sortieSortieTileID);
                    this.Validate(invalidReasons, _sortieTileSkins);
                }
            }
        }
    }
}