namespace HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Customization
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ITalonDualCustomizationReport
        : ITalonCustomizationReport
    {
        ICustomizationReport GetSecondaryCustomizationReport();
    }
}
