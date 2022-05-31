using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Constants
{
    /// <summary>
    /// Details Panel Constants
    /// </summary>
    public class DetailsPanelConstants
    {
        public class Fields
        {
            public class Floats
            {
                public static readonly float SIZE_X = 1;

                public static readonly float SIZE_Y = 4;
            }

            public class Vectors
            {
                public static readonly Vector2 SIZE =
                    new Vector2(Floats.SIZE_X, Floats.SIZE_Y);
            }
        }

        public class Factions
        {
            public class Floats
            {
                public static readonly float SIZE_X = 6;
                public static readonly float SIZE_Y = 3;
            }

            public class Vectors
            {
                public static readonly Vector2 SIZE =
                    new Vector2(Floats.SIZE_X, Floats.SIZE_Y);
            }
        }

        public class Phalanxes
        {
            public class Floats
            {
                public static readonly float SIZE_X = 6;
                public static readonly float SIZE_Y = 3;
            }

            public class Vectors
            {
                public static readonly Vector2 SIZE =
                    new Vector2(Floats.SIZE_X, Floats.SIZE_Y);
            }

        }

        public class Combatants
        {
            public class Floats
            {
                public static readonly float SIZE_X = 6;
                public static readonly float SIZE_Y = 6;
            }

            public class Vectors
            {
                public static readonly Vector2 SIZE =
                    new Vector2(Floats.SIZE_X, Floats.SIZE_Y);
            }
        }

        public class Sorties
        {
            public class Floats
            {
                public static readonly float SIZE_X = 2;
                public static readonly float SIZE_Y = 5;
            }

            public class Vectors
            {
                public static readonly Vector2 SIZE =
                    new Vector2(Floats.SIZE_X, Floats.SIZE_Y);
            }
        }
    }
}