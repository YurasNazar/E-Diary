using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Factories
{
    public interface IFileModelFactory
    {
        public File PrepareFileModel(string fileName, string path);
    }
}
