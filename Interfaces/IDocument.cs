using System.Collections.Generic;
using Documents_Bartova.Classes;

namespace Documents_Bartova.Interfaces
{
    public interface IDocument
    {
        void Save(bool update = false);
        List<DocumentContext> AllDocuments();
        void Delete();
    }
}
