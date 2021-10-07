using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Views.Engagements.Phalanxes.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Views.Insignias.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Views.Engagements.Phalanxes.Implementations
{
    /// <summary>
    /// Phalanx View Construction Implementation
    /// </summary>
    public struct PhalanxViewConstruction : IPhalanxViewConstruction
    {
        // Todo
        private readonly PhalanxCallSign _phalanxCallSign;

        // Todo
        private readonly IInsigniaReport _insigniaReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="phalanxCallSign"></param>
        /// <param name="insigniaReport"> </param>
        private PhalanxViewConstruction(PhalanxCallSign phalanxCallSign, IInsigniaReport insigniaReport)
        {
            _phalanxCallSign = phalanxCallSign;
            _insigniaReport = insigniaReport;
        }

        /// <inheritdoc/>
        PhalanxCallSign IPhalanxViewConstruction.GetPhalanxCallSign()
        {
            return _phalanxCallSign;
        }

        /// <inheritdoc/>
        IInsigniaReport IPhalanxViewConstruction.GetInsigniaReport()
        {
            return _insigniaReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<IPhalanxViewConstruction>
            {
                IBuilder SetPhalanxCallSign(PhalanxCallSign phalanxCallSign);

                IBuilder SetInsigniaReport(IInsigniaReport insigniaReport);
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
            private class InternalBuilder : AbstractBuilder<IPhalanxViewConstruction>, IBuilder
            {
                private IInsigniaReport _insigniaReport;
                private PhalanxCallSign _phalanxCallSign;

                /// <inheritdoc/>
                IBuilder IBuilder.SetPhalanxCallSign(PhalanxCallSign phalanxCallSign)
                {
                    _phalanxCallSign = phalanxCallSign;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetInsigniaReport(IInsigniaReport insigniaReport)
                {
                    _insigniaReport = insigniaReport;
                    return this;
                }

                /// <inheritdoc/>
                protected override IPhalanxViewConstruction BuildObj()
                {
                    return new PhalanxViewConstruction(_phalanxCallSign, _insigniaReport);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _phalanxCallSign);
                    this.Validate(invalidReasons, _insigniaReport);
                }
            }
        }
    }
}