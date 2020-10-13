/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Frameworks.Objects;
using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Initializers.Reports;
using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Views.Objects;
using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Objects;
using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
using HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace HappyBananaStudio.OurAshesTactics.Impl.Objects.Mvc.Views
{
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

        public void DestroyTalonCanvas(ITalonIdentificationReport talonIdentificationReport)
        {
        }

        public bool IsInitialized()
        {
            return this.mvcFrameworkObject != null;
        }

        public void UpdateTalonCanvas(ITalonIdentificationReport talonIdentificationReport)
        {
        }

        public void UpdateTalonOrderList(IList<ITalonObject> talonObjectOrderList)
        {
            throw new System.NotImplementedException();
        }
    }
}
