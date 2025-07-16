using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterMessageService : IGenericService<WriterMessage>
        
    {
        List<WriterMessage> TGetListSenderMessage(string p);
        List<WriterMessage> TGetListReciverMessage(string p);
        //List<WriterMessage> TGetbyFilter(string p, string p2); // If you need to filter by two parameters
        //List<WriterMessage> TGetbyFilter(string p, string p2, string p3); // If you need to filter by three parameters
    }
}
