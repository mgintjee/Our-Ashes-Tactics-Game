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
        /// Todo
        /// </summary>
        private Optional()
        {
        }

        /// <summary>
        /// Todo
        /// </summary>
        private Optional(T value)
        {
            _value = value;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Optional<T> Of(T value)
        {
            return new Optional<T>(value);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static Optional<T> Empty()
        {
            return new Optional<T>();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public bool IsPresent()
        {
            return _value != null;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="value"></param>

        public void SetValue(T value)
        {
            _value = value;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>

        public T GetValue()
        {
            return _value;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="action"></param>

        public void IfPresent(Action<T> action)
        {
            if (_value != null)
            {
                action.Invoke(_value);
            }
        }
    }
}