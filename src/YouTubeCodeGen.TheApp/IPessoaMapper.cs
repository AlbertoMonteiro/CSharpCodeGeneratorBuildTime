using System.ComponentModel;
using YouTubeCodeGen.CodeGenerator;

namespace YouTubeCodeGen.TheApp
{
    [MapObject]
    public interface IPessoaMapper
    {
        [MapProperty(nameof(Pessoa.MiniBio), nameof(PessoaDto.MiniBiografia))]
        [DisplayName]
        PessoaDto MapPessoa(in Pessoa pessoa);
    }
}
