using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Utils;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Reports.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Reports.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Abstrs
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
        protected IMvcViewCanvas mvcViewBackCanvas;

        // Todo
        protected IMvcViewCanvas mvcViewForeCanvas;

        // Todo
        protected IUnityScript unityScript;

        // Todo
        protected IMvcFrameConstruction mvcFrameConstruction;

        // Todo
        private IMvcViewReport _mvcViewReport;

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
        public abstract void Process(IMvcControlReport mvcControlReport);

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