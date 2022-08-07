using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using System;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Abstrs
{
    /// <summary>
    /// Abstract Builder class Impl
    /// </summary>
    public abstract class AbstractBuilder<T>
        : IBuilder<T>
    {
        /// <summary>
        /// Build the T object with the parameters that this builder is tracking
        /// </summary>
        /// <returns>The T object</returns>
        T IBuilder<T>.Build()
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
            IList<string> invalidReasons = new List<string>();
            this.Validate(invalidReasons);
            // Check that there are no invalid reasons
            if (invalidReasons.Count == 0)
            {
                // Build the object
                return this.BuildObj();
            }
            // Throw an error
            throw ExceptionUtil.Builders.Build("Unable to build {}. Invalid attributes (Count={}): [{}]",
                typeof(T).Name, invalidReasons.Count, string.Join("\n", invalidReasons));
        }

        /// <summary>
        /// Build the T object with the parameters that this builder is tracking
        /// </summary>
        /// <returns>The T object</returns>
        protected abstract T BuildObj();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="invalidReasons"></param>
        protected virtual void Validate(IList<string> invalidReasons)
        {
        }

        /// <summary>
        /// Validate that the object is non-null. Add an invalid reason to the parameterized
        /// collection of strings if the object is invalid.
        /// </summary>
        /// <typeparam name="TObject">The type of Object to validate</typeparam>
        /// <param name="invalidReasons">
        /// The Collection of Strings representing the invalid reasons for building
        /// </param>
        /// <param name="tObject">       The Object to validate</param>
        protected void Validate<TObject>(ICollection<string> invalidReasons, TObject tObject)
        {
            if (tObject is Enum && tObject.ToString() == "None")
            {
                invalidReasons.Add(typeof(TObject).Name + " (Enum) cannot be None.");
            }
            else if (tObject == null)
            {
                invalidReasons.Add(typeof(TObject).Name + " (Object) cannot be null.");
            }
        }
    }
}