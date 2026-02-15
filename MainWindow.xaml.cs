using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using Documents_Bartova.Classes;
using Documents_Bartova.Model;

namespace Documents_Bartova
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static MainWindow init;
        public List<DocumentContext> AllDocuments = new DocumentContext().AllDocuments();
        public MainWindow()
        {
            InitializeComponent();
            init = this;
        }
    }
}
