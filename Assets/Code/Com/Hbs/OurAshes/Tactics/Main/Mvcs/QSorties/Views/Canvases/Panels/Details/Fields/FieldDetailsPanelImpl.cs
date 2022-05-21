using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Biomes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Shapes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Constants;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Types;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Maps
{
    /// <summary>
    /// FieldDetails Panel Impl
    /// </summary>
    public class FieldDetailsPanelImpl
        : AbstractPanelWidget, IPanelWidget
    {
        private IDualTextPanelWidget fieldIDText;
        private IDualTextPanelWidget fieldSizeText;
        private IDualTextPanelWidget fieldShapeText;
        private IDualTextPanelWidget fieldBiomeText;

        public override void Process(Commons.Models.States.Inters.IMvcModelState mvcModelState)
        {
            Models.States.Inters.IMvcModelState qSortieMenuModelState = (Models.States.Inters.IMvcModelState)mvcModelState;
            IFieldDetails fieldDetails = qSortieMenuModelState.GetFieldDetails();
            this.fieldIDText.GetRightTextWidget().SetText(fieldDetails.GetFieldID());
            this.fieldSizeText.GetRightTextWidget().SetText(fieldDetails.GetFieldSize());
            this.fieldShapeText.GetRightTextWidget().SetText(fieldDetails.GetFieldShape());
            this.fieldBiomeText.GetRightTextWidget().SetText(fieldDetails.GetFieldBiome());
        }

        protected override void InitialBuild()
        {
            ISet<ICanvasWidget> panelWidgets = new HashSet<ICanvasWidget>() {
                this.BuildAndSetFieldIDText(),
                this.BuildAndSetFieldSizeText(),
                this.BuildAndSetFieldShapeText(),
                this.BuildAndSetFieldBiomeText()
            };
            this.InternalAddWidgets(panelWidgets);
        }

        private IDualTextPanelWidget BuildAndSetFieldIDText()
        {
            this.fieldIDText = this.BuildFieldDualText(typeof(FieldID).Name,
                FieldDetailsPanelConstants.TEXT_FIELD_ID_COORDS);
            return this.fieldIDText;
        }

        private IDualTextPanelWidget BuildAndSetFieldBiomeText()
        {
            this.fieldBiomeText = this.BuildFieldDualText(typeof(FieldBiome).Name,
                FieldDetailsPanelConstants.TEXT_FIELD_BIOME_COORDS);
            return this.fieldBiomeText;
        }

        private IDualTextPanelWidget BuildAndSetFieldSizeText()
        {
            this.fieldSizeText = this.BuildFieldDualText(typeof(FieldSize).Name,
                FieldDetailsPanelConstants.TEXT_FIELD_SIZE_COORDS);
            return this.fieldSizeText;
        }

        private IDualTextPanelWidget BuildAndSetFieldShapeText()
        {
            this.fieldShapeText = this.BuildFieldDualText(typeof(FieldShape).Name,
                FieldDetailsPanelConstants.TEXT_FIELD_SHAPE_COORDS);
            return this.fieldShapeText;
        }

        private IDualTextPanelWidget BuildFieldDualText(string enumString, Vector2 canvasGridCoords)
        {
            return (IDualTextPanelWidget)DualTextPanelImpl.Builder.Get()
                .SetLeftText(enumString)
                .SetLeftTextColor(WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR)
                .SetRightText("null")
                .SetRightTextColor(WidgetConstants.BUTTON_INTERACTABLE_ENABLED_TEXT_COLOR)
                .SetBackgroundColor(WidgetConstants.PRIMARY_COLOR_ID)
                .SetLeftColor(WidgetConstants.SECONDARY_COLOR_ID)
                .SetRightColor(WidgetConstants.BUTTON_INTERACTABLE_ENABLED_IMAGE_COLOR)
                .SetPanelGridSize(new Vector2(2, 1))
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(canvasGridCoords)
                    .SetCanvasGridSize(FieldDetailsPanelConstants.TEXT_SIZE))
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(1)
                .SetInteractable(true)
                .SetEnabled(true)
                .SetName(this.mvcType + ":" + RequestType.FieldDetails + ":" + CanvasWidgetType.Panel + ":" + enumString)
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