using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Frames.Requests.Types;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Frames.Requests.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class UnitWeaponGearIDPopUpRequestImpl
        : DefaultRequestImpl, IUnitWeaponGearIDPopUpRequest
    {
        private readonly int index;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="unitID">      </param>
        /// s
        /// <param name="weaponGearID"></param>
        /// <param name="isAdd">       </param>
        /// <param name="index">       </param>
        /// <param name="requestType"> </param>
        public UnitWeaponGearIDPopUpRequestImpl(int index, RequestType requestType)
            : base(requestType)
        {
            this.index = index;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("Index: {0}", this.index);
        }

        /// <inheritdoc/>
        public int GetIndex()
        {
            return index;
        }
    }
}