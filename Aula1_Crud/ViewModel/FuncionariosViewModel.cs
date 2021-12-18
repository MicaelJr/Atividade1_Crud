using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Aula1_Crud.ViewModel
{
    public class FuncionariosViewModel : BaseNotifyPropertyChanged
    {
        // ObservableCollection notifica a view das alteração
        public ObservableCollection<Model.Funcionario> Funcionarios { get; private set; }  

        private Model.Funcionario _funcionarioSelecionado;
        public Model.Funcionario FuncionarioSelecionado
        {
            get { return _funcionarioSelecionado; }
            set 
            { 
                SetField(ref _funcionarioSelecionado, value);
                Deletar.RaiseCanExecuteChanged(); // notifica o mecanismo de binding do WPF que o valor do “CanExecute” foi alterado, assim desabilita o btndeletar na tela
                Editar.RaiseCanExecuteChanged(); //notifica o mecanismo de binding do WPF que o valor do “CanExecute” foi alterado, assim desabilita o btneditar na tela
            }
        }

        //apresenta o funcionario selecionado na tela (grid)
        public FuncionariosViewModel()
        {
            Funcionarios = new ObservableCollection<Model.Funcionario>();//ObservableCollection notifica a tela
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


}
