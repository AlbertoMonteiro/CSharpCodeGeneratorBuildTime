namespace YouTubeCodeGen.TheApp
{
    public class PessoaDto
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public bool Casado { get; set; }
        public string YouTubeChannel { get; set; } = "https://www.youtube.com/channel/UCDTMgpC_HkyNTo03Yr2pFig";
        public string MiniBiografia { get; set; }

        public override string ToString()
            => $"Sou {Nome} tenho {Idade} anos de idade, {(Casado ? "sou" : "não")} sou casado e meu canal no YouTube é {YouTubeChannel}";
    }
}