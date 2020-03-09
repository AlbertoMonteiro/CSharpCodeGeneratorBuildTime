using System;

namespace YouTubeCodeGen.TheApp
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var type in typeof(Program).Assembly.GetTypes())
                Console.WriteLine(type.FullName);

            IPessoaMapper mapper = new PessoaMapper();

            var pessoaDto = mapper.MapPessoa(new Pessoa
            {
                Nome = "Alberto Monteiro",
                Idade = 29,
                Casado = true
            });

            Console.WriteLine(pessoaDto);
        }
    }
}
