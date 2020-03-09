using AutoMapper;
using YouTubeCodeGen.TheApp;

namespace YouTubeCodeGen.Mesure
{
    public class PessoaProfile : Profile
    {
        public PessoaProfile()
            => CreateMap<Pessoa, PessoaDto>();
    }
}
