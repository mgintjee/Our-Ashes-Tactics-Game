/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.UnityScript;

namespace HappyBananaStudio.OurAshesTactics.Cameras
{
    /// <summary>
    /// Todo
    /// </summary>
    public class CameraTransformScript
        : AbstractUnityScript
    {
        #region Public Fields

        public MapRotation.MapPositionEnum mapPosition = MapRotation.MapPositionEnum.NULL;

        #endregion Public Fields

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        public void Start()
        {
            this.transform.position = CameraPositionUtil.DeterminePositionVector(
                MapRotation.GetZ(this.mapPosition), MapRotation.GetX(this.mapPosition));
            this.transform.localEulerAngles = CameraPositionUtil.DetermineRotationVector(
                MapRotation.GetZ(this.mapPosition), MapRotation.GetX(this.mapPosition));
        }

        #endregion Public Methods
    }
}