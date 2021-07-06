using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Requests.Implementations
{
    /// <summary>
    /// Sortie Request Interface
    /// </summary>
    public class SortieRequest
        : AbstractReport, ISortieRequest
    {
        // Todo
        private readonly CombatantCallSign _callSign;

        // Todo
        private readonly IPath _path;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="callSign"></param>
        /// <param name="path">    </param>
        private SortieRequest(CombatantCallSign callSign, IPath path)
        {
            _callSign = callSign;
            _path = path;
        }

        /// <inheritdoc/>
        CombatantCallSign ISortieRequest.GetCallSign()
        {
            return _callSign;
        }

        /// <inheritdoc/>
        IPath ISortieRequest.GetPath()
        {
            return _path;
        }

        /// <inheritdoc/>
        protected override string GetContent()
        {
            return string.Format("{0}, {1}",
                StringUtils.Format(_callSign),
                StringUtils.Format(_path));
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
            : AbstractBuilder<ISortieRequest>
        {
            // Todo
            private CombatantCallSign _combatantCallSign = CombatantCallSign.None;

            // Todo
            private IPath _path = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="combatantCallSigns"></param>
            /// <returns></returns>
            public Builder SetCombatantCallSign(CombatantCallSign combatantCallSigns)
            {
                _combatantCallSign = combatantCallSigns;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="path"></param>
            /// <returns></returns>
            public Builder SetPath(IPath path)
            {
                _path = path;
                return this;
            }

            /// <inheritdoc/>
            protected override ISortieRequest BuildObj()
            {
                return new SortieRequest(_combatantCallSign, _path);
            }

            /// <inheritdoc/>
            protected override void Validate(ISet<string> invalidReasons)
            {
                ValidateEnum(invalidReasons, _combatantCallSign);
                Validate(invalidReasons, _path);
            }
        }
    }
}