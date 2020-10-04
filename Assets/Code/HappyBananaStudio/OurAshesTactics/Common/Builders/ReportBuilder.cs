/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Reports.Faction;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Reports.Game;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Reports.HexTiles;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Reports.Hoplites;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Reports.Maps.Game;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Reports.Mvc.Initializers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Reports.Mvc.Models;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Reports.Phalanx;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Reports.Rosters;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Reports.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Reports.Talons.Action;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Reports.Talons.Attributes;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Reports.Talons.Combat;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Reports.Talons.Customization;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Reports.Talons.Turn;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Reports.Weapons;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Builders
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class ReportBuilder
    {
        /// <summary>
        /// Todo
        /// </summary>
        public static class Customization
        {
            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            public static TalonCustomizationReportImpl.Builder GetBuilder()
            {
                return new TalonCustomizationReportImpl.Builder();
            }

            public static class Color
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <returns>
                /// </returns>
                public static ColorSchemeReportImpl.Builder GetBuilder()
                {
                    return new ColorSchemeReportImpl.Builder();
                }
            }

            public static class Emblem
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <returns>
                /// </returns>
                public static EmblemSchemeReportImpl.Builder GetBuilder()
                {
                    return new EmblemSchemeReportImpl.Builder();
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public static class Faction
        {
            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            public static FactionReportImpl.Builder GetBuilder()
            {
                return new FactionReportImpl.Builder();
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public static class Game
        {
            /// <summary>
            /// Todo
            /// </summary>
            public static class Action
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <returns>
                /// </returns>
                public static GameActionReportImpl.Builder GetBuilder()
                {
                    return new GameActionReportImpl.Builder();
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public static class HexTile
        {
            /// <summary>
            /// Todo
            /// </summary>
            public static class Construction
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <returns>
                /// </returns>
                public static HexTileConstructionReportImpl.Builder GetBuilder()
                {
                    return new HexTileConstructionReportImpl.Builder();
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            public static class Information
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <returns>
                /// </returns>
                public static HexTileInformationReportImpl.Builder GetBuilder()
                {
                    return new HexTileInformationReportImpl.Builder();
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public static class Hoplite
        {
            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            public static HopliteReportImpl.Builder GetBuilder()
            {
                return new HopliteReportImpl.Builder();
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public static class Maps
        {
            /// <summary>
            /// Todo
            /// </summary>
            public static class Game
            {
                /// <summary>
                /// Todo
                /// </summary>
                public static class Construction
                {
                    /// <summary>
                    /// Todo
                    /// </summary>
                    /// <returns>
                    /// </returns>
                    public static GameMapConstructionReportImpl.Builder GetBuilder()
                    {
                        return new GameMapConstructionReportImpl.Builder();
                    }
                }

                /// <summary>
                /// Todo
                /// </summary>
                public static class Information
                {
                    /// <summary>
                    /// Todo
                    /// </summary>
                    /// <returns>
                    /// </returns>
                    public static GameMapInformationReportImpl.Builder GetBuilder()
                    {
                        return new GameMapInformationReportImpl.Builder();
                    }
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public static class Mvc
        {
            /// <summary>
            /// Todo
            /// </summary>
            public static class Initialization
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <returns>
                /// </returns>
                public static MvcInitializationReportImpl.Builder GetBuilder()
                {
                    return new MvcInitializationReportImpl.Builder();
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            public static class Model
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <returns>
                /// </returns>
                public static MvcModelInformationReportImpl.Builder GetBuilder()
                {
                    return new MvcModelInformationReportImpl.Builder();
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public static class Phalanx
        {
            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            public static PhalanxReportImpl.Builder GetBuilder()
            {
                return new PhalanxReportImpl.Builder();
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public static class Roster
        {
            /// <summary>
            /// Todo
            /// </summary>
            public static class Construction
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <returns>
                /// </returns>
                public static RosterConstructionReportImpl.Builder GetBuilder()
                {
                    return new RosterConstructionReportImpl.Builder();
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            public static class Information
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <returns>
                /// </returns>
                public static RosterInformationReportImpl.Builder GetBuilder()
                {
                    return new RosterInformationReportImpl.Builder();
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public static class Talon
        {
            /// <summary>
            /// Todo
            /// </summary>
            public static class Action
            {
                /// <summary>
                /// Todo
                /// </summary>
                public static class Order
                {
                    /// <summary>
                    /// Todo
                    /// </summary>
                    /// <returns>
                    /// </returns>
                    public static TalonActionOrderReportImpl.Builder GetBuilder()
                    {
                        return new TalonActionOrderReportImpl.Builder();
                    }
                }

                /// <summary>
                /// Todo
                /// </summary>
                public static class Result
                {
                    /// <summary>
                    /// Todo
                    /// </summary>
                    /// <returns>
                    /// </returns>
                    public static TalonActionResultReportImpl.Builder GetBuilder()
                    {
                        return new TalonActionResultReportImpl.Builder();
                    }
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            public static class Attributes
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <returns>
                /// </returns>
                public static TalonAttributesReportImpl.Builder GetBuilder()
                {
                    return new TalonAttributesReportImpl.Builder();
                }

                /// <summary>
                /// Todo
                /// </summary>
                public static class Destructible
                {
                    /// <summary>
                    /// Todo
                    /// </summary>
                    /// <returns>
                    /// </returns>
                    public static DestructibleReportImpl.Builder GetBuilder()
                    {
                        return new DestructibleReportImpl.Builder();
                    }
                }

                /// <summary>
                /// Todo
                /// </summary>
                public static class Fireable
                {
                    /// <summary>
                    /// Todo
                    /// </summary>
                    /// <returns>
                    /// </returns>
                    public static FireableReportImpl.Builder GetBuilder()
                    {
                        return new FireableReportImpl.Builder();
                    }
                }

                /// <summary>
                /// Todo
                /// </summary>
                public static class Movable
                {
                    /// <summary>
                    /// Todo
                    /// </summary>
                    /// <returns>
                    /// </returns>
                    public static MovableReportImpl.Builder GetBuilder()
                    {
                        return new MovableReportImpl.Builder();
                    }
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            public static class Combat
            {
                /// <summary>
                /// Todo
                /// </summary>
                public static class Order
                {
                    /// <summary>
                    /// Todo
                    /// </summary>
                    /// <returns>
                    /// </returns>
                    public static TalonCombatOrderReportImpl.Builder GetBuilder()
                    {
                        return new TalonCombatOrderReportImpl.Builder();
                    }
                }

                /// <summary>
                /// Todo
                /// </summary>
                public static class Result
                {
                    /// <summary>
                    /// Todo
                    /// </summary>
                    /// <returns>
                    /// </returns>
                    public static TalonCombatResultReportImpl.Builder GetBuilder()
                    {
                        return new TalonCombatResultReportImpl.Builder();
                    }
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            public static class Construction
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <returns>
                /// </returns>
                public static TalonConstructionReportImpl.Builder GetBuilder()
                {
                    return new TalonConstructionReportImpl.Builder();
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            public static class Identification
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <returns>
                /// </returns>
                public static TalonIdentificationReportImpl.Builder GetBuilder()
                {
                    return new TalonIdentificationReportImpl.Builder();
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            public static class Information
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <returns>
                /// </returns>
                public static TalonInformationReportImpl.Builder GetBuilder()
                {
                    return new TalonInformationReportImpl.Builder();
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            public static class Turn
            {
                /// <summary>
                /// Todo
                /// </summary>
                public static class Information
                {
                    /// <summary>
                    /// Todo
                    /// </summary>
                    /// <returns>
                    /// </returns>
                    public static TalonTurnInformationReportImpl.Builder GetBuilder()
                    {
                        return new TalonTurnInformationReportImpl.Builder();
                    }
                }

                /// <summary>
                /// Todo
                /// </summary>
                public static class Result
                {
                    /// <summary>
                    /// Todo
                    /// </summary>
                    /// <returns>
                    /// </returns>
                    public static TalonTurnResultReportImpl.Builder GetBuilder()
                    {
                        return new TalonTurnResultReportImpl.Builder();
                    }
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public static class Weapon
        {
            /// <summary>
            /// Todo
            /// </summary>
            public static class Construction
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <returns>
                /// </returns>
                public static WeaponConstructionReportImpl.Builder GetBuilder()
                {
                    return new WeaponConstructionReportImpl.Builder();
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            public static class Information
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <returns>
                /// </returns>
                public static WeaponInformationReportImpl.Builder GetBuilder()
                {
                    return new WeaponInformationReportImpl.Builder();
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            public static class Order
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <returns>
                /// </returns>
                public static WeaponOrderReportImpl.Builder GetBuilder()
                {
                    return new WeaponOrderReportImpl.Builder();
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            public static class Result
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <returns>
                /// </returns>
                public static WeaponResultReportImpl.Builder GetBuilder()
                {
                    return new WeaponResultReportImpl.Builder();
                }
            }
        }
    }
}