using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula1_Crud.ViewModel
{
    public class FuncionariosViewModel : BaseNotifyPropertyChanged
    {
        // ObservableCollection implementa as notificações de alteração (edit/exc) p/ WPF atualizar aut. o Grid (atualiza a tela de forma dinamica)
        public System.Collections.ObjectModel.ObservableCollection<Model.Funcionario> Funcionarios { get; private set; }  

        private Model.Funcionario _funcionarioSelecionado;
        public Model.Funcionario FuncionarioSelecionado
        {
            get { return _funcionarioSelecionado; }
            set 
            { 
                SetField(ref _funcionarioSelecionado, value);
                Deletar.RaiseCanExecuteChanged(); // notificar ao mecanismo de binding do WPF que o valor do “CanExecute” do botão deletar foi alterado
                Editar.RaiseCanExecuteChanged(); //chama o método do comando quando o valor da propriedade “FuncionarioSelecionado” for alterado
            }
        }

        //apresenta o funcionario selecionado na tela (grid)
        public FuncionariosViewModel()
        {
            Funcionarios = new System.Collections.ObjectModel.ObservableCollection<Model.Funcionario>();
            Funcionarios.Add(new Model.Funcionario()
            {
                Id = 1,
                Nome = "Micael",
                Sobrenome = "Silva",
                DataNascimento = new DateTime(1995, 12, 21),
                DataAdmissao = new DateTime(2021, 12, 27)
            });

            FuncionarioSelecionado = Funcionarios.FirstOrDefault();
        }
        public DeletarCommand Deletar { get; private set; } = new DeletarCommand(); //instância do comando  deletar
        public NovoCommand Novo { get; private set; } = new NovoCommand(); //instância do comando  Novo
        public EditarCommand Editar { get; private set; } = new EditarCommand(); //instância do comando  Editar
    }

    //função deletar
    //inicio
    public class DeletarCommand : BaseCommand
    {
        
        public override bool CanExecute(object parameter)
        {
            var viewModel = parameter as FuncionariosViewModel;
            return viewModel != null && viewModel.FuncionarioSelecionado != null;

        }

        public override void Execute(object parameter)
        {
            var viewModel = (FuncionariosViewModel)parameter;
            viewModel.Funcionarios.Remove(viewModel.FuncionarioSelecionado);
            viewModel.FuncionarioSelecionado = viewModel.Funcionarios.FirstOrDefault(); //configura a propriedade com o primeiro registro (sfc)
            
        }
        
    }
    //fim

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
            var viewModel = (FuncionariosViewModel)parameter;
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
