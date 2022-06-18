using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Worlds.Inters;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Worlds.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class WidgetWorldSpecImpl
        : IWidgetWorldSpec
    {
        // Todo
        private Vector2 worldSize;

        // Todo
        private Vector2 worldCoords;

        /// <summary>
        /// Todo
        /// </summary>
        public WidgetWorldSpecImpl()
        {
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: worldSize:{1}, worldCoords:{2}",
                this.GetType().Name, this.worldSize, this.worldCoords);
        }

        public WidgetWorldSpecImpl SetCanvasWorldSize(Vector2 worldSize)
        {
            this.worldSize = worldSize;
            return this;
        }

        public WidgetWorldSpecImpl SetCanvasWorldCoords(Vector2 worldCoords)
        {
            this.worldCoords = worldCoords;
            return this;
        }

        /// <inheritdoc/>
        Vector2 IWidgetWorldSpec.GetWorldCoords()
        {
            return this.worldCoords;
        }

        /// <inheritdoc/>
        Vector2 IWidgetWorldSpec.GetWorldSize()
        {
            return this.worldSize;
        }
    }
}