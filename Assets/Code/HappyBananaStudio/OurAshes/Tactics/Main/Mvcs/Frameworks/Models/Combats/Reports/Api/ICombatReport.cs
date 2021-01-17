namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Combats.Reports.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Effects.Objects.Api;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public interface ICombatReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<ITalonEffectObject> GetTalonEffectObjectSet();
    }
}