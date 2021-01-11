namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.Objects.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.Objects.Api;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// MvcView Object Impl
    /// </summary>
    public class MvcViewObjectImpl
        : IMvcViewObject
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        private MvcViewObjectImpl()
        {
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IMvcViewObject Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new MvcViewObjectImpl();
                }
                else
                {
                    throw ExceptionUtil.Argument.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                return argumentExceptionSet;
            }
        }

        /*

        // Todo
        private readonly GameObject mvcCanvasGameObject;

        // Todo
        private readonly IMvcFrameworkObject mvcFrameworkObject;

        // Todo
        private readonly IMvcInitializationReport mvcInitializationReport;

        // Todo
        private readonly IMvcViewScript mvcViewScript;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameworkObject">
        /// </param>
        /// <param name="mvcInitializationReport">
        /// </param>
        public MvcViewObjectImpl(IMvcFrameworkObject mvcFrameworkObject, IMvcInitializationReport mvcInitializationReport)
        {
            if (mvcFrameworkObject != null &&
                mvcInitializationReport != null)
            {
                logger.Info("Constructing: ?", this.GetType());
                this.mvcFrameworkObject = mvcFrameworkObject;
                this.mvcInitializationReport = mvcInitializationReport;
                // Update this to be a AddComponent call
                this.mvcViewScript = GameObjectResourceLoader.Canvas.LoadMvcCanvasGameObject().GetComponent<IMvcViewScript>();
                this.mvcViewScript.LoadWidgets();
                this.mvcViewScript.UpdateWidgets();
                GameObject.FindObjectOfType<AnimatorMoveUtilScript>().SetMvcViewObject(this);
            }
            else
            {
                throw ExceptionUtil.Argument.Build("Unable to construct ?. Invalid Parameters. " +
                    "\n\t> ? is null: ?" +
                    "\n\t> ? is null: ?", this.GetType(),
                    typeof(IMvcFrameworkObject), (mvcFrameworkObject == null),
                    typeof(IMvcInitializationReport), (mvcInitializationReport == null));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonActionOrderReport">
        /// </param>
        void IMvcViewObject.AnimateActionOrderReport(ITalonActionOrderReport talonActionOrderReport)
        {
            // Use the LineRenderer to draw the path
            LineRendererUtil.DrawPath(talonActionOrderReport.GetPathObject());
            if (talonActionOrderReport.GetPathObject() is PathObjectMoveImpl)
            {
                GameObject.FindObjectOfType<AnimatorMoveUtilScript>().AnimateTalonActionOrderReport(talonActionOrderReport);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gameActionReport">
        /// </param>
        void IMvcViewObject.DisplayCombatReportPopUp(IGameActionReport gameActionReport)
        {
            ITalonActionResultFireReport actualTalonActionOrderFireReport = (ITalonActionResultFireReport)gameActionReport.GetTalonActionResultReport();
            ITalonActionResultFireReport expectedTalonActionOrderFireReport = TalonCombatManager.GetExpectedTalonActionResultFireReport(
                (ITalonActionOrderFireReport)actualTalonActionOrderFireReport.GetTalonActionOrder());
            logger.Debug("Actual=?" +
                "\nExpected=?", actualTalonActionOrderFireReport, expectedTalonActionOrderFireReport);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        bool IMvcViewObject.IsAnimating()
        {
            return GameObject.FindObjectOfType<AnimatorMoveUtilScript>()
                   .GetComponent<AnimatorMoveUtilScript>().IsAnimating();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        bool IMvcViewObject.IsInitialized()
        {
            return this.mvcFrameworkObject != null;
        }

        /// <summary>
        /// Todo
        /// </summary>
        void IMvcViewObject.UpdateCanvas()
        {
            this.mvcViewScript.UpdateWidgets();
        }
        */
    }
}