namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Comparers.Abs
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Talons.Managers;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Comparers.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Reports.Api;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractTalonObjectComparer
        : ITalonObjectComparer
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCallSignA"></param>
        /// <param name="talonCallSignB"></param>
        /// <returns></returns>
        int IComparer<TalonCallSign>.Compare(TalonCallSign talonCallSignA, TalonCallSign talonCallSignB)
        {
            if (!(talonCallSignA.Equals(TalonCallSign.None) ||
                talonCallSignB.Equals(TalonCallSign.None)))
            {
                // Collect the TalonObjects
                ITalonReport talonReportA = TalonRosterManager.GetTalonReport(talonCallSignA);
                ITalonReport talonReportB = TalonRosterManager.GetTalonReport(talonCallSignB);
                // Collect their comparing values
                float movementPointsX = this.GetComparingValue(talonReportA);
                float movementPointsY = this.GetComparingValue(talonReportB);
                if (movementPointsX > movementPointsY)
                {
                    return -1;
                }
                else if (movementPointsX < movementPointsY)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                // Check if talonCallSignB is None
                if (!talonCallSignA.Equals(TalonCallSign.None))
                {
                    return 1;
                }
                // Check if talonCallSignA is None
                else if (!talonCallSignB.Equals(TalonCallSign.None))
                {
                    return 1;
                }
                // Otherwise both of the TalonCallSigns are none
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonReport"></param>
        /// <returns></returns>
        protected abstract float GetComparingValue(ITalonReport talonReport);
    }
}