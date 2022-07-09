using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Types;
using System;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Impls
{
    public class EnumSelectRequestImpl<TEnum>
        : DefaultRequestImpl, IEnumSelectRequest<TEnum>
        where TEnum : Enum
    {
        private readonly TEnum val;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="val">        </param>
        /// <param name="requestType"></param>
        public EnumSelectRequestImpl(TEnum val, RequestType requestType)
            : base(requestType)
        {
            this.val = val;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}:{1}", typeof(TEnum).Name, this.val);
        }

        /// <inheritdoc/>
        TEnum IEnumSelectRequest<TEnum>.GetEnum()
        {
            return this.val;
        }

        /// <inheritdoc/>
        Type IEnumSelectRequest<TEnum>.GetEnumType()
        {
            return typeof(TEnum);
        }
    }
}