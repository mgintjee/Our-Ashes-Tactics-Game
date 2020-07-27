using System.Diagnostics;
using UnityEngine;

/// <summary>
/// Todo
/// </summary>
public class MechModel
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private readonly GameObject mechGameObject;
    private readonly MechIdEnum mechId;
    private GameObject mechModelGameObject;

    #endregion Private Fields

    #region Public Constructors

    public MechModel(MechIdEnum mechId, GameObject mechGameObject)

    {
        logger.Debug("Constructing Object=?: GameObjectName=?",
            this.GetType().ToString(), mechGameObject.name);

        this.mechId = mechId;
        this.mechGameObject = mechGameObject;
        this.LoadModel();

        logger.Debug("Constructed Object=?: GameObjectName=?",
            this.GetType().ToString(), mechGameObject.name);
    }

    #endregion Public Constructors

    #region Public Methods

    public GameObject GetNextEmptyWeaponMountGameObject()
    {
        GameObject weaponSlotsGameObject = this.GetWeaponSlotsGameObject(this.mechModelGameObject);

        foreach (Transform childTransform in weaponSlotsGameObject.transform)
        {
            if (childTransform.childCount == 0)
            {
                return childTransform.gameObject;
            }
        }

        return null;
    }

    #endregion Public Methods

    #region Private Methods

    private GameObject GetWeaponSlotsGameObject(GameObject gameObject)
    {
        if (gameObject != null)
        {
            string weaponSlotsGameObjectName = MechModelResourceConstants.GetWeaponSlotsGameObjectName();
            foreach (Transform childTransform in gameObject.transform)
            {
                if (weaponSlotsGameObjectName.Equals(childTransform.name))
                {
                    return childTransform.gameObject;
                }
                else if (childTransform.childCount > 0)
                {
                    return GetWeaponSlotsGameObject(childTransform.gameObject);
                }
            }
        }
        return null;
    }

    private void LoadModel()
    {
        string mechModelName = this.mechId.ToString();
        logger.Debug("Loading Model: Name=?", mechModelName);
        GameObject spawnedGameObject = SpawnerUtil.SpawnMech(mechModelName);
        // Check if the spawnedGameObject is non-null
        if (spawnedGameObject != null)
        {
            this.mechModelGameObject = spawnedGameObject;
            this.mechModelGameObject.name = mechModelName;
            this.mechModelGameObject.transform.parent = this.mechGameObject.transform;
            logger.Debug("Loaded Model: Name=?", mechModelName);
        }
        else
        {
            logger.Error("Error Loading Model: SpawnerUtil Script loaded a null GameObject");
        }
    }

    #endregion Private Methods
}