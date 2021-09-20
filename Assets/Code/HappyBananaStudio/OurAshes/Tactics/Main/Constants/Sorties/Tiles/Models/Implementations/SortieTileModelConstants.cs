using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Sorties.Maps.Tiles.Attributes.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Sorties.Maps.Tiles.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Constants.Sorties.Tiles.Models.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Constants.Sorties.Tiles.Models.Implementations
{
    /// <summary>
    /// Sortie Tile Model Constants Implementation
    /// </summary>
    public struct SortieTileModelConstants : ISortieTileModelConstants
    {
        private readonly SortieTileID _sortieTileID;
        private readonly ISortieTileAttributes _sortieTileAttributes;

        private SortieTileModelConstants(SortieTileID sortieSortieTileID, ISortieTileAttributes sortieTileAttributes)
        {
            _sortieTileAttributes = sortieTileAttributes;
            _sortieTileID = sortieSortieTileID;
        }

        /// <inheritdoc/>
        ISortieTileAttributes ISortieTileModelConstants.GetSortieTileAttributes()
        {
            return _sortieTileAttributes;
        }

        /// <inheritdoc/>
        SortieTileID ISortieTileModelConstants.GetSortieTileID()
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
            public interface IBuilder : IBuilder<ISortieTileModelConstants>
            {
                IBuilder SetSortieTileID(SortieTileID sortieTileID);

                IBuilder SetSortieTileAttributes(ISortieTileAttributes sortieTileAttributes);
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
            /// Builder Implementation for this object
            /// </summary>
            private class InternalBuilder : AbstractBuilder<ISortieTileModelConstants>, IBuilder
            {
                private ISortieTileAttributes _sortieTileAttributes;
                private SortieTileID _sortieTileID;

                /// <inheritdoc/>
                IBuilder IBuilder.SetSortieTileID(SortieTileID sortieTileID)
                {
                    _sortieTileID = sortieTileID;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetSortieTileAttributes(ISortieTileAttributes sortieTileAttributes)
                {
                    _sortieTileAttributes = sortieTileAttributes;
                    return this;
                }

                /// <inheritdoc/>
                protected override ISortieTileModelConstants BuildObj()
                {
                    return new SortieTileModelConstants(_sortieTileID, _sortieTileAttributes);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _sortieTileID);
                    this.Validate(invalidReasons, _sortieTileAttributes);
                }
            }
        }
    }
}