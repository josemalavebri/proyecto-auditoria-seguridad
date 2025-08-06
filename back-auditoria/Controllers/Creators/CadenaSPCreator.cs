using System.Text;

internal class CadenaSPCreator
{
    private StringBuilder cadenaFinal;

    public CadenaSPCreator()
    {
        cadenaFinal = new StringBuilder();
    }

    private string CrearCadenaFinal(string codigo, string rol)
    {
        cadenaFinal.Clear();
        cadenaFinal.Append(codigo);
        cadenaFinal.Append(rol);
        return cadenaFinal.ToString();
    }

    public string CrearProcedimientoAlmacenado(string sp_query, string rol)
    {
        return CrearCadenaFinal(sp_query, rol);
    }
}
