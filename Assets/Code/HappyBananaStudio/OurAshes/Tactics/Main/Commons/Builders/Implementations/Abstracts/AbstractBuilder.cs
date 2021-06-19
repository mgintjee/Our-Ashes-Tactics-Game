using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts
{
    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractBuilder<T>
    {
        /// <summary>
        /// Build the T object with the parameters that this builder is tracking
        /// </summary>
        /// <returns>The T object</returns>
        public T Build()
        {
            return ValidateBuild();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        protected T ValidateBuild()
        {
            // Collect all of the reasons that this builder cannot build the object
            ISet<string> invalidReasons = this.GetInvalidReasons();
            // Check that there are no invalid reasons
            if (invalidReasons.Count == 0)
            {
                // Build the object
                return this.BuildObj();
            }
            // Throw an error
            throw ExceptionUtil.Builders.Build("Unable to build {}. Invalid attributes (Count={}): [{}]",
                typeof(T), invalidReasons.Count, string.Join("\n", invalidReasons));
        }

        /// <summary>
        /// Get the set of string reasons why this builder cannot build the T object
        /// </summary>
        /// <returns>The set of string reasons. Empty if valid</returns>
        protected abstract ISet<string> GetInvalidReasons();

        /// <summary>
        /// Build the T object with the parameters that this builder is tracking
        /// </summary>
        /// <returns>The T object</returns>
        protected abstract T BuildObj();
    }
}