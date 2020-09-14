/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Framework.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Impl;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.View.Api;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace HappyBananaStudio.OurAshesTactics.Mvc.View.Impl
{
    /// <summary>
    /// MvcView Object Impl
    /// </summary>
    public class MvcViewObjectImpl
    : IMvcViewObject
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Common.Logging.Logger logger = new Common.Logging.Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly GameObject mvcCanvasGameObject;

        // Todo
        private readonly MvcViewScript mvcViewScript;

        // Todo
        private IMvcFrameworkObject mvcFrameworkObject;

        // Todo
        private Dictionary<TalonIdentificationReport, ITalonCanvasObject> talonIdentificationCanvasDictionary =
            new Dictionary<TalonIdentificationReport, ITalonCanvasObject>();

        #endregion Private Fields

        #region Public Constructors

        public MvcViewObjectImpl(MvcViewScript mvcViewScript, GameObject mvcCanvasGameObject)
        {
            if (mvcViewScript != null)
            {
                logger.Info("Contructing: ?", this.GetType());

                logger.Info("Setting: ?=?", typeof(MvcViewScript), mvcViewScript);
                this.mvcViewScript = mvcViewScript;
                logger.Info("Setting: ?=?", typeof(GameObject), mvcCanvasGameObject);
                this.mvcCanvasGameObject = mvcCanvasGameObject;
            }
            else
            {
                throw new ArgumentException("Unable to construct " +
                    this.GetType() + ". Invalid Parameters." +
                    "\n\t>mvcViewScript is null: " + (mvcViewScript == null));
            }
        }

        #endregion Public Constructors

        #region Public Methods

        public void DestroyTalonCanvas(TalonIdentificationReport talonIdentificationReport)
        {
            if (this.talonIdentificationCanvasDictionary.ContainsKey(talonIdentificationReport))
            {
                ITalonCanvasObject talonCanvasObject = this.talonIdentificationCanvasDictionary[talonIdentificationReport];
                talonCanvasObject.DestroyTalonCanvas();
                this.talonIdentificationCanvasDictionary.Remove(talonIdentificationReport);
            }
            else
            {
                logger.Warn("Unable to DestroyTalonCanvas. ? is not tracked.", talonIdentificationReport);
            }
        }

        public MvcViewScript GetMvcViewScript()
        {
            return this.mvcViewScript;
        }

        public void Initialize(IMvcFrameworkObject mvcFrameworkObject)
        {
            if (mvcFrameworkObject != null)
            {
                logger.Info("Initializing Object: ?", this.GetType());
                if (!this.IsInitialized())
                {
                    logger.Info("Setting Object: ?", typeof(IMvcFrameworkObject));
                    this.mvcFrameworkObject = mvcFrameworkObject;
                    /*
                    HashSet<TalonObject> talonObjectSet = this.mvcFrameworkObject.GetMvcModelObject().GetActiveTalonObjectSet();
                    foreach (TalonObject talonObject in talonObjectSet)
                    {
                        logger.Debug("?", talonObject);
                        TalonCanvasObject talonCanvasObject = this.BuildTalonCanvas(talonObject);
                        GameObject talonCanvasGameObject = GameObjectResourceLoader.Canvas.LoadTalonCanvasGameObject();
                        talonCanvasGameObject.transform.SetParent(this.mvcCanvasGameObject.transform);
                        this.talonIdentificationCanvasDictionary.Add(talonObject.GetTalonIdentificationReport(), talonCanvasObject);
                    }
                    */
                }
                else
                {
                    logger.Warn("Unable to Initialize: ?. Already initialized.", this.GetType());
                }
            }
            else
            {
                throw new ArgumentException("Unable to initialize " +
                    this.GetType() + ". Invalid Parameters." +
                    "\n\t>mvcFrameworkObject=" + mvcFrameworkObject);
            }
        }

        public bool IsInitialized()
        {
            return this.mvcFrameworkObject != null;
        }

        public void UpdateTalonCanvas(TalonIdentificationReport talonIdentificationReport)
        {
            if (this.talonIdentificationCanvasDictionary.ContainsKey(talonIdentificationReport))
            {
                this.talonIdentificationCanvasDictionary[talonIdentificationReport].UpdateCanvas();
            }
            else
            {
                logger.Warn("Unable to UpdateTalonCanvas. ? is not tracked.", talonIdentificationReport);
            }
        }

        public void UpdateTalonOrderList(List<ITalonObject> talonObjectOrderList)
        {
            foreach (ITalonObject talonObject in talonObjectOrderList)
            {
            }
            //throw new NotImplementedException();
        }

        #endregion Public Methods

        #region Private Methods

        private ITalonCanvasObject BuildTalonCanvas(ITalonObject talonObject)
        {
            GameObject talonCanvasPlaceHolder = new GameObject("TalonCanvasPlaceHolder");
            talonCanvasPlaceHolder.transform.SetParent(this.mvcViewScript.transform);
            talonCanvasPlaceHolder.transform.localPosition = Vector3.zero;
            TalonCanvasScript talonCanvasScript = talonCanvasPlaceHolder.AddComponent<TalonCanvasScriptImpl>();
            talonCanvasScript.Initialize(talonObject);
            return talonCanvasScript.GetTalonCanvasObject();
        }

        #endregion Private Methods
    }
}