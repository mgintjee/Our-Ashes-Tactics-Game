using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Implementations.Abstracts;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Models.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Controllers.Inputs.Implementations;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Controllers.Splashes.Implementations
{
    /// <summary>
    /// Splash Controller Implementation
    /// </summary>
    public class SplashController : AbstractMvcController, IMvcController
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public SplashController(IMvcFrameConstruction mvcFrameConstruction) : base(mvcFrameConstruction)
        {
            // Todo Build the Controller Input
            /// May include the parent thingy or for the script
            this.mvcControllerInput = MvcControllerInput.Builder.Get().Build();
        }

        /// <inheritdoc/>
        public override void Process(IMvcModelReport mvcModelReport)
        {
            _logger.Debug("Processing {}", mvcModelReport);
            if (this.mvcControllerInput.GetClick().IsPresent())
            {
                _logger.Debug("Clicked {}", this.mvcControllerInput.GetClick().GetValue());
            }
        }
    }
}