/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Talons.Objects;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Customization;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.ResourceLoaders;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Scripts.Unity;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Emblems;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

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

        // Todo
        private Transform callSignTextTransform;

        // Todo
        private IColorSchemeReport factionColorSchemeReport;

        // Todo
        private IEmblemSchemeReport factionEmblemSchemeReport;

        // Todo
        private Transform factionEmblemTransform;

        // Todo
        private IColorSchemeReport phalanxColorSchemeReport;

        // Todo
        private IEmblemSchemeReport phalanxEmblemSchemeReport;

        // Todo
        private Transform phalanxEmblemTransform;

        // Todo
        private ITalonIdentificationReport talonIdentificationReport = null;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonObject">
        /// </param>
        public void Initialize(ITalonObject talonObject)
        {
            if (talonObject != null)
            {
                this.talonIdentificationReport = talonObject.GetTalonInformationReport().GetTalonIdentificationReport();
                logger.Info("Initializing: ? for ?", this.GetType(), talonIdentificationReport);
                this.factionColorSchemeReport = talonObject.GetTalonCustomizationReport().GetFactionColorSchemeReport();
                this.phalanxColorSchemeReport = talonObject.GetTalonCustomizationReport().GetPhalanxColorSchemeReport();
                this.factionEmblemSchemeReport = talonObject.GetTalonCustomizationReport().GetFactionEmblemSchemeReport();
                this.phalanxEmblemSchemeReport = talonObject.GetTalonCustomizationReport().GetPhalanxEmblemSchemeReport();
                this.CollectUIElements();
                this.UpdateCanvas();
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. " +
                    "\n\t>? is null: ?", new StackFrame().GetMethod().Name,
                    typeof(ITalonObject), talonObject);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public void UpdateCanvas()
        {
            if (this.factionEmblemTransform != null)
            {
                logger.Debug("Update Faction Emblem");

                Image factionEmblemBackgrounImage = this.factionEmblemTransform.GetComponent<Image>();
                Image factionEmblemBackgroundImage = this.factionEmblemTransform.Find("backgroundImage").GetComponent<Image>();
                Image factionEmblemIconImage = this.factionEmblemTransform.Find("iconImage").GetComponent<Image>();

                factionEmblemBackgroundImage.sprite = SpriteResourceLoader.Background
                    .LoadSpriteBackgroundResource(this.factionEmblemSchemeReport.GetBackgroundId());
                factionEmblemIconImage.sprite = SpriteResourceLoader.Icon.LoadSpriteIconResource(
                    this.factionEmblemSchemeReport.GetIconId());

                Color factionPrimaryColor = EmblemColorUtil.GetColor(
                    this.factionColorSchemeReport.GetPrimaryPaintColorId());
                Color factionSecondaryColor = EmblemColorUtil.GetColor(
                    this.factionColorSchemeReport.GetSecondaryPaintColorId());
                Color factionTertiaryColor = EmblemColorUtil.GetColor(
                    this.factionColorSchemeReport.GetTertiaryPaintColorId());

                factionPrimaryColor.a = (128f / 255);
                factionSecondaryColor.a = (128f / 255);
                factionTertiaryColor.a = (128f / 255);

                factionEmblemBackgrounImage.color = factionSecondaryColor;
                factionEmblemBackgroundImage.color = factionPrimaryColor;
                factionEmblemIconImage.color = factionTertiaryColor;
            }
            if (this.phalanxEmblemTransform != null)
            {
                logger.Debug("Update Phalanx Emblem");

                Image phalanxEmblemBackgrounImage = this.phalanxEmblemTransform.GetComponent<Image>();
                Image phalanxEmblemBackgroundImage = this.phalanxEmblemTransform.Find("backgroundImage").GetComponent<Image>();
                Image phalanxEmblemIconImage = this.phalanxEmblemTransform.Find("iconImage").GetComponent<Image>();

                phalanxEmblemBackgroundImage.sprite = SpriteResourceLoader.Background
                    .LoadSpriteBackgroundResource(this.phalanxEmblemSchemeReport.GetBackgroundId());
                phalanxEmblemIconImage.sprite = SpriteResourceLoader.Icon.LoadSpriteIconResource(
                    this.phalanxEmblemSchemeReport.GetIconId());

                Color phalanxPrimaryColor = EmblemColorUtil.GetColor(
                    this.phalanxColorSchemeReport.GetPrimaryPaintColorId());
                Color phalanxSecondaryColor = EmblemColorUtil.GetColor(
                    this.phalanxColorSchemeReport.GetSecondaryPaintColorId());
                Color phalanxTertiaryColor = EmblemColorUtil.GetColor(
                    this.phalanxColorSchemeReport.GetTertiaryPaintColorId());

                phalanxPrimaryColor.a = (128f / 255);
                phalanxSecondaryColor.a = (128f / 255);
                phalanxTertiaryColor.a = (128f / 255);

                phalanxEmblemBackgrounImage.color = phalanxSecondaryColor;
                phalanxEmblemBackgroundImage.color = phalanxPrimaryColor;
                phalanxEmblemIconImage.color = phalanxTertiaryColor;
            }
            if (this.callSignTextTransform != null)
            {
                logger.Debug("Update CallSign Text");
                string callSignCharacter = CallSignsUtil.GetCharacter(this.talonIdentificationReport.GetCallSign());
                this.callSignTextTransform.GetComponent<Text>().text = callSignCharacter;
            }
        }

        private void CollectUIElements()
        {
            this.factionEmblemTransform = this.transform.Find("factionEmblem");
            this.phalanxEmblemTransform = this.transform.Find("phalanxEmblem");
            this.callSignTextTransform = this.transform.Find("callSignText");
        }
    }
}