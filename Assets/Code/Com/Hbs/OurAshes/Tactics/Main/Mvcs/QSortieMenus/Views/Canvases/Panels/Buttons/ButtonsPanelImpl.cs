using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Utils;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSortieMenus.Frames.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSortieMenus.Frames.Requests.Types;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSortieMenus.Views.Canvases.Panels.Buttons
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
            Vector2 buttonGridSize = new Vector2(this.canvasGridConvertor.GetGridSize().X,
                this.canvasGridConvertor.GetGridSize().Y / 6);
            this.InternalAddWidget(this.BuildBackground());
            this.qSortieMenuTypeButtons.Add(RequestType.MapDetails,
                (IButtonPanelWidget)ButtonPanelImpl.Builder.Get()
                .SetButtonText(RequestType.MapDetails.ToString())
                .SetButtonType(RequestType.MapDetails.ToString())
                .SetPanelGridSize(new Vector2(2, 1))
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(0, this.canvasGridConvertor.GetGridSize().Y * 5 / 6))
                    .SetCanvasGridSize(buttonGridSize))
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(0)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetName(this.mvcType + ":" + RequestType.MapDetails + ":Button:" + CanvasWidgetType.Panel)
                .SetParent(this)
                .Build());
            this.qSortieMenuTypeButtons.Add(RequestType.PhalanxDetails,
                (IButtonPanelWidget)ButtonPanelImpl.Builder.Get()
                .SetButtonText(RequestType.PhalanxDetails.ToString())
                .SetButtonType(RequestType.PhalanxDetails.ToString())
                .SetPanelGridSize(new Vector2(2, 1))
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(0, this.canvasGridConvertor.GetGridSize().Y * 4 / 6))
                    .SetCanvasGridSize(buttonGridSize))
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(0)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetName(this.mvcType + ":" + RequestType.PhalanxDetails + ":Button:" + CanvasWidgetType.Panel)
                .SetParent(this)
                .Build());
            this.qSortieMenuTypeButtons.Add(RequestType.CombatantDetails,
                (IButtonPanelWidget)ButtonPanelImpl.Builder.Get()
                .SetButtonText(RequestType.CombatantDetails.ToString())
                .SetButtonType(RequestType.CombatantDetails.ToString())
                .SetPanelGridSize(new Vector2(2, 1))
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(0, this.canvasGridConvertor.GetGridSize().Y * 3 / 6))
                    .SetCanvasGridSize(buttonGridSize))
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(0)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetName(this.mvcType + ":" + RequestType.CombatantDetails + ":Button:" + CanvasWidgetType.Panel)
                .SetParent(this)
                .Build());
            this.qSortieMenuTypeButtons.Add(RequestType.SortieDetails,
                (IButtonPanelWidget)ButtonPanelImpl.Builder.Get()
                .SetButtonText(RequestType.SortieDetails.ToString())
                .SetButtonType(RequestType.SortieDetails.ToString())
                .SetPanelGridSize(new Vector2(2, 1))
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(0, this.canvasGridConvertor.GetGridSize().Y * 2 / 6))
                    .SetCanvasGridSize(buttonGridSize))
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(0)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetName(this.mvcType + ":" + RequestType.SortieDetails + ":Button:" + CanvasWidgetType.Panel)
                .SetParent(this)
                .Build());
            this.qSortieMenuTypeButtons.Add(RequestType.SortieStart,
                (IButtonPanelWidget)ButtonPanelImpl.Builder.Get()
                .SetButtonText(RequestType.SortieStart.ToString())
                .SetButtonType(RequestType.SortieStart.ToString())
                .SetPanelGridSize(new Vector2(2, 1))
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(0, 0))
                    .SetCanvasGridSize(buttonGridSize))
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(0)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetName(this.mvcType + ":" + RequestType.SortieStart + ":Button:" + CanvasWidgetType.Panel)
                .SetParent(this)
                .Build());
            this.UpdateButtons(RequestType.SortieDetails);
            foreach (ICanvasWidget canvasWidget in this.qSortieMenuTypeButtons.Values)
            {
                this.InternalAddWidget(canvasWidget);
            }
        }

        private void UpdateButtons(RequestType qSortieMenuRequestType)
        {
            foreach (KeyValuePair<RequestType, IButtonPanelWidget> typeImagePair in this.qSortieMenuTypeButtons)
            {
                CanvasWidgetUtils.SetButtonInteractable(typeImagePair.Value.GetImageWidget(),
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