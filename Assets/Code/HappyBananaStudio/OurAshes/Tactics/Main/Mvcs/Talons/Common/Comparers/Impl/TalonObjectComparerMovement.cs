using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Comparers.Abs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Reports.Api;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Comparers.Impl
{
    /// <summary>
    /// Todo
    /// </summary>
    public class TalonObjectComparerMovement
        : AbstractTalonObjectComparer
    {
        /// <inheritdoc/>
        protected override float GetComparingValue(ITalonReport talonReport)
        {
            return talonReport.GetCurrentTalonAttributesReport().GetMovementPoints();
        }
    }
}