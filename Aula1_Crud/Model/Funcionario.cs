using Aula1_Crud;
using System;

namespace Model
{
    public class Funcionario : BaseNotifyPropertyChanged, ICloneable
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { SetField(ref _id, value); }
        }

        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set { SetField(ref _nome, value); }
        }

        private string _sobrenome;
        public string Sobrenome
        {
            get { return _sobrenome; }
            set { SetField(ref _sobrenome, value); }
        }

        private DateTime _dataNascimento;
        public DateTime DataNascimento
        {
            get { return _dataNascimento; }
            set { SetField(ref _dataNascimento, value); }
        }
                        
        private DateTime _dataAdmissao;
        internal RelayCommand comando;

        public DateTime DataAdmissao
        {
            get { return _dataAdmissao; }
            set { SetField(ref _dataAdmissao, value); }
        }

        // retorna uma copia do objeto funcionario
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }


}