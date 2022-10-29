using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Resources.Loaders.Sprites;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;
using UnityEngine;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Resources.Loaders
{
    /// <summary>
    /// Todo
    /// </summary>
    public class ResourceLoader
    {
        public static IOptional<Sprite> LoadUnitySprite(SpriteID spriteID)
        {
            return SpriteResourceLoader.LoadSpriteResource(spriteID);
        }
    }
}