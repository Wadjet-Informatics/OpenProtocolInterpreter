﻿using System;

namespace OpenProtocolInterpreter.OpenProtocolCommandsDisabled
{
    /// <summary>
    /// MID: Open Protocol commands disabled
    /// Description: 
    ///     Upload the status of the Open Protocol commands disable digital input. 
    ///     The data upload consists of one byte delivering the digital input status. 
    ///     The status is uploaded each time the “Open Protocol commands disable” digital 
    ///     input changes (push function).
    /// Message sent by: Controller
    /// Answer: MID 0422 Open Protocol commands disabled acknowledge
    /// </summary>
    public class MID_0421 : Mid, IOpenProtocolCommandsDisabled
    {
        public const int MID = 421;
        private const int length = 21;
        private const int revision = 1;

        /// <summary>
        /// <para>Automatic Mode = false (0)</para>
        /// <para>Manual Mode = true (1)</para>
        /// </summary>
        public bool DigitalInputStatus { get; set; }

        public MID_0421() : base(length, MID, revision) { }

        internal MID_0421(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override string BuildPackage()
        {
            return base.BuildHeader() + Convert.ToInt32(DigitalInputStatus).ToString();
        }

        public override Mid ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
            {
                HeaderData = ProcessHeader(package);
                var dataField = base.RegisteredDataFields[(int)DataFields.DIGITAL_INPUT_STATUS];
                dataField.Value = package.Substring(dataField.Index, dataField.Size);
                DigitalInputStatus = dataField.ToBoolean();
                return this;
            }

            return NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields()
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.DIGITAL_INPUT_STATUS, 20, 1));
        }

        public enum DataFields
        {
            DIGITAL_INPUT_STATUS
        }
    }
}
