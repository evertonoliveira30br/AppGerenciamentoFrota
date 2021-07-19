using System;
using System.Collections.Generic;
using System.Text;

namespace AppGerenciamentoFrota.Interfaces
{
    public interface IContextDapper
    {
        T ExecuteScalar<T>(string commandText, object parameters);
        T ExcecuteObject<T>(string commandText, object parameters);
        IEnumerable<T> ExecuteCollection<T>(string commandText, object parameters);
    }
}
