/** **************************** "DEFAULT" KEYWORD *****************************
 * 
 * In generic classes and methods, one issue that arises is how to assign a
 * default value to a parameterized type T when you do not know the following in
 * advance:
 * 
 *  => Whether T will be a reference type or a value type.
 *  => If T is a value type, whether it will be a numeric value or a struct.
 *  
 * Given a variable t of a parameterized type T, the statement t = null is only
 * valid if T is a reference type and t = 0 will only work for numeric value
 * types but not for structs.
 * 
 * The solution is to use the default keyword, which will return null for
 * reference types and zero for numeric value types. For structs, it will return
 * each member of the struct initialized to zero or null depending on whether
 * they are value or reference types.
 * 
 *                               https://stackoverflow.com/a/2432926/14009797 */

// TODO => La pregunta es: ¿para qué necesito aquí un valor en default?


using System.Collections.Generic;


namespace Abstract
{
    public interface ICRUD<T>
    {
        void Alta(T objeto = default);
        void Baja(T objeto = default);
        void Modificacion(T objeto = default);

        List<T> ConsultaObjeto(T objeto = default);
        List<T> ConsultaRango(T objetoDesde = default, T objetoHasta = default);
    }
}
