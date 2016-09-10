using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Baku.LibqiDotNet;
using Baku.LibqiDotNet.Libqi;
using Baku.LibqiDotNet.Path;

namespace Test.Baku.LibqiDotNet.Libqi
{
    /// <summary>
    /// ".Libqi"実装では入出力値がQiValue型で処理される性質を用いて、値の一貫性をテストします。
    /// 入れ子構造のデータ型に対するリフレクション処理が正しいかどうかも検証します。
    /// </summary>
    [TestFixture]
    public class TestQiInputValues
    {
        /// <summary>ネイティブAPIの呼び出し元DLLがテスト実行中に参照できるようにします。</summary>
        [OneTimeSetUp]
        public void TestSetupForDllPath()
        {
            PathModifier.AddEnvironmentPath("dlls", PathModifyMode.RelativeToExecutingAssembly);
        }

        [Test]
        public void TestQiInputInt()
        {
            QiInputValue qv = QiInFactory.Create(42);
            Assert.AreEqual(qv.QiValue.Get<int>(), 42);
        }

        [Test]
        public void TestQiInputString()
        {
            QiInputValue qv = QiInFactory.Create("Hello, World");
            Assert.AreEqual(qv.QiValue.Get<string>(), "Hello, World");
        }

        [Test]
        public void TestQiIntArray()
        {
            QiInputValue qv = QiInFactory.Create(new int[]{ 3,5,2 });
            Assert.IsTrue(qv.QiValue.Get<int[]>().SequenceEqual(new int[] { 3, 5, 2 }));
        }

        [Test]
        public void TestQiString2DArray()
        {
            var input = new string[][]
            {
                new string[] { "abc", "def" },
                new string[] { "ghi", "jkl", "mno" }
            };

            QiInputValue qv = QiInFactory.Create(input);
            var output = qv.QiValue.Get<IEnumerable<IEnumerable<string>>>();

            Assert.IsTrue(
                output.ElementAt(0).ElementAt(0) == "abc" &&
                output.ElementAt(0).ElementAt(1) == "def" &&
                output.ElementAt(1).ElementAt(0) == "ghi" &&
                output.ElementAt(1).ElementAt(1) == "jkl" &&
                output.ElementAt(1).ElementAt(2) == "mno"
                );
        }

        [Test]
        public void TestQiStringDic()
        {
            QiInputValue qv = QiInFactory.Create(new Dictionary<string, int>
            { 
                ["jp"] = 4,
                ["en"] = 2,
                ["fr"] = 5 
            });

            var output = qv.QiValue.Get<IDictionary<string, int>>();

            Assert.IsTrue(output.Count == 3 && 
                output["jp"] == 4 &&
                output["en"] == 2 &&
                output["fr"] == 5
                );
        }

        [Test]
        public void TestBinaryData()
        {
            string hello = "Hello, World";
            byte[] encoded = Encoding.UTF8.GetBytes(hello);

            QiInputValue qv = QiInFactory.Create(encoded);
            byte[] output = qv.QiValue.Get<byte[]>();

            Assert.AreEqual(Encoding.UTF8.GetString(output), hello);
        }
    }
}
