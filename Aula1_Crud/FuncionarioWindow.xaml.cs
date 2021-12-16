using Aula1_Crud.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Aula1_Crud
{
    /// <summary>
    /// Lógica interna para FuncionarioWindow.xaml
    /// </summary>
    public partial class FuncionarioWindow : Window
    {
        public FuncionarioWindow()
        {
            InitializeComponent();
        }
                
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true; //pegar o resultado do clique OK da tela
        }
    }
}
