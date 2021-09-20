using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Materials.Indices.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Materials.Indices.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct MaterialIndices
        : IMaterialIndices
    {
        // Todo
        private readonly int primaryIndex;

        // Todo
        private readonly int secondaryIndex;

        // Todo
        private readonly int tertiaryIndex;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="primaryIndex">  </param>
        /// <param name="secondaryIndex"></param>
        /// <param name="tertiaryIndex"> </param>
        private MaterialIndices(int primaryIndex, int secondaryIndex, int tertiaryIndex)
        {
            this.primaryIndex = primaryIndex;
            this.secondaryIndex = secondaryIndex;
            this.tertiaryIndex = tertiaryIndex;
        }

        /// <inheritdoc/>
        int IMaterialIndices.GetPrimaryIndex()
        {
            return this.primaryIndex;
        }

        /// <inheritdoc/>
        int IMaterialIndices.GetSecondaryIndex()
        {
            return this.secondaryIndex;
        }

        /// <inheritdoc/>
        int IMaterialIndices.GetTertiaryIndex()
        {
            return this.tertiaryIndex;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private int primaryIndex = -1;

            // Todo
            private int secondaryIndex = -1;

            // Todo
            private int tertiaryIndex = -1;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IMaterialIndices Build()
            {
                return new MaterialIndices(
                    primaryIndex, secondaryIndex, tertiaryIndex);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            public Builder SetPrimaryIndex(int index)
            {
                primaryIndex = index;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            public Builder SetSecondaryIndex(int index)
            {
                secondaryIndex = index;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            public Builder SetTertiaryIndex(int index)
            {
                tertiaryIndex = index;
                return this;
            }
        }
    }
}