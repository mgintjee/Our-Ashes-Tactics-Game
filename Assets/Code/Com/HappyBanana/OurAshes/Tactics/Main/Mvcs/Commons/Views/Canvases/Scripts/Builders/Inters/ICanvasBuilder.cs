using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Builders.Inters;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Scripts.Builders.Inters
{
    /// <summary>
    /// Canvas Builder class Interface
    /// </summary>
    public interface ICanvasBuilder<T>
        : IScriptBuilder<T>
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ICanvasBuilder<T> SetGridSize(Vector2 gridSize);
    }
}