using System.ComponentModel.DataAnnotations;

namespace ApiClientCoreExample.WEB.Models
{
    public class CurrentStatsViewModel
    {
        [Display(Name = "Временная метка")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal Time { get; set; }

        [Display(Name = "Последнее посещение")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal LastSeen { get; set; }

        [Display(Name = "Текущий хешрейт")]
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal CurrentHashrate { get; set; }

        [Display(Name = "Средний хешрейт")]
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal AverageHashrate { get; set; }

        [Display(Name = "Отосланный хешрейт")]
        [DisplayFormat(DataFormatString = "{0:0}")]
        public decimal ReportedHashrate { get; set; }

        [Display(Name = "Валидные шары")]
        [DisplayFormat(DataFormatString = "{0:0}")]
        public decimal ValidShares { get; set; }

        [Display(Name = "Инвалидные шары")]
        [DisplayFormat(DataFormatString = "{0:0}")]
        public decimal InvalidShares { get; set; }

        [Display(Name = "Устаревшие шары")]
        [DisplayFormat(DataFormatString = "{0:0}")]
        public decimal StaleShares { get; set; }

        [Display(Name = "Активные воркеры")]
        [DisplayFormat(DataFormatString = "{0:0}")]
        public decimal ActiveWorkers { get; set; }

        [Display(Name = "Неоплаченный баланс")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal Unpaid { get; set; }

        [Display(Name = "Неподтв. баланс")]
        [DisplayFormat(DataFormatString = "{0:0}")]
        public decimal Unconfirmed { get; set; }

        [Display(Name = "Койны/мин")]
        [DisplayFormat(DataFormatString = "{0:F10}")]
        public decimal CoinsPerMin { get; set; }

        [Display(Name = "$/мин.")]
        [DisplayFormat(DataFormatString = "{0:F10}")]
        public decimal UsdPerMin { get; set; }

        [Display(Name = "Биткойны/мин.")]
        [DisplayFormat(DataFormatString = "{0:F10}")]
        public decimal BtcPerMin { get; set; }
    }
}
