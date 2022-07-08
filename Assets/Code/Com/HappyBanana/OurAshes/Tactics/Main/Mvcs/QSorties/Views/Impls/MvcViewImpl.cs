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
using System;

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
                    request = BuildEnumSelectRequestFrom<FieldID>(widgetName, requestType);
                    break;

                case RequestType.FieldSizeSelect:
                    request = BuildEnumSelectRequestFrom<FieldSize>(widgetName, requestType);
                    break;

                case RequestType.FieldBiomeSelect:
                    request = BuildEnumSelectRequestFrom<FieldBiome>(widgetName, requestType);
                    break;

                case RequestType.FieldShapeSelect:
                    request = BuildEnumSelectRequestFrom<FieldShape>(widgetName, requestType);
                    break;

                case RequestType.FactionIDSelect:
                    request = BuildEnumSelectRequestFrom<FactionID>(widgetName, requestType);
                    break;

                case RequestType.PhalanxIDSelect:
                    request = BuildEnumSelectRequestFrom<PhalanxID>(widgetName, requestType);
                    break;

                case RequestType.UnitIDSelect:
                    request = BuildEnumSelectRequestFrom<UnitID>(widgetName, requestType);
                    break;

                case RequestType.FactionPhalanxIDMinusMod:
                case RequestType.FactionPhalanxIDAddMod:
                    request = this.BuildPhalanxIDModRequestFrom(requestType == RequestType.FactionPhalanxIDAddMod, widgetName, requestType);
                    break;

                case RequestType.PhalanxUnitIDMinusMod:
                case RequestType.PhalanxUnitIDAddMod:
                    request = this.BuildUnitIDModRequestFrom(requestType == RequestType.PhalanxUnitIDAddMod, widgetName, requestType);
                    break;

                default:
                    request = new DefaultRequestImpl(requestType);
                    break;
            }
            return request;
        }

        private IEnumSelectRequest<TEnum> BuildEnumSelectRequestFrom<TEnum>(string widgetName, RequestType requestType)
            where TEnum : Enum
        {
            TEnum tEnum = EnumUtils.DetermineEnumFrom<TEnum>(widgetName);
            return new EnumSelectRequestImpl<TEnum>(tEnum, requestType);
        }

        private IQSortieMenuMvcRequest BuildPhalanxIDModRequestFrom(bool isAdd, string widgetName, RequestType requestType)
        {
            FactionID factionID = EnumUtils.DetermineEnumFrom<FactionID>(widgetName);
            PhalanxID phalanxID = EnumUtils.DetermineEnumFrom<PhalanxID>(widgetName);
            return new FactionPhalanxIDModRequestImpl(factionID, phalanxID, isAdd, requestType);
        }

        private IQSortieMenuMvcRequest BuildUnitIDModRequestFrom(bool isAdd, string widgetName, RequestType requestType)
        {
            PhalanxID phalanxID = EnumUtils.DetermineEnumFrom<PhalanxID>(widgetName);
            UnitID unitID = EnumUtils.DetermineEnumFrom<UnitID>(widgetName);
            return new PhalanxUnitIDModRequestImpl(phalanxID, unitID, isAdd, requestType);
        }
    }
}