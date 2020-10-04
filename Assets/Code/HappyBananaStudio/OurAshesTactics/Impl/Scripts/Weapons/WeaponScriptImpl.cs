/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Weapons.Objects;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Weapons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Loggers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Scripts.Unity;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Objects.Weapons;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Scripts.Weapons
{
    /// <summary>
    /// Weapon Script Impl
    /// </summary>
    public class WeaponScriptImpl
    : UnityScript, IWeaponScript
    {
        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private WeaponModelIdEnum weaponId = WeaponModelIdEnum.None;

        // Todo
        private IWeaponObject weaponObject = null;

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public WeaponModelIdEnum GetWeaponId()
        {
            return this.weaponId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IWeaponObject GetWeaponObject()
        {
            return this.weaponObject;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponId">
        /// </param>
        public void Initialize(WeaponModelIdEnum weaponId)
        {
            // Check that this has not already been initialized
            if (!this.IsInitialized())
            {
                // Check that the parameters are non-null
                if (weaponId != WeaponModelIdEnum.None)
                {
                    this.weaponId = weaponId;
                    this.weaponObject = new WeaponObjectImpl(this, this.weaponId);
                    this.weaponObject.Initialize();
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. " +
                        "\n\t> ? is invalid", this.GetType(), typeof(WeaponModelIdEnum));
                }
            }
            else
            {
                logger.Warn("Unable to Initialize: ?. Already initialized.", this.GetType());
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public bool IsInitialized()
        {
            return this.weaponObject != null &&
                this.weaponId != WeaponModelIdEnum.None;
        }
    }
}