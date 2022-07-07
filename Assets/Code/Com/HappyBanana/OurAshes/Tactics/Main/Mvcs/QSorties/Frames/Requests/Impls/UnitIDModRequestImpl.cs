using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class UnitIDModRequestImpl
        : DefaultRequestImpl, IUnitIDModRequest
    {
        // Todo
        private PhalanxID phalanxID = PhalanxID.None;

        // Todo
        private UnitID unitID = UnitID.None;

        // Todo
        private bool isAdd = false;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="id"></param>
        public UnitIDModRequestImpl SetPhalanxID(PhalanxID id)
        {
            this.phalanxID = id;
            return this;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UnitIDModRequestImpl SetUnitID(UnitID id)
        {
            this.unitID = id;
            return this;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="isAdd"></param>
        /// <returns></returns>
        public UnitIDModRequestImpl SetIsAdd(bool isAdd)
        {
            this.isAdd = isAdd;
            return this;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: PhalanxID:{1}, UnitID:{2}, IsAdd:{3}",
                this.GetType().Name, this.phalanxID, this.unitID, this.isAdd);
        }

        /// <inheritdoc/>
        PhalanxID IUnitIDModRequest.GetPhalanxID()
        {
            return phalanxID;
        }

        /// <inheritdoc/>
        UnitID IUnitIDModRequest.GetUnitID()
        {
            return unitID;
        }

        /// <inheritdoc/>
        bool IUnitIDModRequest.IsAdd()
        {
            return isAdd;
        }
    }
}