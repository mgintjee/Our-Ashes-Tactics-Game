using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Optionals;
using System;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Internals.Optionals
{
    /// <summary>
    /// IOptional Implementation
    /// </summary>
    public class Optional<T>
        : IOptional<T>
    {
        // Todo
        private T value;

        /// <summary>
        /// Private Constructor for an empty IOptional
        /// </summary>
        private Optional()
        {
        }

        /// <summary>
        /// Private Constructor for a potentially populated IOptional
        /// </summary>
        private Optional(T value)
        {
            this.value = value;
        }

        /// <summary>
        /// Static constructor of a potentially null value
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The IOptional wrapper of the value</returns>
        public static Optional<T> Of(T value)
        {
            return (value != null)
                ? new Optional<T>(value)
                : Empty();
        }

        /// <summary>
        /// Static constructor of a null value
        /// </summary>
        /// <returns>The Empty IOptional wrapper</returns>
        public static Optional<T> Empty()
        {
            return new Optional<T>();
        }

        /// <summary>
        /// Return if the IOptional wrapper is empty or not
        /// </summary>
        /// <returns>bool dependent on if the value is null</returns>
        public bool IsPresent()
        {
            return value != null;
        }

        /// <summary>
        /// Sets the value for this IOptional wrapper
        /// </summary>
        /// <param name="value">The value to set for this IOptional wrapper</param>

        public void SetValue(T value)
        {
            this.value = value;
        }

        /// <summary>
        /// Sets the value from this IOptional wrapper
        /// </summary>
        /// <returns>The value that this IOptional wrapper contains</returns>

        public T GetValue()
        {
            return value;
        }

        /// <summary>
        /// Apply an action on the value that this IOptional wrapper contains
        /// </summary>
        /// <param name="action">The action to invoke on the value</param>

        public void IfPresent(Action<T> action)
        {
            if (value != null)
            {
                action.Invoke(value);
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: {1}",
                typeof(Optional<T>).Name, (value != null) ? value.ToString() : "Empty");
        }
    }
}