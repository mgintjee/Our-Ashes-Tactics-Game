namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.ResourceLoaders.Sprites
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Sprites.Enums;
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
        /// <param name="spriteId">
        /// </param>
        /// <returns>
        /// </returns>
        public static Sprite LoadSpriteResource(SpriteId spriteId)
        {
            if (spriteId != SpriteId.None)
            {
                return LoadSpriteResource(SPRITE_FOLDER_HOME + spriteId.ToString());
            }
            else
            {
                throw ExceptionUtil.Arguments.Build("Unable to ?. ? is not supported.", new StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="spritePath">
        /// </param>
        /// <returns>
        /// </returns>
        private static Sprite LoadSpriteResource(string spritePath)
        {
            return Resources.Load<Sprite>(spritePath);
        }
    }
}