using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Icons.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Icons.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Icons.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Icons.Details.Managers
{
    /// <summary>
    /// Todo
    /// </summary>
    public class IconIDDetailsManager
    {
        private static readonly IDictionary<IconID, IIconDetails> ICON_ID_DETAILS = Internals.BuildModelIDIconDetails();

        public static Optional<IIconDetails> GetDetails(IconID id)
        {
            return Optional<IIconDetails>.Of(
                (ICON_ID_DETAILS.ContainsKey(id))
                    ? ICON_ID_DETAILS[id]
                    : null);
        }

        private class Internals
        {
            public static IDictionary<IconID, IIconDetails> BuildModelIDIconDetails()
            {
                return new Dictionary<IconID, IIconDetails>()
                {
                    { IconID.FactionUO, GetFactionUOIconDetails() },
                    { IconID.FactionBT, GetFactionBTIconDetails() },
                    { IconID.FactionTT, GetFactionTTIconDetails() },
                    { IconID.FactionFL, GetFactionFLIconDetails() },
                    { IconID.UnitModelMaa, GetModelMaaIconDetails() },
                    { IconID.UnitModelMba, GetModelMbaIconDetails() },
                    { IconID.UnitModelMca, GetModelMcaIconDetails() }
                };
            }

            private static IIconDetails GetFactionBTIconDetails()
            {
                return IconDetailsImpl.Builder.Get()
                        .SetPrimaryID(SpriteID.AsciiA)
                        .SetSecondaryID(SpriteID.AsciiG)
                        .SetTertiaryID(SpriteID.AsciiH)
                        .Build();
            }

            private static IIconDetails GetFactionUOIconDetails()
            {
                return IconDetailsImpl.Builder.Get()
                        .SetPrimaryID(SpriteID.AsciiA)
                        .SetSecondaryID(SpriteID.AsciiG)
                        .SetTertiaryID(SpriteID.AsciiH)
                        .Build();
            }

            private static IIconDetails GetFactionTTIconDetails()
            {
                return IconDetailsImpl.Builder.Get()
                        .SetPrimaryID(SpriteID.AsciiA)
                        .SetSecondaryID(SpriteID.AsciiG)
                        .SetTertiaryID(SpriteID.AsciiH)
                        .Build();
            }

            private static IIconDetails GetFactionFLIconDetails()
            {
                return IconDetailsImpl.Builder.Get()
                        .SetPrimaryID(SpriteID.AsciiA)
                        .SetSecondaryID(SpriteID.AsciiG)
                        .SetTertiaryID(SpriteID.AsciiH)
                        .Build();
            }

            private static IIconDetails GetModelMaaIconDetails()
            {
                return IconDetailsImpl.Builder.Get()
                        .SetPrimaryID(SpriteID.CapsuleBorderless)
                        .SetSecondaryID(SpriteID.AsciiW)
                        .SetTertiaryID(SpriteID.AsciiZ)
                        .Build();
            }

            private static IIconDetails GetModelMbaIconDetails()
            {
                return IconDetailsImpl.Builder.Get()
                        .SetPrimaryID(SpriteID.SquareBorderless)
                        .SetSecondaryID(SpriteID.AsciiW)
                        .SetTertiaryID(SpriteID.AsciiZ)
                        .Build();
            }

            private static IIconDetails GetModelMcaIconDetails()
            {
                return IconDetailsImpl.Builder.Get()
                        .SetPrimaryID(SpriteID.TriangleBorderless)
                        .SetSecondaryID(SpriteID.AsciiX)
                        .SetTertiaryID(SpriteID.AsciiY)
                        .Build();
            }
        }
    }
}