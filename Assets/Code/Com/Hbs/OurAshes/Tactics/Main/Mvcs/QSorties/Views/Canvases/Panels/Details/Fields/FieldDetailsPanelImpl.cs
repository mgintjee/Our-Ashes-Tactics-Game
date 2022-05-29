using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Biomes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Shapes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Fields.Constants;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Fields
{
    /// <summary>
    /// Field Details Panel Impl
    /// </summary>
    public class FieldDetailsPanelImpl
        : AbstractPanelWidget, IPanelWidget
    {
        private static readonly IList<FieldID> ids = EnumUtils.GetEnumListWithoutFirst<FieldID>();
        private static readonly IList<FieldBiome> biomes = EnumUtils.GetEnumListWithoutFirst<FieldBiome>();
        private static readonly IList<FieldSize> sizes = EnumUtils.GetEnumListWithoutFirst<FieldSize>();
        private static readonly IList<FieldShape> shapes = EnumUtils.GetEnumListWithoutFirst<FieldShape>();
        private static readonly IList<string> idStrings = EnumUtils.GetEnumsAsStrings(ids);
        private static readonly IList<string> biomeStrings = EnumUtils.GetEnumsAsStrings(biomes);
        private static readonly IList<string> sizeStrings = EnumUtils.GetEnumsAsStrings(sizes);
        private static readonly IList<string> shapeStrings = EnumUtils.GetEnumsAsStrings(shapes);
        private ICarouselPanelWidget idCarouselWidget;
        private ICarouselPanelWidget biomeCarouselWidget;
        private ICarouselPanelWidget sizeCarouselWidget;
        private ICarouselPanelWidget shapeCarouselWidget;
        private int biomeIndex = 0;
        private int sizeIndex = 0;
        private int idIndex = 0;
        private int shapeIndex = 0;

        public override void Process(Commons.Models.States.Inters.IMvcModelState mvcModelState)
        {
            Models.States.Inters.IMvcModelState qSortieMenuModelState = (Models.States.Inters.IMvcModelState)mvcModelState;
            IFieldDetails fieldDetails = qSortieMenuModelState.GetFieldDetails();
            this.idCarouselWidget.UpdateSpinnerText(idIndex, idStrings);
            this.biomeCarouselWidget.UpdateSpinnerText(biomeIndex, biomeStrings);
            this.sizeCarouselWidget.UpdateSpinnerText(sizeIndex, sizeStrings);
            this.shapeCarouselWidget.UpdateSpinnerText(shapeIndex, shapeStrings);
        }

        protected override void InitialBuild()
        {
            ISet<ICanvasWidget> panelWidgets = new HashSet<ICanvasWidget>() {
                this.BuildAndSetIDCarousel(),
                this.BuildAndSetBiomeCarousel(),
                this.BuildAndSetSizeCarousel(),
                this.BuildAndSetShapeCarousel(),
            };
            this.InternalAddWidgets(panelWidgets);
        }

        private ICarouselPanelWidget BuildAndSetIDCarousel()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.FieldID.COORDS)
                    .SetCanvasGridSize(PanelConstants.SIZE);
            string textName = typeof(FieldID).Name;
            this.idCarouselWidget = this.BuildCarousel(textName, widgetGridSpec);
            return this.idCarouselWidget;
        }

        private ICarouselPanelWidget BuildAndSetBiomeCarousel()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.FieldBiome.COORDS)
                    .SetCanvasGridSize(PanelConstants.SIZE);
            string textName = typeof(FieldBiome).Name;
            this.biomeCarouselWidget = this.BuildCarousel(textName, widgetGridSpec);
            return this.biomeCarouselWidget;
        }

        private ICarouselPanelWidget BuildAndSetSizeCarousel()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.FieldSize.COORDS)
                    .SetCanvasGridSize(PanelConstants.SIZE);
            string textName = typeof(FieldSize).Name;
            this.sizeCarouselWidget = this.BuildCarousel(textName, widgetGridSpec);
            return this.sizeCarouselWidget;
        }

        private ICarouselPanelWidget BuildAndSetShapeCarousel()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.FieldShape.COORDS)
                    .SetCanvasGridSize(PanelConstants.SIZE);
            string textName = typeof(FieldShape).Name;
            this.shapeCarouselWidget = this.BuildCarousel(textName, widgetGridSpec);
            return this.shapeCarouselWidget;
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