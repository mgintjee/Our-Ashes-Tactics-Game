﻿namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Fireables.Interfaces
{
    /// <summary>
    /// Fireable Attributes Interface
    /// </summary>
    public interface IFireableAttributes
    {
        /// <summary>
        /// Get the Armor Damage Points
        /// </summary>
        /// <returns></returns>
        float GetArmorDamage();

        /// <summary>
        /// Get the Armor Penetration Points
        /// </summary>
        /// <returns></returns>
        float GetArmorPenetration();

        /// <summary>
        /// Get the Accuracy Points
        /// </summary>
        /// <returns></returns>
        float GetAccuracy();

        /// <summary>
        /// Get the Health Damage Points
        /// </summary>
        /// <returns></returns>
        float GetHealthDamage();

        /// <summary>
        /// Get the Range Points
        /// </summary>
        /// <returns></returns>
        float GetRange();

        /// <summary>
        /// Get the Salvo Points
        /// </summary>
        /// <returns></returns>
        float GetSalvo();
    }
}