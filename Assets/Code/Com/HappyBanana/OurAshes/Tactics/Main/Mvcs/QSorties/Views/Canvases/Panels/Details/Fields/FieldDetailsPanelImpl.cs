using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Enums;
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
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Utils;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Fields.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Fields.PopUps;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Fields
{
    /// <summary>
    /// Field Details Panel Impl
    /// </summary>
    public class FieldDetailsPanelImpl
        : AbstractPanelWidget, IPanelWidget
    {
        private IPopUpPanelWidget popUpWidget;
        private IButtonPanelWidget idButton;
        private IButtonPanelWidget shapeButton;
        private IButtonPanelWidget biomeButton;
        private IButtonPanelWidget sizeButton;
        private IFieldDetails fieldDetails;

        public override void Process(Commons.Models.States.Inters.IMvcModelState mvcModelState)
        {
            Models.States.Inters.IMvcModelState qSortieMenuModelState = (Models.States.Inters.IMvcModelState)mvcModelState;
            this.fieldDetails = qSortieMenuModelState.GetFieldDetails();
            this.UpdateButtons();
            qSortieMenuModelState.GetPrevMvcRequest().IfPresent(request =>
            {
                this.ProcessPrevRequest((IQSortieMenuMvcRequest)request);
            });
        }

        protected override void InitialBuild()
        {
            this.InternalAddWidgets(this.BuildTexts());
            this.InternalAddWidgets(this.BuildButtons());
        }

        private void ProcessPrevRequest(IQSortieMenuMvcRequest mvcRequest)
        {
            RequestType requestType = mvcRequest.GetRequestType();
            switch (requestType)
            {
                case RequestType.FieldIDPopUp:
                    this.popUpWidget.UpdatePopupEntry(this.BuildIDPopUp());
                    break;

                case RequestType.FieldSizePopUp:
                    this.popUpWidget.UpdatePopupEntry(this.BuildSizePopUp());
                    break;

                case RequestType.FieldShapePopUp:
                    this.popUpWidget.UpdatePopupEntry(this.BuildShapePopUp());
                    break;

                case RequestType.FieldBiomePopUp:
                    this.popUpWidget.UpdatePopupEntry(this.BuildBiomePopUp());
                    break;

                case RequestType.FieldIDMod:
                case RequestType.FieldSizeMod:
                case RequestType.FieldShapeMod:
                case RequestType.FieldBiomeMod:
                case RequestType.PopUpDisable:
                    this.popUpWidget.SetEnabled(false);
                    break;

                default:
                    logger.Debug("Unsupported {}", requestType);
                    break;
            }
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

        private void UpdateButtons()
        {
            bool isInteractable = this.fieldDetails.GetFieldID() == FieldID.Random;
            CanvasWidgetUtils.SetButtonInteractable(this.biomeButton, isInteractable);
            CanvasWidgetUtils.SetButtonInteractable(this.shapeButton, isInteractable);
            CanvasWidgetUtils.SetButtonInteractable(this.sizeButton, isInteractable);
            this.idButton.GetTextWidget().SetText(this.fieldDetails.GetFieldID().ToString());
            this.biomeButton.GetTextWidget().SetText(this.fieldDetails.GetFieldBiome().ToString());
            this.sizeButton.GetTextWidget().SetText(this.fieldDetails.GetFieldSize().ToString());
            this.shapeButton.GetTextWidget().SetText(this.fieldDetails.GetFieldShape().ToString());
        }

        private IButtonPanelWidget BuildAndSetIDButton()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.IDs.BUTTON_COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            string buttonType = typeof(FieldID).Name;
            string widgetName = buttonType + "PopUp:Button";
            string buttonText = FieldID.None.ToString();
            idButton = this.BuildButton(widgetName, widgetGridSpec, buttonText, buttonType);
            return idButton;
        }

        private IButtonPanelWidget BuildAndSetSizeButton()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.Sizes.BUTTON_COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            string buttonType = typeof(FieldSize).Name;
            string widgetName = buttonType + "PopUp:Button";
            string buttonText = FieldSize.None.ToString();
            sizeButton = this.BuildButton(widgetName, widgetGridSpec, buttonText, buttonType);
            return sizeButton;
        }

        private IButtonPanelWidget BuildAndSetShapeButton()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.Shapes.BUTTON_COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            string buttonType = typeof(FieldShape).Name;
            string widgetName = buttonType + "PopUp:Button";
            string buttonText = FieldShape.None.ToString();
            shapeButton = this.BuildButton(widgetName, widgetGridSpec, buttonText, buttonType);
            return shapeButton;
        }

        private IButtonPanelWidget BuildAndSetBiomeButton()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.Biomes.BUTTON_COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            string buttonType = typeof(FieldBiome).Name;
            string widgetName = buttonType + "PopUp:Button";
            string buttonText = FieldBiome.None.ToString();
            biomeButton = this.BuildButton(widgetName, widgetGridSpec, buttonText, buttonType);
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
            string widgetName = typeof(FieldBiome).Name + ":Text";
            return this.BuildMultiText(widgetName, widgetGridSpec, textImageWidgetStructs, false);
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
            string widgetName = typeof(FieldID).Name + ":Text";
            return this.BuildMultiText(widgetName, widgetGridSpec, textImageWidgetStructs, false);
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
            string widgetName = typeof(FieldSize).Name + ":Text";
            return this.BuildMultiText(widgetName, widgetGridSpec, textImageWidgetStructs, false);
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
            string widgetName = typeof(FieldShape).Name + ":Text";
            return this.BuildMultiText(widgetName, widgetGridSpec, textImageWidgetStructs, false);
        }

        private IPanelWidget BuildIDPopUp()
        {
            string widgetName = typeof(FieldID).Name + ":PopUp";
            IList<FieldID> vals = EnumUtils.GetEnumListWithoutFirst<FieldID>();
            return IDPopUpImpl.Builder.Get()
                .SetFieldDetails(this.fieldDetails)
                .SetPanelGridSize(new Vector2(1, vals.Count))
                .SetWidgetGridSpec(WidgetConstants.POP_UP_WIDGET_GRID_SPEC)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(99)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetName(widgetName)
                .SetParent(this)
                .Build();
        }
        private IPanelWidget BuildSizePopUp()
        {
            string widgetName = typeof(FieldSize).Name + ":PopUp";
            IList<FieldSize> vals = EnumUtils.GetEnumListWithoutFirst<FieldSize>();
            return SizePopUpImpl.Builder.Get()
                .SetFieldDetails(this.fieldDetails)
                .SetPanelGridSize(new Vector2(1, vals.Count))
                .SetWidgetGridSpec(WidgetConstants.POP_UP_WIDGET_GRID_SPEC)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(99)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetName(widgetName)
                .SetParent(this)
                .Build();
        }
        private IPanelWidget BuildBiomePopUp()
        {
            string widgetName = typeof(FieldBiome).Name + ":PopUp";
            IList<FieldBiome> vals = EnumUtils.GetEnumListWithoutFirst<FieldBiome>();
            return BiomePopUpImpl.Builder.Get()
                .SetFieldDetails(this.fieldDetails)
                .SetPanelGridSize(new Vector2(1, vals.Count))
                .SetWidgetGridSpec(WidgetConstants.POP_UP_WIDGET_GRID_SPEC)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(99)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetName(widgetName)
                .SetParent(this)
                .Build();
        }
        private IPanelWidget BuildShapePopUp()
        {
            string widgetName = typeof(FieldShape).Name + ":PopUp";
            IList<FieldShape> vals = EnumUtils.GetEnumListWithoutFirst<FieldShape>();
            return ShapePopUpImpl.Builder.Get()
                .SetFieldDetails(this.fieldDetails)
                .SetPanelGridSize(new Vector2(1, vals.Count))
                .SetWidgetGridSpec(WidgetConstants.POP_UP_WIDGET_GRID_SPEC)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(99)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetName(widgetName)
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
                IInternalBuilder SetPopUpWidget(IPopUpPanelWidget widget);
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
                private IPopUpPanelWidget popUpWidget;

                IInternalBuilder IInternalBuilder.SetPopUpWidget(IPopUpPanelWidget widget)
                {
                    this.popUpWidget = widget;
                    return this;
                }

                protected override IPanelWidget BuildScript(UnityEngine.GameObject gameObject)
                {
                    FieldDetailsPanelImpl widget = gameObject.AddComponent<FieldDetailsPanelImpl>();
                    widget.popUpWidget = this.popUpWidget;
                    this.ApplyPanelValues(widget);
                    return widget;
                }
            }
        }
    }
}