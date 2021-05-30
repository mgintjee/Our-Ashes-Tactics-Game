using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Schemes.Emblems.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Sprites.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Schemes.Emblems.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Schemes.Emblems.Implementations.Abstracts
{
    /// <summary>
    /// Abstract Emblem Scheme Implementation
    /// </summary>
    public abstract class AbstractEmblemScheme
        : IEmblemScheme
    {
        // Todo
        protected EmblemSchemeID emblemSchemeID;

        // Todo
        protected SpriteID backgroundID;

        // Todo
        protected SpriteID foregroundID;

        // Todo
        protected SpriteID iconID;

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: {1}={2}" +
                "\nIcon {3}={4}" +
                "\nForeground {5}={6}" +
                "\nBackground {7}={8}",
                this.GetType().Name,
                typeof(EmblemSchemeID).Name, this.emblemSchemeID,
                typeof(SpriteID).Name, this.iconID,
                typeof(SpriteID).Name, this.foregroundID,
                typeof(SpriteID).Name, this.backgroundID);
        }

        SpriteID IEmblemScheme.GetBackgroundID()
        {
            return this.backgroundID;
        }

        EmblemSchemeID IEmblemScheme.GetEmblemSchemeID()
        {
            return emblemSchemeID;
        }

        SpriteID IEmblemScheme.GetForegroundID()
        {
            return this.foregroundID;
        }

        SpriteID IEmblemScheme.GetIconID()
        {
            return this.iconID;
        }
    }
}