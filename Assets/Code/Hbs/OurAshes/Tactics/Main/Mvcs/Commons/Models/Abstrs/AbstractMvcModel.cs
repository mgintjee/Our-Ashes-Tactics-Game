using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Requests.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Abstrs
{
    /// <summary>
    /// Abstract Mvc Model
    /// </summary>
    public abstract class AbstractMvcModel : IMvcModel
    {
        // Todo
        protected readonly IClassLogger _logger;

        // Todo
        protected readonly IMvcModelState mvcModelState;

        // Todo
        protected bool _isProcessing = true;

        // Todo
        protected IMvcFrameConstruction _mvcFrameConstruction;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public AbstractMvcModel(IMvcFrameConstruction mvcFrameConstruction)
        {
            _logger = LoggerManager.GetLogger(mvcFrameConstruction.GetMvcType())
                .GetClassLogger(this.GetType());
            _mvcFrameConstruction = mvcFrameConstruction;
            this.mvcModelState = this.BuildInitialMvcModelState();
        }

        /// <inheritdoc/>
        public abstract IMvcModelState Process(IMvcControlRequest mvcControlRequest);

        /// <inheritdoc/>
        bool IMvcModel.IsProcessing()
        {
            return this._isProcessing;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        protected abstract IMvcModelState BuildInitialMvcModelState();
    }
}