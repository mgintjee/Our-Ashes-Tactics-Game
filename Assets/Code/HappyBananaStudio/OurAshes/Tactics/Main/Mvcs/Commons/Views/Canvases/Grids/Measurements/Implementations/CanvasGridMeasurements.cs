namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Implementations
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