namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs
{
    /// <summary>
    /// Greek Alphabet representing Unit IDs
    /// </summary>
    public enum UnitID
    {
        None = 0,
        Alpha = 1,
        Beta = 2,
        Gamma = 3,
        Delta = 4,
        Epsilon = 5,
        Zeta = 6,
        Eta = 7,
        Theta = 8,
        Iota = 9,
        Kappa = 10,
        Lambda = 11,
        Mu = 12,
        Nu = 13,
        Xi = 14,
        Omicron = 15,
        Pi = 16,
        Rho = 17,
        Sigma = 18,
        Tau = 19,
        Upsilon = 20,
        Phi = 21,
        Chi = 22,
        Psi = 23,
        Omega = 24
    }

    public static class Extensions
    {
        public static string GetUpperCase(this UnitID value)
        {
            switch (value)
            {
                case UnitID.Alpha:
                    return "\u0391";

                case UnitID.Beta:
                    return "\u0392";

                case UnitID.Gamma:
                    return "\u0393";

                case UnitID.Delta:
                    return "\u0394";

                case UnitID.Epsilon:
                    return "\u0395";

                case UnitID.Zeta:
                    return "\u0396";

                case UnitID.Eta:
                    return "\u0397";

                case UnitID.Theta:
                    return "\u0398";

                case UnitID.Iota:
                    return "\u0399";

                case UnitID.Kappa:
                    return "\u039A";

                case UnitID.Lambda:
                    return "\u039B";

                case UnitID.Mu:
                    return "\u039C";

                case UnitID.Nu:
                    return "\u039D";

                case UnitID.Xi:
                    return "\u039E";

                case UnitID.Omicron:
                    return "\u039F";

                case UnitID.Pi:
                    return "\u03A0";

                case UnitID.Rho:
                    return "\u03A1";

                case UnitID.Sigma:
                    return "\u03A3";

                case UnitID.Tau:
                    return "\u03A4";

                case UnitID.Upsilon:
                    return "\u03A5";

                case UnitID.Phi:
                    return "\u03A6";

                case UnitID.Chi:
                    return "\u03A7";

                case UnitID.Psi:
                    return "\u03A8";

                case UnitID.Omega:
                    return "\u03A9";

                default:
                    return "";
            }
        }
    }
}