using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Fonts.Aligns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Fonts.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Utils;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSortieMenus.Frames.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSortieMenus.Frames.Requests.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSortieMenus.Models.States.Inters;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSortieMenus.Views.Canvases.Widgets.Impls
{
    /// <summary>
    /// Panel Widget Impl
    /// </summary>
    public class QSortieMenuButtonsPanelImpl
        : AbstractPanelWidget
    {
        private readonly IDictionary<QSortieMenuRequestType, IImageWidget> qSortieMenuTypeButtonImages =
            new Dictionary<QSortieMenuRequestType, IImageWidget>();

        public override void Process(IMvcModelState mvcModelState)
        {
            IQSortieMenuModelState qSortieMenuModelState = (IQSortieMenuModelState)mvcModelState;
            qSortieMenuModelState.GetPrevMvcRequest().IfPresent(request =>
            {
                this.UpdateButtons(((IQSortieMenuRequest)request).GetQSortieRequestType());
            });
        }

        protected override void InitialBuild()
        {
            Vector2 buttonGridSize = new Vector2(this.canvasGridConvertor.GetGridSize().X,
                this.canvasGridConvertor.GetGridSize().Y / 5);
            this.InternalAddWidget(this.BuildBackground());
            // Build MapDetails Button
            this.qSortieMenuTypeButtonImages.Add(QSortieMenuRequestType.MapDetails,
                ImageWidgetImpl.Builder.Get()
                    .SetSpriteID(SpriteID.SquareBordered)
                    .SetColorID(ColorID.Red)
                    .SetMvcType(this.mvcType)
                    .SetCanvasLevel(1)
                    .SetInteractable(true)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(new WidgetGridSpecImpl()
                        .SetCanvasGridCoords(new Vector2(0, canvasGridConvertor.GetGridSize().Y * 4 / 5))
                        .SetCanvasGridSize(buttonGridSize))
                    .SetParent(this)
                    .SetName(this.mvcType + ":" + QSortieMenuRequestType.MapDetails + ":Button:" + CanvasWidgetType.Image)
                    .Build());
            this.InternalAddWidget(TextWidgetImpl.Builder.Get()
                .SetText(QSortieMenuRequestType.MapDetails.ToString())
                .SetFont(FontID.Arial)
                .SetColor(ColorID.White)
                .SetAlign(AlignType.MiddleCenter)
                .SetBestFit(true, 25, 100)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(1)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(0, canvasGridConvertor.GetGridSize().Y * 4 / 5))
                    .SetCanvasGridSize(buttonGridSize))
                .SetParent(this)
                .SetName(this.mvcType + ":" + QSortieMenuRequestType.MapDetails + ":Button:" + CanvasWidgetType.Text)
                .Build());

            // Build PhalanxDetails Button
            this.qSortieMenuTypeButtonImages.Add(QSortieMenuRequestType.PhalanxDetails,
                ImageWidgetImpl.Builder.Get()
                    .SetSpriteID(SpriteID.SquareBordered)
                    .SetColorID(ColorID.Red)
                    .SetMvcType(this.mvcType)
                    .SetCanvasLevel(1)
                    .SetInteractable(true)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(new WidgetGridSpecImpl()
                        .SetCanvasGridCoords(new Vector2(0, canvasGridConvertor.GetGridSize().Y * 3 / 5))
                        .SetCanvasGridSize(buttonGridSize))
                    .SetParent(this)
                    .SetName(this.mvcType + ":" + QSortieMenuRequestType.PhalanxDetails + ":Button:" + CanvasWidgetType.Image)
                    .Build());
            this.InternalAddWidget(TextWidgetImpl.Builder.Get()
                .SetText(QSortieMenuRequestType.PhalanxDetails.ToString())
                .SetFont(FontID.Arial)
                .SetColor(ColorID.White)
                .SetAlign(AlignType.MiddleCenter)
                .SetBestFit(true, 25, 100)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(1)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(0, canvasGridConvertor.GetGridSize().Y * 3 / 5))
                    .SetCanvasGridSize(buttonGridSize))
                .SetParent(this)
                .SetName(this.mvcType + ":" + QSortieMenuRequestType.PhalanxDetails + ":Button:" + CanvasWidgetType.Text)
                .Build());

            // Build CombatantDetails Button
            this.qSortieMenuTypeButtonImages.Add(QSortieMenuRequestType.CombatantDetails,
                ImageWidgetImpl.Builder.Get()
                    .SetSpriteID(SpriteID.SquareBordered)
                    .SetColorID(ColorID.Red)
                    .SetMvcType(this.mvcType)
                    .SetCanvasLevel(1)
                    .SetInteractable(true)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(new WidgetGridSpecImpl()
                        .SetCanvasGridCoords(new Vector2(0, canvasGridConvertor.GetGridSize().Y * 2 / 5))
                        .SetCanvasGridSize(buttonGridSize))
                    .SetParent(this)
                    .SetName(this.mvcType + ":" + QSortieMenuRequestType.CombatantDetails + ":Button:" + CanvasWidgetType.Image)
                    .Build());
            this.InternalAddWidget(TextWidgetImpl.Builder.Get()
                .SetText(QSortieMenuRequestType.CombatantDetails.ToString())
                .SetFont(FontID.Arial)
                .SetColor(ColorID.White)
                .SetAlign(AlignType.MiddleCenter)
                .SetBestFit(true, 25, 100)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(1)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(0, canvasGridConvertor.GetGridSize().Y * 2 / 5))
                    .SetCanvasGridSize(buttonGridSize))
                .SetParent(this)
                .SetName(this.mvcType + ":" + QSortieMenuRequestType.CombatantDetails + ":Button:" + CanvasWidgetType.Text)
                .Build());

            // Build SortieDetails Button
            this.qSortieMenuTypeButtonImages.Add(QSortieMenuRequestType.SortieDetails,
                ImageWidgetImpl.Builder.Get()
                    .SetSpriteID(SpriteID.SquareBordered)
                    .SetColorID(ColorID.Red)
                    .SetMvcType(this.mvcType)
                    .SetCanvasLevel(1)
                    .SetInteractable(true)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(new WidgetGridSpecImpl()
                        .SetCanvasGridCoords(new Vector2(0, canvasGridConvertor.GetGridSize().Y * 1 / 5))
                        .SetCanvasGridSize(buttonGridSize))
                    .SetParent(this)
                    .SetName(this.mvcType + ":" + QSortieMenuRequestType.SortieDetails + ":Button:" + CanvasWidgetType.Image)
                    .Build());
            this.InternalAddWidget(TextWidgetImpl.Builder.Get()
                .SetText(QSortieMenuRequestType.SortieDetails.ToString())
                .SetFont(FontID.Arial)
                .SetColor(ColorID.White)
                .SetAlign(AlignType.MiddleCenter)
                .SetBestFit(true, 25, 100)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(1)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(0, canvasGridConvertor.GetGridSize().Y * 1 / 5))
                    .SetCanvasGridSize(buttonGridSize))
                .SetParent(this)
                .SetName(this.mvcType + ":" + QSortieMenuRequestType.SortieDetails + ":Button:" + CanvasWidgetType.Text)
                .Build());
            // Build SortieDetails Button
            this.qSortieMenuTypeButtonImages.Add(QSortieMenuRequestType.SortieStart,
                ImageWidgetImpl.Builder.Get()
                    .SetSpriteID(SpriteID.SquareBordered)
                    .SetColorID(ColorID.Red)
                    .SetMvcType(this.mvcType)
                    .SetCanvasLevel(1)
                    .SetInteractable(true)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(new WidgetGridSpecImpl()
                        .SetCanvasGridCoords(new Vector2(0, canvasGridConvertor.GetGridSize().Y * 0 / 5))
                        .SetCanvasGridSize(buttonGridSize))
                    .SetParent(this)
                    .SetName(this.mvcType + ":" + QSortieMenuRequestType.SortieStart + ":Button:" + CanvasWidgetType.Image)
                    .Build());
            this.InternalAddWidget(TextWidgetImpl.Builder.Get()
                .SetText(QSortieMenuRequestType.SortieStart.ToString())
                .SetFont(FontID.Arial)
                .SetColor(ColorID.White)
                .SetAlign(AlignType.MiddleCenter)
                .SetBestFit(true, 25, 100)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(1)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(0, canvasGridConvertor.GetGridSize().Y * 0 / 5))
                    .SetCanvasGridSize(buttonGridSize))
                .SetParent(this)
                .SetName(this.mvcType + ":" + QSortieMenuRequestType.SortieStart + ":Button:" + CanvasWidgetType.Text)
                .Build());
            this.UpdateButtons(QSortieMenuRequestType.SortieDetails);
            foreach (ICanvasWidget canvasWidget in this.qSortieMenuTypeButtonImages.Values)
            {
                this.InternalAddWidget(canvasWidget);
            }
            /*
            // Build SortieDetails Button
            this.qSortieMenuTypeButtons.Add(QSortieMenuRequestType.SortieDetails,
                SortieDetailsUtil.BuildButtonImage(this.canvasGridConvertor, this));
            this.InternalAddWidget(SortieDetailsUtil.BuildButtonText(this.canvasGridConvertor, this));

            // Build CombatantDetails Button
            this.qSortieMenuTypeButtons.Add(QSortieMenuRequestType.CombatantDetails,
                CombatantDetailsUtil.BuildButtonImage(this.canvasGridConvertor, this));
            this.InternalAddWidget(CombatantDetailsUtil.BuildButtonText(this.canvasGridConvertor, this));

            // Build PhalanxDetails Button
            this.qSortieMenuTypeButtons.Add(QSortieMenuRequestType.PhalanxDetails,
                PhalanxDetailsUtil.BuildButtonImage(this.canvasGridConvertor, this));
            this.InternalAddWidget(PhalanxDetailsUtil.BuildButtonText(this.canvasGridConvertor, this));
            */
        }

        private void UpdateButtons(QSortieMenuRequestType qSortieMenuRequestType)
        {
            foreach (KeyValuePair<QSortieMenuRequestType, IImageWidget> typeImagePair in this.qSortieMenuTypeButtonImages)
            {
                if (typeImagePair.Key == qSortieMenuRequestType)
                {
                    logger.Debug("Setting {}:Button to not be interactable", typeImagePair.Value);
                    CanvasWidgetUtils.SetButtonInteractable(typeImagePair.Value, false);
                }
                else
                {
                    logger.Debug("Setting {}:Button to be interactable", typeImagePair.Value);
                    CanvasWidgetUtils.SetButtonInteractable(typeImagePair.Value, true);
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
                    IPanelWidget widget = gameObject.AddComponent<QSortieMenuButtonsPanelImpl>();
                    ((QSortieMenuButtonsPanelImpl)widget).mvcType = MvcType.QSortieMenu;
                    this.ApplyPanelValues(widget);
                    return widget;
                }
            }
        }
    }
}