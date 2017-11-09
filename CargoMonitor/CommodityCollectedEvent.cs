﻿using EddiDataDefinitions;
using EddiEvents;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EddiCargoMonitor
{
    public class CommodityCollectedEvent : Event
    {
        public const string NAME = "Commodity collected";
        public const string DESCRIPTION = "Triggered when you pick up a commodity in your ship or SRV";
        public const string SAMPLE = "{\"timestamp\":\"2016-06-10T14:32:03Z\",\"event\":\"CollectCargo\",\"Type\":\"agriculturalmedicines\",\"Stolen\":true}";
        public static Dictionary<string, string> VARIABLES = new Dictionary<string, string>();

        static CommodityCollectedEvent()
        {
            VARIABLES.Add("commodity", "The commodity collected");
            VARIABLES.Add("stolen", "If the cargo is stolen");
        }

        [JsonProperty("commodity")]
        public Commodity commodity { get; private set; }

        [JsonProperty("stolen")]
        public bool stolen { get; private set; }

        public CommodityCollectedEvent(DateTime timestamp, Commodity commodity, bool stolen) : base(timestamp, NAME)
        {
            this.commodity = commodity;
            this.stolen = stolen;
        }
    }
}