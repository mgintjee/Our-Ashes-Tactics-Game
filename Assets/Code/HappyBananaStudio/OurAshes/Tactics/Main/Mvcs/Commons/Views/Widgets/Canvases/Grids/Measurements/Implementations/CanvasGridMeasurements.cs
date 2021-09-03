using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Coordinates.Grids.Dimensions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Coordinates.Grids.Measures.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Grids.Measures.Coordinates.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Grids.Measures.Dimensions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Grids.Measures.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Grids.Measures.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct CanvasGridMeasurements : ICanvasGridMeasurements
    {
        // Todo
        private readonly ICanvasGridCoordinates coordinates;

        // Todo
        private readonly ICanvasGridDimensions dimensions;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="dimensions"> </param>
        /// <param name="coordinates"></param>
        public CanvasGridMeasurements(ICanvasGridDimensions dimensions, ICanvasGridCoordinates coordinates)
        {
            this.dimensions = dimensions;
            this.coordinates = coordinates;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}:({1},{2})",
                this.GetType().Name, this.dimensions, this.coordinates);
        }

        /// <inheritdoc/>
        ICanvasGridCoordinates ICanvasGridMeasurements.GetCoordinates()
        {
            return this.coordinates;
        }

        /// <inheritdoc/>
        ICanvasGridDimensions ICanvasGridMeasurements.GetDimensions()
        {
            return this.dimensions;
        }
    }
}