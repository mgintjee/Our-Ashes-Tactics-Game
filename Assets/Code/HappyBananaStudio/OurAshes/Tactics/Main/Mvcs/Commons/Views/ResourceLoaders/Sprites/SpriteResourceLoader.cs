namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.ResourceLoaders.Sprites
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Sprites.Enums;
    using System.Diagnostics;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public class SpriteResourceLoader
    {
        // Todo
        private static readonly string SPRITE_FOLDER_HOME = "Sprites/";

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="spriteId"></param>
        /// <returns></returns>
        public static Sprite LoadSpriteResource(SpriteID spriteId)
        {
            if (spriteId != SpriteID.None)
            {
                return LoadSpriteResource(SPRITE_FOLDER_HOME + spriteId.ToString());
            }
            throw ExceptionUtil.Arguments.Build("Unable to {}. {} is not supported.", new StackFrame().GetMethod().Name);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="spritePath"></param>
        /// <returns></returns>
        private static Sprite LoadSpriteResource(string spritePath)
        {
            return Resources.Load<Sprite>(spritePath);
        }
    }
}