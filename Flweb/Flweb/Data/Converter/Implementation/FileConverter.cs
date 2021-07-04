using Flweb.Data.Converter.Contract;
using Flweb.Data.VO;
using Flweb.Model;
using System.Collections.Generic;
using System.Linq;

namespace Flweb.Data.Converter.Implementation
{
    public class FileConverter : IParser<FileDetailVO, File>, IParser<File, FileDetailVO>
    {
        public File Parse(FileDetailVO origin)
        {
            throw new System.NotImplementedException();
        }

        public List<File> Parse(List<FileDetailVO> origin)
        {
            throw new System.NotImplementedException();
        }

        public FileDetailVO Parse(File origin)
        {
            throw new System.NotImplementedException();
        }

        public List<FileDetailVO> Parse(List<File> origin)
        {
            throw new System.NotImplementedException();
        }
    }
}
