using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Controllers.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Models.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Coordinates.Implementations;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Dimensions.Implementations;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Implementations;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Implementations.Abstracts;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Views.Canvases.Backs.Implementations;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Views.Canvases.Fores.Implementations;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Views.Implementations
{
    /// <summary>
    /// Splash View Implementation
    /// </summary>
    public class SplashMvcView : AbstractMvcView, IMvcView
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public SplashMvcView(IMvcFrameConstruction mvcFrameConstruction) : base(mvcFrameConstruction)
        {
        }

        /// <inheritdoc/>
        public override void Process(IMvcModelReport mvcModelReport)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public override void Process(IMvcControllerReport mvcControllerReport)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        protected override void BuildCanvas()
        {
            _logger.Debug("Building {}", typeof(SplashViewBackCanvas));
            this.mvcViewBackCanvas = SplashViewBackCanvas.Builder.Get()
                .SetName(typeof(SplashViewBackCanvas).Name)
                .SetParent(this.unityScript)
                // Todo: Store in a const file or something
                .SetMeasurements(CanvasGridMeasurements.Builder.Get()
                    .SetCoordinates(new CanvasGridCoordinates(0, 0))
                    .SetDimensions(new CanvasGridDimensions(1, 1))
                    .Build())
                .Build();

            _logger.Debug("Building {}", typeof(SplashViewForeCanvas));
            this.mvcViewForeCanvas = SplashViewForeCanvas.Builder.Get()
                .SetName(typeof(SplashViewForeCanvas).Name)
                .SetParent(this.unityScript)
                // Todo: Store in a const file or something
                .SetMeasurements(CanvasGridMeasurements.Builder.Get()
                    .SetCoordinates(new CanvasGridCoordinates(0, 0))
                    .SetDimensions(new CanvasGridDimensions(1, 1))
                    .Build())
                .Build();
        }
    }
}