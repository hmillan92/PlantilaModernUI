using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DBTransaction
    {
        public void DACliente()
        {
            DaConnectSQL DASQLConnection = new DaConnectSQL();
        }

        public bool ValidaConexionSQL()
        {
            bool Exitosa = false;
            var ConClass = new DaConnectSQL();

            ConClass.Open();

            if (ConClass.Con.State == ConnectionState.Open)
                Exitosa = true;

            return Exitosa;
        }

        public bool SesionRespuesta(string user, string pass)
        {
            bool response = false;
            var ConClass = new DaConnectSQL();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConClass.DASQLConnection();
            cmd.CommandType = CommandType.Text;

            try
            {
                ConClass.Open();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cmd.Connection;
                cmd.CommandText = "Select * From Users where UserLogin ='" + user + "' and Pass ='" + pass + "'";


                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    response = true;
                }
            }

            catch (Exception ex)
            {
                string Mensaje = ex.Message;
            }

            return response;


            //public string CrearOperador(Operator oOperador)
            //{
            //    string Respuesta;
            //    var ConClass = new DaConnectSQL();

            //    try
            //    {
            //        SqlCommand cmd = new SqlCommand();
            //        cmd.Connection = ConClass.DASQLConnection();
            //        cmd.CommandType = CommandType.Text;
            //        cmd.Transaction = ConClass.Tran;
            //        ConClass.Open();
            //        cmd.Transaction = ConClass.Con.BeginTransaction();

            //        cmd.CommandText = "Insert into Operadores (empID, Huella) " +
            //                "Values  ('" + oOperador.empID + "','" + oOperador.Huella + "')";

            //        cmd.ExecuteNonQuery();
            //        cmd.Transaction.Commit();
            //        Respuesta = "Registro creado";
            //    }

            //    catch (Exception ex)
            //    {
            //        ConClass.RollBackTransaction();
            //        Respuesta = ex.Message;
            //    }

            //    finally
            //    {
            //        ConClass.Close();
            //    }

            //    return Respuesta;
            //}

            //public List<Operator> ListarOpSinHuella()
            //{
            //    List<Operator> ListaOpSH = new List<Operator>();
            //    var ConClass = new DaConnectSQL();

            //    SqlCommand cmd = new SqlCommand();
            //    cmd.Connection = ConClass.DASQLConnection();
            //    cmd.CommandType = CommandType.Text;

            //    try
            //    {
            //        ConClass.Open();
            //        cmd.CommandType = CommandType.Text;
            //        cmd.Connection = cmd.Connection;
            //        cmd.CommandText = "Select T2.empID,T2.firstName,T2.lastName From SBO_DAALTEXT_RC.dbo.ORSC T0 INNER JOIN SBO_DAALTEXT_RC.dbo.RSC4 T1 on T0.ResCode = T1.ResCode INNER JOIN SBO_DAALTEXT_RC.dbo.OHEM T2 ON T1.EmpID = T2.empID LEFT JOIN Operadores T3 ON T1.EmpID = t3.empID where T2.Active = 'Y' and T3.Huella IS NULL";


            //        SqlDataReader dr = cmd.ExecuteReader();

            //        while (dr.Read())
            //        {
            //            {
            //                Operator OpQuery = new Operator();
            //                OpQuery.empID = dr.GetInt32(0);
            //                OpQuery.firstName = dr.GetString(1);
            //                OpQuery.lastName = dr.GetString(2);

            //                ListaOpSH.Add(OpQuery);
            //            }
            //        }
            //        dr.Close();
            //    }

            //    catch (Exception ex)
            //    {
            //        string Mensaje = ex.Message;
            //    }
            //    return ListaOpSH;
            //}
        }
    }
}
