using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Phalanxes.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Phalanxes.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Phalanxes.Models.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Phalanxes.Views.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Phalanxes.Implementaions
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct PhalanxConstruction
        : IPhalanxConstruction
    {
        // Todo
        private readonly PhalanxCallSign phalanxCallSign;

        // Todo
        private readonly IPhalanxModelConstruction phalanxModelConstruction;

        // Todo
        private readonly IPhalanxViewConstruction phalanxViewConstruction;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="phalanxCallSign">         </param>
        /// <param name="phalanxModelConstruction"></param>
        /// <param name="phalanxViewConstruction"> </param>
        private PhalanxConstruction(PhalanxCallSign phalanxCallSign,
            IPhalanxModelConstruction phalanxModelConstruction,
            IPhalanxViewConstruction phalanxViewConstruction)
        {
            this.phalanxCallSign = phalanxCallSign;
            this.phalanxModelConstruction = phalanxModelConstruction;
            this.phalanxViewConstruction = phalanxViewConstruction;
        }

        PhalanxCallSign IPhalanxConstruction.GetPhalanxCallSign()
        {
            return this.phalanxCallSign;
        }

        IPhalanxModelConstruction IPhalanxConstruction.GetPhalanxModelConstruction()
        {
            return this.phalanxModelConstruction;
        }

        Optional<IPhalanxViewConstruction> IPhalanxConstruction.GetPhalanxViewConstruction()
        {
            return Optional<IPhalanxViewConstruction>.Of(this.phalanxViewConstruction);
        }
    }
}