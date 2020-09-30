/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Reports.Faction;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Reports.Game;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Reports.HexTiles;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Reports.Hoplites;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Reports.Maps.Game;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Reports.Mvc.Initializers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Reports.Mvc.Models;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Reports.Paint;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Reports.Phalanx;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Reports.Rosters;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Reports.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Reports.Talons.Action;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Reports.Talons.Attributes;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Reports.Talons.Combat;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Reports.Talons.Turn;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Reports.Weapons;

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
        public static class Faction
        {
            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            public static FactionReport.Builder GetBuilder()
            {
                return new FactionReport.Builder();
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
                public static GameActionReport.Builder GetBuilder()
                {
                    return new GameActionReport.Builder();
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
                public static HexTileConstructionReport.Builder GetBuilder()
                {
                    return new HexTileConstructionReport.Builder();
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
                public static HexTileInformationReport.Builder GetBuilder()
                {
                    return new HexTileInformationReport.Builder();
                }
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
                    public static GameMapConstructionReport.Builder GetBuilder()
                    {
                        return new GameMapConstructionReport.Builder();
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
                    public static GameMapInformationReport.Builder GetBuilder()
                    {
                        return new GameMapInformationReport.Builder();
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
                public static MvcInitializationReport.Builder GetBuilder()
                {
                    return new MvcInitializationReport.Builder();
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
                public static MvcModelInformationReport.Builder GetBuilder()
                {
                    return new MvcModelInformationReport.Builder();
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
            public static PhalanxReport.Builder GetBuilder()
            {
                return new PhalanxReport.Builder();
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
                public static RosterConstructionReport.Builder GetBuilder()
                {
                    return new RosterConstructionReport.Builder();
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
                public static RosterInformationReport.Builder GetBuilder()
                {
                    return new RosterInformationReport.Builder();
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
                    public static TalonActionOrderReport.Builder GetBuilder()
                    {
                        return new TalonActionOrderReport.Builder();
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
                    public static TalonActionResultReport.Builder GetBuilder()
                    {
                        return new TalonActionResultReport.Builder();
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
                public static TalonAttributesReport.Builder GetBuilder()
                {
                    return new TalonAttributesReport.Builder();
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
                    public static DestructibleReport.Builder GetBuilder()
                    {
                        return new DestructibleReport.Builder();
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
                    public static FireableReport.Builder GetBuilder()
                    {
                        return new FireableReport.Builder();
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
                    public static MovableReport.Builder GetBuilder()
                    {
                        return new MovableReport.Builder();
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
                    public static TalonCombatOrderReport.Builder GetBuilder()
                    {
                        return new TalonCombatOrderReport.Builder();
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
                    public static TalonCombatResultReport.Builder GetBuilder()
                    {
                        return new TalonCombatResultReport.Builder();
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
                public static TalonConstructionReport.Builder GetBuilder()
                {
                    return new TalonConstructionReport.Builder();
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
                public static TalonIdentificationReport.Builder GetBuilder()
                {
                    return new TalonIdentificationReport.Builder();
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
                public static TalonInformationReport.Builder GetBuilder()
                {
                    return new TalonInformationReport.Builder();
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
                    public static TalonTurnInformationReport.Builder GetBuilder()
                    {
                        return new TalonTurnInformationReport.Builder();
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
                    public static TalonTurnResultReport.Builder GetBuilder()
                    {
                        return new TalonTurnResultReport.Builder();
                    }
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
            public static HopliteReport.Builder GetBuilder()
            {
                return new HopliteReport.Builder();
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public static class Paint
        {
            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            public static PaintSchemeReport.Builder GetBuilder()
            {
                return new PaintSchemeReport.Builder();
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
                public static WeaponConstructionReport.Builder GetBuilder()
                {
                    return new WeaponConstructionReport.Builder();
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
                public static WeaponInformationReport.Builder GetBuilder()
                {
                    return new WeaponInformationReport.Builder();
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
                public static WeaponOrderReport.Builder GetBuilder()
                {
                    return new WeaponOrderReport.Builder();
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
                public static WeaponResultReport.Builder GetBuilder()
                {
                    return new WeaponResultReport.Builder();
                }
            }
        }
    }
}