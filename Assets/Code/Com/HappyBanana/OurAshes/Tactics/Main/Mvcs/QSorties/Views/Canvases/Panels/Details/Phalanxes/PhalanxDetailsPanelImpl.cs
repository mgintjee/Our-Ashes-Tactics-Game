using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Icons.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Structs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Phalanxes.Constants;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Phalanxes
{
    /// <summary>
    /// Panel Widget Impl
    /// </summary>
    public class PhalanxDetailsPanelImpl
        : AbstractPanelWidget, IPanelWidget
    {
        private IPopUpPanelWidget popUpWidget;
        private IButtonPanelWidget idButton;
        private IButtonPanelWidget iconButton;
        private IButtonPanelWidget unitAddButton;
        private IButtonPanelWidget unitMinusButton;
        private IMultiTextPanelWidget unitIDList;
        private IMultiTextPanelWidget powerText;

        public override void Process(IMvcModelState modelState)
        {
            Models.States.Inters.IMvcModelState mvcModelState = (Models.States.Inters.IMvcModelState)modelState;
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
                this.BuildIconText(),
                this.BuildPhalanxText(),
                this.BuildPhalanxListText(),
                this.BuildPowersText()
            };
        }

        private ISet<ICanvasWidget> BuildButtons()
        {
            return new HashSet<ICanvasWidget>() {
                this.BuildAndSetIDButton(),
                this.BuildAndSetIconButton(),
                this.BuildAndSetUnitMinusButton(),
                this.BuildAndSetUnitAddButton()
            };
        }

        private IButtonPanelWidget BuildAndSetIDButton()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.IDs.BUTTON_COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            string buttonType = typeof(PhalanxID).Name;
            string textName = this.mvcType + ":" + buttonType + "PopUp:Button";
            string buttonText = PhalanxID.None.ToString();
            idButton = this.BuildButton(textName, widgetGridSpec, buttonText, buttonType);
            return idButton;
        }

        private IButtonPanelWidget BuildAndSetIconButton()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.Icons.BUTTON_COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            string buttonType = typeof(IconID).Name;
            string textName = this.mvcType + ":" + buttonType + "PopUp:Button";
            string buttonText = IconID.None.ToString();
            iconButton = this.BuildButton(textName, widgetGridSpec, buttonText, buttonType);
            return iconButton;
        }

        private IButtonPanelWidget BuildAndSetUnitMinusButton()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.UnitHeader.MINUS_BUTTON_COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            string buttonType = typeof(UnitID).Name + ":Minus";
            string textName = this.mvcType + ":" + buttonType + "PopUp:Button";
            string buttonText = "-";
            unitMinusButton = this.BuildButton(textName, widgetGridSpec, buttonText, buttonType);
            return unitMinusButton;
        }

        private IButtonPanelWidget BuildAndSetUnitAddButton()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.UnitHeader.ADD_BUTTON_COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            string buttonType = typeof(UnitID).Name + ":Add";
            string textName = this.mvcType + ":" + buttonType + "PopUp:Button";
            string buttonText = "+";
            unitAddButton = this.BuildButton(textName, widgetGridSpec, buttonText, buttonType);
            return unitAddButton;
        }

        private IMultiTextPanelWidget BuildIconText()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.Icons.TEXT_COORDS)
                    .SetCanvasGridSize(PanelConstants.INFO_SIZE);
            IList<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>
            {
                new TextImageWidgetStruct("Icon:",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR)
            };
            string textName = "Icon:Text";
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
            string textName = typeof(PhalanxID).Name + ":Text";
            return this.BuildMultiText(textName, widgetGridSpec, textImageWidgetStructs, false);
        }

        private IMultiTextPanelWidget BuildPhalanxText()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.UnitHeader.TEXT_COORDS)
                    .SetCanvasGridSize(PanelConstants.UnitHeader.TEXT_SIZE);
            IList<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>
            {
                new TextImageWidgetStruct("Units:",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR)
            };
            string textName = typeof(UnitID).Name + ":Text";
            return this.BuildMultiText(textName, widgetGridSpec, textImageWidgetStructs, false);
        }

        private IMultiTextPanelWidget BuildPhalanxListText()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.UnitList.COORDS)
                    .SetCanvasGridSize(PanelConstants.UnitList.SIZE);
            IList<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>
            {
                new TextImageWidgetStruct("[null]",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR)
            };
            string textName = typeof(UnitID).Name + "List:Text";
            return this.BuildMultiText(textName, widgetGridSpec, textImageWidgetStructs, false);
        }

        private IMultiTextPanelWidget BuildPowersText()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.Powers.COORDS)
                    .SetCanvasGridSize(PanelConstants.Powers.SIZE);
            IList<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>
            {
                new TextImageWidgetStruct("Phalanx Power:",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR),
                new TextImageWidgetStruct("0",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR)
            };
            string textName = typeof(PhalanxID).Name + ":Power:Text";
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
                    PhalanxDetailsPanelImpl widget = gameObject.AddComponent<PhalanxDetailsPanelImpl>();
                    widget.popUpWidget = popUpWidget;
                    this.ApplyPanelValues(widget);
                    return widget;
                }
            }
        }
    }
}