using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Factions.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Factions.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Constants;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Utils.Queries;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Factions.Constants;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Factions
{
    /// <summary>
    /// Panel Widget Impl
    /// </summary>
    public class FactionDetailsPanelImpl
        : AbstractPanelWidget, IPanelWidget
    {
        private IDualTextPanelWidget alphaText;
        private IDualTextPanelWidget bravoText;
        private IDualTextPanelWidget charlieText;
        private IDualTextPanelWidget deltaText;
        private IDualTextPanelWidget alphaButtons;
        private IDualTextPanelWidget bravoButtons;
        private IDualTextPanelWidget charlieButtons;
        private IDualTextPanelWidget deltaButtons;

        public override void Process(IMvcModelState modelState)
        {
            Models.States.Inters.IMvcModelState mvcModelState = (Models.States.Inters.IMvcModelState)modelState;
            this.UpdateText(FactionID.Alpha, this.alphaText, mvcModelState);
            this.UpdateText(FactionID.Bravo, this.bravoText, mvcModelState);
            this.UpdateText(FactionID.Charlie, this.charlieText, mvcModelState);
            this.UpdateText(FactionID.Delta, this.deltaText, mvcModelState);
        }

        protected override void InitialBuild()
        {
            ISet<ICanvasWidget> panelWidgets = new HashSet<ICanvasWidget>() {
                this.BuildAndSetDeltaText(),
                this.BuildAndSetAlphaText(),
                this.BuildAndSetBravoText(),
                this.BuildAndSetCharlieText(),
                this.BuildAndSetDeltaButtons(),
                this.BuildAndSetAlphaButtons(),
                this.BuildAndSetBravoButtons(),
                this.BuildAndSetCharlieButtons()
            };
            this.InternalAddWidgets(panelWidgets);
        }

        private void UpdateText(FactionID factionID, IDualTextPanelWidget text, Models.States.Inters.IMvcModelState mvcModelState)
        {
            MvcModelStateQueryUtil.GetFactionDetails(mvcModelState, factionID).IfPresent(factionDetails =>
            {
                this.UpdateText(text, factionDetails.GetPhalanxDetails());
            });
        }

        private void UpdateText(IDualTextPanelWidget text, ISet<IPhalanxDetails> phalanxDetails)
        {
            string textString = "[";
            foreach (IPhalanxDetails details in phalanxDetails)
            {
                if (textString.Length == 1)
                {
                    textString += details.GetCallSign();
                }
                else
                {
                    textString += ", " + details.GetCallSign();
                }
            }
            textString += "]";
            text.GetRightTextWidget().SetText(textString);
        }

        private IDualTextPanelWidget BuildAndSetAlphaText()
        {
            this.alphaText = this.BuildText(FactionID.Alpha.ToString(),
                FactionDetailsPanelConstants.ALPHA_TEXT_COORDS);
            return this.alphaText;
        }

        private IDualTextPanelWidget BuildAndSetBravoText()
        {
            this.bravoText = this.BuildText(FactionID.Bravo.ToString(),
                FactionDetailsPanelConstants.BRAVO_TEXT_COORDS);
            return this.bravoText;
        }

        private IDualTextPanelWidget BuildAndSetCharlieText()
        {
            this.charlieText = this.BuildText(FactionID.Charlie.ToString(),
                FactionDetailsPanelConstants.CHARLIE_TEXT_COORDS);
            return this.charlieText;
        }

        private IDualTextPanelWidget BuildAndSetDeltaText()
        {
            this.deltaText = this.BuildText(FactionID.Delta.ToString(),
                FactionDetailsPanelConstants.DELTA_TEXT_COORDS);
            return this.deltaText;
        }

        private IDualTextPanelWidget BuildAndSetAlphaButtons()
        {
            this.alphaButtons = this.BuildButtons(FactionID.Alpha.ToString(),
                FactionDetailsPanelConstants.ALPHA_BUTTONS_COORDS);
            return this.alphaButtons;
        }

        private IDualTextPanelWidget BuildAndSetBravoButtons()
        {
            this.bravoButtons = this.BuildButtons(FactionID.Bravo.ToString(),
                FactionDetailsPanelConstants.BRAVO_BUTTONS_COORDS);
            return this.bravoButtons;
        }

        private IDualTextPanelWidget BuildAndSetCharlieButtons()
        {
            this.charlieButtons = this.BuildButtons(FactionID.Charlie.ToString(),
                FactionDetailsPanelConstants.CHARLIE_BUTTONS_COORDS);
            return this.charlieButtons;
        }

        private IDualTextPanelWidget BuildAndSetDeltaButtons()
        {
            this.deltaButtons = this.BuildButtons(FactionID.Delta.ToString(),
                FactionDetailsPanelConstants.DELTA_BUTTONS_COORDS);
            return this.deltaButtons;
        }

        private IDualTextPanelWidget BuildText(string enumString, Vector2 canvasGridCoords)
        {
            return (IDualTextPanelWidget)DualTextPanelImpl.Builder.Get()
                .SetLeftText(enumString)
                .SetLeftTextColor(WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR)
                .SetRightText("null")
                .SetRightTextColor(WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR)
                .SetBackgroundColor(WidgetConstants.PRIMARY_COLOR_ID)
                .SetLeftColor(WidgetConstants.SECONDARY_COLOR_ID)
                .SetRightColor(WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR)
                .SetPanelGridSize(new Vector2(2, 1))
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(canvasGridCoords)
                    .SetCanvasGridSize(FactionDetailsPanelConstants.TEXT_SIZE))
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(1)
                .SetInteractable(true)
                .SetEnabled(true)
                .SetName(this.mvcType + ":" + RequestType.FactionDetails + ":" + CanvasWidgetType.Panel + ":" + enumString)
                .SetParent(this)
                .Build();
        }

        private IDualTextPanelWidget BuildButtons(string enumString, Vector2 canvasGridCoords)
        {
            return (IDualTextPanelWidget)DualTextPanelImpl.Builder.Get()
                .SetLeftText("-")
                .SetLeftTextColor(WidgetConstants.BUTTON_INTERACTABLE_ENABLED_TEXT_COLOR)
                .SetRightText("+")
                .SetRightTextColor(WidgetConstants.BUTTON_INTERACTABLE_ENABLED_TEXT_COLOR)
                .SetBackgroundColor(WidgetConstants.PRIMARY_COLOR_ID)
                .SetLeftColor(WidgetConstants.BUTTON_INTERACTABLE_ENABLED_IMAGE_COLOR)
                .SetRightColor(WidgetConstants.BUTTON_INTERACTABLE_ENABLED_IMAGE_COLOR)
                .SetPanelGridSize(new Vector2(2, 1))
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(canvasGridCoords)
                    .SetCanvasGridSize(FactionDetailsPanelConstants.TEXT_SIZE))
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(1)
                .SetInteractable(true)
                .SetEnabled(true)
                .SetName(this.mvcType + ":" + RequestType.FactionDetails + ":" + CanvasWidgetType.Panel + ":" + enumString + ":Buttons")
                .SetParent(this)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IInternalBuilder
                : PanelWidgetBuilders.IPanelWidgetBuilder
            {
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static IInternalBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Todo
            /// </summary>
            private class InternalBuilder
                : PanelWidgetBuilders.InternalPanelWidgetBuilder, IInternalBuilder
            {
                protected override IPanelWidget BuildScript(UnityEngine.GameObject gameObject)
                {
                    IPanelWidget widget = gameObject.AddComponent<FactionDetailsPanelImpl>();
                    this.ApplyPanelValues(widget);
                    return widget;
                }
            }
        }
    }
}