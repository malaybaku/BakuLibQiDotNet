namespace Baku.LibqiDotNet
{
    /// <summary>Qiで使われる値の型一覧</summary>
    public enum QiValueKind
    {
        QiInvalid = -1,
        QiUnknown = 0,
        QiVoid = 1,
        QiInt = 2,
        QiFloat = 3,
        QiString = 4,
        QiList = 5,
        QiMap = 6,
        QiObject = 7,
        QiPointer = 8,
        QiTuple = 9,
        QiDynamic = 10,
        QiRaw = 11,
        QiIterator = 12
    }

    /// <summary>Qiで使われる型一覧。<see cref="QiValueKind"/>との違いに注意</summary>
    public enum QiTypeKind
    {
        QiInvalid = -1,
        QiUnknown = 0,
        QiVoid = 1,
        QiInt = 2,
        QiFloat = 3,
        QiString = 4,
        QiList = 5,
        QiMap = 6,
        QiObject = 7,
        QiPointer = 8,
        QiTuple = 9,
        QiDynamic = 10,
        QiRaw = 11,
        QiIterator = 13,
        QiFunction = 14,
        QiSignal = 15,
        QiProperty = 16,
        QiVarargs = 17

    }

}
