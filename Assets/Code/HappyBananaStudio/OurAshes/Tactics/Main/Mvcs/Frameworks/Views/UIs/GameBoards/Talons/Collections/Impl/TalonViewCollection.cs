namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.Talons.Collections.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Talons.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.Talons.Collections.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.Talons.Views.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.Talons.Views.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Scripts.Unity.Abs;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public class TalonViewCollection
        : AbstractUnityScript, ITalonViewCollection
    {
        // Todo
        private IDictionary<TalonCallSign, ITalonView> talonCallSignTalonViewDictionary;

        /// <inheritdoc/>
        ITalonView ITalonViewCollection.GetTalonView(TalonCallSign talonCallSign)
        {
            if (this.talonCallSignTalonViewDictionary.ContainsKey(talonCallSign))
            {
                return this.talonCallSignTalonViewDictionary[talonCallSign];
            }
            else
            {
                throw ExceptionUtil.Arguments.Build();
            }
        }

        /// <inheritdoc/>
        void ITalonViewCollection.DestroyTalonView(TalonCallSign talonCallSign)
        {
            if (this.talonCallSignTalonViewDictionary.ContainsKey(talonCallSign))
            {
                this.talonCallSignTalonViewDictionary[talonCallSign].Destroy();
                this.talonCallSignTalonViewDictionary.Remove(talonCallSign);
            }
            else
            {
                throw ExceptionUtil.Arguments.Build();
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonRosterReport"></param>
        private void SetTalonRosterReport(ITalonRosterReport talonRosterReport)
        {
            this.talonCallSignTalonViewDictionary = new Dictionary<TalonCallSign, ITalonView>();
            foreach (ITalonReport talonReport in talonRosterReport.GetTalonCallSignReportDictionary().Values)
            {
                TalonCallSign talonCallSign = talonReport.GetTalonCallSign();
                ITalonView talonView = new TalonView.Builder()
                    .SetTalonCallSign(talonCallSign)
                    .SetCubeCoordinates(talonReport.GetCubeCoordinates())
                    .SetParentTransform(this.GetTransform())
                    .Build();
                this.talonCallSignTalonViewDictionary.Add(talonCallSign, talonView);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private Transform parentTransform = null;

            // Todo
            private ITalonRosterReport talonRosterReport = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ITalonViewCollection Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    TalonViewCollection talonViewCollection = new GameObject(typeof(TalonViewCollection).Name)
                        .AddComponent<TalonViewCollection>();
                    talonViewCollection.GetTransform().SetParent(this.parentTransform);
                    talonViewCollection.SetTalonRosterReport(this.talonRosterReport);
                    return talonViewCollection;
                }
                else
                {
                    throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="parentTransform"></param>
            /// <returns></returns>
            public Builder SetParentTransform(Transform parentTransform)
            {
                this.parentTransform = parentTransform;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="talonRosterReport"></param>
            /// <returns></returns>
            public Builder SetTalonRosterReport(ITalonRosterReport talonRosterReport)
            {
                this.talonRosterReport = talonRosterReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                if (this.talonRosterReport == null)
                {
                    argumentExceptionSet.Add(typeof(ITalonRosterReport).Name + " cannot be null.");
                }
                if (this.parentTransform == null)
                {
                    argumentExceptionSet.Add("Parent " + typeof(Transform).Name + " cannot be null.");
                }

                return argumentExceptionSet;
            }
        }
    }
}