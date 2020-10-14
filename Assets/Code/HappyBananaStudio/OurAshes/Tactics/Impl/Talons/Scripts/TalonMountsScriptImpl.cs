
namespace HappyBananaStudio.OurAshesTactics.Impl.Scripts.Talons
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Script;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using HappyBananaStudio.OurAshesTactics.Common.Scripts.Unity;
    using System.Collections.Generic;
    using System.Diagnostics;
    using UnityEngine;

    /// <summary>
    /// TalonMounts Script Impl
    /// </summary>
    public class TalonMountsScriptImpl
    : UnityScriptImpl, ITalonMountsScript
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly static string UtilityGameObjectPrefix = "UtilityMount:";

        // Todo
        private readonly static string WeaponGameObjectPrefix = "WeaponMount:";

        // Todo
        [SerializeField]
        private readonly IList<GameObject> utilityMountGameObjectsList = new List<GameObject>();

        // Todo
        [SerializeField]
        private readonly IList<GameObject> weaponMountGameObjectsList = new List<GameObject>();

        /// <summary>
        /// Todo
        /// </summary>
        public void Awake()
        {
            foreach (Transform childTransform in this.transform)
            {
                if (childTransform.name.Contains(UtilityGameObjectPrefix))
                {
                    this.utilityMountGameObjectsList.Add(childTransform.gameObject);
                }
                else if (childTransform.name.Contains(WeaponGameObjectPrefix))
                {
                    this.weaponMountGameObjectsList.Add(childTransform.gameObject);
                }
            }
            logger.Debug("Collected mounts for ?. " +
                "\n\t> WeaponMounts=?" +
                "\n\t> UtilityMounts=?", this.transform.name,
                this.weaponMountGameObjectsList.Count, this.utilityMountGameObjectsList.Count);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int ITalonMountsScript.GetUtilityMountCount()
        {
            return this.utilityMountGameObjectsList.Count;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="index">
        /// </param>
        /// <returns>
        /// </returns>
        GameObject ITalonMountsScript.GetUtilityMountGameObject(int index)
        {
            return this.utilityMountGameObjectsList[index];
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int ITalonMountsScript.GetWeaponMountCount()
        {
            return this.weaponMountGameObjectsList.Count;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="index">
        /// </param>
        /// <returns>
        /// </returns>
        GameObject ITalonMountsScript.GetWeaponMountGameObject(int index)
        {
            return this.weaponMountGameObjectsList[index];
        }
    }
}
