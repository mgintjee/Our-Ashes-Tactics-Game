﻿using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Fonts.Aligns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Fonts.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Scripts.Canvases.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Scripts.Canvases.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Utils;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Abstrs
{
    /// <summary>
    /// Mvc View Canvas Interface
    /// </summary>
    public abstract class AbstractMvcViewCanvas
        : AbstractCanvasScript, IMvcViewCanvas
    {
        // Todo
        protected ICanvasScript mvcViewCanvasScript;

        // Todo
        protected IDictionary<int, ISet<ICanvasWidget>> canvasLevelWidgets = new Dictionary<int, ISet<ICanvasWidget>>();

        // Todo
        protected ICanvasGridConvertor canvasGridConvertor;

        // Todo
        protected Vector2 worldGridSize;

        // Todo
        protected IClassLogger logger;

        // Todo
        protected MvcType mvcType;

        public void SetGridSize(Vector2 gridSize)
        {
            this.worldGridSize = gridSize;
            Vector2 worldSize = new Vector2(this.GetRectTransform().sizeDelta.x,
                this.GetRectTransform().sizeDelta.y);
            this.canvasGridConvertor = new CanvasGridConvertorImpl(gridSize, worldSize);
        }

        protected ICanvasWidget BuildBackground()
        {
            return ImageWidgetImpl.Builder.Get()
                .SetSpriteID(SpriteID.SquareBordered)
                .SetColorID(ColorID.Blue)
                .SetCanvasLevel(0)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetWidgetGridSpec(new CanvasGridSpecImpl()
                    .SetCanvasGridCoords(Vector2.Zero)
                    .SetCanvasGridSize(new Vector2(
                        this.canvasGridConvertor.GetGridSize().X,
                        this.canvasGridConvertor.GetGridSize().Y - 1)))
                .SetParent(this)
                .SetName(this.mvcType + ":Background:Image")
                .Build();
        }
        protected ISet<ICanvasWidget> BuildHeader()
        {
            int headerHeight = 1;
            IWidgetGridSpec widgetGridSpec = new CanvasGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(0, this.canvasGridConvertor.GetGridSize().Y - headerHeight))
                    .SetCanvasGridSize(new Vector2(this.canvasGridConvertor.GetGridSize().X / 2, headerHeight));
            return new HashSet<ICanvasWidget>
            {
                ImageWidgetImpl.Builder.Get()
                    .SetSpriteID(SpriteID.SquareBordered)
                    .SetColorID(ColorID.Blue)
                    .SetCanvasLevel(1)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(new CanvasGridSpecImpl()
                        .SetCanvasGridCoords(new Vector2(0, this.canvasGridConvertor.GetGridSize().Y - headerHeight))
                        .SetCanvasGridSize(new Vector2(this.canvasGridConvertor.GetGridSize().X, headerHeight)))
                    .SetParent(this)
                    .SetName(this.mvcType + ":Header:BackImage")
                    .Build(),
                ImageWidgetImpl.Builder.Get()
                    .SetSpriteID(SpriteID.SquareBordered)
                    .SetColorID(ColorID.Red)
                    .SetCanvasLevel(1)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(widgetGridSpec)
                    .SetParent(this)
                    .SetName(this.mvcType + ":Header:FrontImage")
                    .Build(),
                TextWidgetImpl.Builder.Get()
                    .SetText(this.mvcType.ToString())
                    .SetFont(FontID.Arial)
                    .SetColor(ColorID.White)
                    .SetAlign(AlignType.MiddleCenter)
                    .SetBestFit(true, 25, 100)
                    .SetCanvasLevel(1)
                    .SetInteractable(false)
                    .SetEnabled(true)
                    .SetWidgetGridSpec(widgetGridSpec)
                    .SetParent(this)
                    .SetName(this.mvcType + ":Header:Text")
                    .Build()
                };
        }

        /// <inheritdoc/>
        Optional<ICanvasWidget> IMvcViewCanvas.GetWidget(IMvcControlInput mvcControlInput)
        {
            Optional<ICanvasWidget> canvasWidget = CanvasWidgetUtils.GetWidgetFromInput(this.canvasGridConvertor,
                this.canvasLevelWidgets, mvcControlInput);
            canvasWidget.IfPresent(widget => this.ProcessSelectedWidget(widget));
            return canvasWidget;
        }

        /// <inheritdoc/>
        Vector2 IMvcViewCanvas.GetWorldSize()
        {
            return this.canvasGridConvertor.GetWorldSize();
        }

        protected virtual void ProcessSelectedWidget(ICanvasWidget canvasWidget)
        {
        }

        protected void AddWidget(ICanvasWidget widget)
        {
            logger.Info("Adding {}:{}", widget.GetType(), widget.GetName());
            CanvasWidgetUtils.AddWidget(this.canvasGridConvertor, this.canvasLevelWidgets, widget);
        }
        protected void AddWidgets(ICollection<ICanvasWidget> widgets)
        {
            foreach(ICanvasWidget canvasWidget in widgets)
            {
                this.AddWidget(canvasWidget);
            }
        }
        public abstract void Process(IMvcModelState mvcModelState);
        public abstract void InitialBuild();

        /// <summary>
        /// Todo
        /// </summary>
        public class AbstractViewCanvasBuilders
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IViewCanvasBuilder
                : AbstractCanvasBuilders.ICanvasBuilder<IMvcViewCanvas>
            {
                IViewCanvasBuilder SetMvcType(MvcType mvcType);
            }

            /// <summary>
            /// Todo
            /// </summary>
            public abstract class AbstractViewCanvasBuilder
                : AbstractCanvasBuilders.AbstractCanvasBuilder<IMvcViewCanvas>, IViewCanvasBuilder
            {
                private MvcType mvcType;

                /// <inheritdoc/>
                IViewCanvasBuilder IViewCanvasBuilder.SetMvcType(MvcType mvcType)
                {
                    this.mvcType = mvcType;
                    return this;
                }

                protected void ApplyMvcViewValues(IMvcViewCanvas mvcViewCanvas)
                {
                    ((AbstractMvcViewCanvas)mvcViewCanvas).mvcType = this.mvcType;
                    ((AbstractMvcViewCanvas)mvcViewCanvas).logger = LoggerManager.GetLogger(this.mvcType)
                        .GetClassLogger(mvcViewCanvas.GetType());
                    this.ApplyCanvasValues((AbstractMvcViewCanvas)mvcViewCanvas);
                }
            }
        }
    }
}