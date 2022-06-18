using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Biomes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Shapes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Structs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Fields.Constants;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Fields
{
    /// <summary>
    /// Field Details Panel Impl
    /// </summary>
    public class FieldDetailsPanelImpl
        : AbstractPanelWidget, IPanelWidget
    {
        private IButtonPanelWidget idButton;
        private IButtonPanelWidget shapeButton;
        private IButtonPanelWidget biomeButton;
        private IButtonPanelWidget sizeButton;

        public override void Process(Commons.Models.States.Inters.IMvcModelState mvcModelState)
        {
            Models.States.Inters.IMvcModelState qSortieMenuModelState = (Models.States.Inters.IMvcModelState)mvcModelState;
            IFieldDetails fieldDetails = qSortieMenuModelState.GetFieldDetails();
        }

        protected override void InitialBuild()
        {
            this.InternalAddWidgets(this.BuildTexts());
            this.InternalAddWidgets(this.BuildButtons());
        }

        private ISet<ICanvasWidget> BuildTexts()
        {
            return new HashSet<ICanvasWidget>
            {
                this.BuildIDText(),
                this.BuildSizeText(),
                this.BuildShapeText(),
                this.BuildBiomeText()
            }; ;
        }

        private ISet<ICanvasWidget> BuildButtons()
        {
            return new HashSet<ICanvasWidget>
            {
                this.BuildAndSetIDButton(),
                this.BuildAndSetShapeButton(),
                this.BuildAndSetBiomeButton(),
                this.BuildAndSetSizeButton()
            };
        }

        private IButtonPanelWidget BuildAndSetIDButton()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.IDs.BUTTON_COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            string buttonType = typeof(FieldID).Name;
            string textName = this.mvcType + ":" + buttonType + ":Button";
            string buttonText = FieldID.None.ToString();
            idButton = this.BuildButton(textName, widgetGridSpec, buttonText, buttonType);
            return idButton;
        }

        private IButtonPanelWidget BuildAndSetSizeButton()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.Sizes.BUTTON_COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            string buttonType = typeof(FieldSize).Name;
            string textName = this.mvcType + ":" + buttonType + ":Button";
            string buttonText = FieldSize.None.ToString();
            sizeButton = this.BuildButton(textName, widgetGridSpec, buttonText, buttonType);
            return sizeButton;
        }

        private IButtonPanelWidget BuildAndSetShapeButton()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.Shapes.BUTTON_COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            string buttonType = typeof(FieldShape).Name;
            string textName = this.mvcType + ":" + buttonType + ":Button";
            string buttonText = FieldShape.None.ToString();
            shapeButton = this.BuildButton(textName, widgetGridSpec, buttonText, buttonType);
            return shapeButton;
        }

        private IButtonPanelWidget BuildAndSetBiomeButton()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.Biomes.BUTTON_COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            string buttonType = typeof(FieldBiome).Name;
            string textName = this.mvcType + ":" + buttonType + ":Button";
            string buttonText = FieldBiome.None.ToString();
            biomeButton = this.BuildButton(textName, widgetGridSpec, buttonText, buttonType);
            return biomeButton;
        }

        private IMultiTextPanelWidget BuildBiomeText()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.Biomes.TEXT_COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            IList<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>
            {
                new TextImageWidgetStruct("Biome:",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR)
            };
            string textName = typeof(FieldBiome).Name + ":Text";
            return this.BuildMultiText(textName, widgetGridSpec, textImageWidgetStructs, false);
        }

        private IMultiTextPanelWidget BuildIDText()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.IDs.TEXT_COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            IList<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>
            {
                new TextImageWidgetStruct("ID:",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR)
            };
            string textName = typeof(FieldID).Name + ":Text";
            return this.BuildMultiText(textName, widgetGridSpec, textImageWidgetStructs, false);
        }

        private IMultiTextPanelWidget BuildSizeText()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.Sizes.TEXT_COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            IList<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>
            {
                new TextImageWidgetStruct("Size:",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR)
            };
            string textName = typeof(FieldSize).Name + ":Text";
            return this.BuildMultiText(textName, widgetGridSpec, textImageWidgetStructs, false);
        }

        private IMultiTextPanelWidget BuildShapeText()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.Shapes.TEXT_COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            IList<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>
            {
                new TextImageWidgetStruct("Shape:",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR)
            };
            string textName = typeof(FieldShape).Name + ":Text";
            return this.BuildMultiText(textName, widgetGridSpec, textImageWidgetStructs, false);
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