using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Canvases.Interfaces
{
    /// <summary>
    /// Canvas Builder class Interface
    /// </summary>
    public interface ICanvasBuilder<T> : IBuilder<T>
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ICanvasBuilder<T> SetName(string name);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ICanvasBuilder<T> SetParent(IUnityScript unityScript);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ICanvasBuilder<T> SetMeasurements(ICanvasGridMeasurements canvasGridMeasurements);
    }
}