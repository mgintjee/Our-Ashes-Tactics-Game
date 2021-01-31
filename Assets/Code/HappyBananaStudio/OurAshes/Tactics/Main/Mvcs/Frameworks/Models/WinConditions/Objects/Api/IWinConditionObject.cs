namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.WinConditions.Objects.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.WinConditions.Reports.Api;

    /// <summary>
    /// WinCondition Object Api
    /// </summary>
    public interface IWinConditionObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IWinConditionReport GetWinConditionReport();
    }
}