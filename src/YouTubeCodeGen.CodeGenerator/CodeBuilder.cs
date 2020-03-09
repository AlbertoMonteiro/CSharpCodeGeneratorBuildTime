using System.Text;

namespace YouTubeCodeGen.CodeGenerator
{
    public class CodeBuilder
    {
        private readonly StringBuilder _stringBuilder = new StringBuilder();
        private string _identation = "";

        public void Write(string str)
            => _stringBuilder.AppendLine(_identation + str);

        public void StartBlock()
        {
            _stringBuilder.AppendLine(_identation + "{");
            _identation = _identation.PadLeft(_identation.Length + 4, ' ');
        }

        public void EndBlock()
        {
            _stringBuilder.AppendLine(_identation + "}");
            _identation = _identation.Substring(4);
        }

        public override string ToString() 
            => _stringBuilder.ToString();
    }
}
