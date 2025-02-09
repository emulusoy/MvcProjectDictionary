using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T> //bu t ben hangi repository gonderirsem o olacak!
    {
        List<T> List();
        void Insert(T p);

        T Get(Expression<Func<T, bool>> filter);

        void Delete(T p);
        void Update(T p);
        List<T> List(Expression<Func<T, bool>>filter);//burasi da sartli listeleme yazar adi su olani getir gibi
    }
}
