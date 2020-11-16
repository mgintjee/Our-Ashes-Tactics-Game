namespace HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information
{
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Factions;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Phalanxes;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public interface ITalonRoeReport
    {
        ISet<FactionId> GetFriendlyFactionIdSet();

        ISet<PhalanxId> GetFriendlyPhalanxIdSet();
    }
}
