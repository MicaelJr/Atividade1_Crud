using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula1_Crud.ViewModel
{
    //função editar
    //inicio
    public class EditarCommand : BaseCommand
    {
        public override bool CanExecute(object parameter)
        {
            var viewModel = parameter as FuncionariosViewModel;
            return viewModel != null && viewModel.FuncionarioSelecionado != null;
        }

        // clona o funcionario selecionado -  manda pra janela FW - click OK = copia os novos valores no funcionario selecionado
        public override void Execute(object parameter)
        {
            var viewModel = (FuncionariosViewModel)parameter;
            var cloneFuncionario = (Model.Funcionario)viewModel.FuncionarioSelecionado.Clone();
            var fw = new FuncionarioWindow();
            fw.DataContext = cloneFuncionario;
            fw.ShowDialog(); //recebe o valor do DialogResult que esta no evento do Ok_clik do formulario

            if (fw.DialogResult.HasValue && fw.DialogResult.Value) // verifica o valor do DialogResult e altera os dados do funcionario
            {
                viewModel.FuncionarioSelecionado.Nome = cloneFuncionario.Nome;
                viewModel.FuncionarioSelecionado.Sobrenome = cloneFuncionario.Sobrenome;
                viewModel.FuncionarioSelecionado.DataNascimento = cloneFuncionario.DataNascimento;
                viewModel.FuncionarioSelecionado.DataAdmissao = cloneFuncionario.DataAdmissao;
            }
        }
    }
    //fim
}
