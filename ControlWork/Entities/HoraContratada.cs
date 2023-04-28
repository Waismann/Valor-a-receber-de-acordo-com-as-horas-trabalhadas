namespace ControlWork.Entities
{
    class HoraContratada
    {
        public DateTime Data { get; set; }
        public double ValorPorHora { get; set; }
        public int Horas { get; set; }

        public HoraContratada ( )
        {

        }
        public HoraContratada (DateTime data, double valorPorHora, int horas)
        {
            Data = data;
            ValorPorHora= valorPorHora;
            Horas = horas;
        }

        public double ValorTotal ()
        {
            return Horas * ValorPorHora;
        }
    }
}
