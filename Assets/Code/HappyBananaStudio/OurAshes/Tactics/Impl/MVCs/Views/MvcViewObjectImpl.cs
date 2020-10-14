

namespace HappyBananaStudio.OurAshesTactics.Impl.Objects.Mvc.Views
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Frameworks.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Initializers.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Views.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Actions.Orders;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
    using HappyBananaStudio.OurAshes.Tactics.Common.Animators;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
    using HappyBananaStudio.OurAshesTactics.Common.Utils.LineRenderers;
    using HappyBananaStudio.OurAshesTactics.Impl.Objects.Paths.Objects.Move;
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

        // TODO
        private readonly GameObject mvcCanvasGameObject;

        // Todo
        private readonly IMvcFrameworkObject mvcFrameworkObject;

        // Todo
        private readonly IMvcInitializationReport mvcInitializationReport;

        public MvcViewObjectImpl(IMvcFrameworkObject mvcFrameworkObject, IMvcInitializationReport mvcInitializationReport)
        {
            if (mvcFrameworkObject != null &&
                mvcInitializationReport != null)
            {
                logger.Info("Constructing: ?", this.GetType());
                this.mvcFrameworkObject = mvcFrameworkObject;
                this.mvcInitializationReport = mvcInitializationReport;
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
        /// <param name="talonIdentificationReport">
        /// </param>
        void IMvcViewObject.UpdateTalonCanvas(ITalonIdentificationReport talonIdentificationReport)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonObjectOrderList">
        /// </param>
        void IMvcViewObject.UpdateTalonOrderList(IList<ITalonObject> talonObjectOrderList)
        {
            throw new System.NotImplementedException();
        }
    }
}
