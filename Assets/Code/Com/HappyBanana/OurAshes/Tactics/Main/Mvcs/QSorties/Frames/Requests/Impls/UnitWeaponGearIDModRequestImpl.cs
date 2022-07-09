using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Weapons.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Types;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class UnitWeaponGearIDModRequestImpl
        : DefaultRequestImpl, IUnitWeaponGearIDModRequest
    {
        private readonly int index;

        // Todo
        private readonly UnitID unitID = UnitID.None;

        // Todo
        private readonly WeaponGearID weaponGearID = WeaponGearID.EMPTY;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="unitID">      </param>
        /// <param name="weaponGearID"></param>
        /// <param name="isAdd">       </param>
        /// <param name="index">       </param>
        /// <param name="requestType"> </param>
        public UnitWeaponGearIDModRequestImpl(UnitID unitID, WeaponGearID weaponGearID,  int index, RequestType requestType)
            : base(requestType)
        {
            this.index = index;
            this.unitID = unitID;
            this.weaponGearID = weaponGearID;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: UnitID:{1}, Index:{2}, WeaponGearID:{3}",
                this.GetType().Name, this.unitID, this.index, this.weaponGearID);
        }

        /// <inheritdoc/>
        UnitID IUnitWeaponGearIDModRequest.GetUnitID()
        {
            return unitID;
        }

        /// <inheritdoc/>
        WeaponGearID IUnitWeaponGearIDModRequest.GetWeaponGearID()
        {
            return weaponGearID;
        }

        /// <inheritdoc/>
        int IUnitWeaponGearIDModRequest.GetWeaponIndex()
        {
            return index;
        }
    }
}