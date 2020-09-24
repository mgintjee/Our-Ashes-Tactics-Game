/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Enums;
using System;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Talon.Attributes.Reports
{
    /// <summary>
    /// Report to display the current attributes for a specific Fireable
    /// </summary>
    public class FireableAttributesReport
    {
        #region Private Fields

        // Todo
        private readonly int currentWeaponPoints;

        // Todo
        private readonly int maximumWeaponPoints;

        // Todo
        private readonly List<WeaponIdEnum> weaponIdList;

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        /// Private constructor to force using the Builder
        /// </summary>
        /// <param name="weaponIdList"></param>
        private FireableAttributesReport(List<WeaponIdEnum> weaponIdList)
        {
            this.weaponIdList = weaponIdList;
            this.maximumWeaponPoints = this.weaponIdList.Count;
            int weaponCounter = 0;
            this.weaponIdList.ForEach(
                weaponId =>
                {
                    if (weaponId.Equals(WeaponIdEnum.NULL))
                    {
                        weaponCounter++;
                    }
                }
                );
            this.currentWeaponPoints = weaponCounter;
        }

        #endregion Private Constructors

        #region Public Methods

        /// <summary>
        /// Get the currentWeaponPoints
        /// </summary>
        /// <returns>The int currentWeaponPoints</returns>
        public int GetCurrentWeaponPoints()
        {
            return this.currentWeaponPoints;
        }

        /// <summary>
        /// Get the maximumWeaponPoints
        /// </summary>
        /// <returns>The int maximumWeaponPoints</returns>
        public int GetMaximumWeaponPoints()
        {
            return this.maximumWeaponPoints;
        }

        /// <summary>
        /// Get the List: WeaponId
        /// </summary>
        /// <returns>The List: WeaponId</returns>
        public List<WeaponIdEnum> GetWeaponIdList()
        {
            return new List<WeaponIdEnum>(this.weaponIdList);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>currentWeaponPoints= " + this.GetCurrentWeaponPoints() +
                "\n\t>maximumWeaponPoints= " + this.GetMaximumWeaponPoints() +
                "\n\t>weaponIdList= [" +
                "\n\t>" + string.Join("\n\t>", this.GetWeaponIdList()) +
                "\n]";
        }

        #endregion Public Methods

        #region Public Classes

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            #region Private Fields

            private List<WeaponIdEnum> weaponIdList = null;

            #endregion Private Fields

            #region Public Methods

            /// <summary>
            /// Build the FireableAttributesReport with the set parameters
            /// </summary>
            /// <returns>The FireableAttributesReport</returns>
            public FireableAttributesReport Build()
            {
                HashSet<string> invalidReasons = this.IsValid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new FireableAttributesReport(this.weaponIdList);
                }
                else
                {
                    throw new ArgumentException("Unable to construct " + this.GetType().Name + ". Invalid Parameters." +
                        string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the List: WeaponId
            /// </summary>
            /// <param name="weaponIdList">The List: WeaponId to set</param>
            /// <returns>The Builder to continue building with</returns>
            public Builder SetWeaponIdList(List<WeaponIdEnum> weaponIdList)
            {
                this.weaponIdList = weaponIdList;
                return this;
            }

            #endregion Public Methods

            #region Private Methods

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            private HashSet<string> IsValid()
            {
                // Default an empty Set: String
                HashSet<string> argumentExceptionSet = new HashSet<string>();
                // Check that weaponIdList has been set
                if (this.weaponIdList == null)
                {
                    argumentExceptionSet.Add("weaponIdList has not been set");
                }
                return argumentExceptionSet;
            }

            #endregion Private Methods
        }

        #endregion Public Classes
    }
}