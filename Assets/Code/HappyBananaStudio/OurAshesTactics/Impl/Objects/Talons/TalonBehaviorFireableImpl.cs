/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Paths.Object;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Talons.Behaviors;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Weapons.Behaviors;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Attributes;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Combat;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Weapons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Builders;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Loggers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Paths.Finder;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Objects.Talons
{
    /// <summary>
    /// Todo
    /// </summary>
    public class TalonBehaviorFireableImpl
    : ITalonBehaviorFireable
    {
        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly IFireableAttributes fireableAttributes = null;

        // Todo
        private readonly List<IWeaponBehavior> weaponBehaviorList;

        // Todo
        private Dictionary<ICubeCoordinates, IPathObject> cubeCoordinatesPathObjectDictionary = new Dictionary<ICubeCoordinates, IPathObject>();

        // Todo
        private ICubeCoordinates currentCubeCoordinates = null;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="fireableAttributes">
        /// </param>
        public TalonBehaviorFireableImpl(IFireableAttributes fireableAttributes)
        {
            if (fireableAttributes != null)
            {
                this.fireableAttributes = fireableAttributes;
                this.weaponBehaviorList = new List<IWeaponBehavior>();
                for (int i = 0; i < this.fireableAttributes.GetWeaponPoints(); ++i)
                {
                    this.weaponBehaviorList.Add(null);
                }
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. " +
                    "\n\t> ? is null", this.GetType(), typeof(IFireableAttributes));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponBehavior">
        /// </param>
        public void AddWeapon(int index, IWeaponBehavior weaponBehavior)
        {
            if (weaponBehavior != null)
            {
                if (index >= 0 &&
                    index < this.weaponBehaviorList.Count)
                {
                    this.weaponBehaviorList[index] = weaponBehavior;
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. " +
                        "\n\t> Index=? is out of range=[0,?]", new StackFrame().GetMethod().Name,
                        index, this.fireableAttributes.GetWeaponPoints());
                }
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. " +
                    "\n\t> ? is null", new StackFrame().GetMethod().Name, typeof(IWeaponBehavior));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public void BeginPathFinding()
        {
            this.cubeCoordinatesPathObjectDictionary = (this.weaponBehaviorList.Count > 0)
                ? PathFinderFireUtil.BeginPathfindingFor(this.currentCubeCoordinates)
                : new Dictionary<ICubeCoordinates, IPathObject>();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IFireableReport GetFireableAttributesReport()
        {
            List<IWeaponInformationReport> weaponIdList = new List<IWeaponInformationReport>();

            this.weaponBehaviorList.ForEach(weaponBehavior =>
                {
                    if (weaponBehavior != null)
                    {
                        weaponIdList.Add(weaponBehavior.GetWeaponInformationReport());
                    }
                    else
                    {
                        weaponIdList.Add(null);
                    }
                }
            );

            return ReportBuilder.Talon.Attributes.Fireable.GetBuilder()
                .SetWeaponIdList(weaponIdList)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="targetRange">
        /// </param>
        /// <returns>
        /// </returns>
        public int GetMaxAccuracyPenalty(int targetRange)
        {
            int maxAccuracyPenalty = int.MinValue;
            foreach (IWeaponBehavior weaponBehavior in this.weaponBehaviorList)
            {
                int weaponMaxAccuracyPenalty = weaponBehavior.GetMaxAccuracyPenalty(targetRange);
                if (maxAccuracyPenalty < weaponMaxAccuracyPenalty)
                {
                    maxAccuracyPenalty = weaponMaxAccuracyPenalty;
                }
            }

            return maxAccuracyPenalty;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public HashSet<IPathObject> GetPathObjectFireSet()
        {
            return new HashSet<IPathObject>(this.cubeCoordinatesPathObjectDictionary.Values);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObjectFire">
        /// </param>
        /// <returns>
        /// </returns>
        public ITalonCombatOrderReport GetTalonCombatOrderReport(IPathObject pathObjectFire)
        {
            List<IWeaponOrderReport> weaponCombatOrderList = new List<IWeaponOrderReport>();
            if (pathObjectFire != null)
            {
                logger.Debug("Firing with: [?]", string.Join(", ", this.weaponBehaviorList));
                // Iterate over the List: WeaponBehavior
                foreach (IWeaponBehavior weaponBehavior in this.weaponBehaviorList)
                {
                    // Collect the weaponCombatOrder from the weaponBehavior
                    IWeaponOrderReport weaponCombatOrder = weaponBehavior.GenerateWeaponReport(
                        pathObjectFire.GetPathObjectCost(),
                        pathObjectFire.GetPathObjectLength());
                    logger.Debug("Added ?", weaponCombatOrder);
                    // Add the generated weaponCombatOrder to the list
                    weaponCombatOrderList.Add(weaponCombatOrder);
                }
            }
            return ReportBuilder.Talon.Combat.Order.GetBuilder()
                .SetWeaponOrderReportList(weaponCombatOrderList)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public List<WeaponModelIdEnum> GetWeaponIdList()
        {
            List<WeaponModelIdEnum> weaponIdList = new List<WeaponModelIdEnum>();

            foreach (IWeaponBehavior weaponBehavior in this.weaponBehaviorList)
            {
                if (weaponBehavior != null)
                {
                    weaponIdList.Add(weaponBehavior.GetWeaponInformationReport().GetWeaponId());
                }
                else
                {
                    weaponIdList.Add(WeaponModelIdEnum.None);
                }
            }
            return weaponIdList;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        public void SetCubeCoodinates(ICubeCoordinates cubeCoordinates)
        {
            if (cubeCoordinates != null)
            {
                this.currentCubeCoordinates = cubeCoordinates;
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. " +
                    "\n\t> ? is null", new StackFrame().GetMethod().Name, typeof(ICubeCoordinates));
            }
        }
    }
}