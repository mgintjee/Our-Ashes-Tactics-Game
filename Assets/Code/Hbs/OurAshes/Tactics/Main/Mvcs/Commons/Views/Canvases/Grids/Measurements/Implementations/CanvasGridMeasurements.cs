using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Coordinates.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Dimensions.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Implementations
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

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<ICanvasGridMeasurements>
            {
                IBuilder SetDimensions(ICanvasGridDimensions dimentions);

                IBuilder SetCoordinates(ICanvasGridCoordinates coordinates);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static IBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Todo
            /// </summary>
            private class InternalBuilder : AbstractBuilder<ICanvasGridMeasurements>, IBuilder
            {
                // Todo
                private ICanvasGridDimensions _dimensions;

                // Todo
                private ICanvasGridCoordinates _coordinates;

                /// <inheritdoc/>
                IBuilder IBuilder.SetDimensions(ICanvasGridDimensions dimensions)
                {
                    _dimensions = dimensions;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetCoordinates(ICanvasGridCoordinates coordinates)
                {
                    _coordinates = coordinates;
                    return this;
                }

                /// <inheritdoc/>
                protected override ICanvasGridMeasurements BuildObj()
                {
                    return new CanvasGridMeasurements(_dimensions, _coordinates);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _dimensions);
                    this.Validate(invalidReasons, _coordinates);
                }
            }
        }
    }
}