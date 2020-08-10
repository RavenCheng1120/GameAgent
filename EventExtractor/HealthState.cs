﻿using System;
using System.Collections.Generic;
using System.Text;
using RedisEndpoint;

namespace EventDetectors
{
    public class HealthState
    {
        private byte realHP = 100;
        private DateTime lastBloodLossSignal = DateTime.Now;
        private DateTime? lastHPBurst = null;

        public Publisher publisher;
        public byte RealHP { get => realHP; set => realHP = value; }
        public DateTime LastBloodLossSignal { get => lastBloodLossSignal; set => lastBloodLossSignal = value; }
        public DateTime? LastHPBurst { get => lastHPBurst; set => lastHPBurst = value; }

        public HealthState(Publisher publisher) => this.publisher = publisher;
    }
}
