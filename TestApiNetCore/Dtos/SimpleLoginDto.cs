namespace FaxiApiNetCore.Dtos
{
    public class SimpleLoginDto
    {
        public string Telefono { get; set; }
        public string Password { get; set; }
        public int? Codigo { get; set; }
        public string TipoCuenta { get; set; }
    }
}
