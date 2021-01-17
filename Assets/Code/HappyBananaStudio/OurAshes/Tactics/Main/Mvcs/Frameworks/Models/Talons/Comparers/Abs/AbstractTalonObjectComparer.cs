namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Comparers.Abs
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Managers;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Comparers.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Objects.Api;
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
        /// <param name="talonCallSignX"></param>
        /// <param name="talonCallSignY"></param>
        /// <returns></returns>
        int IComparer<TalonCallSign>.Compare(TalonCallSign talonCallSignX, TalonCallSign talonCallSignY)
        {
            if (!(talonCallSignX.Equals(TalonCallSign.None) ||
                talonCallSignY.Equals(TalonCallSign.None)))
            {
                // Collect the TalonObjects
                ITalonObject talonObjectX = RosterManager.GetTalonObject(talonCallSignX);
                ITalonObject talonObjectY = RosterManager.GetTalonObject(talonCallSignY);
                // Collect their comparing values
                float movementPointsX = this.GetComparingValue(talonObjectX);
                float movementPointsY = this.GetComparingValue(talonObjectY);
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
                // Check if talonCallSignY is None
                if (!talonCallSignX.Equals(TalonCallSign.None))
                {
                    return 1;
                }
                // Check if talonCallSignX is None
                else if (!talonCallSignY.Equals(TalonCallSign.None))
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
        /// <param name="talonObject"></param>
        /// <returns></returns>
        protected abstract float GetComparingValue(ITalonObject talonObject);
    }
}