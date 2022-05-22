using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Biomes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Shapes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Constants;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Fields.Constants;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Fields
{
    /// <summary>
    /// FieldDetails Panel Impl
    /// </summary>
    public class FieldDetailsPanelImpl
        : AbstractPanelWidget, IPanelWidget
    {
        private IMultiTextPanelWidget fieldIDText;
        private IMultiTextPanelWidget fieldIDButtons;
        private IMultiTextPanelWidget fieldSizeText;
        private IMultiTextPanelWidget fieldShapeText;
        private IMultiTextPanelWidget fieldBiomeText;
        private IMultiTextPanelWidget fieldSizeButtons;
        private IMultiTextPanelWidget fieldShapeButtons;
        private IMultiTextPanelWidget fieldBiomeButtons;

        public override void Process(Commons.Models.States.Inters.IMvcModelState mvcModelState)
        {
            Models.States.Inters.IMvcModelState qSortieMenuModelState = (Models.States.Inters.IMvcModelState)mvcModelState;
            IFieldDetails fieldDetails = qSortieMenuModelState.GetFieldDetails();
            this.fieldIDText.GetTextWidget(1).IfPresent(textWidget => { textWidget.SetText(fieldDetails.GetFieldID()); });
            this.fieldSizeText.GetTextWidget(1).IfPresent(textWidget => { textWidget.SetText(fieldDetails.GetFieldSize()); });
            this.fieldShapeText.GetTextWidget(1).IfPresent(textWidget => { textWidget.SetText(fieldDetails.GetFieldShape()); });
            this.fieldBiomeText.GetTextWidget(1).IfPresent(textWidget => { textWidget.SetText(fieldDetails.GetFieldBiome()); });
        }

        protected override void InitialBuild()
        {
            ISet<ICanvasWidget> panelWidgets = new HashSet<ICanvasWidget>() {
                this.BuildAndSetFieldIDText(),
                this.BuildAndSetFieldSizeText(),
                this.BuildAndSetFieldShapeText(),
                this.BuildAndSetFieldBiomeText(),
                this.BuildAndSetFieldIDButtons(),
                this.BuildAndSetFieldSizeButtons(),
                this.BuildAndSetFieldShapeButtons(),
                this.BuildAndSetFieldBiomeButtons()
            };
            this.InternalAddWidgets(panelWidgets);
        }

        private IMultiTextPanelWidget BuildAndSetFieldIDText()
        {
            this.fieldIDText = this.BuildText(typeof(FieldID).Name,
                FieldDetailsPanelConstants.FIELD_ID_TEXT_COORDS);
            return this.fieldIDText;
        }

        private IMultiTextPanelWidget BuildAndSetFieldIDButtons()
        {
            this.fieldIDButtons = this.BuildButtons(typeof(FieldID).Name,
                FieldDetailsPanelConstants.FIELD_ID_BUTTONS_COORDS);
            return this.fieldIDButtons;
        }

        private IMultiTextPanelWidget BuildAndSetFieldBiomeText()
        {
            this.fieldBiomeText = this.BuildText(typeof(FieldBiome).Name,
                FieldDetailsPanelConstants.FIELD_BIOME_TEXT_COORDS);
            return this.fieldBiomeText;
        }

        private IMultiTextPanelWidget BuildAndSetFieldSizeText()
        {
            this.fieldSizeText = this.BuildText(typeof(FieldSize).Name,
                FieldDetailsPanelConstants.FIELD_SIZE_TEXT_COORDS);
            return this.fieldSizeText;
        }

        private IMultiTextPanelWidget BuildAndSetFieldShapeText()
        {
            this.fieldShapeText = this.BuildText(typeof(FieldShape).Name,
                FieldDetailsPanelConstants.FIELD_SHAPE_TEXT_COORDS);
            return this.fieldShapeText;
        }

        private IMultiTextPanelWidget BuildAndSetFieldBiomeButtons()
        {
            this.fieldBiomeButtons = this.BuildButtons(typeof(FieldBiome).Name,
                FieldDetailsPanelConstants.FIELD_BIOME_BUTTONS_COORDS);
            return this.fieldBiomeButtons;
        }

        private IMultiTextPanelWidget BuildAndSetFieldSizeButtons()
        {
            this.fieldSizeButtons = this.BuildButtons(typeof(FieldSize).Name,
                FieldDetailsPanelConstants.FIELD_SIZE_BUTTONS_COORDS);
            return this.fieldSizeButtons;
        }

        private IMultiTextPanelWidget BuildAndSetFieldShapeButtons()
        {
            this.fieldShapeButtons = this.BuildButtons(typeof(FieldShape).Name,
                FieldDetailsPanelConstants.FIELD_SHAPE_BUTTONS_COORDS);
            return this.fieldShapeButtons;
        }

        private IMultiTextPanelWidget BuildText(string enumString, Vector2 canvasGridCoords)
        {
            TextImageWidgetStruct leftTextImageWidgetStruct = new TextImageWidgetStruct(enumString,
                WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR, WidgetConstants.SECONDARY_COLOR_ID);
            TextImageWidgetStruct rightTextImageWidgetStruct = new TextImageWidgetStruct("null",
                WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR, WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR);
            Vector2 panelGridSize = new Vector2(2, 1);
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(canvasGridCoords)
                    .SetCanvasGridSize(FieldDetailsPanelConstants.TEXT_SIZE);
            return (IMultiTextPanelWidget)MultiTextPanelImpl.Builder.Get()
                .SetTextImageWidgetStruct(0, leftTextImageWidgetStruct)
                .SetTextImageWidgetStruct(1, rightTextImageWidgetStruct)
                .SetBackgroundColor(WidgetConstants.PRIMARY_COLOR_ID)
                .SetPanelGridSize(panelGridSize)
                .SetWidgetGridSpec(widgetGridSpec)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(1)
                .SetInteractable(true)
                .SetEnabled(true)
                .SetName(this.mvcType + ":" + this.GetType().Name + ":" + CanvasWidgetType.Panel + ":" + enumString + ":Texts")
                .SetParent(this)
                .Build();
        }

        private IMultiTextPanelWidget BuildButtons(string enumString, Vector2 canvasGridCoords)
        {
            TextImageWidgetStruct leftTextImageWidgetStruct = new TextImageWidgetStruct("<",
                WidgetConstants.BUTTON_INTERACTABLE_ENABLED_TEXT_COLOR, WidgetConstants.BUTTON_INTERACTABLE_ENABLED_IMAGE_COLOR);
            TextImageWidgetStruct rightTextImageWidgetStruct = new TextImageWidgetStruct(">",
                WidgetConstants.BUTTON_INTERACTABLE_ENABLED_TEXT_COLOR, WidgetConstants.BUTTON_INTERACTABLE_ENABLED_IMAGE_COLOR);
            Vector2 panelGridSize = new Vector2(2, 1);
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(canvasGridCoords)
                    .SetCanvasGridSize(FieldDetailsPanelConstants.TEXT_SIZE);
            return (IMultiTextPanelWidget)MultiTextPanelImpl.Builder.Get()
                .SetTextImageWidgetStruct(0, leftTextImageWidgetStruct)
                .SetTextImageWidgetStruct(1, rightTextImageWidgetStruct)
                .SetBackgroundColor(WidgetConstants.PRIMARY_COLOR_ID)
                .SetPanelGridSize(panelGridSize)
                .SetWidgetGridSpec(widgetGridSpec)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(1)
                .SetInteractable(true)
                .SetEnabled(true)
                .SetName(this.mvcType + ":" + this.GetType().Name + ":" + CanvasWidgetType.Panel + ":" + enumString + ":Buttons")
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
                    IPanelWidget widget = gameObject.AddComponent<FieldDetailsPanelImpl>();
                    this.ApplyPanelValues(widget);
                    return widget;
                }
            }
        }
    }
}