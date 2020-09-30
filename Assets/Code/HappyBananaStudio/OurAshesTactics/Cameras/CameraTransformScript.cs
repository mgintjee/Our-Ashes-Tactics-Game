/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Unity;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Cameras
{
    /// <summary>
    /// Todo
    /// </summary>
    public class CameraTransformScript
        : UnityScript
    {
        public MapRotation.MapDirectionEnum mapPosition = MapRotation.MapDirectionEnum.NULL;

        /// <summary>
        /// Todo
        /// </summary>
        public void Start()
        {
            this.GetTransform().position = CameraPositionUtil.DeterminePositionVector(
                MapRotation.GetZ(this.mapPosition), MapRotation.GetX(this.mapPosition));
            this.GetTransform().localEulerAngles = CameraPositionUtil.DetermineRotationVector(
                MapRotation.GetZ(this.mapPosition), MapRotation.GetX(this.mapPosition));
        }
    }
}