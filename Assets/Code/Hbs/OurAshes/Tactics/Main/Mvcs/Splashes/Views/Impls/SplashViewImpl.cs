﻿using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Requests.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Coordinates.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Dimensions.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Views.Canvases.Backs.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Views.Canvases.Fores.Impls;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Views.Impls
{
    /// <summary>
    /// Splash View Impl
    /// </summary>
    public class SplashViewImpl
        : AbstractMvcView, IMvcView
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public SplashViewImpl(IMvcFrameConstruction mvcFrameConstruction)
            : base(mvcFrameConstruction)
        {
        }

        /// <inheritdoc/>
        public override void Process(IMvcModelState mvcModelState)
        {
            _logger.Info("Processing {}...", mvcModelState);
            this.mvcModelState = mvcModelState;
        }

        /// <inheritdoc/>
        public override IMvcViewState Process(IMvcControlInput mvcControlInput)
        {
            _logger.Info("Processing {}...", mvcControlInput);
            ((MvcViewStateImpl)this.mvcViewState).SetMvcControlInputTypes(
                new HashSet<MvcControlInputType>());
            ((MvcViewStateImpl)this.mvcViewState).SetMvcModelRequest(
                new List<IMvcModelRequest>(this.mvcModelState.GetMvcModelRequests())[0]);
            return this.mvcViewState;
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

        /// <inheritdoc/>
        protected override IMvcViewState BuildInitialMvcViewState()
        {
            return new MvcViewStateImpl();
        }
    }
}