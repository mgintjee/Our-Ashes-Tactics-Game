﻿using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Fonts.Aligns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Fonts.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Scripts.Builders.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Scripts.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Specs.Grids.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSortieMenus.Frames.Requests.Types;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSortieMenus.Views.Canvases.Impls
{
    /// <summary>
    /// QSortie View Canvas Implementation
    /// </summary>
    public class QSortieMenuViewCanvasImpl
        : AbstractMvcViewCanvas, IMvcViewCanvas
    {
        /// <inheritdoc/>
        protected override void InternalBuild()
        {
            this.BuildSplashImages();
            this.BuildSplashTexts();
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void BuildSplashImages()
        {
            this.AddWidget(ImageWidgetImpl.Builder.Get()
                .SetSpriteID(SpriteID.SquareBorderless)
                .SetColorID(ColorID.Fuchsia)
                .SetCanvasLevel(1)
                .SetInteractable(false)
                .SetMvcViewCanvas(this)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(Vector2.Zero)
                    .SetCanvasGridSize(this.gridConvertor.GetGridSize()))
                .SetParent(this)
                .SetName(typeof(ImageWidgetImpl).Name + ":Back")
                .Build());
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void BuildSplashTexts()
        {
            this.AddWidget(TextWidgetImpl.Builder.Get()
                .SetText(QSortieRequestType.Map)
                .SetFont(FontID.Arial)
                .SetAlign(AlignType.MiddleCenter)
                .SetBestFit(true, 13, 60)
                .SetCanvasLevel(0)
                .SetInteractable(true)
                .SetMvcViewCanvas(this)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(1, 1))
                    .SetCanvasGridSize(new Vector2(2, 1)))
                .SetParent(this)
                .SetName(typeof(TextWidgetImpl).Name + ":" + QSortieRequestType.Map)
                .Build());
            this.AddWidget(TextWidgetImpl.Builder.Get()
                .SetText(QSortieRequestType.Combatants)
                .SetFont(FontID.Arial)
                .SetAlign(AlignType.MiddleCenter)
                .SetBestFit(true, 13, 60)
                .SetCanvasLevel(0)
                .SetInteractable(true)
                .SetMvcViewCanvas(this)
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(1, 1))
                    .SetCanvasGridSize(new Vector2(2, 1)))
                .SetParent(this)
                .SetName(typeof(TextWidgetImpl).Name + ":" + QSortieRequestType.Combatants)
                .Build());
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
                : AbstractViewCanvasBuilders.IViewCanvasBuilder
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
                : AbstractViewCanvasBuilders.AbstractViewCanvasBuilder, IInternalBuilder
            {
                /// <inheritdoc/>
                protected override IMvcViewCanvas BuildScript(UnityEngine.GameObject gameObject)
                {
                    IMvcViewCanvas mvcViewCanvas = gameObject.AddComponent<QSortieMenuViewCanvasImpl>();
                    this.ApplyMvcViewValues((AbstractMvcViewCanvas)mvcViewCanvas);
                    mvcViewCanvas.Build();
                    return mvcViewCanvas;
                }
            }
        }
    }
}