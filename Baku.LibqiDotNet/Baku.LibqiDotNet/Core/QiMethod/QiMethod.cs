using System;
using System.Collections.Generic;
using System.Linq;

using Baku.LibqiDotNet.Utils;

namespace Baku.LibqiDotNet
{
    /// <summary>Qi Frameworkのモジュール上に登録された関数を表します。</summary>
    public sealed class QiMethod
    {
        internal QiMethod(QiObject obj, IEnumerable<QiMethodInfo> overloads)
        {
            _obj = obj;
            Name = overloads.First().Name;
            Overloads = new ReadOnlyList<QiMethodInfo>(overloads.ToList());
        }

        private readonly QiObject _obj;

        /// <summary>メソッド名を取得します。</summary>
        public string Name { get; }

        /// <summary>関数を同期的に呼び出し、結果を取得します。</summary>
        /// <param name="args">関数の引数</param>
        /// <returns>結果</returns>
        public QiValue Call(params QiAnyValue[] args)
        {
            return _obj
                .CallDirect(GetMethodSignature(args), QiTuple.CreateDynamic(args).QiValue)
                .Wait()
                .GetValue();
        }

        /// <summary>関数を同期的に呼び出し、結果となる<see cref="QiObject"/>型変数を取得します。</summary>
        /// <param name="args">関数の引数</param>
        /// <returns>結果</returns>
        public QiObject CallObject(params QiAnyValue[] args)
        {
            return _obj
                .CallDirect(GetMethodSignature(args), QiTuple.CreateDynamic(args).QiValue)
                .GetObject();
        }

        /// <summary>関数を非同期で呼び出し、進行状態の確認に利用可能なIDを発行します。</summary>
        /// <param name="args">関数の引数</param>
        /// <returns>非同期呼び出しの結果確認に使うID</returns>
        public int Post(params QiAnyValue[] args)
        {
            return _obj.PostDirect(
                GetMethodSignature(args),
                QiTuple.CreateDynamic(args).QiValue
                );
        }

        /// <summary>関数のオーバーロード情報を取得します。オーバーロードされていない場合、1つの要素のみを含みます</summary>
        public ReadOnlyList<QiMethodInfo> Overloads { get; }


        private string GetMethodSignature(QiAnyValue[] args)
        {
            if (Overloads.Count == 1)
            {
                return Name + QiSignatures.MethodNameSuffix + Overloads.First().ArgumentSignature;
            }

            //オーバーロードがある場合は引数リストと見比べて適合するのがあるか判定
            var fittedMethod = Overloads.FirstOrDefault(
                ol => QiSignatureValidityChecker.CheckValidity(ol.ArgumentSignature, args)
                );

            if (fittedMethod != null)
            {
                return Name + QiSignatures.MethodNameSuffix + fittedMethod.ArgumentSignature;
            }

            throw new InvalidOperationException(
                $"Could not find proper overload for {Name}, " +
                $"args: {QiTuple.Create(args).Signature}, " +
                $"existing method signatures: {string.Join(",", Overloads.Select(ol => ol.ArgumentSignature).ToArray())}"
                );
        }


    }
}
