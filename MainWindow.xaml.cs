using System.Collections.Generic;
using System.Windows;
using Documents_Bartova.Classes;

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

            frame.Navigate(new Pages.Main());
        }
    }
}
