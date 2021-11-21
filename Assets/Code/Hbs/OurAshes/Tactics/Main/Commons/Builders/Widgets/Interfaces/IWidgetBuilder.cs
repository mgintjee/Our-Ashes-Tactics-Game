using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Interfaces;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Widgets.Interfaces
{
    /// <summary>
    /// Widget Builder class Interface
    /// </summary>
    public interface IWidgetBuilder<T> : IBuilder<T>
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IWidgetBuilder<T> SetName(string name);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IWidgetBuilder<T> SetParent(IUnityScript unityScript);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IWidgetBuilder<T> SetMeasurements(ICanvasGridMeasurements canvasGridMeasurements);
    }
}