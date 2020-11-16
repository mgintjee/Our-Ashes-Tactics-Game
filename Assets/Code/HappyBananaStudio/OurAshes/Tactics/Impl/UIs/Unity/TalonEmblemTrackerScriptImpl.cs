namespace HappyBananaStudio.OurAshes.Tactics.Impl.UIs.Unity
{
    using HappyBananaStudio.OurAshes.Tactics.Abs.Unity.Scripts;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
    using HappyBananaStudio.OurAshes.Tactics.Api.UIs.Unity;
    using HappyBananaStudio.OurAshes.Tactics.Api.UIs.WidgetUIs.Complex;
    using HappyBananaStudio.OurAshes.Tactics.Common.Managers.CodeObjects;
    using HappyBananaStudio.OurAshes.Tactics.Common.Managers.GameObjects;
    using UnityEngine;

    /// <summary>
    /// Todo: Maybe have just set the ITalonIdentificationReport and have it track that way?
    /// </summary>
    public class TalonEmblemTrackerScriptImpl
        : AbstractUnityScriptImpl, ITalonEmblemTrackerScript
    {
        // Todo
        private ITalonEmblemWidget talonEmblemWidget = null;

        // Todo
        private ITalonIdentificationReport talonIdentificationReport = null;

        /// <summary>
        /// Todo
        /// </summary>
        public void FixedUpdate()
        {
            if (this.talonIdentificationReport != null)
            {
                if (RosterObjectManager.GetActiveTalonIdentificationReportSet().Contains(this.talonIdentificationReport))
                {
                    GameObject talonGameObject = TalonGameObjectManager.GetTalonGameObject(this.talonIdentificationReport);
                    Vector2 talonEmblemWidgetOldPosition = talonEmblemWidget.GetRectTransform().anchoredPosition;
                    Vector3 talonGameObjectPosition = talonGameObject.transform.position;
                    Vector2 talonEmblemWidgetNewPosition = RectTransformUtility.WorldToScreenPoint(Camera.main, talonGameObjectPosition);
                    if (talonEmblemWidgetOldPosition != talonEmblemWidgetNewPosition)
                    {
                        talonEmblemWidget.GetRectTransform().anchoredPosition = talonEmblemWidgetNewPosition;
                    }
                }
                else
                {
                    // Todo: Deactivate this thing
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport">
        /// </param>
        void ITalonEmblemTrackerScript.SetTalonIdentificationReport(ITalonIdentificationReport talonIdentificationReport)
        {
            if (this.talonIdentificationReport == null)
            {
                this.talonIdentificationReport = talonIdentificationReport;
                // Todo: Move the talonEmblemGeneration somewhere else to reduce amount of times I
                // have to check the CustomizationReport
            }
        }
    }
}
