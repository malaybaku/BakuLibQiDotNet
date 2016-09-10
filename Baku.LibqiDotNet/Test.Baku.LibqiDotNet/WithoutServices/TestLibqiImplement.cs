using NUnit.Framework;
using Baku.LibqiDotNet;
using QiNative = Baku.LibqiDotNet.Libqi;
using System.Threading;

namespace Test.Baku.LibqiDotNet
{
    [TestFixture]
    public class TestLibqiImplement : CommonTest
    {
        protected override QiSession GetConnectedSession()
        {
            var session = new QiSessionFactory().CreateLibqiSession();
            session.Port = ConnectionSetting.LibqiPort;
            session.Connect(ConnectionSetting.LibqiIP);
            return session;
        }

        #region Wrapper

        [OneTimeSetUp]
        public override void SetUpConnection()
        {
            base.SetUpConnection();
        }

        [OneTimeTearDown]
        public override void CloseAllConnection()
        {
            base.CloseAllConnection();
        }

        [Test]
        public override void TestMotionSummary()
        {
            base.TestMotionSummary();
        }

        [Test]
        public override void TestDialogEvents()
        {
            base.TestDialogEvents();
        }

        [Test]
        public override void TestMotionPose()
        {
            base.TestMotionPose();
        }

        [Test]
        public override void TestSensors()
        {
            base.TestSensors();
        }

        [Test]
        public override void TestHelloWorld()
        {
            base.TestHelloWorld();
        }

        [Test]
        public override void TestBinaryOutput()
        {
            base.TestBinaryOutput();
        }

        [Test]
        public override void TestNotFoundMethod()
        {
            base.TestNotFoundMethod();
        }

        [Test]
        public override void TestComplicatedArg()
        {
            base.TestComplicatedArg();
        }

        #endregion

        [Test]
        public void TestRegisterQiObject()
        {
            var objBuilder = QiNative.QiObjectBuilder.Create();
            //function which do nothing
            objBuilder.AdvertiseMethod("testPing::v()", (sig, arg) =>
            {
                return QiNative.QiValue.Void;
            });

            uint id = Session.RegisterService("myTestService", objBuilder.BuildObject());
            Thread.Sleep(500);

            var myTestService = Session.GetService("myTestService");
            myTestService["testPing"].Call();

            Thread.Sleep(500);
            Session.UnregisterService(id);
        }

    }
}
