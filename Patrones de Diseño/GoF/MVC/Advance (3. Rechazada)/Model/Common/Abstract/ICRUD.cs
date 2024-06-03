using System.Collections.Generic;

namespace Model
{
    internal interface ICRUD<T> where T : class
    {
        int Create(T objeto);
        List<T> ReadAll(string condicion = "");
        T ReadById(int id);
        int Update(T objeto);
        int Delete(int id);
    }
}
