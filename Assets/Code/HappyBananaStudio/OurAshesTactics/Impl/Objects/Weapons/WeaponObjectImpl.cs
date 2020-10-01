/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Weapons.Behaviors;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Weapons.Objects;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Weapons.Visuals;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Weapons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Weapons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Loggers;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Objects.Weapons
{
    /// <summary>
    /// Weapon Object Impl
    /// </summary>
    public class WeaponObjectImpl
    : IWeaponObject
    {
        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly WeaponModelIdEnum weaponId = WeaponModelIdEnum.None;

        // Todo
        private readonly IWeaponScript weaponScript = null;

        // Todo
        private IWeaponBehavior weaponBehavior = null;

        // Todo
        private IWeaponVisual weaponVisual = null;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponScript">
        /// </param>
        /// <param name="weaponId">
        /// </param>
        public WeaponObjectImpl(IWeaponScript weaponScript, WeaponModelIdEnum weaponId)
        {
            if (weaponScript != null &&
                weaponId != WeaponModelIdEnum.None)
            {
                this.weaponScript = weaponScript;
                this.weaponId = weaponId;
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. " +
                    "\n\t> ? is null: ? " +
                    "\n\t> ? is invalid: ?", this.GetType(),
                    typeof(IWeaponScript), (weaponScript == null),
                    typeof(WeaponModelIdEnum), weaponId.Equals(WeaponModelIdEnum.None));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="accuracyPenalty">
        /// </param>
        /// <param name="targetRange">
        /// </param>
        /// <returns>
        /// </returns>
        public IWeaponOrderReport GenerateWeaponCombatOrderReport(int accuracyPenalty, int targetRange)
        {
            return this.weaponBehavior.GenerateWeaponReport(accuracyPenalty, targetRange);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IWeaponBehavior GetWeaponBehavior()
        {
            return this.weaponBehavior;
        }

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
        public IWeaponScript GetWeaponScript()
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
        /// <returns>
        /// </returns>
        public bool IsInitialized()
        {
            return this.weaponBehavior != null &&
                this.weaponVisual != null;
        }
    }
}