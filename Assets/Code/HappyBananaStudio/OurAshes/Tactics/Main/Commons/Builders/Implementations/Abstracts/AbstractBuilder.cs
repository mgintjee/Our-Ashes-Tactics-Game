using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using System;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts
{
    /// <summary>
    /// Abstract Builder class Implementation
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
            ISet<string> invalidReasons = new HashSet<string>();
            this.Validate(invalidReasons);
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
        /// Build the T object with the parameters that this builder is tracking
        /// </summary>
        /// <returns>The T object</returns>
        protected abstract T BuildObj();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="invalidReasons"></param>
        protected abstract void Validate(ISet<string> invalidReasons);

        /// <summary>
        /// Validate that the collection of objects is non-null and not empty. Add an invalid reason
        /// to the parameterized collection of strings if the collection is invalid.
        /// </summary>
        /// <typeparam name="TObject">The type of elements in the Collection to validate</typeparam>
        /// <param name="invalidReasons">
        /// The Collection of Strings representing the invalid reasons for building
        /// </param>
        /// <param name="tCollection">   The Collection of elements to validate</param>
        protected void Validate<TObject>(ICollection<string> invalidReasons, ICollection<TObject> tCollection)
        {
            if (tCollection == null)
            {
                invalidReasons.Add("Collection:" + typeof(TObject) + " cannot be null.");
            }
            else if (tCollection.Count == 0)
            {
                invalidReasons.Add("Collection:" + typeof(TObject) + " cannot be empty.");
            }
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
            if (tObject == null)
            {
                invalidReasons.Add("Object:" + typeof(TObject) + " cannot be null.");
            }
        }

        /// <summary>
        /// Validate that the enum is not none. Add an invalid reason to the parameterized
        /// collection of strings if the enum is invalid.
        /// </summary>
        /// <typeparam name="TEnum">The type of Enum to validate</typeparam>
        /// <param name="invalidReasons">
        /// The Collection of Strings representing the invalid reasons for building
        /// </param>
        /// <param name="tEnum">         The Enum to validate</param>
        protected void ValidateEnum<TEnum>(ICollection<string> invalidReasons, TEnum tEnum)
            where TEnum : Enum
        {
            if (tEnum.ToString() == "None")
            {
                invalidReasons.Add("Enum:" + typeof(TEnum) + " cannot be None.");
            }
        }
    }
}