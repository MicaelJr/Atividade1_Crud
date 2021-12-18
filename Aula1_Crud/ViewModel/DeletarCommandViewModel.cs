using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula1_Crud.ViewModel
{
    //função deletar
    //inicio
    public class DeletarCommand : BaseCommand
    {

        public override bool CanExecute(object parameter)
        {
            var viewModel = parameter as FuncionariosViewModel;// nao e recomendado não usar var usar o tipo da direita
            return viewModel != null && viewModel.FuncionarioSelecionado != null;

        }

        public override void Execute(object parameter)
        {
            var viewModel = (FuncionariosViewModel)parameter;
            viewModel.Funcionarios.Remove(viewModel.FuncionarioSelecionado); // exclui o funcionario selecionado
            viewModel.FuncionarioSelecionado = viewModel.Funcionarios.FirstOrDefault(); //passa a ser o funcionario selecioando o primeiro registro (se tiver outro)

        }

    }
    //fim
}
