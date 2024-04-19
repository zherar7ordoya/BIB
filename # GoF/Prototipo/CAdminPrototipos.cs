using System;
using System.Collections.Generic;

namespace Prototipo
{
    public class CAdminPrototipos
    {
        private Dictionary<string, IPrototipo> prototipos = new Dictionary<string, IPrototipo>();
        public CAdminPrototipos()
        {
            // Adicionamos los objetos prototipo con los valores iniciales que nos interesan
            CPersona persona = new CPersona("Ciudadano", 1);
            prototipos.Add("Persona", persona);

            CValores valores = new CValores(10);
            prototipos.Add("Valores", valores);
        }

        public void AdicionarPrototipo(string pLlave, IPrototipo pPrototipo)
        {
            prototipos.Add(pLlave, pPrototipo);
        }
        public object ObtenerPrototipo(string pLlave)
        {
            return prototipos[pLlave].Clonar();
        }
    }
}