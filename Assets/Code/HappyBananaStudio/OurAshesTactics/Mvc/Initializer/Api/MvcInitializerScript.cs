/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.UnityScript;
using HappyBananaStudio.OurAshesTactics.Mvc.Framework.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Framework.Constants;
using HappyBananaStudio.OurAshesTactics.Mvc.Framework.Impl;
using HappyBananaStudio.OurAshesTactics.Mvc.Initializer.Reports;
using UnityEngine;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Initializer.Api
{
    /// <summary>
    /// MvcInitializer Script Api
    /// </summary>
    public abstract class MvcInitializerScript
    : AbstractUnityScript
    {
        #region Private Fields

        private bool game = false;
        private MvcFrameworkScript mvcFrameworkScript;

        #endregion Private Fields

        #region Public Methods

        public void FixedUpdate()
        {
            if (!game)
            {
                if (this.mvcFrameworkScript != null)
                {
                    if (!this.mvcFrameworkScript.IsInitialized())
                    {
                        game = true;
                        this.mvcFrameworkScript.Initialize(BuildMvcInitializationReport());
                    }
                }
            }
        }

        public void Start()
        {
            GameObject mvcFrameworkGameObject = new GameObject(MvcFrameworkConstants.Script.GetMvcFrameworkGameObjectName());
            MvcFrameworkScript mvcFrameworkScript = mvcFrameworkGameObject.AddComponent<MvcFrameworkScriptImpl>();
            mvcFrameworkGameObject.transform.SetParent(this.transform);
            this.mvcFrameworkScript = mvcFrameworkScript;
        }

        #endregion Public Methods

        #region Protected Methods

        protected abstract MvcInitializationReport BuildMvcInitializationReport();

        #endregion Protected Methods
    }
}