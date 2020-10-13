/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Attributes;
using HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Impl.Attributes.Talons
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct MovableAttributesImpl
        : IMovableAttributes
    {
        // Todo
        private readonly int movePoints;

        // Todo
        private readonly int actionPoints;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="movePoints">
        /// </param>
        /// <param name="turnPoints">
        /// </param>
        public MovableAttributesImpl(int movePoints, int turnPoints)
        {
            this.movePoints = movePoints;
            this.actionPoints = turnPoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="movableAttributeCollection">
        /// </param>
        private MovableAttributesImpl(ICollection<IMovableAttributes> movableAttributeCollection)
        {
            int movePoints = 0;
            int turnPoints = 0;
            foreach (IMovableAttributes movableAttributes in movableAttributeCollection)
            {
                if (movableAttributes != null)
                {
                    movePoints += movableAttributes.GetMovePoints();
                    turnPoints += movableAttributes.GetActionPoints();
                }
            }
            this.movePoints = movePoints;
            this.actionPoints = turnPoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ": movePoints = " + this.movePoints +
            ", actionPoints = " + this.actionPoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int IMovableAttributes.GetMovePoints()
        {
            return this.movePoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int IMovableAttributes.GetActionPoints()
        {
            return this.actionPoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ICollection<IMovableAttributes> movableAttributesCollection = null;

            // Todo
            private int movePoints;

            // Todo
            private bool setMovePoints = false;

            // Todo
            private bool setTurnPoints = false;

            // Todo
            private int turnPoints;

            /// <summary>
            /// Build the FireableAttributes with the set parameters
            /// </summary>
            /// <returns>
            /// The IMovableAttributes
            /// </returns>
            public IMovableAttributes Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    if (this.movableAttributesCollection != null)
                    {
                        // Instantiate a new Report
                        return new MovableAttributesImpl(this.movableAttributesCollection);
                    }
                    else
                    {
                        // Instantiate a new Report
                        return new MovableAttributesImpl(this.movePoints, this.turnPoints);
                    }
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the Collection: MovableAttributes
            /// </summary>
            /// <param name="movableAttributesCollection">
            /// The Collection: MovableAttributes to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetMovableAttributesCollection(ICollection<IMovableAttributes> movableAttributesCollection)
            {
                this.movableAttributesCollection = movableAttributesCollection;
                return this;
            }

            /// <summary>
            /// Set the value of the movePoints
            /// </summary>
            /// <param name="movePoints">
            /// The movePoints to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetMovePoints(int movePoints)
            {
                this.movePoints = movePoints;
                this.setMovePoints = true;
                return this;
            }

            /// <summary>
            /// Set the value of the movePoints
            /// </summary>
            /// <param name="turnPoints">
            /// The movePoints to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetTurnPoints(int turnPoints)
            {
                this.turnPoints = turnPoints;
                this.setTurnPoints = true;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                // Check if the movableAttributesCollection has been set
                if (this.movableAttributesCollection == null)
                {
                    // Check that movePoints has been set
                    if (!this.setMovePoints)
                    {
                        argumentExceptionSet.Add("movePoints has not been set");
                    }
                    // Check that turnPoints has been set
                    if (!this.setTurnPoints)
                    {
                        argumentExceptionSet.Add("turnPoints has not been set");
                    }
                }
                else
                {
                    // Check if the movableAttributesCollection is valid
                    if (this.movableAttributesCollection.Count == 0)
                    {
                        argumentExceptionSet.Add("Collection: " + typeof(IMovableAttributes) + " is empty.");
                    }
                }
                return argumentExceptionSet;
            }
        }
    }
}
