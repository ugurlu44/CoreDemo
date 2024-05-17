using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IWriterService 
    {
        void WriterAdd(Writer writer);
        List<Writer> GetList();
    }
}
