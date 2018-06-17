﻿using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.MotorTuning
{
    internal class MotorTuningMessages : IMessagesTemplate
    {
        private readonly IMid templates;

        public MotorTuningMessages()
        {
            templates = new Mid0500(new Mid0501(new Mid0502(new Mid0503(new Mid0504(null)))));
        }

        public MotorTuningMessages(System.Collections.Generic.IEnumerable<Mid> selectedMids)
        {
            templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package)
        {
            return templates.Parse(package);
        }
    }
}
