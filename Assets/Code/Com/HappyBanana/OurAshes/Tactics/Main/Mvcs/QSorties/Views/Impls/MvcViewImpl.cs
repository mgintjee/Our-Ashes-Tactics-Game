using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
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
                logger.Info("Widget to process: Name={}, Found RequestType={}",
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
                case RequestType.FieldIDSelect:
                    request = this.BuildFieldIDModRequestFrom(widgetName);
                    break;

                case RequestType.FieldSizeSelect:
                    request = this.BuildFieldSizeModRequestFrom(widgetName);
                    break;

                case RequestType.FieldBiomeSelect:
                    request = this.BuildFieldBiomeModRequestFrom(widgetName);
                    break;

                case RequestType.FieldShapeSelect:
                    request = this.BuildFieldShapeModRequestFrom(widgetName);
                    break;

                case RequestType.FactionIDSelect:
                    request = this.BuildFactionIDSelectRequestFrom(widgetName);
                    break;

                case RequestType.PhalanxIDMinusMod:
                case RequestType.PhalanxIDAddMod:
                    request = this.BuildPhalanxIDModRequestFrom(requestType == RequestType.PhalanxIDAddMod, widgetName);
                    break;

                case RequestType.PhalanxIDSelect:
                    request = this.BuildPhalanxIDSelectRequestFrom(widgetName);
                    break;

                case RequestType.UnitIDMinusMod:
                case RequestType.UnitIDAddMod:
                    request = this.BuildUnitIDModRequestFrom(requestType == RequestType.UnitIDAddMod, widgetName);
                    break;

                default:
                    request = new DefaultRequestImpl();
                    break;
            }
            ((DefaultRequestImpl)request)
                .SetRequestType(requestType);
            return request;
        }

        private IQSortieMenuMvcRequest BuildFactionIDSelectRequestFrom(string widgetName)
        {
            FactionID id = EnumUtils.DetermineEnumFrom<FactionID>(widgetName);
            return new FactionIDSelectRequestImpl()
                .SetFactionID(id);
        }

        private IQSortieMenuMvcRequest BuildPhalanxIDSelectRequestFrom(string widgetName)
        {
            PhalanxID id = EnumUtils.DetermineEnumFrom<PhalanxID>(widgetName);
            return new PhalanxIDSelectRequestImpl()
                .SetPhalanxID(id);
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

        private IQSortieMenuMvcRequest BuildPhalanxIDModRequestFrom(bool isAdd, string widgetName)
        {
            FactionID factionID = EnumUtils.DetermineEnumFrom<FactionID>(widgetName);
            PhalanxID phalanxID = EnumUtils.DetermineEnumFrom<PhalanxID>(widgetName);
            return new PhalanxIDModRequestImpl()
                .SetFactionID(factionID)
                .SetPhalanxID(phalanxID)
                .SetIsAdd(isAdd);
        }

        private IQSortieMenuMvcRequest BuildUnitIDModRequestFrom(bool isAdd, string widgetName)
        {
            PhalanxID phalanxID = EnumUtils.DetermineEnumFrom<PhalanxID>(widgetName);
            UnitID unitID = EnumUtils.DetermineEnumFrom<UnitID>(widgetName);
            return new UnitIDModRequestImpl()
                .SetUnitID(unitID)
                .SetPhalanxID(phalanxID)
                .SetIsAdd(isAdd);
        }
    }
}