using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.IDs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Skins.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Skins.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Schemes.Insignias.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combatants.Constructions.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combatants.Constructions.Implementaions
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct CombatantConstruction
        : ICombatantConstruction
    {
        // Todo
        private readonly CombatantCallSign _combatantCallSign;

        // Todo
        private readonly CombatantID _combatantID;

        // Todo
        private readonly ILoadoutReport _loadoutReport;

        // Todo
        private readonly CombatantSkin _combatantSkin;

        // Todo
        private readonly IList<GearSkin> _gearSkins;

        // Todo
        private readonly IInsigniaScheme _insigniaScheme;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantCallSign"></param>
        /// <param name="combatantID">      </param>
        /// <param name="loadoutReport">    </param>
        /// <param name="combatantSkin">    </param>
        /// <param name="gearSkins">        </param>
        /// <param name="insigniaScheme">   </param>
        private CombatantConstruction(CombatantCallSign combatantCallSign, CombatantID combatantID,
            ILoadoutReport loadoutReport, CombatantSkin combatantSkin, IList<GearSkin> gearSkins,
            IInsigniaScheme insigniaScheme)
        {
            _combatantCallSign = combatantCallSign;
            _combatantID = combatantID;
            _loadoutReport = loadoutReport;
            _combatantSkin = combatantSkin;
            _gearSkins = gearSkins;
            _insigniaScheme = insigniaScheme;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            string value = (_gearSkins.Count != 0)
                ? string.Join(", ", _gearSkins)
                : "empty";
            return string.Format("{0}: " +
                "\n{1}" +
                "\n{2}" +
                "\n{3}" +
                "\n{4}" +
                "\n{5}" +
                "\n {6}",
                this.GetType().Name,
                StringUtils.Format(typeof(CombatantCallSign), this._combatantCallSign),
                StringUtils.Format(typeof(CombatantID), this._combatantID),
                this._loadoutReport,
                StringUtils.Format(typeof(CombatantSkin), _combatantSkin),
                (_insigniaScheme != null) ? _insigniaScheme.ToString() : typeof(IInsigniaScheme).Name + ": Null",
                StringUtils.Format(typeof(GearSkin), value));
        }

        /// <inheritdoc/>
        CombatantID ICombatantConstruction.GetCombatantID()
        {
            return _combatantID;
        }

        /// <inheritdoc/>
        ILoadoutReport ICombatantConstruction.GetLoadoutReport()
        {
            return _loadoutReport;
        }

        /// <inheritdoc/>
        CombatantSkin ICombatantConstruction.GetCombatantSkin()
        {
            return _combatantSkin;
        }

        /// <inheritdoc/>
        Optional<IInsigniaScheme> ICombatantConstruction.GetInsigniaScheme()
        {
            return Optional<IInsigniaScheme>.Of(_insigniaScheme);
        }

        /// <inheritdoc/>
        IList<GearSkin> ICombatantConstruction.GetGearSkins()
        {
            return new List<GearSkin>(_gearSkins);
        }

        /// <inheritdoc/>
        CombatantCallSign ICombatantConstruction.GetCombatantCallSign()
        {
            return _combatantCallSign;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private CombatantCallSign _combatantCallSign = CombatantCallSign.None;

            // Todo
            private CombatantID _combatantID = CombatantID.None;

            // Todo
            private ILoadoutReport _loadoutReport = null;

            // Todo
            private CombatantSkin _combatantSkin = CombatantSkin.None;

            // Todo
            private IList<GearSkin> _gearSkins = new List<GearSkin>();

            // Todo
            private IInsigniaScheme _insigniaScheme = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ICombatantConstruction Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new construction
                    return new CombatantConstruction(_combatantCallSign, _combatantID,
                        _loadoutReport, _combatantSkin, _gearSkins, _insigniaScheme);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="combatantCallSign"></param>
            /// <returns></returns>
            public Builder SetCombatantCallSign(CombatantCallSign combatantCallSign)
            {
                _combatantCallSign = combatantCallSign;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="combatantID"></param>
            /// <returns></returns>
            public Builder SetCombatantID(CombatantID combatantID)
            {
                _combatantID = combatantID;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="loadoutReport"></param>
            /// <returns></returns>
            public Builder SetLoadoutReport(ILoadoutReport loadoutReport)
            {
                _loadoutReport = loadoutReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="combatantSkin"></param>
            /// <returns></returns>
            public Builder SetCombatantSkin(CombatantSkin combatantSkin)
            {
                _combatantSkin = combatantSkin;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="gearSkins"></param>
            /// <returns></returns>
            public Builder SetGearSkins(IList<GearSkin> gearSkins)
            {
                if (gearSkins != null)
                {
                    _gearSkins = new List<GearSkin>(gearSkins);
                }
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="insigniaScheme"></param>
            /// <returns></returns>
            public Builder SetInsigniaScheme(IInsigniaScheme insigniaScheme)
            {
                _insigniaScheme = insigniaScheme;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                // Check that _combatantCallSign has been set
                if (_combatantCallSign == CombatantCallSign.None)
                {
                    argumentExceptionSet.Add(typeof(CombatantCallSign).Name + " cannot be none.");
                }
                // Check that _combatantID has been set
                if (_combatantID == CombatantID.None)
                {
                    argumentExceptionSet.Add(typeof(CombatantID).Name + " cannot be none.");
                }
                // Check that _loadoutReport has been set
                if (_loadoutReport == null)
                {
                    argumentExceptionSet.Add(typeof(ILoadoutReport).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}