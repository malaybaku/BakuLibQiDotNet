namespace Baku.LibqiDotNet
{
    /// <summary>Qiで使われる値の型一覧</summary>
    public enum QiValueKind
    {
        /// <summary>無効な値</summary>
        QiInvalid = -1,
        /// <summary>不明な値。エラーを表す場合もある</summary>
        QiUnknown = 0,
        /// <summary>戻り値が無いことを示す。</summary>
        QiVoid = 1,
        /// <summary>整数型</summary>
        QiInt = 2,
        /// <summary>小数型</summary>
        QiFloat = 3,
        /// <summary>文字列型</summary>
        QiString = 4,
        /// <summary>配列型</summary>
        QiList = 5,
        /// <summary>マップ(辞書)型</summary>
        QiMap = 6,
        /// <summary>オブジェクト型</summary>
        QiObject = 7,
        /// <summary>ポインタ型</summary>
        QiPointer = 8,
        /// <summary>タプル型</summary>
        QiTuple = 9,
        /// <summary>動的型</summary>
        QiDynamic = 10,
        /// <summary>バイナリ型</summary>
        QiRaw = 11,
        /// <summary>イテレータ型</summary>
        QiIterator = 12
    }

    /// <summary>Qiで使われる型一覧。<see cref="QiValueKind"/>との違いに注意</summary>
    public enum QiTypeKind
    {
        /// <summary>無効な値</summary>
        QiInvalid = -1,
        /// <summary>未知の値。エラーを表すこともある</summary>
        QiUnknown = 0,
        /// <summary>戻り値が無い事を表す値</summary>
        QiVoid = 1,
        /// <summary>整数型</summary>
        QiInt = 2,
        /// <summary>小数型</summary>
        QiFloat = 3,
        /// <summary>文字列型</summary>
        QiString = 4,
        /// <summary>配列型</summary>
        QiList = 5,
        /// <summary>マップ(辞書)型</summary>
        QiMap = 6,
        /// <summary>オブジェクト型</summary>
        QiObject = 7,
        /// <summary>ポインタ型</summary>
        QiPointer = 8,
        /// <summary>タプル型</summary>
        QiTuple = 9,
        /// <summary>動的型</summary>
        QiDynamic = 10,
        /// <summary>バイナリ型</summary>
        QiRaw = 11,
        /// <summary>イテレータ型</summary>
        QiIterator = 13,
        /// <summary>関数型</summary>
        QiFunction = 14,
        /// <summary>シグナル型</summary>
        QiSignal = 15,
        /// <summary>プロパティ型</summary>
        QiProperty = 16,
        /// <summary>可変長引数型</summary>
        QiVarargs = 17

    }

}
