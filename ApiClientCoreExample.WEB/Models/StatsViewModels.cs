using System.ComponentModel.DataAnnotations;

namespace ApiClientCoreExample.WEB.Models
{
    public class CurrentStatsViewModel
    {
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal Time { get; set; }

        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal LastSeen { get; set; }

        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal CurrentHashrate { get; set; }

        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal AverageHashrate { get; set; }

        [DisplayFormat(DataFormatString = "{0:0}")]
        public decimal ReportedHashrate { get; set; }

        [DisplayFormat(DataFormatString = "{0:0}")]
        public decimal ValidShares { get; set; }

        [DisplayFormat(DataFormatString = "{0:0}")]
        public decimal InvalidShares { get; set; }

        [DisplayFormat(DataFormatString = "{0:0}")]
        public decimal StaleShares { get; set; }

        [DisplayFormat(DataFormatString = "{0:0}")]
        public decimal ActiveWorkers { get; set; }

        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal Unpaid { get; set; }

        [DisplayFormat(DataFormatString = "{0:0}")]
        public decimal Unconfirmed { get; set; }

        [DisplayFormat(DataFormatString = "{0:F10}")]
        public decimal CoinsPerMin { get; set; }

        [DisplayFormat(DataFormatString = "{0:F10}")]
        public decimal UsdPerMin { get; set; }

        [DisplayFormat(DataFormatString = "{0:F10}")]
        public decimal BtcPerMin { get; set; }
    }
}
