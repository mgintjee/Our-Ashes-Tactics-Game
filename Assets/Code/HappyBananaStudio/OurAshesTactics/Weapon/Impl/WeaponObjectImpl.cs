/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.Logging;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Enums;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Reports;
using System;
using System.Diagnostics;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Impl
{
    /// <summary>
    /// Weapon Object Impl
    /// </summary>
    public class WeaponObjectImpl
    : IWeaponObject
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly WeaponIdEnum weaponId = WeaponIdEnum.NULL;

        // Todo
        private readonly WeaponScript weaponScript = null;

        // Todo
        private IWeaponBehavior weaponBehavior = null;

        // Todo
        private IWeaponVisual weaponVisual = null;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponScript"></param>
        /// <param name="weaponId">    </param>
        public WeaponObjectImpl(WeaponScript weaponScript, WeaponIdEnum weaponId)
        {
            if (weaponScript != null &&
                weaponId != WeaponIdEnum.NULL)
            {
                logger.Info("Constructing: ?.", this.GetType());
                this.weaponScript = weaponScript;
                this.weaponId = weaponId;
            }
            else
            {
                throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                    "\n\t>" + typeof(WeaponScript) + " is null: " + (weaponScript == null) +
                    "\n\t>" + typeof(WeaponIdEnum) + " is null: " + (weaponId == WeaponIdEnum.NULL));
            }
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="accuracyPenalty"></param>
        /// <param name="targetRange">    </param>
        /// <returns></returns>
        public WeaponCombatOrderReport GenerateWeaponCombatOrderReport(int accuracyPenalty, int targetRange)
        {
            return this.weaponBehavior.GenerateWeaponReport(accuracyPenalty, targetRange);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public IWeaponBehavior GetWeaponBehavior()
        {
            return this.weaponBehavior;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public WeaponIdEnum GetWeaponId()
        {
            return this.weaponId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public WeaponScript GetWeaponScript()
        {
            return this.weaponScript;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public void Initialize()
        {
            if (!this.IsInitialized())
            {
                this.weaponBehavior = new WeaponBehaviorImpl(this.weaponId);
                //this.talonVisual = new TalonVisualImpl(this, this.talonConstructionReport);
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
        public bool IsInitialized()
        {
            return this.weaponBehavior != null &&
                this.weaponVisual != null;
        }

        #endregion Public Methods
    }
}