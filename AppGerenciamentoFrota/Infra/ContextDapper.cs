using AppGerenciamentoFrota.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace AppGerenciamentoFrota.Infra
{
    public class ContextDapper : IContextDapper
    {
        protected SqlConnection _connection;
        IConfiguration _configuration;

        public ContextDapper(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new SqlConnection(_configuration.GetConnectionString(""));
        }

        public T ExcecuteObject<T>(string commandText, object parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> ExecuteCollection<T>(string commandText, object parameters)
        {
            throw new NotImplementedException();
        }

        public T ExecuteScalar<T>(string commandText, object parameters)
        {
            throw new NotImplementedException();
        }

        private void OpenConnection()
        {
            if(_connection.State == ConnectionState.Closed)
            {
                try
                {
                    _connection.Open();
                }
                catch (SqlException sqlException)
                {
                    throw sqlException;
                }
                catch(InvalidOperationException invalidException)
                {
                    throw invalidException;
                }
            }
        }

        private void CloseConnection()
        {
            if (_connection.State != ConnectionState.Closed)
                _connection.Close();
        }
    }
}
