﻿using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Details.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters
{
    public interface IFieldDetails
    {
        FieldID GetFieldID();

        ISet<ITileDetails> GetTileDetails();
    }
}