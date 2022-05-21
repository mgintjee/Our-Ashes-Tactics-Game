using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Utils;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Maps;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Buttons
{
    /// <summary>
    /// Panel Widget Impl
    /// </summary>
    public class ButtonsPanelImpl
        : AbstractPanelWidget
    {
        private readonly IDictionary<RequestType, IButtonPanelWidget> qSortieMenuTypeButtons =
            new Dictionary<RequestType, IButtonPanelWidget>();

        public override void Process(Commons.Models.States.Inters.IMvcModelState mvcModelState)
        {
            Models.States.Inters.IMvcModelState qSortieMenuModelState = (Models.States.Inters.IMvcModelState)mvcModelState;
            qSortieMenuModelState.GetPrevMvcRequest().IfPresent(request =>
            {
                this.UpdateButtons(((IQSortieMenuMvcRequest)request).GetRequestType());
            });
        }

        protected override void InitialBuild()
        {
            this.InternalAddWidget(this.BuildBackground());
            this.BuildAndSetFieldDetailsButton();
            this.BuildAndSetPhalanxDetailsButton();
            this.BuildAndSetCombatantDetailsButton();
            this.BuildAndSetSortieDetailsButton();
            this.BuildAndSetSortieStartButton();
            this.UpdateButtons(RequestType.SortieDetails);
            foreach (ICanvasWidget canvasWidget in this.qSortieMenuTypeButtons.Values)
            {
                this.InternalAddWidget(canvasWidget);
            }
        }

        private IButtonPanelWidget BuildAndSetFieldDetailsButton()
        {
            return this.BuildAndSetRequestTypeButtonPanel(RequestType.FieldDetails, ButtonPanelConstants.BUTTON_FIELD_DETAILS_COORDS);
        }
        private IButtonPanelWidget BuildAndSetPhalanxDetailsButton()
        {
            return this.BuildAndSetRequestTypeButtonPanel(RequestType.PhalanxDetails, ButtonPanelConstants.BUTTON_PHALANX_DETAILS_COORDS);
        }
        private IButtonPanelWidget BuildAndSetSortieDetailsButton()
        {
            return this.BuildAndSetRequestTypeButtonPanel(RequestType.SortieDetails, ButtonPanelConstants.BUTTON_SORTIE_DETAILS_COORDS);
        }
        private IButtonPanelWidget BuildAndSetCombatantDetailsButton()
        {
            return this.BuildAndSetRequestTypeButtonPanel(RequestType.CombatantDetails, ButtonPanelConstants.BUTTON_COMBATANT_DETAILS_COORDS);
        }
        private IButtonPanelWidget BuildAndSetSortieStartButton()
        {
            return this.BuildAndSetRequestTypeButtonPanel(RequestType.SortieStart, ButtonPanelConstants.BUTTON_SORTIE_START_COORDS);
        }

        private IButtonPanelWidget BuildAndSetRequestTypeButtonPanel(RequestType requestType, Vector2 buttonCoords)
        {
            this.qSortieMenuTypeButtons[requestType] = this.BuildButtonPanelWidget(requestType, buttonCoords);
            return this.qSortieMenuTypeButtons[requestType];
        }

        private IButtonPanelWidget BuildButtonPanelWidget(RequestType requestType, Vector2 canvasGridCoords)
        {
            return (IButtonPanelWidget)ButtonPanelImpl.Builder.Get()
                    .SetButtonText(requestType.ToString())
                    .SetButtonType(requestType.ToString())
                    .SetPanelGridSize(Vector2.One)
                    .SetWidgetGridSpec(new WidgetGridSpecImpl()
                        .SetCanvasGridCoords(canvasGridCoords)
                        .SetCanvasGridSize(ButtonPanelConstants.BUTTON_SIZE))
                    .SetMvcType(this.mvcType)
                    .SetCanvasLevel(0)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetName(this.mvcType + ":" + requestType + ":Button:" + CanvasWidgetType.Panel)
                    .SetParent(this)
                    .Build();
        }

        private void UpdateButtons(RequestType qSortieMenuRequestType)
        {
            foreach (KeyValuePair<RequestType, IButtonPanelWidget> typeImagePair in this.qSortieMenuTypeButtons)
            {
                CanvasWidgetUtils.SetImageInteractable(typeImagePair.Value.GetImageWidget(),
                    typeImagePair.Key != qSortieMenuRequestType);
                CanvasWidgetUtils.SetTextInteractable(typeImagePair.Value.GetTextWidget(),
                    typeImagePair.Key != qSortieMenuRequestType);
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