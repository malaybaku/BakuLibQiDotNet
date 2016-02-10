
//参考元: http://doc.aldebaran.com/libqi/api/cpp/type/signature.html

namespace Baku.LibqiDotNet
{
    /// <summary>Qiの値型を表す文字列の一覧</summary>
    public static class QiSignatures
    {

        public static readonly string TypeNone = "_";
        public static readonly string TypeVoid = "v";

        //number
        public static readonly string TypeBool = "b";
        public static readonly string TypeInt8 = "c";
        public static readonly string TypeUInt8 = "C";
        public static readonly string TypeInt16 = "w";
        public static readonly string TypeUInt16 = "W";
        public static readonly string TypeInt32 = "i";
        public static readonly string TypeUInt32 = "I";
        public static readonly string TypeInt64 = "l";
        public static readonly string TypeUInt64 = "L";

        public static readonly string TypeFloat = "f";
        public static readonly string TypeDouble = "d";

        //string
        public static readonly string TypeString = "s";

        //container
        public static readonly string TypeListBegin = "[";
        public static readonly string TypeListEnd = "]";
        public static readonly string TypeMapBegin = "{";
        public static readonly string TypeMapEnd = "}";
        public static readonly string TypeTupleBegin = "(";
        public static readonly string TypeTupleEnd = ")";

        public static readonly string TypeDynamic = "m";
        public static readonly string TypeRaw = "r";
        public static readonly string TypePointer = "*";
        public static readonly string TypeObject = "o";

        //
        public static readonly string TypeVarArgs = "#";
        public static readonly string TypeKwArgs = "~";
        public static readonly string TypeUnknown = "X";

        public static readonly string MethodNameSuffix = "::";

    }
}
