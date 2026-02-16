using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using Documents_Bartova.Classes;
using Microsoft.Win32;

namespace Documents_Bartova.Pages
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        string s_src = "";
        DocumentContext Document;
        public Add(DocumentContext documentContext = null)
        {
            InitializeComponent();
            if (documentContext != null) { 
                Document = documentContext;

                if(File.Exists(documentContext.Src))
                    src.Source = new BitmapImage(new Uri(documentContext.Src));
                tbName.Text = documentContext.Name;
                tbUser.Text = documentContext.User;
                tbCode.Text = documentContext.IdDocument.ToString();
                tbDate.Text = documentContext.Date.ToString("dd.MM.yyyy");
                tbStatus.SelectedIndex = documentContext.Status;
                tbDirection.Text = documentContext.Direction;
            }
        }

        private void Back(object sender, RoutedEventArgs e) =>
            MainWindow.init.frame.Navigate(new Main());

        private void SelectImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "c:\\";
            ofd.Filter = "PNG (*.png)|*.pnf|All files (*.*)|*.*";
            ofd.FilterIndex = 2;
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                src.Source = new BitmapImage(new Uri(ofd.FileName));
                s_src = ofd.FileName;
            }
        }

        private void AddDocument(object sender, RoutedEventArgs e)
        {
            if (s_src.Length == 0)
            {
                MessageBox.Show("Необходимо выбрать изображение");
                return;
            }
            if (tbName.Text.Length == 0)
            {
                MessageBox.Show("Необходимо указать наименование");
                return;
            }
            if (tbUser.Text.Length == 0)
            {
                MessageBox.Show("Необходимо указать ответственного");
                return;
            }
            if (tbCode.Text.Length == 0)
            {
                MessageBox.Show("Необходимо указать код документа");
                return;
            }
            if (tbDate.Text.Length == 0)
            {
                MessageBox.Show("Необходимо указать дату поступления");
                return;
            }
            if (tbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Необходимо выбрать статус документа");
                return;
            }
            if (tbDirection.Text.Length == 0)
            {
                MessageBox.Show("Необходимо указать направление");
                return;
            }
            if (Document == null)
            {
                Document = new DocumentContext()
                {
                    Src = s_src,
                    Name = tbName.Text,
                    User = tbUser.Text,
                    IdDocument = Convert.ToInt32(tbCode.Text),
                    Date = DateTime.Parse(tbDate.Text),
                    Status = tbStatus.SelectedIndex,
                    Direction = tbDirection.Text

                };
                Document.Save();
                MessageBox.Show("Документ добавлен");
            }
            else {
                Document.Src = s_src;
                Document.Name = tbName.Text;
                Document.User = tbUser.Text;
                Document.IdDocument = Convert.ToInt32(tbCode.Text);
                Document.Date = DateTime.Parse(tbDate.Text);
                Document.Status = tbStatus.SelectedIndex;
                Document.Direction = tbDirection.Text;
                Document.Save(true);
                MessageBox.Show("Документ изменён");
            }
            MainWindow.init.AllDocuments = new DocumentContext().AllDocuments();
            MainWindow.init.frame.Navigate(new Main());
        }
    }
}
