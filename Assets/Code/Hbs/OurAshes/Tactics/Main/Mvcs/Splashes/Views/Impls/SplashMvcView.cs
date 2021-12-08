using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Coordinates.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Dimensions.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Views.Canvases.Backs.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Views.Canvases.Fores.Impls;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Views.Impls
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
        public override void Process(IMvcControlReport mvcControlReport)
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