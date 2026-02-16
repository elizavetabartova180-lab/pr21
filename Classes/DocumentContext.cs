using System.Collections.Generic;
using System.Data.OleDb;
using Documents_Bartova.Classes.Common;
using Documents_Bartova.Interfaces;
using Documents_Bartova.Model;

namespace Documents_Bartova.Classes
{
    public class DocumentContext : Document , IDocument
    {
        public List<DocumentContext> AllDocuments()
        {
            List<DocumentContext> allDocuments = new List<DocumentContext>();
            OleDbConnection connection = DBConnection.Connection();
            OleDbDataReader dataDocuments = DBConnection.Querty("Select * From [Документы]" , connection);
            while (dataDocuments.Read())
            {
                allDocuments.Add(new DocumentContext()
                {
                    Id = dataDocuments.GetInt32(0),
                    Src = dataDocuments.GetString(1),
                    Name = dataDocuments.GetString(2),
                    User = dataDocuments.GetString(3),
                    IdDocument = dataDocuments.GetInt32(4),
                    Date = dataDocuments.GetDateTime(5),
                    Status = dataDocuments.GetInt32(6),
                    Direction = dataDocuments.GetString(7)

                });
            }
            DBConnection.CloseConnection(connection);
            return allDocuments;
        }
        public void Delete()
        {
            OleDbConnection connection = DBConnection.Connection();
            DBConnection.Querty(
                    $"DELETE FROM [Документы] WHERE [Код] = {this.Id}", connection);
            DBConnection.CloseConnection(connection);
        }
        public void Save(bool update = false) 
        {
            OleDbConnection connection = DBConnection.Connection();
            if (update)
            {
                DBConnection.Querty(
                    $"UPDATE" +
                        $"[Документы]" +
                    $"SET" +
                        $"[Изображение] = '{this.Src}'," +
                        $"[Наименование] = '{this.Name}'," +
                        $"[Ответственный] = '{this.User}'," +
                        $"[Код документа] = '{this.IdDocument}'," +
                        $"[Дата поступления] = '{this.Date.ToString("dd.MM.yyyy")}'," +
                        $"[Статус] = '{this.Status}'," +
                        $"[Направление] = '{this.Direction}'" +
                    $"WHERE" +
                        $"[Код] = {this.Id}", connection);
            }
            else {
                DBConnection.Querty(
                    $"INSENT INTO +" +
                        $"[Документы](" +
                        $"[Изображение]," +
                        $"[Наименование]," +
                        $"[Ответственный]," +
                        $"[Код документа]," +
                        $"[Дата поступления]," +
                        $"[Статус]," +
                        $"[Направление])" +
                    $" VALUES (" +
                    $"'{this.Src}'," +
                    $" '{this.Name}'," +
                    $" '{this.User}'," +
                    $" '{this.IdDocument}'," +
                    $" '{this.Date.ToString("dd.MM.yyyy")}'," +
                    $" '{this.Status}'," +
                    $" '{this.Direction}',)", connection);
            }
            DBConnection.CloseConnection(connection );
        }
    }
}
