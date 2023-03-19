using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Managers.Randoms;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Armors.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Cabins.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Engines.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Models.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Biomes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Shapes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Frames.Requests.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Models.States.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Models.Utils;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Models.Utils.Combatants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Models.Utils.Fields;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Models.Impls
{
    /// <summary>
    /// Sortie Menu Model Impl
    /// </summary>
    public class MvcModelImpl
        : AbstractMvcModel, IMvcModel
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public MvcModelImpl(IMvcFrameConstruction mvcFrameConstruction)
            : base(mvcFrameConstruction)
        {
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        protected override IMvcModelState ProcessInitialMvcModelRequest()
        {
            return this.mvcModelState;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcRequest"></param>
        /// <returns></returns>
        protected override IMvcModelState ProcessMvcModelRequest(IMvcRequest mvcRequest)
        {
            IQSortieMenuMvcRequest qSortieMenuMvcRequest = (IQSortieMenuMvcRequest)mvcRequest;
            bool updateTileDetailsUnitIDs = false;
            logger.Info("Received {}", qSortieMenuMvcRequest);
            switch (qSortieMenuMvcRequest.GetRequestType())
            {
                case RequestType.FactionIDSelect:
                    this.HandleFactionIDSelect((IEnumSelectRequest<FactionID>)mvcRequest);
                    break;

                case RequestType.PhalanxIDSelect:
                    this.HandlePhalanxIDSelect((IEnumSelectRequest<PhalanxID>)mvcRequest);
                    break;

                case RequestType.UnitIDSelect:
                    this.HandleUnitIDSelect((IEnumSelectRequest<UnitID>)mvcRequest);
                    break;

                case RequestType.FieldIDSelect:
                    FieldModUtil.HandleFieldIDSelect(this.CastMvcModelState(), (IEnumSelectRequest<FieldID>)mvcRequest);
                    updateTileDetailsUnitIDs = true;
                    break;

                case RequestType.FieldBiomeSelect:
                    FieldModUtil.HandleFieldBiomeSelect(this.CastMvcModelState(), (IEnumSelectRequest<FieldBiome>)mvcRequest);
                    updateTileDetailsUnitIDs = true;
                    break;

                case RequestType.FieldSizeSelect:
                    FieldModUtil.HandleFieldSizeSelect(this.CastMvcModelState(), (IEnumSelectRequest<FieldSize>)mvcRequest);
                    updateTileDetailsUnitIDs = true;
                    break;

                case RequestType.FieldShapeSelect:
                    FieldModUtil.HandleFieldShapeSelect(this.CastMvcModelState(), (IEnumSelectRequest<FieldShape>)mvcRequest);
                    updateTileDetailsUnitIDs = true;
                    break;

                case RequestType.FactionPhalanxIDAddSelect:
                case RequestType.FactionPhalanxIDMinusSelect:
                    CombatantsModUtil.HandlePhalanxIDMod(this.CastMvcModelState(), (IFactionPhalanxIDModRequest)mvcRequest);
                    break;

                case RequestType.PhalanxUnitIDAddSelect:
                case RequestType.PhalanxUnitIDMinusSelect:
                    CombatantsModUtil.HandleUnitIDMod(this.CastMvcModelState(), (IPhalanxUnitIDModRequest)mvcRequest);
                    updateTileDetailsUnitIDs = true;
                    break;

                case RequestType.UnitWeaponGearIDSelect:
                    CombatantsModUtil.HandleUnitWeaponGearIDMod(this.CastMvcModelState(), (IUnitWeaponGearIDModRequest)mvcRequest);
                    break;

                case RequestType.UnitModelIDSelect:
                    CombatantsModUtil.HandleUnitModelIDSelect(this.CastMvcModelState(), (IEnumSelectRequest<ModelID>)mvcRequest);
                    break;

                case RequestType.UnitArmorGearIDSelect:
                    CombatantsModUtil.HandleUnitArmorGearIDSelect(this.CastMvcModelState(), (IEnumSelectRequest<ArmorGearID>)mvcRequest);
                    break;

                case RequestType.UnitCabinGearIDSelect:
                    CombatantsModUtil.HandleUnitCabinGearIDSelect(this.CastMvcModelState(), mvcRequest: (IEnumSelectRequest<CabinGearID>)mvcRequest);
                    break;

                case RequestType.UnitEngineGearIDSelect:
                    CombatantsModUtil.HandleUnitEngineGearIDSelect(this.CastMvcModelState(), (IEnumSelectRequest<EngineGearID>)mvcRequest);
                    break;

                case RequestType.SortieStart:
                    isProcessing = false;
                    break;
            }
            if (updateTileDetailsUnitIDs)
            {
                FieldModUtil.UpdateTileDetailsUnitIDs(this.CastMvcModelState().GetFieldDetails(),
                    this.CastMvcModelState().GetCombatantsDetails().GetUnitDetails());
            }
            ((MvcModelStateImpl)this.mvcModelState)
                .SetPrevMvcRequest(mvcRequest);

            return this.mvcModelState;
        }

        protected override IMvcModelState BuildInitialMvcModelState()
        {
            return MvcModelStateRandomizerUtil.Randomize(RandomManager.GetRandom(MvcType.QSortieMenu));
        }

        private void HandleFactionIDSelect(IEnumSelectRequest<FactionID> mvcRequest)
        {
            ((MvcModelStateImpl)this.mvcModelState).SetFactionID(mvcRequest.GetEnum());
        }

        private void HandlePhalanxIDSelect(IEnumSelectRequest<PhalanxID> mvcRequest)
        {
            ((MvcModelStateImpl)this.mvcModelState).SetPhalanxID(mvcRequest.GetEnum());
        }

        private void HandleUnitIDSelect(IEnumSelectRequest<UnitID> mvcRequest)
        {
            ((MvcModelStateImpl)this.mvcModelState).SetUnitID(mvcRequest.GetEnum());
        }

        private States.Inters.IMvcModelState CastMvcModelState()
        {
            return ((States.Inters.IMvcModelState)this.mvcModelState);
        }
    }
}