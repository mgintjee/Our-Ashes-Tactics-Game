using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class PhalanxIDSelectRequestImpl
        : DefaultRequestImpl, IPhalanxIDSelectRequest
    {
        // Todo
        private PhalanxID id = PhalanxID.None;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PhalanxIDSelectRequestImpl SetPhalanxID(PhalanxID id)
        {
            this.id = id;
            return this;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: ID:{1}",
                this.GetType().Name, this.id);
        }

        /// <inheritdoc/>
        PhalanxID IPhalanxIDSelectRequest.GetPhalanxID()
        {
            return id;
        }
    }
}