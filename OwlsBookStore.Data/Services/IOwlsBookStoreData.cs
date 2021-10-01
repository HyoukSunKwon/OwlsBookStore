using OwlsBookStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwlsBookStore.Data.Services
{
    public interface IOwlsBookStoreData
    {
        IEnumerable<Writer> GetAll();
    }
}
