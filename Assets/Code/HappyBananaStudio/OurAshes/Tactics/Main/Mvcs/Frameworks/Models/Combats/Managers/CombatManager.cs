namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Combats.Managers
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Combats.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Combats.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Roster Manager
    /// </summary>
    public class CombatManager
    {
        // Todo
        private static ICombatObject combatObject;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatObject"></param>
        public static void SetCombatObject(ICombatObject combatObject)
        {
            if (CombatManager.combatObject == null)
            {
                CombatManager.combatObject = combatObject;
            }
            else
            {
                throw ExceptionUtil.Arguments.Build("Unable to ?. ? is already set.",
                    new StackFrame().GetMethod().Name, typeof(ICombatObject));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static IList<ICombatReport> GetAverageCombatReport(TalonCallSign actingTalonCallSign,
            TalonCallSign targetTalonCallSign, float accuracyCost)
        {
            if (combatObject != null)
            {
                return combatObject.GetAverageCombatReport(actingTalonCallSign, targetTalonCallSign, accuracyCost);
            }
            else
            {
                throw ExceptionUtil.Arguments.Build();
            }
        }
    }
}