using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Resources.Loaders.Sprites;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Sprites.IDs;
using UnityEngine;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Resources.Loaders
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