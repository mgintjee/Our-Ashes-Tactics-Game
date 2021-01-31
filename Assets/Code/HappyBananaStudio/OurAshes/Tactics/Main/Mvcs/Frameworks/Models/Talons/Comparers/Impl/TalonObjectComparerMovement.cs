namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Comparers.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Comparers.Abs;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Reports.Api;

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