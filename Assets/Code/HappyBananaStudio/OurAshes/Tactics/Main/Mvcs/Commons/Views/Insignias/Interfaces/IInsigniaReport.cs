using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Schemes.Emblems.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Schemes.Patterns.IDs;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Insignias.Interfaces
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