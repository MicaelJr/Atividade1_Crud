using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula1_Crud.ViewModel
{
    //função novo
    //inicio
    public class NovoCommand : BaseCommand
    {
        public override bool CanExecute(object parameter)
        {
            return parameter is FuncionariosViewModel;
        }

        public override void Execute(object parameter)
        {
            var viewModel = (FuncionariosViewModel)parameter; // conversao de cast força o parametro se essa classe
            var funcionario = new Model.Funcionario();
            var maxId = 0;
            if (viewModel.Funcionarios.Any())
            {
                maxId = viewModel.Funcionarios.Max(f => f.Id);
            }
            funcionario.Id = maxId + 1;

            var fw = new FuncionarioWindow(); //criar uma nova instância de FuncionarioWindow 
            fw.DataContext = funcionario; //novo usuario criado
            fw.ShowDialog(); //recebe o valor do DialogResult que esta no evento do Ok_clik do formulario

            if (fw.DialogResult.HasValue && fw.DialogResult.Value) // verifica o valor do DialogResult e adiciona o novo funcionario
            {
                viewModel.Funcionarios.Add(funcionario);
                viewModel.FuncionarioSelecionado = funcionario;
            }
        }
    }
    //fim
}
