namespace Matricula.Models
{
    public class Student
    {
        public string NomeEstudante { get; set; }
        public int  CPF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Curso { get; set; }   // Nome do curso
        public string Turno { get; set; }       // Turno
        public DateTime DataNas { get; set; }  // Data de nascimento
    }
}
