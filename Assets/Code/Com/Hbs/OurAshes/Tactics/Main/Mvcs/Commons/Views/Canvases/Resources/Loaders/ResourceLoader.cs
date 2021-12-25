using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Resources.Loaders.Sprites;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;
using UnityEngine;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Resources.Loaders
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