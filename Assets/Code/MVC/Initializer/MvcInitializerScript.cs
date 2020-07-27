using UnityEngine;

/// <summary>
/// MvcInitializer Script Api
/// </summary>
public abstract class MvcInitializerScript
    : AbstractUnityScript
{
    #region Private Fields

    private MvcFrameworkScript mvcFrameworkScript;

    #endregion Private Fields

    #region Public Methods

    public void Start()
    {
        GameObject mvcFrameworkGameObject = new GameObject(MvcFrameworkConstants.Script.GetMvcFrameworkGameObjectName());
        MvcFrameworkScript mvcFrameworkScript = mvcFrameworkGameObject.AddComponent<MvcFrameworkScriptImpl>();
        mvcFrameworkGameObject.transform.SetParent(this.transform);
        this.mvcFrameworkScript = mvcFrameworkScript;
    }

    public void FixedUpdate()
    {
        if (this.mvcFrameworkScript != null)
        {
            if (!this.mvcFrameworkScript.IsInitialized())
            {
                this.mvcFrameworkScript.Initialize(BuildMvcInitializationReport());
            }
        }
    }

    #endregion Public Methods

    #region Protected Methods

    protected abstract MvcInitializationReport BuildMvcInitializationReport();

    #endregion Protected Methods
}