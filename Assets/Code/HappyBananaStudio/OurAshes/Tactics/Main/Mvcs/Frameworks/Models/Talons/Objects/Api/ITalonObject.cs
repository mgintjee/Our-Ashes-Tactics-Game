namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Objects.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Reports.Api;
    using System.Collections.Generic;

    /// <summary>
    /// Talon MvcObject Api
    /// </summary>
    public interface ITalonObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ITalonReport GetTalonReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="actionPoints"></param>
        /// <param name="movementPoints"></param>
        void InputMovableCosts(float actionPoints, float movementPoints);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="armorDamage"></param>
        /// <param name="healthDamage"></param>
        void InputDestructableCosts(float armorDamage, float healthDamage);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<ITalonOrderReport> GetTalonOrderReportSet();

        /// <summary>
        /// Todo
        /// </summary>
        void ResetForNewPhase();

        /// <summary>
        /// Todo
        /// </summary>
        void SetCubeCoordinates(ICubeCoordinates cubeCoordinates);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IMovableObject GetMovableObject();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IFireableObject GetFireableObject();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IDestructibleObject GetDestructibleObject();
    }
}