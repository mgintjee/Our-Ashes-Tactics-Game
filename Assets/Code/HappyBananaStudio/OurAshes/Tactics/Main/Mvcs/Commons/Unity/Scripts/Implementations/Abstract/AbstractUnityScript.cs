﻿using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Unity.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Unity.Scripts.Implementations.Abstract
{
    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractUnityScript : MonoBehaviour, IUnityScript
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
    }
}