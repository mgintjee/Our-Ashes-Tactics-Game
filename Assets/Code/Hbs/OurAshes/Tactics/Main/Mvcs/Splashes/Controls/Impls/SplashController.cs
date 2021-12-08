using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Reports.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Controls.Impls
{
    /// <summary>
    /// Splash Control Implementation
    /// </summary>
    public class SplashControl : AbstractMvcControl, IMvcControl
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public SplashControl(IMvcFrameConstruction mvcFrameConstruction) : base(mvcFrameConstruction)
        {
            // Todo Build the Control Input
            /// May include the parent thingy or for the script
            this.mvcControlInput = MvcControlInput.Builder.Get().Build();
        }

        /// <inheritdoc/>
        public override void Process(IMvcModelReport mvcModelReport)
        {
            _logger.Debug("Processing {}", mvcModelReport);
        }
    }
}