namespace ControlWork.Entities
{
    class Departamento
    {
        public string Nome { get; set; }

        public Departamento()
        {

        }
        // Construtor para receber o nome do Departamento que será vinculado ao trabalhador
        public Departamento (string nome)
        {
            Nome = nome;
        }
    }
}
