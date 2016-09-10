using Baku.LibqiDotNet;
using NUnit.Framework;
using System;

namespace Test.Baku.LibqiDotNet
{
    [TestFixture]
    public class TestSocketIoImplementWithServices : CommonTestWithServices
    {
        protected override QiSession GetConnectedSession()
        {
            QiSession result = new QiSessionFactory().CreateSocketIoSession();
            result.Port = ConnectionSetting.SocketIOPort;
            result.Connect(ConnectionSetting.SocketIP);
            return result;
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
        public void FailTestQiObjectBuilderCreate()
        {
            try
            {
                Session.RegisterService("willFail", null);
            }
            catch (NotSupportedException)
            {
                Assert.Pass($"Expected exception: {nameof(NotSupportedException)}");
            }

            Assert.Fail("No exception or unexpected exception");
        }

    }
}
