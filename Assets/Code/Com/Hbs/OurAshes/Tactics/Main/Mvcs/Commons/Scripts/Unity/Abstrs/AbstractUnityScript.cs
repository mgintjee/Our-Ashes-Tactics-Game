using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Inters;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Abstrs
{
    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractUnityScript
        : MonoBehaviour, IUnityScript
    {
        /// <inheritdoc/>
        void IUnityScript.Destroy()
        {
            Destroy(this.GetGameObject());
            Destroy(this);
        }

        /// <inheritdoc/>
        GameObject IUnityScript.GetGameObject()
        {
            return this.GetGameObject();
        }

        /// <inheritdoc/>
        Transform IUnityScript.GetTransform()
        {
            return this.GetTransform();
        }

        /// <inheritdoc/>
        void IUnityScript.SetParent(IUnityScript unityScript)
        {
            this.SetParent(unityScript.GetTransform());
        }

        /// <inheritdoc/>
        void IUnityScript.SetParent(Transform transform)
        {
            this.SetParent(transform);
        }

        /// <inheritdoc/>
        string IUnityScript.GetName()
        {
            return this.GetGameObject().name;
        }

        IUnityScript IUnityScript.GetParent()
        {
            return this.transform.parent.GetComponent<IUnityScript>();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="transform"></param>
        protected void SetParent(Transform transform)
        {
            this.transform.SetParent(transform);
            this.transform.localPosition = Vector3.zero;
            this.transform.localScale = Vector3.one;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        protected GameObject GetGameObject()
        {
            return this.gameObject;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        protected Transform GetTransform()
        {
            return this.transform;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class ScriptBuilder
        {
            /// <summary>
            /// Script Builder Interface
            /// </summary>
            public interface IScriptBuilder<T>
                : IBuilder<T>
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <returns></returns>
                IScriptBuilder<T> SetName(string name);

                /// <summary>
                /// Todo
                /// </summary>
                /// <returns></returns>
                IScriptBuilder<T> SetParent(IUnityScript unityScript);
            }

            /// <summary>
            /// Abstract Script Builder
            /// </summary>
            public abstract class AbstractScriptBuilder<T>
                : AbstractBuilder<T>, IScriptBuilder<T>
            {
                // Todo
                protected string name;

                // Todo
                protected IUnityScript unityScript;

                /// <inheritdoc/>
                IScriptBuilder<T> IScriptBuilder<T>.SetName(string name)
                {
                    this.name = name;
                    return this;
                }

                /// <inheritdoc/>
                IScriptBuilder<T> IScriptBuilder<T>.SetParent(IUnityScript unityScript)
                {
                    this.unityScript = unityScript;
                    return this;
                }

                /// <inheritdoc/>
                protected override T BuildObj()
                {
                    return this.BuildScript(new UnityEngine.GameObject(this.name));
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, this.name);
                    this.Validate(invalidReasons, this.unityScript);
                    this.ValidateScriptBuilder(invalidReasons);
                }

                protected void ApplyScriptValues(IUnityScript unityScript)
                {
                    unityScript.GetGameObject().name = this.name;
                    unityScript.SetParent(this.unityScript);
                }

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="invalidReasons"></param>
                protected virtual void ValidateScriptBuilder(ISet<string> invalidReasons)
                {
                }

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="gameObject"></param>
                /// <returns></returns>
                protected abstract T BuildScript(UnityEngine.GameObject gameObject);
            }
        }
    }
}