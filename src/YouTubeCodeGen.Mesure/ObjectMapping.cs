using AutoMapper;
using BenchmarkDotNet.Attributes;
using YouTubeCodeGen.TheApp;

namespace YouTubeCodeGen.Mesure
{
    [MemoryDiagnoser, MinColumn, MaxColumn]
    public class ObjectMapping
    {
        private readonly Mapper _mapper;
        private readonly IPessoaMapper _pessoaMapper;
        private readonly Pessoa _pessoa;

        public ObjectMapping()
        {
            _mapper = new Mapper(new MapperConfiguration(c => c.AddProfile<PessoaProfile>()));
            _pessoaMapper = new PessoaMapper();
            _pessoa = new Pessoa
            {
                Nome = "Alberto Monteiro",
                Idade = 29,
                Casado = true,
                MiniBio = "Mini Biografia"
            };
        }

        [Benchmark]
        public PessoaDto MapearComAutoMapper()
            => _mapper.Map<PessoaDto>(_pessoa);

        [Benchmark]
        public PessoaDto MapearComGerador()
            => _pessoaMapper.MapPessoa(_pessoa);
    }
}
