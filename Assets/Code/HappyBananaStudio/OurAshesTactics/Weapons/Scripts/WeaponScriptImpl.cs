/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Weapons.Objects;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Weapons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Loggers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Unity;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Weapons.Objects;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Weapons.Scripts
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
        private WeaponIdEnum weaponId = WeaponIdEnum.None;

        // Todo
        private IWeaponObject weaponObject = null;

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public WeaponIdEnum GetWeaponId()
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
        public void Initialize(WeaponIdEnum weaponId)
        {
            // Check that this has not already been initialized
            if (!this.IsInitialized())
            {
                // Check that the parameters are non-null
                if (weaponId != WeaponIdEnum.None)
                {
                    this.weaponId = weaponId;
                    this.weaponObject = new WeaponObjectImpl(this, this.weaponId);
                    this.weaponObject.Initialize();
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. " +
                        "\n\t> ? is invalid", this.GetType(), typeof(WeaponIdEnum));
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
                this.weaponId != WeaponIdEnum.None;
        }
    }
}