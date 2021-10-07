using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Frames.Requests.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Frames.Requests.Implementations
{
    /// <summary>
    /// Sortie Request Interface
    /// </summary>
    public class SortieRequest : AbstractReport, ISortieRequest
    {
        // Todo
        private readonly CombatantCallSign _combatantCallSign;

        // Todo
        private readonly ISortieMapPath _sortieMapPath;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="callSign"></param>
        /// <param name="path">    </param>
        private SortieRequest(CombatantCallSign callSign, ISortieMapPath path)
        {
            _combatantCallSign = callSign;
            _sortieMapPath = path;
        }

        /// <inheritdoc/>
        CombatantCallSign ISortieRequest.GetCallSign()
        {
            return _combatantCallSign;
        }

        /// <inheritdoc/>
        ISortieMapPath ISortieRequest.GetPath()
        {
            return _sortieMapPath;
        }

        /// <inheritdoc/>
        protected override string GetContent()
        {
            return string.Format("{0}, {1}",
                StringUtils.Format(_combatantCallSign), _sortieMapPath);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<ISortieRequest>
            {
                IBuilder SetCombatantCallSign(CombatantCallSign combatantCallSign);

                IBuilder SetSortieMapPath(ISortieMapPath sortieMapPath);
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
            private class InternalBuilder : AbstractBuilder<ISortieRequest>, IBuilder
            {
                // Todo
                private CombatantCallSign _combatantCallSign;

                // Todo
                private ISortieMapPath _sortieMapPath;

                /// <inheritdoc/>
                IBuilder IBuilder.SetCombatantCallSign(CombatantCallSign combatantCallSign)
                {
                    _combatantCallSign = combatantCallSign;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetSortieMapPath(ISortieMapPath sortieMapPath)
                {
                    _sortieMapPath = sortieMapPath;
                    return this;
                }

                /// <inheritdoc/>
                protected override ISortieRequest BuildObj()
                {
                    return new SortieRequest(_combatantCallSign, _sortieMapPath);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _combatantCallSign);
                    this.Validate(invalidReasons, _sortieMapPath);
                }
            }
        }
    }
}