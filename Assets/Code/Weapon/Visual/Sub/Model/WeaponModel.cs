using System.Diagnostics;
using UnityEngine;

/// <summary>
/// Todo
/// </summary>
public class WeaponModel
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    // Todo
    private readonly GameObject weaponGameObject;

    private readonly WeaponIdEnum weaponId;

    // Todo
    private GameObject weaponModelGameObject;

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// </summary>
    /// <param name="weaponGameObject"></param>
    public WeaponModel(WeaponIdEnum weaponId, GameObject weaponGameObject)

    {
        logger.Debug("Constructing Object=?: Name=?",
            this.GetType().ToString(), weaponGameObject.name);

        this.weaponId = weaponId;
        this.weaponGameObject = weaponGameObject;
        this.LoadModel();

        logger.Debug("Constructed Object=?: Name=?",
            this.GetType().ToString(), weaponGameObject.name);
    }

    #endregion Public Constructors

    #region Protected Methods

    /// <summary>
    /// Todo
    /// </summary>
    protected void LoadModel()
    {
        string weaponModelName = this.weaponId.ToString();
        logger.Debug("Loading Model: Name=?", weaponModelName);
        GameObject spawnedGameObject = GameObjectSpawnerUtil.SpawnWeapon(weaponModelName);
        // Check if the spawnedGameObject is non-null
        if (spawnedGameObject != null)
        {
            this.weaponModelGameObject = spawnedGameObject;
            this.weaponModelGameObject.name = weaponModelName;
            this.weaponModelGameObject.transform.parent = this.weaponGameObject.transform;
            logger.Debug("Loaded Model: Name=?", weaponModelName);
        }
        else
        {
            logger.Error("Error Loading Model: SpawnerUtil Script loaded a null GameObject");
        }
    }

    #endregion Protected Methods
}