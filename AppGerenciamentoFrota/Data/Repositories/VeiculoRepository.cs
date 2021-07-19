using AppGerenciamentoFrota.Data.Entities;
using AppGerenciamentoFrota.Infra;
using AppGerenciamentoFrota.Interfaces;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System;

namespace AppGerenciamentoFrota.Data.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly GerenciamentoFrotaContext _context;
        public VeiculoRepository(GerenciamentoFrotaContext context)
        {
            _context = context;
        }

        public void DeletarVeiculo(Veiculo veiculo)
        {

            try
            {
                _context.Remove<Veiculo>(veiculo);
                _context.SaveChanges();
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public void EditarCorVeiculo(Veiculo veiculo)
        {


            try
            {
                _context.Entry(veiculo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            
        }

        public void InserirNovoVeiculo(Veiculo veiculo)
        {

            try
            {
                _context.Add<Veiculo>(veiculo);
                _context.SaveChanges();
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        
        }
        public IEnumerable<Veiculo> ListarVeiculos()
        {

            try
            {
                return (from c in _context.Veiculo
                        select c
                    );
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }          

        }

        public Veiculo PesquisarVeiculoPorChassi(string chassi)
        {
            try
            {
                return _context.Veiculo.Where(v => v.Chassi == chassi).FirstOrDefault();
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            
        }
    }
}
