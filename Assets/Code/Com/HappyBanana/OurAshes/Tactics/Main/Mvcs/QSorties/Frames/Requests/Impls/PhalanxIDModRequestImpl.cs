using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class PhalanxIDModRequestImpl
        : DefaultRequestImpl, IPhalanxIDModRequest
    {
        // Todo
        private FactionID factionID = FactionID.None;

        // Todo
        private PhalanxID phalanxID = PhalanxID.None;

        // Todo
        private bool isAdd = false;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="id"></param>
        public PhalanxIDModRequestImpl SetFactionID(FactionID id)
        {
            this.factionID = id;
            return this;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PhalanxIDModRequestImpl SetPhalanxID(PhalanxID id)
        {
            this.phalanxID = id;
            return this;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="isAdd"></param>
        /// <returns></returns>
        public PhalanxIDModRequestImpl SetIsAdd(bool isAdd)
        {
            this.isAdd = isAdd;
            return this;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: FactionID:{1}, PhalanxID:{2}, IsAdd:{3}",
                this.GetType().Name, this.factionID, this.phalanxID, this.isAdd);
        }

        /// <inheritdoc/>
        FactionID IPhalanxIDModRequest.GetFactionID()
        {
            return factionID;
        }

        /// <inheritdoc/>
        PhalanxID IPhalanxIDModRequest.GetPhalanxID()
        {
            return phalanxID;
        }

        /// <inheritdoc/>
        bool IPhalanxIDModRequest.IsAdd()
        {
            return isAdd;
        }
    }
}