namespace DTOs
{
    public class AuditoriaEncuestaDto
    {
        public int IdAuditoria { get; set; }
        public string TituloAuditoria { get; set; }
        public string NombrePersona { get; set; }
        public DateOnly FechaRealizacion { get; set; }
    }
}
