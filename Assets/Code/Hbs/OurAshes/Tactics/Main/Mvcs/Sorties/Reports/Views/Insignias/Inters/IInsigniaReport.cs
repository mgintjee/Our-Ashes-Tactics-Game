using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Views.Schemes.Emblems.IDs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Views.Schemes.Patterns.IDs;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Views.Insignias.Inters
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