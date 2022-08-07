using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Constants
{
    /// <summary>
    /// Todo
    /// </summary>
    public class CanvasGridConstants
    {
        // Todo
        private static readonly IDictionary<MvcType, Vector2> MVC_TYPE_GRID_SIZES =
            new Dictionary<MvcType, Vector2>()
            {
                // Screen MVCs
                { MvcType.SplashScreen, new Vector2(9, 7) },
                { MvcType.LoadingScreen, new Vector2(9, 7) },
                // Menu MVCs
                { MvcType.HomeMenu, new Vector2(9, 7) },
                { MvcType.QSortieMenu, new Vector2(9, 7) }
            };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcType"></param>
        /// <returns></returns>
        public static Vector2 GetMvcTypeGridSize(MvcType mvcType)
        {
            if (MVC_TYPE_GRID_SIZES.ContainsKey(mvcType))
            {
                return MVC_TYPE_GRID_SIZES[mvcType];
            }
            return Vector2.One;
        }
    }
}