namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Roes.Managers
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Roes.Objects.Api;

    /// <summary>
    /// Roster Manager
    /// </summary>
    public class RoeManager
    {
        // Todo
        private static IRoeObject roeObject;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="roeObject"></param>
        public static void SetRoeObject(IRoeObject roeObject)
        {
            RoeManager.roeObject = roeObject;
        }
    }
}