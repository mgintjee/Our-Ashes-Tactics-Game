using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Maps.Coordinates.Cube.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Sorties.Maps.Tiles.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Constructions.Models.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Reports.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.Tiles.Interfaces;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.Tiles.Implementations
{
    /// <summary>
    /// Sortie Tile Model Implementation
    /// </summary>
    public class SortieTileModel
        : ISortieTileModel
    {
        // Provides logging capability
        private readonly ILogger _logger = LoggerManager.GetLogger(MvcType.Sortie, new StackFrame().GetMethod().DeclaringType);

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
                _logger.Info("Setting {} @ {}", combatantCallSign, _cubeCoordinates);
            }
            else
            {
                _logger.Info("Clearing {} @ {}", typeof(CombatantCallSign), _cubeCoordinates);
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