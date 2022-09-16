using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Frames.Requests.Types;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Frames.Requests.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class PhalanxUnitIDModRequestImpl
        : DefaultRequestImpl, IPhalanxUnitIDModRequest
    {
        // Todo
        private readonly PhalanxID phalanxID = PhalanxID.None;

        // Todo
        private readonly UnitID unitID = UnitID.None;

        // Todo
        private readonly bool isAdd = false;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factionID">  </param>
        /// <param name="phalanxID">  </param>
        /// <param name="isAdd">      </param>
        /// <param name="requestType"></param>
        public PhalanxUnitIDModRequestImpl(PhalanxID phalanxID, UnitID unitID, bool isAdd, RequestType requestType)
            : base(requestType)
        {
            this.phalanxID = phalanxID;
            this.unitID = unitID;
            this.isAdd = isAdd;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: PhalanxID:{1}, UnitID:{2}, IsAdd:{3}",
                this.GetType().Name, this.phalanxID, this.unitID, this.isAdd);
        }

        /// <inheritdoc/>
        PhalanxID IPhalanxUnitIDModRequest.GetPhalanxID()
        {
            return phalanxID;
        }

        /// <inheritdoc/>
        UnitID IPhalanxUnitIDModRequest.GetUnitID()
        {
            return unitID;
        }

        /// <inheritdoc/>
        bool IPhalanxUnitIDModRequest.IsAdd()
        {
            return isAdd;
        }
    }
}