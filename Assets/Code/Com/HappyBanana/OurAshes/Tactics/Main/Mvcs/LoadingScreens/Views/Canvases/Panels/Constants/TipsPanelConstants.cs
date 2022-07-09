using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.LoadingScreens.Views.Canvases.Panels.Constants
{
    /// <summary>
    /// Todo
    /// </summary>
    public class TipsPanelConstants
    {
        private static readonly IList<string> LOADING_SCREEN_TIPS = new List<string>()
        {
            "TIP 1",
            "TIP 2",
            "TIP 3",
            "TIP 4"
        };

        public static string GetRandomLoadingScreenTip()
        {
            int randomIndex = RandomManager.GetRandom(MvcType.LoadingScreen).Next(LOADING_SCREEN_TIPS.Count);
            return new List<string>(LOADING_SCREEN_TIPS)[randomIndex];
        }
    }
}