using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Sorties.Maps.Tiles.IDs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Maps.Coordinates.Cube.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Models.Maps.Tiles.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Models.Maps.Tiles.Impls
{
    /// <summary>
    /// Sortie Tile Model Construction Impl
    /// </summary>
    public class SortieTileModelConstruction : ISortieTileModelConstruction
    {
        // Todo
        private readonly ICubeCoordinates _cubeCoordinates;

        // Todo
        private readonly SortieTileID _sortieTileID;

        // Todo
        private readonly CombatantCallSign _combatantCallSign;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <param name="sortieTileID">   </param>
        private SortieTileModelConstruction(ICubeCoordinates cubeCoordinates, SortieTileID sortieTileID, CombatantCallSign combatantCallSign)
        {
            _cubeCoordinates = cubeCoordinates;
            _sortieTileID = sortieTileID;
            _combatantCallSign = combatantCallSign;
        }

        /// <inheritdoc/>
        ICubeCoordinates ISortieTileModelConstruction.GetCubeCoordinates()
        {
            return _cubeCoordinates;
        }

        /// <inheritdoc/>
        SortieTileID ISortieTileModelConstruction.GetSortieTileID()
        {
            return _sortieTileID;
        }

        /// <inheritdoc/>
        CombatantCallSign ISortieTileModelConstruction.GetCombatantCallSign()
        {
            return _combatantCallSign;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<ISortieTileModelConstruction>
            {
                IBuilder SetCubeCoordinates(ICubeCoordinates cubeCoordinates);

                IBuilder SetSortieTileID(SortieTileID sortieTileID);

                IBuilder SetCombatantCallSign(CombatantCallSign combatantCallSign);
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
            private class InternalBuilder : AbstractBuilder<ISortieTileModelConstruction>, IBuilder
            {
                // Todo
                private ICubeCoordinates _cubeCoordinates;

                // Todo
                private SortieTileID _sortieTileID;

                // Todo
                private CombatantCallSign _combatantCallSign;

                /// <inheritdoc/>
                IBuilder IBuilder.SetCubeCoordinates(ICubeCoordinates cubeCoordinates)
                {
                    _cubeCoordinates = cubeCoordinates;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetSortieTileID(SortieTileID sortieTileID)
                {
                    _sortieTileID = sortieTileID;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetCombatantCallSign(CombatantCallSign combatantCallSign)
                {
                    _combatantCallSign = combatantCallSign;
                    return this;
                }

                /// <inheritdoc/>
                protected override ISortieTileModelConstruction BuildObj()
                {
                    return new SortieTileModelConstruction(_cubeCoordinates, _sortieTileID, _combatantCallSign);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _cubeCoordinates);
                    this.Validate(invalidReasons, _sortieTileID);
                }
            }
        }
    }
}