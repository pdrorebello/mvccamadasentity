using System;
using System.Collections.Generic;
using System.Linq;
using WebAppMVC.Model;
using WebAppMVC.Bll.Repositorio;
using WebAppMVC.DAL.Persistencia;


namespace WebAppMVC.Bll.RegraNegocio
{
    public class regranegocioTime
    {
        IdalTime _daltime;

        public regranegocioTime()
        {
            //cria uma instância do repositorio Time
            _daltime = new repositorioTime();
        }

        public bool Adicionar(Time objTime)
        {

            bool insert = false;

            try
            {
                //Adiciona Time
                _daltime.Add(objTime);
                _daltime.Commit();

                insert = true;

                return insert;
            }
            catch (Exception)
            {
                return false;
                throw;
            }


        }

        public bool Atualizar(Time objTime)
        {

            bool update = false;

            try
            {

                //Atualiza Time
                _daltime.Update(objTime);
                _daltime.Commit();

                update = true;

                return update;
            }
            catch (Exception)
            {
                throw;
            }


        }

        public bool Deletar(Time objTime)
        {

            bool delete = false;

            try
            {


                //Deleta Time
                _daltime.Excluir(c => c == objTime);
                _daltime.Commit();

                delete = true;

                return delete;

            }
            catch (Exception)
            {
                throw;
            }


        }

        public List<Time> Pesquisar()
        {

            try
            {
                //retorna todos os times
                var lstTime = _daltime.GetAll().ToList();

                // Listar todos os times
                return lstTime;

            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
