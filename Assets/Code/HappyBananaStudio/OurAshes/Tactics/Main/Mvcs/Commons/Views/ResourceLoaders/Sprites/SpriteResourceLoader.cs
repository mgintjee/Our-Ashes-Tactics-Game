namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.ResourceLoaders.Sprites
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Sprites.IDs;
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
        /// <param name="spriteID"></param>
        /// <returns></returns>
        public static Sprite LoadSpriteResource(SpriteID spriteID)
        {
            if (spriteID != SpriteID.None)
            {
                return LoadSpriteResource(SPRITE_FOLDER_HOME + spriteID.ToString());
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