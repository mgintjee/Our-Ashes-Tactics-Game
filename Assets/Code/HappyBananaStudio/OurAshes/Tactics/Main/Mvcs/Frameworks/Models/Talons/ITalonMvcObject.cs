namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons
{
    /// <summary>
    /// Talon MvcObject Api
    /// </summary>
    public interface ITalonMvcObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ITalonObjectReport GetTalonObjectReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="actionPoints"></param>
        /// <param name="movementPoints"></param>
        void InputMovableCosts(int actionPoints, int movementPoints);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="armorDamage"></param>
        /// <param name="healthDamage"></param>
        void InputDestructableCosts(double armorDamage, double healthDamage);
    }
}