using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Armors.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Cabins.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Engines.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Weapons.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Models;
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
using System.Text.RegularExpressions;

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
            bool isAdd;
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

                case RequestType.UnitModelIDSelect:
                    request = BuildEnumSelectRequestFrom<ModelID>(widgetName, requestType);
                    break;

                case RequestType.UnitArmorGearIDSelect:
                    request = BuildEnumSelectRequestFrom<ArmorGearID>(widgetName, requestType);
                    break;

                case RequestType.UnitCabinGearIDSelect:
                    request = BuildEnumSelectRequestFrom<CabinGearID>(widgetName, requestType);
                    break;

                case RequestType.UnitEngineGearIDSelect:
                    request = BuildEnumSelectRequestFrom<EngineGearID>(widgetName, requestType);
                    break;

                case RequestType.FactionPhalanxIDAddSelect:
                case RequestType.FactionPhalanxIDMinusSelect:
                    isAdd = requestType == RequestType.FactionPhalanxIDAddSelect;
                    request = BuildFactionPhalanxIDModRequestFrom(isAdd, widgetName, requestType);
                    break;

                case RequestType.PhalanxUnitIDAddSelect:
                case RequestType.PhalanxUnitIDMinusSelect:
                    isAdd = requestType == RequestType.PhalanxUnitIDAddSelect;
                    request = this.BuildPhalanxUnitIDModRequestFrom(isAdd, widgetName, requestType);
                    break;

                case RequestType.UnitWeaponGearIDModSelect:
                case RequestType.UnitWeaponGearIDMinusSelect:
                    isAdd = requestType == RequestType.UnitWeaponGearIDModSelect;
                    request = this.BuildUnitWeaponGearIDModRequestFrom(isAdd, widgetName, requestType);
                    break;

                default:
                    request = new DefaultRequestImpl(requestType);
                    break;
            }
            return request;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="widgetName"> </param>
        /// <param name="requestType"></param>
        /// <returns></returns>
        private IEnumSelectRequest<TEnum> BuildEnumSelectRequestFrom<TEnum>(string widgetName, RequestType requestType)
            where TEnum : Enum
        {
            TEnum tEnum = EnumUtils.DetermineEnumFrom<TEnum>(widgetName);
            return new EnumSelectRequestImpl<TEnum>(tEnum, requestType);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="isAdd">      </param>
        /// <param name="widgetName"> </param>
        /// <param name="requestType"></param>
        /// <returns></returns>
        private IQSortieMenuMvcRequest BuildFactionPhalanxIDModRequestFrom(bool isAdd, string widgetName, RequestType requestType)
        {
            FactionID factionID = EnumUtils.DetermineEnumFrom<FactionID>(widgetName);
            PhalanxID phalanxID = EnumUtils.DetermineEnumFrom<PhalanxID>(widgetName);
            return new FactionPhalanxIDModRequestImpl(factionID, phalanxID, isAdd, requestType);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="isAdd">      </param>
        /// <param name="widgetName"> </param>
        /// <param name="requestType"></param>
        /// <returns></returns>
        private IQSortieMenuMvcRequest BuildPhalanxUnitIDModRequestFrom(bool isAdd, string widgetName, RequestType requestType)
        {
            PhalanxID phalanxID = EnumUtils.DetermineEnumFrom<PhalanxID>(widgetName);
            UnitID unitID = EnumUtils.DetermineEnumFrom<UnitID>(widgetName);
            return new PhalanxUnitIDModRequestImpl(phalanxID, unitID, isAdd, requestType);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="isAdd">      </param>
        /// <param name="widgetName"> </param>
        /// <param name="requestType"></param>s
        /// <returns></returns>
        private IQSortieMenuMvcRequest BuildUnitWeaponGearIDModRequestFrom(bool isAdd, string widgetName, RequestType requestType)
        {
            UnitID unitID = EnumUtils.DetermineEnumFrom<UnitID>(widgetName);
            WeaponGearID weaponGearID = EnumUtils.DetermineEnumFrom<WeaponGearID>(widgetName);
            int weaponIndex = int.Parse(Regex.Match(widgetName, @"\d+").Value);
            return new UnitWeaponGearIDModRequestImpl(unitID, weaponGearID, isAdd, weaponIndex, requestType);
        }
    }
}