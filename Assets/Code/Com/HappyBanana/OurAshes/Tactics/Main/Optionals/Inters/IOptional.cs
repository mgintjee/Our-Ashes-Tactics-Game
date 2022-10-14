using System;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Optionals
{
    /// <summary>
    /// IOptional Interface
    /// </summary>
    public interface IOptional<T>
    {

        /// <summary>
        /// Return if the IOptional wrapper is empty or not
        /// </summary>
        /// <returns>bool dependent on if the value is null</returns>
         bool IsPresent();

        /// <summary>
        /// Sets the value for this IOptional wrapper
        /// </summary>
        /// <param name="value">The value to set for this IOptional wrapper</param>

         void SetValue(T value);

        /// <summary>
        /// Sets the value from this IOptional wrapper
        /// </summary>
        /// <returns>The value that this IOptional wrapper contains</returns>

         T GetValue();

        /// <summary>
        /// Apply an action on the value that this IOptional wrapper contains
        /// </summary>
        /// <param name="action">The action to invoke on the value</param>

         void IfPresent(Action<T> action);
    }
}