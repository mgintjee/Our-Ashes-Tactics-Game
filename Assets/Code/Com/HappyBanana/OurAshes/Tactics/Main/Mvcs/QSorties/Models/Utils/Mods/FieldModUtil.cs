﻿using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Biomes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Shapes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Models.Utils.Randomizations;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Models.Utils.Mods
{
    public class FieldModUtil
    {
        private static readonly IClassLogger logger = LoggerManager.GetLogger(MvcType.Common)
                .GetClassLogger(new StackFrame().GetMethod().DeclaringType);

        public static void HandleFieldIDSelect(IMvcModelState modelState, IEnumSelectRequest<FieldID> mvcRequest)
        {
            IFieldDetails fieldDetails = modelState.GetFieldDetails();
            IFieldDetails newFieldDetails = UpdateFieldDetails(mvcRequest.GetEnum(), fieldDetails.GetFieldBiome(),
                fieldDetails.GetFieldShape(), fieldDetails.GetFieldSize(), fieldDetails);
            UpdateFieldDetails(newFieldDetails, modelState);
        }

        public static void HandleFieldBiomeSelect(IMvcModelState modelState, IEnumSelectRequest<FieldBiome> mvcRequest)
        {
            IFieldDetails fieldDetails = modelState.GetFieldDetails();
            IFieldDetails newFieldDetails = UpdateFieldDetails(fieldDetails.GetFieldID(), mvcRequest.GetEnum(),
                fieldDetails.GetFieldShape(), fieldDetails.GetFieldSize(), fieldDetails);
            UpdateFieldDetails(newFieldDetails, modelState);
        }

        public static void HandleFieldShapeSelect(IMvcModelState modelState, IEnumSelectRequest<FieldShape> mvcRequest)
        {
            IFieldDetails fieldDetails = modelState.GetFieldDetails();
            IFieldDetails newFieldDetails = UpdateFieldDetails(fieldDetails.GetFieldID(),
                fieldDetails.GetFieldBiome(), mvcRequest.GetEnum(), fieldDetails.GetFieldSize(), fieldDetails);
            UpdateFieldDetails(newFieldDetails, modelState);
        }

        public static void HandleFieldSizeSelect(IMvcModelState modelState, IEnumSelectRequest<FieldSize> mvcRequest)
        {
            IFieldDetails fieldDetails = modelState.GetFieldDetails();
            IFieldDetails newFieldDetails = UpdateFieldDetails(fieldDetails.GetFieldID(),
                fieldDetails.GetFieldBiome(), fieldDetails.GetFieldShape(), mvcRequest.GetEnum(), fieldDetails);
            UpdateFieldDetails(newFieldDetails, modelState);
        }

        private static IFieldDetails UpdateFieldDetails(FieldID fieldID, FieldBiome fieldBiome,
            FieldShape fieldShape, FieldSize fieldSize, IFieldDetails fieldDetails)
        {
            IFieldDetails newFieldDetails = FieldDetailsManager.GetFieldDetails(fieldID).GetValue();
            if (newFieldDetails == null)
            {
                IList<ITileDetails> tileDetails = fieldDetails.GetTileDetails();
                if (ShouldBuildNewTileDetails(fieldID, fieldShape, fieldSize, fieldDetails))
                {
                    tileDetails = FieldDetailsRandomizerUtil.GetRandomTileDetails(
                       RandomManager.GetRandom(MvcType.QSortieMenu), fieldShape, fieldSize);
                }
                newFieldDetails = FieldDetailsImpl.Builder.Get()
                    .SetFieldBiome(fieldBiome)
                    .SetFieldID(fieldID)
                    .SetFieldShape(fieldShape)
                    .SetFieldSize(fieldSize)
                    .SetTileDetails(tileDetails)
                    .Build();
            }
            return newFieldDetails;
        }

        private static bool ShouldBuildNewTileDetails(FieldID fieldID, FieldShape fieldShape,
            FieldSize fieldSize, IFieldDetails fieldDetails)
        {
            return fieldID == FieldID.Random || fieldShape != fieldDetails.GetFieldShape() || fieldSize != fieldDetails.GetFieldSize();
        }

        private static void UpdateFieldDetails(IFieldDetails details, IMvcModelState modelState)
        {
            ((MvcModelStateImpl)modelState)
                .SetFieldDetails(details);
        }
    }
}