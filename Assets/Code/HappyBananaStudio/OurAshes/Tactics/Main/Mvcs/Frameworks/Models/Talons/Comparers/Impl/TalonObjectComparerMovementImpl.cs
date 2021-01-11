namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Comparers.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Comparers.Abs;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Objects.Api;

    /// <summary>
    /// Todo
    /// </summary>
    public class TalonObjectComparerMovementImpl
        : AbstractTalonObjectComparerImpl
    {
        /// <inheritdoc/>
        protected override float GetComparingValue(ITalonObject talonObject)
        {
            return talonObject.GetTalonReport().GetCurrentMovementPoints();
        }
    }
}