/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Framework.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;
using HappyBananaStudio.OurAshesTactics.Talon.Object.Api;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Mvc.View.Api
{
    /// <summary>
    /// MvcView Object Api
    /// </summary>
    public interface IMvcViewObject
    {
        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport"></param>
        void DestroyTalonCanvas(TalonIdentificationReport talonIdentificationReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        MvcViewScript GetMvcViewScript();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameworkObject"></param>
        void Initialize(IMvcFrameworkObject mvcFrameworkObject);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        bool IsInitialized();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport"></param>
        void UpdateTalonCanvas(TalonIdentificationReport talonIdentificationReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonObjectOrderList"></param>
        void UpdateTalonOrderList(List<ITalonObject> talonObjectOrderList);

        #endregion Public Methods
    }
}