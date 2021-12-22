using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Specs.Inters;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Specs.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class CanvasWidgetSpecImpl
        : ICanvasWidgetSpec
    {
        // Todo
        private Vector2 gridCoords;

        // Todo
        private Vector2 gridSize;

        // Todo
        private int level;

        // Todo
        private bool interactable;

        // Todo
        private Vector2 worldSize;

        // Todo
        private Vector2 worldCoords;

        /// <summary>
        /// Todo
        /// </summary>
        public CanvasWidgetSpecImpl()
        {
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: level:{1}, interactable:{2}, gridSize:{3}, " +
                "gridCoords:{4}, worldSize:{5}, worldCoords:{6}",
                this.GetType().Name, this.level, this.interactable, this.gridSize,
                this.gridCoords, this.worldSize, this.worldCoords);
        }

        public CanvasWidgetSpecImpl SetCanvasGridSize(Vector2 gridSize)
        {
            this.gridSize = gridSize;
            return this;
        }

        public CanvasWidgetSpecImpl SetCanvasGridCoords(Vector2 gridCoords)
        {
            this.gridCoords = gridCoords;
            return this;
        }

        public CanvasWidgetSpecImpl SetCanvasWorldSize(Vector2 worldSize)
        {
            this.worldSize = worldSize;
            return this;
        }

        public CanvasWidgetSpecImpl SetCanvasWorldCoords(Vector2 worldCoords)
        {
            this.worldCoords = worldCoords;
            return this;
        }

        public CanvasWidgetSpecImpl SetCanvasLevel(int level)
        {
            this.level = level;
            return this;
        }

        public CanvasWidgetSpecImpl SetInteractable(bool isInteractable)
        {
            this.interactable = isInteractable;
            return this;
        }

        /// <inheritdoc/>
        Vector2 ICanvasWidgetSpec.GetGridCoords()
        {
            return this.gridCoords;
        }

        /// <inheritdoc/>
        Vector2 ICanvasWidgetSpec.GetGridSize()
        {
            return this.gridSize;
        }

        /// <inheritdoc/>
        int ICanvasWidgetSpec.GetLevel()
        {
            return this.level;
        }

        /// <inheritdoc/>
        Vector2 ICanvasWidgetSpec.GetWorldCoords()
        {
            return this.worldCoords;
        }

        /// <inheritdoc/>
        Vector2 ICanvasWidgetSpec.GetWorldSize()
        {
            return this.worldSize;
        }

        /// <inheritdoc/>
        bool ICanvasWidgetSpec.GetInteractable()
        {
            return this.interactable;
        }
    }
}