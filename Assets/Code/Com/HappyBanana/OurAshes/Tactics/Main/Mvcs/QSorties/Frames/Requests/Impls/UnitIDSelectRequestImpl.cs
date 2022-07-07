using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class UnitIDSelectRequestImpl
        : DefaultRequestImpl, IUnitIDSelectRequest
    {
        // Todo
        private UnitID id = UnitID.None;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UnitIDSelectRequestImpl SetUnitID(UnitID id)
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
        UnitID IUnitIDSelectRequest.GetUnitID()
        {
            return id;
        }
    }
}