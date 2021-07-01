﻿using Flweb.Data.Converter.Contract;
using Flweb.Data.VO;
using Flweb.Model;
using System.Collections.Generic;
using System.Linq;

namespace Flweb.Data.Converter.Implementation
{
    public class ArquivoConverter : IParser<FileVO, Arquivo>, IParser<Arquivo, FileVO>
    {
        public Arquivo Parse(FileVO origin)
        {
            if (origin == null) return null;

            return new Arquivo
            {
                Name = origin.Name
            };
        }
        public FileVO Parse(Arquivo origin)
        {
            if (origin == null) return null;

            return new FileVO
            {
                Name = origin.Name
            };
        }

        public List<Arquivo> Parse(List<FileVO> origin)
        {
            if (origin == null)
            {
                return null;
            }
            else
            {
                return origin.Select(item => Parse(item)).ToList();
            }
        }

        public List<FileVO> Parse(List<Arquivo> origin)
        {
            if (origin == null)
            {
                return null;
            }
            else
            {
                return origin.Select(item => Parse(item)).ToList();
            }
        }
    }
}
