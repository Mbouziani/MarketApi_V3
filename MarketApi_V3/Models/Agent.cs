using System;
using System.Collections.Generic;

namespace MarketApi_V3.Models
{
    public partial class Agent
    {
        public int AgentId { get; set; }
        public string? AgentName { get; set; }
        public string? AgentEmail { get; set; }
        public string? AgentAddress { get; set; }
        public string? AgentMobile { get; set; }
        public string? AgentTele { get; set; }
        public long? AgentAccountNumber { get; set; }
        public string? AgentVatNumber { get; set; }
        public double? AgentPercentDiscount { get; set; }
    }
}
