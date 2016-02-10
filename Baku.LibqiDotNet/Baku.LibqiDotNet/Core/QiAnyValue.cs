namespace Baku.LibqiDotNet
{
    /// <summary>Qiの値型の基底</summary>
    public abstract class QiAnyValue
    {
        public abstract QiValue QiValue { get; }

        public abstract string Signature { get; }

        public string Dump() => QiValue.Dump();
    }
}
