using System;

namespace FaxiApiNetCore.Dtos
{
    public class SmsResponseDto
    {
        public string cliente { get; set; }
        public int lote_id { get; set; }
        public DateTime fecha_recepcion { get; set; }
        public int resultado { get; set; }
        public string resultado_t { get; set; }
        public int sms_procesados { get; set; }
        public string referencia { get; set; }
        public string ip { get; set; }
        public string sms { get; set; }
    }
}
