using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Widgets.Inters
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