using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class MvcModelStateImpl
        : DefaultMvcModelStateImpl, IMvcModelState
    {
        private ICombatantsDetails combatantsDetails;
        private IFieldDetails fieldDetails;
        private FactionID factionID = FactionID.None;
        private PhalanxID phalanxID = PhalanxID.None;
        private UnitID unitID = UnitID.None;

        public override Commons.Models.States.Inters.IMvcModelState GetCopy()
        {
            return new MvcModelStateImpl()
                .SetFactionID(factionID)
                .SetPhalanxID(phalanxID)
                .SetUnitID(unitID)
                .SetFieldDetails(fieldDetails)
                .SetCombatantsDetails(combatantsDetails)
                .SetPrevMvcRequest(prevMvcRequest);
        }

        public MvcModelStateImpl SetCombatantsDetails(ICombatantsDetails details)
        {
            if (factionID == FactionID.None)
            {
                factionID = details.GetFactionDetails()[0].GetFactionID();
            }
            if (phalanxID == PhalanxID.None)
            {
                phalanxID = details.GetPhalanxDetails()[0].GetPhalanxID();
            }
            if (unitID == UnitID.None)
            {
                unitID = details.GetUnitDetails()[0].GetUnitID();
            }
            combatantsDetails = details;
            return this;
        }

        public MvcModelStateImpl SetFieldDetails(IFieldDetails details)
        {
            fieldDetails = details;
            return this;
        }

        public MvcModelStateImpl SetFactionID(FactionID id)
        {
            factionID = id;
            return this;
        }

        public MvcModelStateImpl SetPhalanxID(PhalanxID id)
        {
            phalanxID = id;
            return this;
        }

        public MvcModelStateImpl SetUnitID(UnitID id)
        {
            unitID = id;
            return this;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("\nSelected: {0}, {1}, {2}" +
                "\n{3}" +
                "\n{4}" +
                "\n{5}", factionID, phalanxID, unitID,
                combatantsDetails, fieldDetails, prevMvcRequest);
        }

        IFieldDetails IMvcModelState.GetFieldDetails()
        {
            return fieldDetails;
        }

        ICombatantsDetails IMvcModelState.GetCombatantsDetails()
        {
            return combatantsDetails;
        }

        FactionID IMvcModelState.GetSelectedFactionID()
        {
            return factionID;
        }

        PhalanxID IMvcModelState.GetSelectedPhalanxID()
        {
            return phalanxID;
        }

        UnitID IMvcModelState.GetSelectedUnitID()
        {
            return unitID;
        }
    }
}