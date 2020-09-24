/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.Logging;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Enums;
using System;
using System.Diagnostics;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Impl
{
    /// <summary>
    /// Weapon Script Impl
    /// </summary>
    public class WeaponScriptImpl
    : WeaponScript
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private WeaponIdEnum weaponId = WeaponIdEnum.NULL;

        // Todo
        private IWeaponObject weaponObject = null;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override WeaponIdEnum GetWeaponId()
        {
            return this.weaponId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override IWeaponObject GetWeaponObject()
        {
            return this.weaponObject;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponId"></param>
        public override void Initialize(WeaponIdEnum weaponId)
        {
            // Check that this has not already been initialized
            if (!this.IsInitialized())
            {
                // Check that the parameters are non-null
                if (weaponId != WeaponIdEnum.NULL)
                {
                    logger.Info("Initializing: ?.", this.GetType());
                    this.weaponId = weaponId;
                    this.weaponObject = new WeaponObjectImpl(this, this.weaponId);
                    this.weaponObject.Initialize();
                }
                else
                {
                    throw new ArgumentException("Unable to initialize " + this.GetType() + ". Invalid Parameters." +
                        "\n\t>" + typeof(WeaponIdEnum) + "=" + weaponId);
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
        /// <returns></returns>
        public override bool IsInitialized()
        {
            return this.weaponObject != null &&
                this.weaponId != WeaponIdEnum.NULL;
        }

        #endregion Public Methods
    }
}