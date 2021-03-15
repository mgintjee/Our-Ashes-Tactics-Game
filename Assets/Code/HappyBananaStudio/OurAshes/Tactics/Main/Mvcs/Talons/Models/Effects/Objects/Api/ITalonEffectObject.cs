namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Effects.Objects.Api
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ITalonEffectObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        float GetArmorEffect();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        float GetHealthEffect();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        float GetActionEffect();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        float GetMovementEffect();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        int GetDuration();
    }
}