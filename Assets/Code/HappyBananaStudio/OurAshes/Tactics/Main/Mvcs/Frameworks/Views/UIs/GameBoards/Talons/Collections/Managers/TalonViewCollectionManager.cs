namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.Talons.Collections.Managers
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.Talons.Collections.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.Talons.Views.Api;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public class TalonViewCollectionManager
    {
        // Todo
        private static ITalonViewCollection talonViewCollection;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonViewCollection"></param>
        public static void SetTalonViewCollection(ITalonViewCollection talonViewCollection)
        {
            if (TalonViewCollectionManager.talonViewCollection == null)
            {
                TalonViewCollectionManager.talonViewCollection = talonViewCollection;
            }
            else
            {
                throw ExceptionUtil.Arguments.Build("Unable to ?. ? is already set.",
                    new StackFrame().GetMethod().Name, typeof(ITalonViewCollection));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCallSign"></param>
        /// <returns></returns>
        public static ITalonView GetTalonView(TalonCallSign talonCallSign)
        {
            if (talonViewCollection != null)
            {
                return talonViewCollection.GetTalonView(talonCallSign);
            }
            else
            {
                throw ExceptionUtil.Arguments.Build("Unable to ?. ? is null.",
                    new StackFrame().GetMethod().Name, typeof(ITalonViewCollection));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCallSign"></param>
        /// <returns></returns>
        public static void DestroyTalonView(TalonCallSign talonCallSign)
        {
            if (talonViewCollection != null)
            {
                talonViewCollection.DestroyTalonView(talonCallSign);
            }
            else
            {
                throw ExceptionUtil.Arguments.Build("Unable to ?. ? is null.",
                    new StackFrame().GetMethod().Name, typeof(ITalonViewCollection));
            }
        }
    }
}