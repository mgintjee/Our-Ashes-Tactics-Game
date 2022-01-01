﻿using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Frames.Sorties.Maps.Tiles.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Maps.Coordinates.Cube.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Reports.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Reports.Models.Tiles.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Reports.Models.Tiles.Impls
{
    /// <summary>
    /// Sortie Tile Report Impl
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