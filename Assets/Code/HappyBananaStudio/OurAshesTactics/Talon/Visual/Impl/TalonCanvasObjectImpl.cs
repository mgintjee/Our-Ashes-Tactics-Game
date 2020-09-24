/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Constants;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;
using HappyBananaStudio.OurAshesTactics.Talon.Object.Api;
using HappyBananaStudio.OurAshesTactics.Talon.Visual.Api;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

namespace HappyBananaStudio.OurAshesTactics.Talon.Visual.Impl
{
    /// <summary>
    /// Talon Canvas Object Impl
    /// </summary>
    public class TalonCanvasObjectImpl
    : ITalonCanvasObject
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Common.Logging.Logger logger = new Common.Logging.Logger(new StackFrame().GetMethod().DeclaringType);

        private readonly GameObject talonCanvasGameObject = null;
        private readonly TalonCanvasScript talonCanvasScript = null;
        private readonly ITalonObject talonObject = null;
        private Text talonArmourText = null;
        private GameObject talonCanvasBackgroundGameObject = null;
        private Text talonHealthText = null;
        private Text talonPhalanxIndexText = null;

        #endregion Private Fields

        #region Public Constructors

        public TalonCanvasObjectImpl(TalonCanvasScript talonCanvasScript, ITalonObject talonObject, GameObject talonCanvasGameObject)
        {
            if (talonCanvasScript != null &&
                talonObject != null &&
                talonCanvasGameObject != null)
            {
                logger.Info("Contructing: ?", this.GetType());
                this.talonCanvasScript = talonCanvasScript;
                this.talonObject = talonObject;
                this.talonCanvasGameObject = talonCanvasGameObject;
                this.CollectCanvasUiObjects();
                this.UpdateCanvas();
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to build ?. Invalid Parameters. " +
                    "\n\t> ? is null: ?" +
                    "\n\t> ? is null: ?" +
                    "\n\t> ? is null: ?", this.GetType().Name,
                    typeof(TalonCanvasScript), (talonCanvasScript == null),
                    typeof(ITalonObject), (talonObject == null),
                    typeof(GameObject), (talonCanvasGameObject == null));
            }
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        public void DestroyTalonCanvas()
        {
            // Todo: Destroy this Canvas
        }

        /// <summary>
        /// Todo
        /// </summary>
        public void UpdateCanvas()
        {
            string teamIdString = "Null";
            string healthString = "Null";
            string armourString = "Null";

            if (this.talonObject != null)
            {
                TalonInformationReport talonInformationReport = this.talonObject.GetTalonInformationReport();
                teamIdString = talonInformationReport.GetTalonIdentificationReport().GetTalonPhalanxIndex().ToString();
                healthString = talonInformationReport.GetTalonAttributesReport().GetDestructableAttributesReport().GetCurrentHealthPoints().ToString();
                armourString = talonInformationReport.GetTalonAttributesReport().GetMovableAttributesReport().GetCurrentMovePoints().ToString();
            }
            else
            {
                logger.Warn("Unable to update ?. ? is null. No information to present.", this.GetType(), typeof(ITalonObject));
            }

            this.talonPhalanxIndexText.text = teamIdString;
            this.talonHealthText.text = healthString;
            this.talonArmourText.text = armourString;
            this.talonCanvasScript.UpdateCanvas();
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Todo
        /// </summary>
        private void CollectCanvasUiObjects()
        {
            if (this.talonCanvasGameObject != null)
            {
                Transform canvasBackgroundTransform = this.talonCanvasGameObject.transform.Find(TalonCanvasConstants.GetCanvasBackgroundGameObjectName());
                if (canvasBackgroundTransform != null)
                {
                    this.talonCanvasBackgroundGameObject = canvasBackgroundTransform.gameObject;
                }

                this.talonPhalanxIndexText = CollectTextObjectFrom(
                    TalonCanvasConstants.GetTeamIdBackgroundGameObjectName(),
                    TalonCanvasConstants.GetTeamIdTextGameObjectName());

                this.talonArmourText = CollectTextObjectFrom(
                    TalonCanvasConstants.GetArmourBackgroundGameObjectName(),
                    TalonCanvasConstants.GetArmourTextGameObjectName());

                this.talonHealthText = CollectTextObjectFrom(
                    TalonCanvasConstants.GetHealthBackgroundGameObjectName(),
                    TalonCanvasConstants.GetHealthTextGameObjectName());
            }
            // Check that the collection process was a success
            if (this.talonPhalanxIndexText == null ||
                this.talonArmourText == null ||
                this.talonHealthText == null)
            {
                logger.Error("Failed to collect Text objects for ?.", this.GetType());
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="backgroundId"></param>
        /// <param name="textId">      </param>
        /// <returns></returns>
        private Text CollectTextObjectFrom(string backgroundId, string textId)
        {
            Text text = null;
            if (this.talonCanvasBackgroundGameObject != null)
            {
                Transform backgroundTransform = this.talonCanvasBackgroundGameObject.transform.Find(backgroundId);
                if (backgroundTransform != null)
                {
                    Transform textTransform = backgroundTransform.Find(textId);
                    if (textTransform != null)
                    {
                        text = textTransform.GetComponent<Text>();
                    }
                }
            }
            return text;
        }

        #endregion Private Methods
    }
}