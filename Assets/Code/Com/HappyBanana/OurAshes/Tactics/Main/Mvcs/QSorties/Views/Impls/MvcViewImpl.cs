using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Factions.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Biomes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Shapes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Impls;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Impls
{
    /// <summary>
    /// QSortieMenu View Impl
    /// </summary>
    public class MvcViewImpl
        : AbstractMvcView, IMvcView
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public MvcViewImpl(IMvcFrameConstruction mvcFrameConstruction)
            : base(mvcFrameConstruction)
        {
        }

        /// <inheritdoc/>
        protected override void InternalProcess(IMvcControlInput mvcControlInput)
        {
            logger.Info("Processing {}...", mvcControlInput);
            this.mvcViewCanvas.GetWidget(mvcControlInput).IfPresent(widget =>
            {
                RequestType requestType = EnumUtils.DetermineEnumFrom<RequestType>(widget.GetName());
                logger.Info("Widget to process: Name={}, Found={}",
                    widget.GetName(), StringUtils.Format(requestType));
                if (requestType != RequestType.None)
                {
                    IQSortieMenuMvcRequest request = this.BuildRequestFrom(requestType, widget.GetName());
                    logger.Info("Built {}", request);
                    ((DefaultMvcViewStateImpl)this.mvcViewState)
                        .SetMvcModelRequest(request);
                }
            });
        }

        /// <inheritdoc/>
        protected override IMvcViewCanvas BuildInitialMvcViewCanvas()
        {
            return MvcViewCanvasImpl.Builder.Get()
                .SetMvcType(MvcType.QSortieMenu)
                .SetGridSize(CanvasGridConstants.GetMvcTypeGridSize(MvcType.QSortieMenu))
                .SetName(typeof(MvcViewCanvasImpl).Name)
                .SetParent(this.mvcFrameConstruction.GetUnityScript())
                .Build();
        }

        private IQSortieMenuMvcRequest BuildRequestFrom(RequestType requestType, string widgetName)
        {
            IQSortieMenuMvcRequest request;
            switch (requestType)
            {
                case RequestType.PopUpDisable:
                case RequestType.UnitDetails:
                case RequestType.FactionDetails:
                case RequestType.FieldDetails:
                case RequestType.PhalanxDetails:
                case RequestType.SortieDetails:
                case RequestType.FactionRandomize:
                case RequestType.FieldRandomize:
                case RequestType.SortieRandomize:
                case RequestType.FieldIDPopUp:
                case RequestType.FieldBiomePopUp:
                case RequestType.FieldSizePopUp:
                case RequestType.FieldShapePopUp:
                    request = new DefaultRequestImpl();
                    break;

                case RequestType.FieldIDMod:
                    request = this.BuildFieldIDModRequestFrom(widgetName);
                    break;

                case RequestType.FieldSizeMod:
                    request = this.BuildFieldSizeModRequestFrom(widgetName);
                    break;

                case RequestType.FieldBiomeMod:
                    request = this.BuildFieldBiomeModRequestFrom(widgetName);
                    break;

                case RequestType.FieldShapeMod:
                    request = this.BuildFieldShapeModRequestFrom(widgetName);
                    break;

                case RequestType.FactionIDMod:
                    request = this.BuildFactionIDModRequestFrom(widgetName);
                    break;

                case RequestType.UnitMod:
                case RequestType.PhalanxMod:
                case RequestType.FactionMod:
                case RequestType.None:
                default:
                    logger.Warn("Unable to build {}. {} is not currently supported.",
                        typeof(IQSortieMenuMvcRequest).Name, requestType);
                    request = new DefaultRequestImpl();
                    break;
            }
            ((DefaultRequestImpl)request)
                .SetRequestType(requestType);
            return request;
        }

        private IQSortieMenuMvcRequest BuildFactionIDModRequestFrom(string widgetName)
        {
            FactionID factionID = EnumUtils.DetermineEnumFrom<FactionID>(widgetName);
            return new FactionIDModRequestImpl()
                .SetFactionID(factionID);
        }

        private IQSortieMenuMvcRequest BuildFieldIDModRequestFrom(string widgetName)
        {
            FieldID fieldID = EnumUtils.DetermineEnumFrom<FieldID>(widgetName);
            return new FieldIDModRequestImpl()
                .SetFieldID(fieldID);
        }

        private IQSortieMenuMvcRequest BuildFieldBiomeModRequestFrom(string widgetName)
        {
            FieldBiome biome = EnumUtils.DetermineEnumFrom<FieldBiome>(widgetName);
            return new FieldBiomeModRequestImpl()
                .SetFieldBiome(biome);
        }

        private IQSortieMenuMvcRequest BuildFieldSizeModRequestFrom(string widgetName)
        {
            FieldSize size = EnumUtils.DetermineEnumFrom<FieldSize>(widgetName);
            return new FieldSizeModRequestImpl()
                .SetFieldSize(size);
        }

        private IQSortieMenuMvcRequest BuildFieldShapeModRequestFrom(string widgetName)
        {
            FieldShape shape = EnumUtils.DetermineEnumFrom<FieldShape>(widgetName);
            return new FieldShapeModRequestImpl()
                .SetFieldShape(shape);
        }
    }
}