/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Talons.Canvas;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Talons.Objects;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Unity;
using System;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Scripts.Talons
{
    /// <summary>
    /// Talon Canvas Script Impl
    /// TODO: Shamelessly copy Battle Brothers' UI for pawns
    /// </summary>
    public class TalonCanvasScriptImpl
    : UnityScript, ITalonCanvasScript
    {
        // Provide logging capability
        private static readonly Common.Loggers.Logger logger = new Common.Loggers.Logger(new StackFrame().GetMethod().DeclaringType);

        private readonly GameObject talonCanvasBackgroundGameObject = null;
        private readonly ITalonCanvasObject talonCanvasObject = null;
        private ITalonIdentificationReport talonIdentificationReport = null;

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public ITalonCanvasObject GetTalonCanvasObject()
        {
            return this.talonCanvasObject;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonObject">
        /// </param>
        public void Initialize(ITalonObject talonObject)
        {
            if (talonObject != null)
            {
                talonIdentificationReport = talonObject.GetTalonInformationReport().GetTalonIdentificationReport();
                logger.Info("Initializing: ? for ?", this.GetType(), talonIdentificationReport);
                //this.GetGameObject().transform.SetParent(talonObject.GetTalonScript().GetGameObject().transform);
                //Vector3 parentPosition = talonObject.GetTalonScript().GetGameObject().transform.position;
                //this.transform.localPosition = new Vector3(parentPosition.x, 7.5f, parentPosition.z);

                //GameObject talonCanvasGameObject = GameObjectResourceLoader.Canvas.LoadTalonCanvasGameObject();
                //talonCanvasGameObject.transform.SetParent(this.GetGameObject().transform);
                //talonCanvasGameObject.transform.localPosition = Vector3.zero;
                //this.talonCanvasObject = new TalonCanvasObjectImpl(this, talonObject, talonCanvasGameObject);
                //this.talonCanvasBackgroundGameObject = talonCanvasGameObject.transform.GetChild(0).gameObject;
                this.UpdateCanvas();
            }
            else
            {
                throw new ArgumentException("Unable to initialize " + this.GetType() + ". Invalid Parameters." +
                    "\n\t>" + typeof(ITalonObject) + " is null");
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public void UpdateCanvas()
        {
            if (this.talonCanvasBackgroundGameObject != null)
            {
                Vector3 canvasPosition = Camera.main.WorldToScreenPoint(this.transform.position);
                logger.Info("For ?: Converting World=? to Camera=?", talonIdentificationReport, this.transform.position, canvasPosition);
                this.talonCanvasBackgroundGameObject.transform.position = canvasPosition;
            }
        }
    }
}