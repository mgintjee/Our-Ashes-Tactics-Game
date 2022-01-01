using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Reports.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Commons.Maps.Paths.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Frames.Requests.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Frames.Requests.Impls
{
    /// <summary>
    /// Sortie Request Interface
    /// </summary>
    public class SortieRequest : AbstractReport, IMvcControlSortieRequest
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
        CombatantCallSign IMvcControlSortieRequest.GetCallSign()
        {
            return _combatantCallSign;
        }

        /// <inheritdoc/>
        ISortieMapPath IMvcControlSortieRequest.GetPath()
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
            public interface IBuilder : IBuilder<IMvcControlSortieRequest>
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
            private class InternalBuilder : AbstractBuilder<IMvcControlSortieRequest>, IBuilder
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
                protected override IMvcControlSortieRequest BuildObj()
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