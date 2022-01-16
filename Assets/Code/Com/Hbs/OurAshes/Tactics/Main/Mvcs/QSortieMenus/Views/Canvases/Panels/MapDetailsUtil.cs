using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Fonts.Aligns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Fonts.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSortieMenus.Frames.Requests.Types;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSortieMenus.Views.Canvases.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class MapDetailsUtil
    {
        private static readonly int BUTTON_HEIGHT = 1;
        private static readonly int BUTTON_Y_OFFSET = 1 * BUTTON_HEIGHT;

        public static ICanvasWidget BuildButtonText(ICanvasGridConvertor canvasGridConvertor, IMvcViewCanvas mvcViewCanvas)
        {
            return TextWidgetImpl.Builder.Get()
                .SetText(QSortieMenuRequestType.MapDetails.ToString())
                .SetFont(FontID.Arial)
                .SetColor(ColorID.White)
                .SetAlign(AlignType.MiddleCenter)
                .SetBestFit(true, 25, 100)
                .SetMvcType(MvcType.QSortieMenu)
                .SetCanvasLevel(1)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(0,
                        canvasGridConvertor.GetGridSize().Y - BUTTON_HEIGHT - BUTTON_Y_OFFSET))
                    .SetCanvasGridSize(new Vector2(canvasGridConvertor.GetGridSize().X / 4, 1)))
                .SetParent(mvcViewCanvas)
                .SetName(MvcType.QSortieMenu + ":" + QSortieMenuRequestType.MapDetails + ":Button:Text")
                .Build();
        }

        public static IImageWidget BuildButtonImage(ICanvasGridConvertor canvasGridConvertor, IMvcViewCanvas mvcViewCanvas)
        {
            return ImageWidgetImpl.Builder.Get()
                .SetSpriteID(SpriteID.SquareBordered)
                .SetColorID(ColorID.Red)
                .SetMvcType(MvcType.QSortieMenu)
                .SetCanvasLevel(1)
                .SetInteractable(true)
                .SetEnabled(true)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(0,
                        canvasGridConvertor.GetGridSize().Y - BUTTON_HEIGHT - BUTTON_Y_OFFSET))
                    .SetCanvasGridSize(new Vector2(canvasGridConvertor.GetGridSize().X / 4, 1)))
                .SetParent(mvcViewCanvas)
                .SetName(MvcType.QSortieMenu + ":" + QSortieMenuRequestType.MapDetails + ":Button:Image")
                .Build();
        }

        public static ISet<ICanvasWidget> BuildPanel(ICanvasGridConvertor canvasGridConvertor, IMvcViewCanvas mvcViewCanvas)
        {
            int widgetHeight = 1;
            float widgetWidth = canvasGridConvertor.GetGridSize().X / 4;
            Vector2 widgetGridSize = new Vector2(widgetWidth, widgetHeight);
            return new HashSet<ICanvasWidget>
            {
                ImageWidgetImpl.Builder.Get()
                    .SetSpriteID(SpriteID.RoundSquareBordered)
                    .SetColorID(ColorID.Red)
                .SetMvcType(MvcType.QSortieMenu)
                    .SetCanvasLevel(1)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(new WidgetGridSpecImpl()
                        .SetCanvasGridCoords(new Vector2(widgetWidth,
                            canvasGridConvertor.GetGridSize().Y - 1 - widgetHeight))
                        .SetCanvasGridSize(widgetGridSize))
                    .SetParent(mvcViewCanvas)
                    .SetName(MvcType.QSortieMenu + ":" + QSortieMenuRequestType.MapDetails + ":Panel:Field:ID:Image")
                    .Build(),
                TextWidgetImpl.Builder.Get()
                    .SetText(typeof(FieldID).Name  + ":" + FieldID.None.ToString())
                    .SetFont(FontID.Arial)
                    .SetColor(ColorID.White)
                    .SetAlign(AlignType.MiddleLeft)
                    .SetBestFit(true, 25, 100)
                .SetMvcType(MvcType.QSortieMenu)
                    .SetCanvasLevel(1)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(new WidgetGridSpecImpl()
                        .SetCanvasGridCoords(new Vector2(widgetWidth,
                            canvasGridConvertor.GetGridSize().Y - 1 - widgetHeight))
                        .SetCanvasGridSize(widgetGridSize))
                    .SetParent(mvcViewCanvas)
                    .SetName(MvcType.QSortieMenu + ":" + QSortieMenuRequestType.MapDetails + ":Panel:Field:ID:Text")
                    .Build(),
                ImageWidgetImpl.Builder.Get()
                    .SetSpriteID(SpriteID.RoundSquareBordered)
                    .SetColorID(ColorID.Red)
                .SetMvcType(MvcType.QSortieMenu)
                    .SetCanvasLevel(1)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(new WidgetGridSpecImpl()
                        .SetCanvasGridCoords(new Vector2(2*widgetWidth,
                            canvasGridConvertor.GetGridSize().Y - 1 - widgetHeight))
                        .SetCanvasGridSize(widgetGridSize))
                    .SetParent(mvcViewCanvas)
                    .SetName(MvcType.QSortieMenu + ":" + QSortieMenuRequestType.MapDetails + ":Panel:Field:Tile:Count:Image")
                    .Build(),
                TextWidgetImpl.Builder.Get()
                    .SetText( "Tile#:" + 0)
                    .SetFont(FontID.Arial)
                    .SetColor(ColorID.White)
                    .SetAlign(AlignType.MiddleLeft)
                    .SetBestFit(true, 25, 100)
                .SetMvcType(MvcType.QSortieMenu)
                    .SetCanvasLevel(1)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(new WidgetGridSpecImpl()
                        .SetCanvasGridCoords(new Vector2(2*widgetWidth,
                            canvasGridConvertor.GetGridSize().Y - 1 - widgetHeight))
                        .SetCanvasGridSize(widgetGridSize))
                    .SetParent(mvcViewCanvas)
                    .SetName(MvcType.QSortieMenu + ":" + QSortieMenuRequestType.MapDetails + ":Panel:Field:Tile:CountD:Text")
                    .Build(),
                ImageWidgetImpl.Builder.Get()
                    .SetSpriteID(SpriteID.RoundSquareBordered)
                    .SetColorID(ColorID.Red)
                .SetMvcType(MvcType.QSortieMenu)
                    .SetCanvasLevel(1)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(new WidgetGridSpecImpl()
                        .SetCanvasGridCoords(new Vector2(widgetWidth,
                            canvasGridConvertor.GetGridSize().Y - 1 - 2 * widgetHeight))
                        .SetCanvasGridSize(widgetGridSize))
                    .SetParent(mvcViewCanvas)
                    .SetName(MvcType.QSortieMenu + ":" + QSortieMenuRequestType.MapDetails + ":Panel:Phalanx:Count:Image")
                    .Build(),
                TextWidgetImpl.Builder.Get()
                    .SetText("Phalanx#:" + 0)
                    .SetFont(FontID.Arial)
                    .SetColor(ColorID.White)
                    .SetAlign(AlignType.MiddleLeft)
                    .SetBestFit(true, 25, 100)
                .SetMvcType(MvcType.QSortieMenu)
                    .SetCanvasLevel(1)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(new WidgetGridSpecImpl()
                        .SetCanvasGridCoords(new Vector2(widgetWidth,
                            canvasGridConvertor.GetGridSize().Y - 1 - 2 * widgetHeight))
                        .SetCanvasGridSize(widgetGridSize))
                    .SetParent(mvcViewCanvas)
                    .SetName(MvcType.QSortieMenu + ":" + QSortieMenuRequestType.MapDetails + ":Panel:Phalanx:Count:Text")
                    .Build(),
                ImageWidgetImpl.Builder.Get()
                    .SetSpriteID(SpriteID.RoundSquareBordered)
                    .SetColorID(ColorID.Red)
                .SetMvcType(MvcType.QSortieMenu)
                    .SetCanvasLevel(1)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(new WidgetGridSpecImpl()
                        .SetCanvasGridCoords(new Vector2(2*widgetWidth,
                            canvasGridConvertor.GetGridSize().Y - 1 - 2 * widgetHeight))
                        .SetCanvasGridSize(widgetGridSize))
                    .SetParent(mvcViewCanvas)
                    .SetName(MvcType.QSortieMenu + ":" + QSortieMenuRequestType.MapDetails + ":Panel:Phalanx:Count:Image")
                    .Build(),
                TextWidgetImpl.Builder.Get()
                    .SetText("Combatant#:" + 0)
                    .SetFont(FontID.Arial)
                    .SetColor(ColorID.White)
                    .SetAlign(AlignType.MiddleLeft)
                    .SetBestFit(true, 25, 100)
                .SetMvcType(MvcType.QSortieMenu)
                    .SetCanvasLevel(1)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(new WidgetGridSpecImpl()
                        .SetCanvasGridCoords(new Vector2(2*widgetWidth,
                            canvasGridConvertor.GetGridSize().Y - 1 - 2 * widgetHeight))
                        .SetCanvasGridSize(widgetGridSize))
                    .SetParent(mvcViewCanvas)
                    .SetName(MvcType.QSortieMenu + ":" + QSortieMenuRequestType.MapDetails + ":Panel:Combatant:Count:Text")
                    .Build()
            };
        }
    }
}