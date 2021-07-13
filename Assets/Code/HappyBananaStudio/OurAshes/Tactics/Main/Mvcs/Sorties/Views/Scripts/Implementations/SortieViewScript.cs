using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Implementations.Abstract;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Scripts.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Scripts.Implementations
{
    /// <summary>
    /// Sortie View Script Implementation
    /// </summary>
    public class SortieViewScript : AbstractUnityScript, ISortieViewScript
    {
        /// <summary>
        /// Builder class for this object
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Builder Interface for this object
            /// </summary>
            public interface IBuilder : IBuilder<ISortieViewScript>
            {
                IBuilder SetMvcFrameConstruction(IMvcFrameConstruction mvcFrameConstruction);
            }

            /// <summary>
            /// Get the Builder for this object
            /// </summary>
            /// <returns></returns>
            public static IBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Builder Implementation for this object
            /// </summary>
            private class InternalBuilder : AbstractBuilder<ISortieViewScript>, IBuilder
            {
                // Todo
                private IMvcFrameConstruction _mvcFrameConstruction;

                /// <inheritdoc/>
                IBuilder IBuilder.SetMvcFrameConstruction(IMvcFrameConstruction mvcFrameConstruction)
                {
                    _mvcFrameConstruction = mvcFrameConstruction;
                    return this;
                }

                /// <inheritdoc/>
                protected override ISortieViewScript BuildObj()
                {
                    GameObject gameObject = new GameObject(typeof(ISortieViewScript).Name + ": " + _mvcFrameConstruction.GetMvcType());
                    ISortieViewScript sortieViewScript = gameObject.AddComponent<SortieViewScript>();
                    sortieViewScript.SetParent(_mvcFrameConstruction.GetUnityScript());
                    return gameObject.GetComponent<ISortieViewScript>();
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _mvcFrameConstruction);
                }
            }
        }
    }
}