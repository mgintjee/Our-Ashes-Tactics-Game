using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Factions.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class FactionIDModRequestImpl
        : DefaultRequestImpl, IFactionIDModRequest
    {
        // Todo
        private FactionID factionID = FactionID.None;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="factionID"></param>
        public FactionIDModRequestImpl SetFactionID(FactionID factionID)
        {
            this.factionID = factionID;
            return this;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: ID:{1}",
                this.GetType().Name, this.factionID);
        }

        /// <inheritdoc/>
        FactionID IFactionIDModRequest.GetFactionID()
        {
            return this.factionID;
        }
    }
}