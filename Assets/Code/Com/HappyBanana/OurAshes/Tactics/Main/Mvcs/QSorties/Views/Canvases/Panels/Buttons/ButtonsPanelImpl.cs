﻿using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Utils;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Buttons.Constants;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Buttons
{
    /// <summary>
    /// Panel Widget Impl
    /// </summary>
    public class ButtonsPanelImpl
        : AbstractPanelWidget
    {
        private readonly IDictionary<RequestType, IButtonWidget> qSortieMenuTypeButtons =
            new Dictionary<RequestType, IButtonWidget>();

        public override void Process(Commons.Models.States.Inters.IMvcModelState mvcModelState)
        {
            mvcModelState.GetPrevMvcRequest().IfPresent(request =>
            {
                this.UpdateButtons(((IQSortieMenuMvcRequest)request).GetRequestType());
            });
        }

        protected override void InitialBuild()
        {
            this.InternalAddWidget(this.BuildBackground());
            this.BuildAndSetFieldDetailsButton();
            this.BuildAndSetFactionDetailsButton();
            this.BuildAndSetPhalanxDetailsButton();
            this.BuildAndSetUnitDetailsButton();
            this.BuildAndSetSortieDetailsButton();
            this.BuildAndSetSortieStartButton();
            this.UpdateButtons(RequestType.DetailsSortie);
            foreach (ICanvasWidget canvasWidget in this.qSortieMenuTypeButtons.Values)
            {
                this.InternalAddWidget(canvasWidget);
            }
        }

        private void BuildAndSetFieldDetailsButton()
        {
            this.BuildAndSetRequestTypeButtonPanel(RequestType.DetailsField,
               ButtonPanelConstants.BUTTON_FIELD_DETAILS_COORDS);
        }

        private void BuildAndSetFactionDetailsButton()
        {
            this.BuildAndSetRequestTypeButtonPanel(RequestType.DetailsFaction,
               ButtonPanelConstants.BUTTON_FACTION_DETAILS_COORDS);
        }

        private void BuildAndSetPhalanxDetailsButton()
        {
            this.BuildAndSetRequestTypeButtonPanel(RequestType.DetailsPhalanx,
                ButtonPanelConstants.BUTTON_PHALANX_DETAILS_COORDS);
        }

        private void BuildAndSetSortieDetailsButton()
        {
            this.BuildAndSetRequestTypeButtonPanel(RequestType.DetailsSortie,
               ButtonPanelConstants.BUTTON_SORTIE_DETAILS_COORDS);
        }

        private void BuildAndSetUnitDetailsButton()
        {
            this.BuildAndSetRequestTypeButtonPanel(RequestType.DetailsUnit,
               ButtonPanelConstants.BUTTON_COMBATANT_DETAILS_COORDS);
        }

        private void BuildAndSetSortieStartButton()
        {
            this.BuildAndSetRequestTypeButtonPanel(RequestType.SortieStart,
                ButtonPanelConstants.BUTTON_SORTIE_START_COORDS);
        }

        private IButtonWidget BuildAndSetRequestTypeButtonPanel(RequestType requestType, Vector2 buttonCoords)
        {
            this.qSortieMenuTypeButtons[requestType] = this.BuildButtonPanelWidget(requestType, buttonCoords);
            return this.qSortieMenuTypeButtons[requestType];
        }

        private IButtonWidget BuildButtonPanelWidget(RequestType requestType, Vector2 canvasGridCoords)
        {
            return (IButtonWidget)ButtonWidgetImpl.Builder.Get()
                    .SetButtonText(requestType.ToString())
                    .SetPanelGridSize(Vector2.One)
                    .SetWidgetGridSpec(new WidgetGridSpecImpl()
                        .SetCanvasGridCoords(canvasGridCoords)
                        .SetCanvasGridSize(ButtonPanelConstants.BUTTON_SIZE))
                    .SetMvcType(this.mvcType)
                    .SetCanvasLevel(0)
                    .SetInteractable(true)
                    .SetEnabled(true)
                    .SetName(requestType + ":Button")
                    .SetParent(this)
                    .Build();
        }

        private void UpdateButtons(RequestType requestType)
        {
            if (requestType.ToString().Contains("Details"))
            {
                foreach (KeyValuePair<RequestType, IButtonWidget> typeImagePair in this.qSortieMenuTypeButtons)
                {
                    CanvasWidgetUtils.SetButtonInteractable(typeImagePair.Value, typeImagePair.Key != requestType);
                }
            }
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
                    IPanelWidget widget = gameObject.AddComponent<ButtonsPanelImpl>();
                    this.ApplyPanelValues(widget);
                    return widget;
                }
            }
        }
    }
}