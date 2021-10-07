using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Views.Resources.Loaders
{
    /// <summary>
    /// Todo
    /// </summary>
    public class ResourceLoader
    {
        public static Optional<Sprite> LoadUnitySprite(SpriteID spriteID)
        {
            return SpriteResourceLoader.LoadSpriteResource(spriteID);
        }
    }
}