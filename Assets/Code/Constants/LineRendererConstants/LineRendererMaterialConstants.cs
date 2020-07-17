using UnityEngine;

/// <summary>
/// </summary>
public static class LineRendererMaterialConstants
{
    #region Private Fields

    // Todo
    private static readonly Material MATERIAL_PATH_TYPE_FIRE = MaterialResourceLoader.Path.LoadPathMaterialResource(MechActionTypeEnum.Fire);

    // Todo
    private static readonly Material MATERIAL_PATH_TYPE_MOVE = MaterialResourceLoader.Path.LoadPathMaterialResource(MechActionTypeEnum.Move);

    // Todo
    private static readonly Material MATERIAL_PATH_TYPE_WAIT = MaterialResourceLoader.Path.LoadPathMaterialResource(MechActionTypeEnum.Wait);

    #endregion Private Fields

    #region Public Methods

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public static Material GetMaterialPathTypeFire()
    {
        return MATERIAL_PATH_TYPE_FIRE;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public static Material GetMaterialPathTypeMove()
    {
        return MATERIAL_PATH_TYPE_MOVE;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public static Material GetMaterialPathTypeWait()
    {
        return MATERIAL_PATH_TYPE_WAIT;
    }

    #endregion Public Methods
}