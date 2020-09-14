/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Framework.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Initializer.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Api
{
    /// <summary>
    /// MvcModel Object Api
    /// </summary>
    public interface IMvcModelObject
    {
        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        bool ContinueGame();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        HashSet<TalonIdentificationReport> GetActiveTalonIdentificationReportSet();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        TalonIdentificationReport GetCurrentTalonIdentificationReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        MvcModelInformationReport GetMvcModelInformationReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        MvcModelScript GetMvcModelScript();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>

        List<TalonIdentificationReport> GetOrderedTalonIdentificationReportList();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport"></param>
        /// <returns></returns>
        TalonInformationReport GetTalonInformationReport(TalonIdentificationReport talonIdentificationReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameworkObject">     </param>
        /// <param name="mvcInitializationReport"></param>
        void Initialize(IMvcFrameworkObject mvcFrameworkObject, MvcInitializationReport mvcInitializationReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="actionReport"></param>
        /// <returns></returns>

        TalonTurnResultReport InputTalonActionOrderReport(TalonActionOrderReport actionReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>

        bool IsInitialized();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>

        bool IsProcessingActionReport();

        /// <summary>
        /// Todo
        /// </summary>

        void StartGame();

        #endregion Public Methods
    }
}