﻿using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Exceptions;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;
using System.Diagnostics;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Internals.Optionals;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Resources.Loaders.Sprites
{
    /// <summary>
    /// Todo
    /// </summary>
    public class SpriteResourceLoader
    {
        // Todo
        private static readonly string SPRITE_FOLDER_HOME = "Sprites/sprite_";

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="spriteID"></param>
        /// <returns></returns>
        public static IOptional<UnityEngine.Sprite> LoadSpriteResource(SpriteID spriteID)
        {
            if (spriteID != SpriteID.None)
            {
                string path = SPRITE_FOLDER_HOME + spriteID.ToString();
                UnityEngine.Sprite sprite = LoadSpriteResource(path);
                if (sprite != null)
                {
                    // Todo have a way of spltting off of camel case
                    return Optional<UnityEngine.Sprite>.Of(sprite);
                }
                throw ExceptionUtil.Arguments.Build("Unable to {}. {} did not provide a Sprite.",
                    new StackFrame().GetMethod().Name, path);
            }
            throw ExceptionUtil.Arguments.Build("Unable to {}. {} is not supported.",
                new StackFrame().GetMethod().Name, spriteID);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="spritePath"></param>
        /// <returns></returns>
        private static UnityEngine.Sprite LoadSpriteResource(string spritePath)
        {
            return UnityEngine.Resources.Load<UnityEngine.Sprite>(spritePath);
        }
    }
}