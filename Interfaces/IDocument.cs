using System.Collections.Generic;

namespace Documents_Bartova.Interfaces
{
    public interface IDocument
    {
        void Save(bool update = false);
        List<Model.Document> AllDocuments();
        void Delete();
    }
}
