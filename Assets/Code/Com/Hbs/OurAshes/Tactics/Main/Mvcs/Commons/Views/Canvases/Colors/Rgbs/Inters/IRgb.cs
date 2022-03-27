using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IRgb
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        float GetFloatBlue();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        float GetFloatGreen();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        float GetFloatRed();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        int GetIntBlue();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        int GetIntGreen();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        int GetIntRed();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ColorID GetColorID();
    }
}