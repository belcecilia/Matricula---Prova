using System.ComponentModel.DataAnnotations;

namespace Matricula.Models
{
    public class Student
    {
        public int Id { get; set; } // Chave primária, identificador único do aluno

        public string NomeEstudante { get; set; } // Nome completo do aluno

        public string CPF { get; set; } // CPF do aluno, agora como string para suportar formatos e tamanhos variados

        public string Telefone { get; set; } // Telefone do aluno

        public string Email { get; set; } // E-mail do aluno

        public string Curso { get; set; } // Curso em que o aluno está matriculado

        public string Turno { get; set; } // Turno em que o aluno estuda (manhã, tarde, noite)

        public DateTime DataNas { get; set; } // Data de nascimento do aluno
    }
}
