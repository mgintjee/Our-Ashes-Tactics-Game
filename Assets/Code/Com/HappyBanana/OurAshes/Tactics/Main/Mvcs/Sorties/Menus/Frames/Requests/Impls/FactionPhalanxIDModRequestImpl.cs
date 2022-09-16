using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Frames.Requests.Types;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Frames.Requests.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class FactionPhalanxIDModRequestImpl
        : DefaultRequestImpl, IFactionPhalanxIDModRequest
    {
        // Todo
        private readonly FactionID factionID = FactionID.None;

        // Todo
        private readonly PhalanxID phalanxID = PhalanxID.None;

        // Todo
        private readonly bool isAdd = false;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factionID">  </param>
        /// <param name="phalanxID">  </param>
        /// <param name="isAdd">      </param>
        /// <param name="requestType"></param>
        public FactionPhalanxIDModRequestImpl(FactionID factionID, PhalanxID phalanxID, bool isAdd, RequestType requestType)
            : base(requestType)
        {
            this.factionID = factionID;
            this.phalanxID = phalanxID;
            this.isAdd = isAdd;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: FactionID:{1}, PhalanxID:{2}, IsAdd:{3}",
                this.GetType().Name, this.factionID, this.phalanxID, this.isAdd);
        }

        /// <inheritdoc/>
        public FactionID GetFactionID()
        {
            return factionID;
        }

        /// <inheritdoc/>
        public PhalanxID  GetPhalanxID()
        {
            return phalanxID;
        }

        /// <inheritdoc/>
        public bool IsAdd()
        {
            return isAdd;
        }
    }
}