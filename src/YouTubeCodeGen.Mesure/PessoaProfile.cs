using AutoMapper;
using YouTubeCodeGen.TheApp;

namespace YouTubeCodeGen.Mesure
{
    public class PessoaProfile : Profile
    {
        public PessoaProfile()
            => CreateMap<Pessoa, PessoaDto>()
                .ForMember(x => x.MiniBiografia, src => src.MapFrom(p => p.MiniBio));
    }
}
