using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    public class BusinessLogic
    {
        DBTransaction transaccion = new DBTransaction();
        public bool ValidaConexionSQL()
        {
            bool Exitosa = transaccion.ValidaConexionSQL();
            return Exitosa;
        }

        public bool Sesion(string user, string pass)
        {
            bool r = transaccion.SesionRespuesta(user, pass);
            return r;
        }

        //public string CrearOperador(Fmd pResult, int pempID)
        //{
        //    Operator oOperador;
        //    string Mensaje;

        //    conexion = ValidaConexionSQL();

        //    if (conexion)
        //    {
        //        oOperador = CompararHuella(pResult);

        //        if (oOperador == null)
        //        {
        //            string huellaString = Convert.ToBase64String(pResult.Bytes);

        //            oOperador = new Operator();
        //            oOperador.empID = pempID;
        //            oOperador.Huella = huellaString;

        //            Mensaje = transaccion.CrearOperador(oOperador);
        //        }

        //        else
        //        {
        //            Mensaje = "No permitido, Ya existe un operador registrado con esta huella";
        //        }
        //    }

        //    else
        //    {
        //        Mensaje = "Error al conectar con el servidor";
        //    }


        //    return Mensaje;
        //}

        //public List<Operator> ListarOp([Optional]int opc)
        //{
        //    List<Operator> listarOp;
        //    if (opc == 1)
        //    {
        //        listarOp = transaccion.ListarOpSinHuella();

        //    }
        //    else
        //    {
        //        listarOp = transaccion.ListarOpConHuella();
        //    }

        //    return listarOp;
        //}
    }
}
