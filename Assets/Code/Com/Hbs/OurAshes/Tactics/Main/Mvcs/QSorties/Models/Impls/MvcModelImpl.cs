using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Factions.Details.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Factions.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Factions.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Biomes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Shapes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Utils.Queries;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Utils.Randomizations;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Models.Impls
{
    /// <summary>
    /// QSortie Model Impl
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
            logger.Info("Received {}", qSortieMenuMvcRequest.GetRequestType());
            switch (qSortieMenuMvcRequest.GetRequestType())
            {
                case RequestType.SortieRandomize:
                    this.HandleSortieRandomize();
                    break;

                case RequestType.FieldRandomize:
                    this.HandleFieldRandomize();
                    break;

                case RequestType.FactionRandomize:
                    this.HandleFactionRandomize();
                    break;

                case RequestType.FieldMod:
                    this.HandleFieldMod((IMvcRequestFieldMod)mvcRequest);
                    break;

                case RequestType.FactionMod:
                    this.HandleFactionMod((IMvcRequestFactionMod)mvcRequest);
                    break;

                case RequestType.PhalanxMod:
                    this.HandlePhalanxMod((IMvcRequestPhalanxMod)mvcRequest);
                    break;

                case RequestType.CombatantMod:
                    this.HandleCombatantMod((IMvcRequestCombatantMod)mvcRequest);
                    break;
            }
            ((MvcModelStateImpl)this.mvcModelState)
                .SetPrevMvcRequest(mvcRequest);
            // Todo: This is where I would modify the existing MvcModelState
            return this.mvcModelState;
        }

        protected override IMvcModelState BuildInitialMvcModelState()
        {
            return MvcModelStateRandomizerUtil.Randomize(RandomManager.GetRandom(MvcType.QSortieMenu));
        }

        private ISet<IMvcRequest> BuildInitialMvcModelRequests()
        {
            ISet<IMvcRequest> panelMvcRequests = this.BuildPanelMvcModelRequests();
            panelMvcRequests.Add(new MvcRequestImpl().SetRequestType(RequestType.SortieRandomize));
            return panelMvcRequests;
        }

        private ISet<IMvcRequest> BuildPanelMvcModelRequests()
        {
            return new HashSet<IMvcRequest>
                    {
                        new MvcRequestImpl().SetRequestType(RequestType.FieldDetails),
                        new MvcRequestImpl().SetRequestType(RequestType.PhalanxDetails),
                        new MvcRequestImpl().SetRequestType(RequestType.CombatantDetails),
                        new MvcRequestImpl().SetRequestType(RequestType.SortieDetails),
                        new MvcRequestImpl().SetRequestType(RequestType.SortieStart),
                    };
        }

        private void HandlePhalanxMod(IMvcRequestPhalanxMod mvcRequest)
        {
            FactionID factionID = mvcRequest.GetFactionID();
            IPhalanxDetails phalanxDetails = mvcRequest.GetPhalanxDetails();

            if (mvcRequest.IsDel())
            {
                this.DelPhalanxCallSign(phalanxDetails.GetCallSign());
            }
            else if (mvcRequest.IsAdd())
            {
                this.AddPhalanxCallSign(factionID, phalanxDetails);
            }
            else if (mvcRequest.IsMod())
            {
            }
        }

        private void HandleCombatantMod(IMvcRequestCombatantMod mvcRequest)
        {
            PhalanxCallSign phalanxCallSign = mvcRequest.GetPhalanxCallSign();
            ICombatantDetails combatantDetails = mvcRequest.GetCombatantDetails();

            if (mvcRequest.IsDel())
            {
                this.DelCombatantCallSign(combatantDetails.GetCallSign());
            }
            else if (mvcRequest.IsAdd())
            {
                this.AddCombatantCallSign(phalanxCallSign, combatantDetails);
            }
            else if (mvcRequest.IsMod())
            {
            }
        }

        private void AddCombatantCallSign(PhalanxCallSign phalanxCallSign, ICombatantDetails combatantDetails)
        {
            // Todo
        }

        private void DelCombatantCallSign(CombatantCallSign combatantCallSign)
        {
            // Todo
        }

        private void AddPhalanxCallSign(FactionID factionID, IPhalanxDetails phalanxDetails)
        {
            MvcModelStateQueryUtil.GetFactionDetails(this.CastMvcModelState(), factionID).IfPresent(factionDetails =>
            {
                IList<IPhalanxDetails> phalanxDetailsSet = factionDetails.GetPhalanxDetails();
                this.DelPhalanxCallSign(phalanxDetails.GetCallSign());
                this.DelFactionID(factionID);
                phalanxDetailsSet.Add(phalanxDetails);
                IFactionDetails newFactionDetails = FactionDetailsImpl.Builder.Get()
                  .SetFactionID(factionID)
                  .SetPhalanxDetails(phalanxDetailsSet)
                  .Build();
                IList<IFactionDetails> factionDetailsSetCopy = this.CastMvcModelState().GetFactionDetails();
                factionDetailsSetCopy.Add(factionDetails);
                this.UpdateFactionDetails(factionDetailsSetCopy);
            });
        }

        private void DelPhalanxCallSign(PhalanxCallSign phalanxCallSign)
        {
            FactionID factionID = MvcModelStateQueryUtil.GetFactionIDFromPhalanx(this.CastMvcModelState(), phalanxCallSign);

            MvcModelStateQueryUtil.GetFactionDetails(this.CastMvcModelState(), factionID).IfPresent(factionDetails =>
            {
                MvcModelStateQueryUtil.GetPhalanxDetails(phalanxCallSign, factionDetails.GetPhalanxDetails()).IfPresent(phalanxDetails =>
                {
                    IList<IPhalanxDetails> phalanxDetailsSetCopy = factionDetails.GetPhalanxDetails();
                    phalanxDetailsSetCopy.Remove(phalanxDetails);
                    this.DelFactionID(factionID);
                    IFactionDetails newFactionDetails = FactionDetailsImpl.Builder.Get()
                        .SetFactionID(factionID)
                        .SetPhalanxDetails(phalanxDetailsSetCopy)
                        .Build();
                    IList<IFactionDetails> newFactionDetailsSet = this.CastMvcModelState().GetFactionDetails();
                    newFactionDetailsSet.Add(newFactionDetails);
                    this.UpdateFactionDetails(newFactionDetailsSet);
                });
            });
        }

        private void HandleFactionMod(IMvcRequestFactionMod mvcRequest)
        {
            FactionID factionID = mvcRequest.GetFactionID();

            if (mvcRequest.IsDel())
            {
                this.DelFactionID(factionID);
            }
            else
            {
                this.AddFactionID(factionID);
            }
        }

        private void AddFactionID(FactionID factionID)
        {
            if (!MvcModelStateQueryUtil.GetFactionDetails(this.CastMvcModelState(), factionID).IsPresent())
            {
                IFactionDetails factionDetails = FactionDetailsImpl.Builder.Get()
                  .SetFactionID(factionID)
                  .SetPhalanxDetails(new List<IPhalanxDetails>())
                  .Build();
                IList<IFactionDetails> factionDetailsSetCopy = this.CastMvcModelState().GetFactionDetails();
                factionDetailsSetCopy.Add(factionDetails);
                this.UpdateFactionDetails(factionDetailsSetCopy);
            }
        }

        private void DelFactionID(FactionID factionID)
        {
            MvcModelStateQueryUtil.GetFactionDetails(this.CastMvcModelState(), factionID).IfPresent(factionDetails =>
            {
                IList<IFactionDetails> factionDetailsSetCopy = this.CastMvcModelState().GetFactionDetails();
                factionDetailsSetCopy.Remove(factionDetails);
                this.UpdateFactionDetails(factionDetailsSetCopy);
            });
        }

        private void HandleFieldMod(IMvcRequestFieldMod mvcRequest)
        {
            IFieldDetails fieldDetailsMod = mvcRequest.GetFieldDetails();
            FieldID fieldID = fieldDetailsMod.GetFieldID();

            IFieldDetails fieldDetails = FieldDetailsManager.GetFieldDetails(fieldID).GetValue();
            if (fieldID == FieldID.Random)
            {
                FieldBiome fieldBiome = fieldDetailsMod.GetFieldBiome();
                FieldShape fieldShape = fieldDetailsMod.GetFieldShape();
                FieldSize fieldSize = fieldDetailsMod.GetFieldSize();
                ISet<ITileDetails> tileDetails = FieldDetailsRandomizerUtil.GetRandomTileDetails(
                    RandomManager.GetRandom(MvcType.QSortieMenu), fieldShape, fieldSize);
                fieldDetails = FieldDetailsImpl.Builder.Get()
                    .SetFieldBiome(fieldBiome)
                    .SetFieldID(fieldID)
                    .SetFieldShape(fieldShape)
                    .SetFieldSize(fieldSize)
                    .SetTileDetails(tileDetails)
                    .Build();
            }
            this.UpdateFieldDetails(fieldDetails);
        }

        private void HandleSortieRandomize()
        {
            this.HandleFieldRandomize();
            this.HandleFactionRandomize();
        }

        private void HandleFieldRandomize()
        {
            IFieldDetails fieldDetails = FieldDetailsRandomizerUtil
                .Randomize(RandomManager.GetRandom(MvcType.QSortieMenu));
            this.UpdateFieldDetails(fieldDetails);
        }

        private void HandleFactionRandomize()
        {
            IList<IFactionDetails> factionDetails = FactionDetailsRandomizerUtil
                .Randomize(RandomManager.GetRandom(MvcType.QSortieMenu),
                this.CastMvcModelState().GetFieldDetails());
            this.UpdateFactionDetails(factionDetails);
        }

        private void UpdateFieldDetails(IFieldDetails fieldDetails)
        {
            ((MvcModelStateImpl)this.mvcModelState)
                .SetFieldDetails(fieldDetails);
        }

        private void UpdateFactionDetails(IList<IFactionDetails> factionDetails)
        {
            ((MvcModelStateImpl)this.mvcModelState)
                .SetFactionDetails(factionDetails);
        }

        private States.Inters.IMvcModelState CastMvcModelState()
        {
            return ((States.Inters.IMvcModelState)this.mvcModelState);
        }
    }
}