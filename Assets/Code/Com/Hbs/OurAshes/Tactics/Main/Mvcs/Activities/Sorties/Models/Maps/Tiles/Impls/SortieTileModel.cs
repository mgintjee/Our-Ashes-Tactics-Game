using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Frames.Sorties.Maps.Tiles.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Maps.Coordinates.Cube.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Models.Maps.Tiles.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Models.Maps.Tiles.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Reports.Models.Tiles.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Reports.Models.Tiles.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using System.Diagnostics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Models.Maps.Tiles.Impls
{
    /// <summary>
    /// Sortie Tile Model Impl
    /// </summary>
    public class SortieTileModel
        : ISortieTileModel
    {
        // Provides logging capability
        private readonly IClassLogger logger = LoggerManager.GetLogger(MvcType.Sortie)
            .GetClassLogger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly ICubeCoordinates _cubeCoordinates;

        // Todo
        private readonly SortieTileID _sortieTileID;

        // Todo
        private CombatantCallSign _combatantCallSign;

        // Todo
        private ISortieTileReport _sortieTileReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="sortieTileModelConstruction"></param>
        public SortieTileModel(ISortieTileModelConstruction sortieTileModelConstruction)
        {
            _cubeCoordinates = sortieTileModelConstruction.GetCubeCoordinates();
            _sortieTileID = sortieTileModelConstruction.GetSortieTileID();
            _combatantCallSign = CombatantCallSign.None;
            this.BuildReport();
        }

        /// <inheritdoc/>
        ISortieTileReport ISortieTileModel.GetReport()
        {
            return _sortieTileReport;
        }

        /// <inheritdoc/>
        void ISortieTileModel.SetCombatantCallSign(CombatantCallSign combatantCallSign)
        {
            if (combatantCallSign != CombatantCallSign.None)
            {
                logger.Info("Setting {} @ {}", combatantCallSign, _cubeCoordinates);
            }
            else
            {
                logger.Info("Clearing {} @ {}", typeof(CombatantCallSign), _cubeCoordinates);
            }
            _combatantCallSign = combatantCallSign;
            this.BuildReport();
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void BuildReport()
        {
            _sortieTileReport = SortieTileReport.Builder.Get()
                    .SetCombatantCallSign(_combatantCallSign)
                    .SetCubeCoordinates(_cubeCoordinates)
                    .SetSortieTileID(_sortieTileID)
                    .Build();
        }
    }
}