using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Requests.Interfaces;
using System;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Requests.Implementations.Abstracts
{
    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractRequest
        : IRequest
    {
        // Todo
        protected readonly DateTime _dateTime;

        /// <summary>
        /// Todo
        /// </summary>
        protected AbstractRequest()
        {
            _dateTime = DateTime.Now;
        }

        /// <inheritdoc/>
        DateTime IRequest.GetDateTime()
        {
            return _dateTime;
        }
    }
}