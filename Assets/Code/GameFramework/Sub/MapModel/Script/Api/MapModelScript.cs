using UnityEngine;

/// <summary>
/// MapModelScript Api
/// </summary>
[SerializeField]
public abstract class MapModelScript
    : AbstractUnityScript
{
    #region Public Methods

    public abstract GameFrameworkScript GetGameFrameworkScript();

    public abstract MapModelObject GetMapModelObject();

    public abstract void Initialize(GameFrameworkScript gameFrameworkScript);

    #endregion Public Methods
}