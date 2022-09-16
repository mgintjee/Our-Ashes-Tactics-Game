using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Biomes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Shapes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Structs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Utils;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Frames.Requests.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Views.Canvases.Panels.Details.Commons.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Views.Canvases.Panels.Details.Commons.Panels;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Views.Canvases.Panels.Details.Fields.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Views.Canvases.Panels.Details.Fields.PopUps;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Views.Canvases.Panels.Details.Fields
{
    /// <summary>
    /// Field Details Panel Impl
    /// </summary>
    public class FieldDetailsPanelImpl
        : AbstractPanelWidget, IPanelWidget
    {
        private IPopUpPanelWidget popUpWidget;
        private IButtonWidget idButton;
        private IButtonWidget shapeButton;
        private IButtonWidget biomeButton;
        private IButtonWidget sizeButton;
        private IFieldPanelWidget fieldPanelWidget;
        private IFieldDetails fieldDetails;

        public override void Process(IMvcModelState mvcModelState)
        {
            IMvcModelState qSortieMenuModelState = (IMvcModelState)mvcModelState;
            this.fieldDetails = qSortieMenuModelState.GetFieldDetails();
            this.UpdateButtons();
            this.fieldPanelWidget.Process(mvcModelState);
            qSortieMenuModelState.GetPrevMvcRequest().IfPresent(request =>
            {
                this.ProcessPrevRequest((IQSortieMenuMvcRequest)request);
            });
        }

        protected override void InitialBuild()
        {
            this.InternalAddWidgets(this.BuildTexts());
            this.InternalAddWidgets(this.BuildButtons());
            this.InternalAddWidget(this.BuildAndSetFieldPanelWidget());
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

                case RequestType.FieldIDSelect:
                case RequestType.FieldSizeSelect:
                case RequestType.FieldShapeSelect:
                case RequestType.FieldBiomeSelect:
                case RequestType.PopUpDisable:
                    CanvasWidgetUtils.EnableWidget(popUpWidget, false);
                    break;
            }
        }

        private IList<ICanvasWidget> BuildTexts()
        {
            return new List<ICanvasWidget>
            {
                this.BuildIDText(),
                this.BuildSizeText(),
                this.BuildShapeText(),
                this.BuildBiomeText()
            };
        }

        private IList<ICanvasWidget> BuildButtons()
        {
            return new List<ICanvasWidget>
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

        private IButtonWidget BuildAndSetIDButton()
        {
            IWidgetGridSpec widgetGridSpec = IDsConstants.BUTTON_SPEC;
            string widgetName = typeof(FieldID).Name + "PopUp:Button";
            idButton = this.BuildButton(widgetName, widgetGridSpec, "null");
            return idButton;
        }

        private IButtonWidget BuildAndSetSizeButton()
        {
            IWidgetGridSpec widgetGridSpec = SizesConstants.BUTTON_SPEC;
            string widgetName = typeof(FieldSize).Name + "PopUp:Button";
            sizeButton = this.BuildButton(widgetName, widgetGridSpec, "null");
            return sizeButton;
        }

        private IButtonWidget BuildAndSetShapeButton()
        {
            IWidgetGridSpec widgetGridSpec = ShapesConstants.BUTTON_SPEC;
            string widgetName = typeof(FieldShape).Name + "PopUp:Button";
            shapeButton = this.BuildButton(widgetName, widgetGridSpec, "null");
            return shapeButton;
        }

        private IButtonWidget BuildAndSetBiomeButton()
        {
            IWidgetGridSpec widgetGridSpec = BiomesConstants.BUTTON_SPEC;
            string widgetName = typeof(FieldBiome).Name + "PopUp:Button";
            biomeButton = this.BuildButton(widgetName, widgetGridSpec, "null");
            return biomeButton;
        }

        private IMultiTextPanelWidget BuildBiomeText()
        {
            IWidgetGridSpec widgetGridSpec = BiomesConstants.TEXT_SPEC;
            IList<TextImageWidgetStruct> textImageWidgetStructs = BiomesConstants.TEXT_TIWS;
            string widgetName = typeof(FieldBiome).Name + ":Text";
            return this.BuildMultiText(widgetName, widgetGridSpec, textImageWidgetStructs, false);
        }

        private IMultiTextPanelWidget BuildIDText()
        {
            IWidgetGridSpec widgetGridSpec = IDsConstants.TEXT_SPEC;
            IList<TextImageWidgetStruct> textImageWidgetStructs = IDsConstants.TEXT_TIWS;
            string widgetName = typeof(FieldID).Name + ":Text";
            return this.BuildMultiText(widgetName, widgetGridSpec, textImageWidgetStructs, false);
        }

        private IMultiTextPanelWidget BuildSizeText()
        {
            IWidgetGridSpec widgetGridSpec = SizesConstants.TEXT_SPEC;
            IList<TextImageWidgetStruct> textImageWidgetStructs = SizesConstants.TEXT_TIWS;
            string widgetName = typeof(FieldSize).Name + ":Text";
            return this.BuildMultiText(widgetName, widgetGridSpec, textImageWidgetStructs, false);
        }

        private IMultiTextPanelWidget BuildShapeText()
        {
            IWidgetGridSpec widgetGridSpec = ShapesConstants.TEXT_SPEC;
            IList<TextImageWidgetStruct> textImageWidgetStructs = ShapesConstants.TEXT_TIWS;
            string widgetName = typeof(FieldShape).Name + ":Text";
            return this.BuildMultiText(widgetName, widgetGridSpec, textImageWidgetStructs, false);
        }

        private IPanelWidget BuildIDPopUp()
        {
            IList<FieldID> ids = EnumUtils.GetEnumListWithoutFirst<FieldID>();
            return IDPopUpImpl.Builder.Get()
                .SetFieldDetails(this.fieldDetails)
                .SetPanelGridSize(new Vector2(1, ids.Count))
                .SetWidgetGridSpec(WidgetConstants.POP_UP_WIDGET_GRID_SPEC)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(99)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetName(RequestType.FieldIDPopUp.ToString())
                .SetParent(this)
                .Build();
        }

        private IPanelWidget BuildSizePopUp()
        {
            IList<FieldSize> sizes = EnumUtils.GetEnumListWithoutFirst<FieldSize>();
            return SizePopUpImpl.Builder.Get()
                .SetFieldDetails(this.fieldDetails)
                .SetPanelGridSize(new Vector2(1, sizes.Count))
                .SetWidgetGridSpec(WidgetConstants.POP_UP_WIDGET_GRID_SPEC)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(99)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetName(RequestType.FieldSizePopUp.ToString())
                .SetParent(this)
                .Build();
        }

        private IPanelWidget BuildBiomePopUp()
        {
            IList<FieldBiome> biomes = EnumUtils.GetEnumListWithoutFirst<FieldBiome>();
            return BiomePopUpImpl.Builder.Get()
                .SetFieldDetails(this.fieldDetails)
                .SetPanelGridSize(new Vector2(1, biomes.Count))
                .SetWidgetGridSpec(WidgetConstants.POP_UP_WIDGET_GRID_SPEC)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(99)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetName(RequestType.FieldBiomePopUp.ToString())
                .SetParent(this)
                .Build();
        }

        private IPanelWidget BuildShapePopUp()
        {
            IList<FieldShape> shapes = EnumUtils.GetEnumListWithoutFirst<FieldShape>();
            return ShapePopUpImpl.Builder.Get()
                .SetFieldDetails(this.fieldDetails)
                .SetPanelGridSize(new Vector2(1, shapes.Count))
                .SetWidgetGridSpec(WidgetConstants.POP_UP_WIDGET_GRID_SPEC)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(99)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetName(RequestType.FieldShapePopUp.ToString())
                .SetParent(this)
                .Build();
        }

        private IFieldPanelWidget BuildAndSetFieldPanelWidget()
        {
            this.fieldPanelWidget = (IFieldPanelWidget)MiniFieldPanelImpl.Builder.Get()
                .SetPanelGridSize(Vector2.One)
                .SetWidgetGridSpec(MiniFieldTileConstants.MINI_FIELD_SPEC)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(1)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetName("MiniFieldPanel")
                .SetParent(this)
                .Build();
            return this.fieldPanelWidget;
        }

        public class Builder
        {
            public interface IInternalBuilder
                : PanelWidgetBuilders.IPanelWidgetBuilder
            {
                IInternalBuilder SetPopUpWidget(IPopUpPanelWidget widget);
            }

            public static IInternalBuilder Get()
            {
                return new InternalBuilder();
            }

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