using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class FactionIDSelectRequestImpl
        : DefaultRequestImpl, IFactionIDSelectRequest
    {
        // Todo
        private FactionID id = FactionID.None;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="factionID"></param>
        public FactionIDSelectRequestImpl SetFactionID(FactionID factionID)
        {
            this.id = factionID;
            return this;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: ID:{1}",
                this.GetType().Name, this.id);
        }

        /// <inheritdoc/>
        FactionID IFactionIDSelectRequest.GetFactionID()
        {
            return this.id;
        }
    }
}