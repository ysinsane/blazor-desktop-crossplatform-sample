using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                SetupMethod = (SetupMethod) (new Random().Next() % 2)
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
            return new PgaParameters { AcValue = new Random().Next(3, 10), DcValue = new Random().Next(3, 10) };
        }

        /// <inheritdoc />
        public void SetSensorThreshold(int address, double voltageRatio)
        {
        }

        /// <inheritdoc />
        public double ReadSensorThreshold(int address)
        {
            return new Random().NextDouble() * 5;
        }

        /// <inheritdoc />
        public LightSensorVoltage GetLightIntensity(int address)
        {
            return new LightSensorVoltage
            { ActualVoltage = new Random().NextDouble() * 5, Percentage = new Random().NextDouble() };
        }

        /// <inheritdoc />
        public bool GetSensorCheckResult(int address)
        {
            return new Random().Next() % 2 == 0;
        }

        /// <inheritdoc />
        public BbdResult GetBbdResult(int address)
        {
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
            
        }
    }
}
