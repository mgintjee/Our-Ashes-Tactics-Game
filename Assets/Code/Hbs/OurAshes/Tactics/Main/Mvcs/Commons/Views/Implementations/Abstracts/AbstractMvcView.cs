using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Controllers.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Models.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Views.Implementations;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Views.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Utils;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Interfaces;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Implementations.Abstracts
{
    /// <summary>
    /// Abstract Mvc View Implementation
    /// </summary>
    public abstract class AbstractMvcView : IMvcView
    {
        // Todo
        protected readonly IClassLogger _logger;

        // Todo
        protected bool _isProcessing = false;

        // Todo
        private IMvcViewReport _mvcViewReport;

        // Todo
        protected IMvcViewCanvas mvcViewBackCanvas;

        // Todo
        protected IMvcViewCanvas mvcViewForeCanvas;

        // Todo
        protected IUnityScript unityScript;

        // Todo
        protected IMvcFrameConstruction mvcFrameConstruction;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public AbstractMvcView(IMvcFrameConstruction mvcFrameConstruction)
        {
            _logger = LoggerManager.GetLogger(mvcFrameConstruction.GetMvcType()).GetClassLogger(this.GetType());
            this.mvcFrameConstruction = mvcFrameConstruction;
            this.unityScript = UnityScriptUtils.BuildViewUnityScript(typeof(IMvcView),
                mvcFrameConstruction.GetMvcType(), this.mvcFrameConstruction.GetUnityScript());
            this.BuildCanvas();
            this.BuildReport();
        }

        /// <inheritdoc/>
        public abstract void Process(IMvcModelReport mvcModelReport);

        /// <inheritdoc/>
        public abstract void Process(IMvcControllerReport mvcControllerReport);

        /// <inheritdoc/>
        IMvcViewReport IMvcView.GetReport()
        {
            return _mvcViewReport;
        }

        /// <inheritdoc/>
        protected void BuildReport()
        {
            _mvcViewReport = MvcViewReport.Builder.Get()
                .SetIsProcessing(_isProcessing)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected abstract void BuildCanvas();
    }
}