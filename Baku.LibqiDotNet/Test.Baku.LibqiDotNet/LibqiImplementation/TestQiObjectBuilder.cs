using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

using Baku.LibqiDotNet;
using Baku.LibqiDotNet.Libqi;
using Baku.LibqiDotNet.Path;

namespace Test.Baku.LibqiDotNet.Libqi
{
    [TestFixture]
    public class TestQiObjectBuilder
    {
        const double EPSILON = 1.0e-5;

        private QiObjectBuilder GetObjectBuilder()
        {
            var builder = QiObjectBuilder.Create();
            builder.AdvertiseMethod("ping::v()", (sig, arg) => QiValue.Void);
            builder.AdvertiseMethod("number::i()", (sig, arg) => new QiInt32(42).QiValue);
            builder.AdvertiseMethod("twice::d(d)", (sig, arg) => new QiDouble(2.0 * arg[0].ToDouble()).QiValue);
            builder.AdvertiseMethod("id::s(s)", (sig, arg) => (arg[0] as QiValue));

            builder.AdvertiseMethod("poly::[i](s)", (sig, arg) => QiList.Create(new int[] { 1, 2, 3 }).QiValue);
            builder.AdvertiseMethod("poly::[i](f)", (sig, arg) => QiList.Create(new int[] { 4, 5, 6 }).QiValue);
            return builder;
        }

        /// <summary>ネイティブAPIの呼び出し元DLLがテスト実行中に参照できるようにします。</summary>
        [SetUp]
        public void TestSetupForDllPath()
        {
            PathModifier.AddEnvironmentPath("dlls", PathModifyMode.RelativeToExecutingAssembly);
        }

        /// <summary>QiObjectBuilderが動く所を確認</summary>
        [Test]
        public void TestObjectCreate()
        {
            var obj = GetObjectBuilder().BuildObject();
        }

        /// <summary>関数呼び出してみる</summary>
        [Test]
        public void TestObjectCall()
        {
            GetObjectBuilder().BuildObject()["ping"].Call();
        }

        /// <summary>結果を受け取ってみる</summary>
        [Test]
        public void TestObjectResult()
        {
            Assert.AreEqual(GetObjectBuilder().BuildObject()["number"].Call<int>(), 42);
        }

        /// <summary>引数をきちんと使う場合</summary>
        [Test]
        public void TestObjectArgAndResult()
        {
            double x = 3.0;
            double y = GetObjectBuilder().BuildObject()["twice"].Call<double>(x);
            Assert.IsTrue(Math.Abs(x * 2.0 - y) < EPSILON);
        }

        /// <summary>IQiResultで受け取ってみる</summary>
        [Test]
        public void TestIQiResultReceive()
        {
            Assert.AreEqual(
                GetObjectBuilder().BuildObject()["id"].Call<IQiResult>("hello").ToQiString(), 
                "hello");
        }

        /// <summary>関数オーバーロードが正しく捌けるかチェック</summary>
        [Test]
        public void TestPolymorphic()
        {
            var method = GetObjectBuilder().BuildObject()["poly"];

            Assert.IsTrue(
                method.Call<IEnumerable<int>>("test").SequenceEqual(new int[] { 1, 2, 3 }) &&
                method.Call<IEnumerable<int>>(1.0f).SequenceEqual(new int[] { 4, 5, 6 })
                );
        }

    }
}
