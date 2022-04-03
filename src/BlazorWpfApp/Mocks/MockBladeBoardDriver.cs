using System;
using System.Threading;
using Ultron.BladeBoard.Abstraction;
using Ultron.BladeBoard.Abstraction.DataObjects;

namespace WpfBlazor.Mocks
{
    internal class MockBladeBoardDriver : IBladeBoardDriver
    {
        /// <inheritdoc />
        public SetupFlag CheckSetupFlag(int channel)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public string ReadBoardVersion()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void SwitchSetup(int axIdx, bool @on, bool cs)
        {
        }

        /// <inheritdoc />
        public SetupSettings ReadSetupSwitchStatus(int axIdx)
        {
            return new SetupSettings
            {
                Enabled = new Random().Next() % 2 == 0,
                SetupMethod = (SetupMethod)(new Random().Next() % 2)
            };
        }

        /// <inheritdoc />
        public void StartBbd(int axIdx)
        {
        }

        /// <inheritdoc />
        public int ReadEccentricity(int axIdx)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void SetPga(int address, int dcValue, int acValue)
        {
        }

        /// <inheritdoc />
        public PgaParameters ReadPagParameters(int address)
        {
            Thread.Sleep(100);
            return new PgaParameters { AcValue = new Random().Next(3, 10), DcValue = new Random().Next(3, 10) };
        }

        /// <inheritdoc />
        public void SetSensorThreshold(int address, double voltageRatio)
        {
        }

        /// <inheritdoc />
        public double ReadSensorThreshold(int address)
        {
            Thread.Sleep(100);
            return new Random().NextDouble() * 5;
        }

        /// <inheritdoc />
        public LightSensorVoltage GetLightIntensity(int address)
        {
            Thread.Sleep(100);
            var per = new Random().NextDouble();
            return new LightSensorVoltage
            { ActualVoltage = per * 5, Percentage = per };
        }

        /// <inheritdoc />
        public bool GetSensorCheckResult(int address)
        {
            Thread.Sleep(100);
            return new Random().Next() % 2 == 0;
        }

        /// <inheritdoc />
        public BbdResult GetBbdResult(int address)
        {
            Thread.Sleep(100);
            return new BbdResult()
            {
                FullBreakage = new Random().Next() % 2 == 0,
                PartialBreakage = new Random().Next() % 2 == 0
            };
        }

        /// <inheritdoc />
        public void Disconnected()
        {
        }

        /// <inheritdoc />
        public void Connect(ConnectParameter connectParameter)
        {
            Thread.Sleep(100);
            if (connectParameter.ComPort == 4)
            {
                throw new Exception("测试连接失败");
            }
        }
    }
}
