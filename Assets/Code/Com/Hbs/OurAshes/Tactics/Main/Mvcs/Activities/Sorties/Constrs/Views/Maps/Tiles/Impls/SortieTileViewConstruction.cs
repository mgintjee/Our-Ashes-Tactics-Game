﻿using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Frames.Sorties.Maps.Tiles.Skins;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Maps.Coordinates.Cube.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Views.Maps.Tiles.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Views.Maps.Tiles.Impls
{
    /// <summary>
    /// Sortie Tile View Construction Impl
    /// </summary>
    public class SortieTileViewConstruction : ISortieTileViewConstruction
    {
        // Todo
        private readonly ICubeCoordinates _cubeCoordinates;

        // Todo
        private readonly SortieTileSkin _sortieTileSkin;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <param name="sortieTileSkin"> </param>
        private SortieTileViewConstruction(ICubeCoordinates cubeCoordinates, SortieTileSkin sortieTileSkin)
        {
            _cubeCoordinates = cubeCoordinates;
            _sortieTileSkin = sortieTileSkin;
        }

        /// <inheritdoc/>
        ICubeCoordinates ISortieTileViewConstruction.GetCubeCoordinates()
        {
            return _cubeCoordinates;
        }

        /// <inheritdoc/>
        SortieTileSkin ISortieTileViewConstruction.GetSortieTileSkin()
        {
            return _sortieTileSkin;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<ISortieTileViewConstruction>
            {
                IBuilder SetCubeCoordinates(ICubeCoordinates cubeCoordinates);

                IBuilder SetSortieTileSkin(SortieTileSkin sortieTileSkin);
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
            private class InternalBuilder : AbstractBuilder<ISortieTileViewConstruction>, IBuilder
            {
                // Todo
                private ICubeCoordinates _cubeCoordinates;

                // Todo
                private SortieTileSkin _sortieTileSkin;

                /// <inheritdoc/>
                IBuilder IBuilder.SetCubeCoordinates(ICubeCoordinates cubeCoordinates)
                {
                    _cubeCoordinates = cubeCoordinates;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetSortieTileSkin(SortieTileSkin sortieTileSkin)
                {
                    _sortieTileSkin = sortieTileSkin;
                    return this;
                }

                /// <inheritdoc/>
                protected override ISortieTileViewConstruction BuildObj()
                {
                    return new SortieTileViewConstruction(_cubeCoordinates, _sortieTileSkin);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _cubeCoordinates);
                    this.Validate(invalidReasons, _sortieTileSkin);
                }
            }
        }
    }
}