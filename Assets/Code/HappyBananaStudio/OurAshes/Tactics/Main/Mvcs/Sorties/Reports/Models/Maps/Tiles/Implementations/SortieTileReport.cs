using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Maps.Coordinates.Cube.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Sorties.Maps.Tiles.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Utils.Strings;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Maps.Tiles.Implementations
{
    /// <summary>
    /// Sortie Tile Report Implementation
    /// </summary>
    public class SortieTileReport : AbstractReport, ISortieTileReport
    {
        // Todo
        private readonly CombatantCallSign _combatantCallSign;

        // Todo
        private readonly ICubeCoordinates _cubeCoordinates;

        // Todo
        private readonly SortieTileID _sortieTileID;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <param name="sortieTileID">   </param>
        /// <param name="callSign">       </param>
        private SortieTileReport(ICubeCoordinates cubeCoordinates,
            SortieTileID sortieTileID, CombatantCallSign callSign)
        {
            _cubeCoordinates = cubeCoordinates;
            _sortieTileID = sortieTileID;
            _combatantCallSign = callSign;
        }

        /// <inheritdoc/>
        CombatantCallSign ISortieTileReport.GetCombatantCallSign()
        {
            return _combatantCallSign;
        }

        /// <inheritdoc/>
        ICubeCoordinates ISortieTileReport.GetCubeCoordinates()
        {
            return _cubeCoordinates;
        }

        /// <inheritdoc/>
        SortieTileID ISortieTileReport.GetSortieTileID()
        {
            return _sortieTileID;
        }

        /// <inheritdoc/>
        protected override string GetContent()
        {
            return string.Format("{0}, {1}, {2}",
                _cubeCoordinates, StringUtils.Format(_combatantCallSign), StringUtils.Format(_sortieTileID));
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<ISortieTileReport>
            {
                IBuilder SetCombatantCallSign(CombatantCallSign combatantCallSign);

                IBuilder SetCubeCoordinates(ICubeCoordinates cubeCoordinates);

                IBuilder SetSortieTileID(SortieTileID sortieTileID);
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
            private class InternalBuilder : AbstractBuilder<ISortieTileReport>, IBuilder
            {
                // Todo
                private CombatantCallSign _combatantCallSign = CombatantCallSign.None;

                // Todo
                private ICubeCoordinates _cubeCoordinates;

                // Todo
                private SortieTileID _sortieTileID;

                /// <inheritdoc/>
                IBuilder IBuilder.SetCombatantCallSign(CombatantCallSign combatantCallSign)
                {
                    _combatantCallSign = combatantCallSign;
                    return this;
                }

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
                protected override ISortieTileReport BuildObj()
                {
                    return new SortieTileReport(_cubeCoordinates, _sortieTileID, _combatantCallSign);
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