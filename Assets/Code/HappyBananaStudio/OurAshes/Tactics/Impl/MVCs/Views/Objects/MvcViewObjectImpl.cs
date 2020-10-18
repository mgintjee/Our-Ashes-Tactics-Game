namespace HappyBananaStudio.OurAshes.Tactics.Impl.MVCs.Views
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Frameworks.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.GameActions.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Initializers.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Views.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Views.Scripts;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Actions.Orders;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Actions.Results;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
    using HappyBananaStudio.OurAshes.Tactics.Common.Managers.CodeObjects;
    using HappyBananaStudio.OurAshes.Tactics.Common.ResourceLoaders;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Animators;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.LineRenderers;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Paths.Objects.Move;
    using System.Collections.Generic;
    using System.Diagnostics;
    using UnityEngine;

    /// <summary>
    /// MvcView Object Impl
    /// </summary>
    public class MvcViewObjectImpl
    : IMvcViewObject
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

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
                this.mvcViewScript = GameObjectResourceLoader.Canvas.LoadMvcCanvasGameObject().GetComponent<IMvcViewScript>();
                this.mvcViewScript.LoadWidgets();
                this.mvcViewScript.UpdateWidgets();
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. " +
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
        /// <param name="talonIdentificationReport">
        /// </param>
        void IMvcViewObject.DestroyTalonCanvas(ITalonIdentificationReport talonIdentificationReport)
        {
            throw new System.NotImplementedException();
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
    }
}
