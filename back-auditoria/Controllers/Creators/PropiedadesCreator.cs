using System.Data;

namespace back_auditoria.Controllers.Creators
{

    //CREA LOS LAS PROPIEDADES QUE SE USARAN DENTRO DE LOS PARAMETROS
    internal class PropiedadesCreator
    {

        private List<ParametrosCreator> lista;

        public PropiedadesCreator()
        {
            lista = new List<ParametrosCreator>();
        }

        public List<ParametrosCreator> CrearListaPropiedades<T>(T entidad)
        {
            return ListarPropiedades(entidad);
        }


        private List<ParametrosCreator> ListarPropiedades<T>(T entidad)
        {
            lista.Clear();
            var propiedades = typeof(T).GetProperties();

            foreach (var propiedad in propiedades)
            {
                var nombreParametro = $"@{propiedad.Name}";
                var valor = propiedad.GetValue(entidad);
                var tipo = MapearTipo(propiedad.PropertyType);
                lista.Add(new ParametrosCreator(nombreParametro, valor, tipo));
            }

            return lista;
        }

        public List<ParametrosCreator> ListarPropiedadNoId<T>(T entidad)
        {
            lista.Clear();
            var propiedades = typeof(T).GetProperties();
            foreach (var propiedad in propiedades)
            {
                if (!(propiedad.Name.ToLower() == "id"))
                {
                    var nombreParametro = $"@{propiedad.Name}";
                    var valor = propiedad.GetValue(entidad);
                    var tipo = MapearTipo(propiedad.PropertyType);
                    lista.Add(new ParametrosCreator(nombreParametro, valor, tipo));
                }
            }
            return lista;
        }



        private List<ParametrosCreator> ListarPropiedadEspecifica<T>(string atributo, T entidad)
        {
            lista.Clear();
            var propiedades = typeof(T).GetProperties();
            foreach (var propiedad in propiedades)
            {
                if (propiedad.Name.ToLower() == atributo)
                {
                    var nombreParametro = $"@{propiedad.Name}";
                    var valor = propiedad.GetValue(entidad);
                    var tipo = MapearTipo(propiedad.PropertyType);
                    lista.Add(new ParametrosCreator(nombreParametro, valor, tipo));
                    break;
                }
            }
            return lista;
        }
        private List<ParametrosCreator> ListaPropiedadesEspecificas<T>(List<string> lista_propie, T entidad)
        {
            lista.Clear();
            var propiedades = typeof(T).GetProperties();
            int i = 0;
            foreach (var propiedad in propiedades)
            {
                /* foreach(string pro in lista_propie)
                // {
                    /* if (propiedad.Name.ToLower().ToString() == pro.ToString())
                     {*/
                var nombreParametro = $"@{propiedad.Name}";
                var valor = propiedad.GetValue(entidad);
                var tipo = MapearTipo(propiedad.PropertyType);
                lista.Add(new ParametrosCreator(nombreParametro, valor, tipo));
                break;

                //}
                //  }//

            }

            return lista;
        }



        public List<ParametrosCreator> CrearListaPropiedadesEspecificas<T>(List<string> lista_propie, T entidad)
        {
            return ListaPropiedadesEspecificas(lista_propie, entidad);
        }

        public List<ParametrosCreator> CrearListaPropiedadesEspecifica<T>(string propiedad, T entidad)
        {
            return ListarPropiedadEspecifica(propiedad, entidad);
        }

        public List<ParametrosCreator> CrearListaPropiedadesId<T>(T entidad)
        {
            return ListarPropiedadEspecifica("id", entidad);
        }

        public List<ParametrosCreator> CrearListaPropiedadesCedula<T>(T entidad)
        {
            return ListarPropiedadEspecifica("cedula", entidad);
        }


        private bool EsValorValido(object valor)
        {
            if (valor == null)
            {
                return false;
            }

            if (valor is string strValue && string.IsNullOrWhiteSpace(strValue))
            {
                return false;
            }

            if (valor is int intValue && intValue == 0)
            {
                return false;
            }
            return false;

            throw new ArgumentException("Valor no valido");
        }

        private static SqlDbType MapearTipo(Type tipo)
        {
            if (tipo == typeof(string))
                return SqlDbType.Text;
            if (tipo == typeof(int))
                return SqlDbType.Int;
            if (tipo == typeof(DateTime))
                return SqlDbType.Date;
            if (tipo == typeof(float))
                return SqlDbType.Float;
            if (tipo == typeof(bool))
                return SqlDbType.Bit;

            throw new ArgumentException("Tipo no soportado");
        }

    }
}
