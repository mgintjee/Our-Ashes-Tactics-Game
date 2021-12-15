using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Canvases.Inters
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