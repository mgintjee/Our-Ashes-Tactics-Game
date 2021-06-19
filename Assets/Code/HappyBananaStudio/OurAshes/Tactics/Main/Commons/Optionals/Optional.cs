using System;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals
{
    /// <summary>
    /// Optional Interface
    /// </summary>
    public class Optional<T>
    {
        // Todo
        private T _value;

        /// <summary>
        /// Private Constructor for an empty Optional
        /// </summary>
        private Optional()
        {
        }

        /// <summary>
        /// Private Constructor for a potentially populated Optional
        /// </summary>
        private Optional(T value)
        {
            _value = value;
        }

        /// <summary>
        /// Static constructor of a potentially null value
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The Optional wrapper of the value</returns>
        public static Optional<T> Of(T value)
        {
            return (value != null)
                ? new Optional<T>(value)
                : Empty();
        }

        /// <summary>
        /// Static constructor of a null value
        /// </summary>
        /// <returns>The Empty Optional wrapper</returns>
        public static Optional<T> Empty()
        {
            return new Optional<T>();
        }

        /// <summary>
        /// Return if the Optional wrapper is empty or not
        /// </summary>
        /// <returns>bool dependent on if the value is null</returns>
        public bool IsPresent()
        {
            return _value != null;
        }

        /// <summary>
        /// Sets the value for this Optional wrapper
        /// </summary>
        /// <param name="value">The value to set for this Optional wrapper</param>

        public void SetValue(T value)
        {
            _value = value;
        }

        /// <summary>
        /// Sets the value from this Optional wrapper
        /// </summary>
        /// <returns>The value that this Optional wrapper contains</returns>

        public T GetValue()
        {
            return _value;
        }

        /// <summary>
        /// Apply an action on the value that this Optional wrapper contains
        /// </summary>
        /// <param name="action">The action to invoke on the value</param>

        public void IfPresent(Action<T> action)
        {
            if (_value != null)
            {
                action.Invoke(_value);
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: {1}",
                typeof(Optional<T>).Name, (_value != null) ? _value.ToString() : "Empty");
        }
    }
}