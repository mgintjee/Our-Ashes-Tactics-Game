﻿using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Factions.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Factions.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.CallSigns;
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
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Phalanxes.Constants;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Phalanxes
{
    /// <summary>
    /// Panel Widget Impl
    /// </summary>
    public class PhalanxDetailsPanelImpl
        : AbstractPanelWidget, IPanelWidget
    {
        private IDualTextPanelWidget alphaText;
        private IDualTextPanelWidget bravoText;
        private IDualTextPanelWidget charlieText;
        private IDualTextPanelWidget deltaText;
        private IDualTextPanelWidget echoText;
        private IDualTextPanelWidget foxtrotText;
        private IDualTextPanelWidget alphaButtons;
        private IDualTextPanelWidget bravoButtons;
        private IDualTextPanelWidget charlieButtons;
        private IDualTextPanelWidget deltaButtons;
        private IDualTextPanelWidget echoButtons;
        private IDualTextPanelWidget foxtrotButtons;

        public override void Process(Commons.Models.States.Inters.IMvcModelState mvcModelState)
        {
            Models.States.Inters.IMvcModelState qSortieMenuModelState = (Models.States.Inters.IMvcModelState)mvcModelState;
            this.UpdateText(PhalanxCallSign.Alpha, this.alphaText, qSortieMenuModelState);
            this.UpdateText(PhalanxCallSign.Bravo, this.bravoText, qSortieMenuModelState);
            this.UpdateText(PhalanxCallSign.Charlie, this.charlieText, qSortieMenuModelState);
            this.UpdateText(PhalanxCallSign.Delta, this.deltaText, qSortieMenuModelState);
            this.UpdateText(PhalanxCallSign.Echo, this.echoText, qSortieMenuModelState);
            this.UpdateText(PhalanxCallSign.Foxtrot, this.foxtrotText, qSortieMenuModelState);
        }

        protected override void InitialBuild()
        {
            ISet<ICanvasWidget> panelWidgets = new HashSet<ICanvasWidget>() {
                this.BuildAndSetAlphaText(),
                this.BuildAndSetBravoText(),
                this.BuildAndSetCharlieText(),
                this.BuildAndSetDeltaText(),
                this.BuildAndSetEchoText(),
                this.BuildAndSetFoxtrotText(),
                this.BuildAndSetAlphaButtons(),
                this.BuildAndSetBravoButtons(),
                this.BuildAndSetCharlieButtons(),
                this.BuildAndSetDeltaButtons(),
                this.BuildAndSetEchoButtons(),
                this.BuildAndSetFoxtrotButtons()
            };
            this.InternalAddWidgets(panelWidgets);
        }

        private void UpdateText(PhalanxCallSign phalanxCallSign, IDualTextPanelWidget text, Models.States.Inters.IMvcModelState mvcModelState)
        {
            MvcModelStateQueryUtil.GetPhalanxDetails(mvcModelState, phalanxCallSign).IfPresent(phalanxDetails =>
            {
                this.UpdateText(text, phalanxDetails);
            });
        }

        private void UpdateText(IDualTextPanelWidget text, IPhalanxDetails phalanxDetails)
        {
            string textString = "[";
            foreach (ICombatantDetails details in phalanxDetails.GetCombatantDetails())
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
            this.alphaText = this.BuildText(PhalanxCallSign.Alpha.ToString(),
                PhalanxDetailsPanelConstants.ALPHA_TEXT_COORDS);
            return this.alphaText;
        }
        private IDualTextPanelWidget BuildAndSetBravoText()
        {
            this.bravoText = this.BuildText(PhalanxCallSign.Bravo.ToString(),
                PhalanxDetailsPanelConstants.BRAVO_TEXT_COORDS);
            return this.bravoText;
        }
        private IDualTextPanelWidget BuildAndSetCharlieText()
        {
            this.charlieText = this.BuildText(PhalanxCallSign.Charlie.ToString(),
                PhalanxDetailsPanelConstants.CHARLIE_TEXT_COORDS);
            return this.charlieText;
        }
        private IDualTextPanelWidget BuildAndSetDeltaText()
        {
            this.deltaText = this.BuildText(PhalanxCallSign.Delta.ToString(),
                PhalanxDetailsPanelConstants.DELTA_TEXT_COORDS);
            return this.deltaText;
        }
        private IDualTextPanelWidget BuildAndSetEchoText()
        {
            this.echoText = this.BuildText(PhalanxCallSign.Echo.ToString(),
                PhalanxDetailsPanelConstants.ECHO_TEXT_COORDS);
            return this.echoText;
        }
        private IDualTextPanelWidget BuildAndSetFoxtrotText()
        {
            this.foxtrotText = this.BuildText(PhalanxCallSign.Foxtrot.ToString(),
                PhalanxDetailsPanelConstants.FOXTROT_TEXT_COORDS);
            return this.foxtrotText;
        }
        private IDualTextPanelWidget BuildAndSetAlphaButtons()
        {
            this.alphaButtons = this.BuildButtons(PhalanxCallSign.Alpha.ToString(),
                PhalanxDetailsPanelConstants.ALPHA_BUTTONS_COORDS);
            return this.alphaButtons;
        }
        private IDualTextPanelWidget BuildAndSetBravoButtons()
        {
            this.bravoButtons = this.BuildButtons(PhalanxCallSign.Bravo.ToString(),
                PhalanxDetailsPanelConstants.BRAVO_BUTTONS_COORDS);
            return this.bravoButtons;
        }
        private IDualTextPanelWidget BuildAndSetCharlieButtons()
        {
            this.charlieButtons = this.BuildButtons(PhalanxCallSign.Charlie.ToString(),
                PhalanxDetailsPanelConstants.CHARLIE_BUTTONS_COORDS);
            return this.charlieButtons;
        }
        private IDualTextPanelWidget BuildAndSetDeltaButtons()
        {
            this.deltaButtons = this.BuildButtons(PhalanxCallSign.Delta.ToString(),
                PhalanxDetailsPanelConstants.DELTA_BUTTONS_COORDS);
            return this.deltaButtons;
        }
        private IDualTextPanelWidget BuildAndSetEchoButtons()
        {
            this.echoButtons = this.BuildButtons(PhalanxCallSign.Echo.ToString(),
                PhalanxDetailsPanelConstants.ECHO_BUTTONS_COORDS);
            return this.echoButtons;
        }
        private IDualTextPanelWidget BuildAndSetFoxtrotButtons()
        {
            this.foxtrotButtons = this.BuildButtons(PhalanxCallSign.Foxtrot.ToString(),
                PhalanxDetailsPanelConstants.FOXTROT_BUTTONS_COORDS);
            return this.foxtrotButtons;
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
                    .SetCanvasGridSize(PhalanxDetailsPanelConstants.TEXT_SIZE))
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(1)
                .SetInteractable(true)
                .SetEnabled(true)
                .SetName(this.mvcType + ":" + RequestType.PhalanxDetails + ":" + CanvasWidgetType.Panel + ":" + enumString)
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
                    .SetCanvasGridSize(PhalanxDetailsPanelConstants.TEXT_SIZE))
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(1)
                .SetInteractable(true)
                .SetEnabled(true)
                .SetName(this.mvcType + ":" + RequestType.PhalanxDetails + ":" + CanvasWidgetType.Panel + ":" + enumString + ":Buttons")
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
                    IPanelWidget widget = gameObject.AddComponent<PhalanxDetailsPanelImpl>();
                    this.ApplyPanelValues(widget);
                    return widget;
                }
            }
        }
    }
}