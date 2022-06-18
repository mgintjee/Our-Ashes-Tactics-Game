using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Inters;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class WidgetGridSpecImpl
        : IWidgetGridSpec
    {
        // Todo
        private Vector2 gridCoords;

        // Todo
        private Vector2 gridSize;

        /// <summary>
        /// Todo
        /// </summary>
        public WidgetGridSpecImpl()
        {
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: gridSize:{1}, gridCoords:{2}",
                this.GetType().Name, this.gridSize, this.gridCoords);
        }

        public WidgetGridSpecImpl SetCanvasGridSize(Vector2 gridSize)
        {
            this.gridSize = gridSize;
            return this;
        }

        public WidgetGridSpecImpl SetCanvasGridCoords(Vector2 gridCoords)
        {
            this.gridCoords = gridCoords;
            return this;
        }

        /// <inheritdoc/>
        Vector2 IWidgetGridSpec.GetGridCoords()
        {
            return this.gridCoords;
        }

        /// <inheritdoc/>
        Vector2 IWidgetGridSpec.GetGridSize()
        {
            return this.gridSize;
        }
    }
}