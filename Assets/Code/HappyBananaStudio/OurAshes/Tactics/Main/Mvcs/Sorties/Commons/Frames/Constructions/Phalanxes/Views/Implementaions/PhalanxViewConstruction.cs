using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Phalanxes.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Schemes.Insignias.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Phalanxes.Views.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Phalanxes.Views.Implementaions
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct PhalanxViewConstruction
        : IPhalanxViewConstruction
    {
        IInsigniaScheme IPhalanxViewConstruction.GetInsigniaScheme()
        {
            throw new System.NotImplementedException();
        }

        PhalanxCallSign IPhalanxViewConstruction.GetPhalanxCallSign()
        {
            throw new System.NotImplementedException();
        }
    }
}