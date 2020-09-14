/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Framework.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Initializer.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Controller.Api
{
    /// <summary>
    /// MvcController Object Api
    /// </summary>
    public interface IMvcControllerObject
    {
        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonTurnInformationReport"></param>
        void BeginDecisionProcess(TalonTurnInformationReport talonTurnInformationReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        MvcControllerScript GetMvcControllerScript();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameworkObject">     </param>
        /// <param name="mvcInitializationReport"></param>
        void Initialize(IMvcFrameworkObject mvcFrameworkObject, MvcInitializationReport mvcInitializationReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        bool IsDeterminingActionReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        bool IsInitialized();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        bool IsReadyToOutputActionReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        TalonActionOrderReport OutputActionReport();

        #endregion Public Methods
    }
}