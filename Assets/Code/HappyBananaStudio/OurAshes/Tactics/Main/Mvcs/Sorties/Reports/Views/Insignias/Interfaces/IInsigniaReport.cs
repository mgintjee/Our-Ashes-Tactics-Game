using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Views.Insignias.Interfaces
{
    /// <summary>
    /// Insignia Report Interface
    /// </summary>
    public interface IInsigniaReport : IReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        PatternSchemeID GetPatternSchemeID();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        EmblemSchemeID GetEmblemSchemeID();
    }
}