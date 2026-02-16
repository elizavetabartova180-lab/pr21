using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Documents_Bartova.Classes;

namespace Documents_Bartova.Elements
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        DocumentContext Document;
        public Item(DocumentContext documentContext)
        {
            InitializeComponent();
            img.Source = new BitmapImage(new Uri(documentContext.Src));
            lName.Content = documentContext.Name;
            lUser.Content = "Ответственный: " + documentContext.User;
            lCode.Content = "Код документа: " + documentContext.IdDocument;
            lDate.Content = "Дата поступления: " + documentContext.Date.ToString("dd.MM.yyyy");
            lStatus.Content = documentContext.Status == 0 ? "Статус: входящий" : "Статус: исходящий";
            lDirection.Content = "Направление: " + documentContext.Direction;

            this.Document = documentContext;
        }

        public void EditeDocument(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.Add(Document));
        }

        public void DeleteDocument(object sender, RoutedEventArgs e)
        {
            Document.Delete();
            MainWindow.init.AllDocuments = new DocumentContext().AllDocuments();
            MainWindow.init.frame.Navigate(new Pages.Main());
        }
    }
}
