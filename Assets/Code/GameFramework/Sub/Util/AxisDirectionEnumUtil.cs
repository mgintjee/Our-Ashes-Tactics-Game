public class AxisDirectionEnumUtil
{
    #region Public Methods

    public static AxisDirectionEnum InverseAxisDirectionEnum(AxisDirectionEnum axisDirectionEnum)
    {
        AxisDirectionEnum invertedAxisDirectionEnum = AxisDirectionEnum.INVALID;
        switch (axisDirectionEnum)
        {
            case AxisDirectionEnum.POS_X:
                invertedAxisDirectionEnum = AxisDirectionEnum.NEG_X;
                break;

            case AxisDirectionEnum.POS_Z:
                invertedAxisDirectionEnum = AxisDirectionEnum.NEG_Z;
                break;

            case AxisDirectionEnum.POS_Y:
                invertedAxisDirectionEnum = AxisDirectionEnum.NEG_Y;
                break;

            case AxisDirectionEnum.NEG_X:
                invertedAxisDirectionEnum = AxisDirectionEnum.POS_X;
                break;

            case AxisDirectionEnum.NEG_Z:
                invertedAxisDirectionEnum = AxisDirectionEnum.POS_Z;
                break;

            case AxisDirectionEnum.NEG_Y:
                invertedAxisDirectionEnum = AxisDirectionEnum.POS_Y;
                break;
        }
        return invertedAxisDirectionEnum;
    }

    #endregion Public Methods
}