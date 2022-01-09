using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Worlds.Inters;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Worlds.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class CanvasWorldSpecImpl
        : ICanvasWorldSpec
    {
        // Todo
        private Vector2 worldSize;

        // Todo
        private Vector2 worldCoords;

        /// <summary>
        /// Todo
        /// </summary>
        public CanvasWorldSpecImpl()
        {
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: worldSize:{1}, worldCoords:{2}",
                this.GetType().Name, this.worldSize, this.worldCoords);
        }

        public CanvasWorldSpecImpl SetCanvasWorldSize(Vector2 worldSize)
        {
            this.worldSize = worldSize;
            return this;
        }

        public CanvasWorldSpecImpl SetCanvasWorldCoords(Vector2 worldCoords)
        {
            this.worldCoords = worldCoords;
            return this;
        }

        /// <inheritdoc/>
        Vector2 ICanvasWorldSpec.GetWorldCoords()
        {
            return this.worldCoords;
        }

        /// <inheritdoc/>
        Vector2 ICanvasWorldSpec.GetWorldSize()
        {
            return this.worldSize;
        }
    }
}