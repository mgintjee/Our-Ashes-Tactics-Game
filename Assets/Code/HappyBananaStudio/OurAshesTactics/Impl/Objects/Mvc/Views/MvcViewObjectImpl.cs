/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Mvc.Frameworks;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Mvc.Views;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Talons.Canvas;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Talons.Objects;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Mvc.Views;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Scripts.Talons;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Objects.Mvc.Views
{
    /// <summary>
    /// MvcView Object Impl
    /// </summary>
    public class MvcViewObjectImpl
    : IMvcViewObject
    {
        // Provide logging capability
        private static readonly Common.Loggers.Logger logger = new Common.Loggers.Logger(new StackFrame().GetMethod().DeclaringType);

        // TODO
        private readonly GameObject mvcCanvasGameObject;

        // Todo
        private readonly IMvcViewScript mvcViewScript;

        // Todo
        private IMvcFrameworkObject mvcFrameworkObject;

        // Todo
        private Dictionary<ITalonIdentificationReport, ITalonCanvasObject> talonIdentificationCanvasDictionary =
            new Dictionary<ITalonIdentificationReport, ITalonCanvasObject>();

        public MvcViewObjectImpl(IMvcViewScript mvcViewScript, GameObject mvcCanvasGameObject)
        {
            if (mvcViewScript != null &&
                mvcCanvasGameObject != null)
            {
                logger.Info("Constructing: ?", this.GetType());

                logger.Info("Setting: ?=?", typeof(IMvcViewScript), mvcViewScript);
                this.mvcViewScript = mvcViewScript;
                logger.Info("Setting: ?=?", typeof(GameObject), mvcCanvasGameObject);
                this.mvcCanvasGameObject = mvcCanvasGameObject;
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. " +
                    "\n\t>? is null: ?" +
                    "\n\t>? is null: ?", this.GetType(),
                    typeof(IMvcViewScript), (mvcViewScript == null),
                    typeof(GameObject), (mvcCanvasGameObject == null));
            }
        }

        public void DestroyTalonCanvas(ITalonIdentificationReport talonIdentificationReport)
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

        public IMvcViewScript GetMvcViewScript()
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
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is null.",
                    this.GetType(), typeof(IMvcFrameworkObject));
            }
        }

        public bool IsInitialized()
        {
            return this.mvcFrameworkObject != null;
        }

        public void UpdateTalonCanvas(ITalonIdentificationReport talonIdentificationReport)
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

        private ITalonCanvasObject BuildTalonCanvas(ITalonObject talonObject)
        {
            GameObject talonCanvasPlaceHolder = new GameObject("TalonCanvasPlaceHolder");
            talonCanvasPlaceHolder.transform.SetParent(this.mvcViewScript.GetTransform());
            talonCanvasPlaceHolder.transform.localPosition = Vector3.zero;
            ITalonCanvasScript talonCanvasScript = talonCanvasPlaceHolder.AddComponent<TalonCanvasScriptImpl>();
            talonCanvasScript.Initialize(talonObject);
            return talonCanvasScript.GetTalonCanvasObject();
        }
    }
}