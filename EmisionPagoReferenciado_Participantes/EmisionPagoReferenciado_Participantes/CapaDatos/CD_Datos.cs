﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Data;
using System.Data.OracleClient;
#region Hecho por
//Nombre:      Lisseth Gtz. Gómez
//Correo:      melissargz@hotmail.com
//Institución: Unach
#endregion

namespace CapaDatos
{
    public class CD_Datos
    {
        #region Variable
        string StrConexion = "Data Source=DSIA;User ID=ingresos; Password=unach09; Unicode=True";
        private OracleConnection Cnn;
        private OracleTransaction trans;
        OracleCommand functionReturnValue = default(OracleCommand);
        #endregion
        #region Constructor
        public CD_Datos()
        {
            this.Cnn = new OracleConnection(StrConexion);
        }
        #endregion
        #region Métodos Transacción

        public void StartTrans()
        {
            if (Cnn.State == ConnectionState.Closed) Cnn.Open();
            if (trans == null) trans = Cnn.BeginTransaction();
        }

        public void CommitTrans()
        {
            trans.Commit();
            trans.Dispose();
            Cnn.Close();
        }

        public void RollBackTrans()
        {
            trans.Rollback();
            trans.Dispose();
            Cnn.Close();
        }
        #endregion
        #region Métodos
        #region ExecuteReader
        public OracleCommand GenerarOracleCommand(string SP, ref OracleDataReader dr)
        {

            try
            {
                functionReturnValue = new OracleCommand(SP, Cnn);
                functionReturnValue.CommandType = CommandType.StoredProcedure;

                if (trans != null) functionReturnValue.Transaction = trans;
                if (trans == null) Cnn.Open();
                StartTrans();
                dr = functionReturnValue.ExecuteReader(CommandBehavior.CloseConnection);
                CommitTrans();
            }
            catch (Exception ex)
            {
                RollBackTrans();
                throw new Exception(ex.Message);
            }
            return functionReturnValue;
        }
        public OracleCommand GenerarOracleCommand(string SP, string tableName, ref DataTable dt)
        {

            try
            {
                functionReturnValue = new OracleCommand(SP, Cnn);
                functionReturnValue.CommandType = CommandType.StoredProcedure;

                if (trans != null) functionReturnValue.Transaction = trans;
                if (trans == null) Cnn.Open();

                OracleDataAdapter da = new OracleDataAdapter(functionReturnValue);
                dt = new DataTable(tableName);
                da.Fill(dt);
                da.Dispose();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return functionReturnValue;
        }
        public OracleCommand GenerarOracleCommand(string SP, string tableName, ref DataTable dt, string[] Parametros, object[] Valores)
        {
            try
            {
                functionReturnValue = new OracleCommand(SP, Cnn);
                functionReturnValue.CommandType = CommandType.StoredProcedure;

                if (trans != null) functionReturnValue.Transaction = trans;
                if (trans == null) Cnn.Open();

                if (Parametros != null)
                    for (int i = 0; i <= Parametros.Length - 1; i++)
                        functionReturnValue.Parameters.AddWithValue(Parametros[i], Valores[i]);
                OracleDataAdapter da = new OracleDataAdapter(functionReturnValue);
                dt = new DataTable(tableName);
                da.Fill(dt);
                da.Dispose();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return functionReturnValue;
        }
        public OracleCommand GenerarOracleCommand(string SP, ref OracleDataReader dr, string[] Parametros, object[] Valores)
        {
            try
            {
                functionReturnValue = new OracleCommand(SP, Cnn);
                functionReturnValue.CommandType = CommandType.StoredProcedure;

                if (trans != null) functionReturnValue.Transaction = trans;
                if (trans == null) Cnn.Open();

                if (Parametros != null)
                    for (int i = 0; i <= Parametros.Length - 1; i++)
                        functionReturnValue.Parameters.AddWithValue(Parametros[i], Valores[i]);
                dr = functionReturnValue.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return functionReturnValue;
        }
        #region Cursor
        public OracleCommand GenerarOracleCommandCursor(string SP, ref OracleDataReader dr)
        {
            try
            {
                functionReturnValue = new OracleCommand(SP, Cnn);
                functionReturnValue.CommandType = CommandType.StoredProcedure;

                if (trans != null) functionReturnValue.Transaction = trans;
                if (trans == null) Cnn.Open();

                functionReturnValue.Parameters.Add("p_registros", OracleType.Cursor).Direction = ParameterDirection.Output;
                dr = functionReturnValue.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return functionReturnValue;
        }
        public OracleCommand GenerarOracleCommandCursor(string SP, ref OracleDataReader dr, string[] Parametros, object[] Valores)
        {
            try
            {
                functionReturnValue = new OracleCommand(SP, Cnn);
                functionReturnValue.CommandType = CommandType.StoredProcedure;

                if (trans != null) functionReturnValue.Transaction = trans;
                if (trans == null) Cnn.Open();

                if (Parametros != null)
                    for (int i = 0; i <= Parametros.Length - 1; i++)
                        functionReturnValue.Parameters.Add(Parametros[i], OracleType.VarChar).Value = Valores[i];
                functionReturnValue.Parameters.Add("p_registros", OracleType.Cursor).Direction = ParameterDirection.Output;
                dr = functionReturnValue.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return functionReturnValue;
        }
        #endregion
        #endregion
        #region ExecuteScalar
        public OracleCommand GenerarOracleCommand(string SP, ref string verificador)
        {
            try
            {
                functionReturnValue = new OracleCommand(SP, Cnn);
                functionReturnValue.CommandType = CommandType.StoredProcedure;

                if (trans != null) functionReturnValue.Transaction = trans;
                if (trans == null) Cnn.Open();

                verificador = Convert.ToString(functionReturnValue.ExecuteNonQuery());
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
            return functionReturnValue;
        }
        public OracleCommand GenerarOracleCommand(string SP, ref string verificador, string[] Parametros, object[] Valores)
        {
            try
            {
                functionReturnValue = new OracleCommand(SP, Cnn);
                functionReturnValue.CommandType = CommandType.StoredProcedure;

                if (trans != null) functionReturnValue.Transaction = trans;
                if (trans == null) Cnn.Open();

                if (Parametros != null)
                    for (int i = 0; i <= Parametros.Length - 1; i++)
                        functionReturnValue.Parameters.AddWithValue(Parametros[i], Valores[i]);
                object res = functionReturnValue.ExecuteScalar();
                verificador = Convert.ToString(res);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return functionReturnValue;
        }

        public OracleCommand GenerarOracleCommand(string SP, object resultado, string[] Parametros, object[] Valores)
        {
            try
            {
                functionReturnValue = new OracleCommand(SP, Cnn);
                functionReturnValue.CommandType = CommandType.StoredProcedure;

                if (trans != null) functionReturnValue.Transaction = trans;
                if (trans == null) Cnn.Open();

                if (Parametros != null)
                    for (int i = 0; i <= Parametros.Length - 1; i++)
                        functionReturnValue.Parameters.AddWithValue(Parametros[i], Valores[i]);
                resultado = functionReturnValue.ExecuteScalar();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return functionReturnValue;
        }
        #endregion
        #region ExecuteNonQuery
        //public OracleCommand GenerarOracleCommand(string SP, ref string Verificador, string[] ParametrosIn, string[] Valores, string[] ParametrosOut)
        //{

        //    OracleCommand cmd = new OracleCommand(SP, Cnn);
        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;

        //    for (int i = 0; i < ParametrosIn.Length; i++)
        //    {
        //        cmd.Parameters.Add(ParametrosIn[i], OracleType.VarChar).Value = Valores[i];
        //    }

        //    for (int i = 0; i < ParametrosOut.Length; i++)
        //    {
        //        cmd.Parameters.Add(ParametrosOut[i], OracleType.VarChar, 1024).Direction = ParameterDirection.Output;
        //    }


        //    try
        //    {
        //        Cnn.Open();
        //        //dr = cmd.ExecuteReader();
        //        cmd.ExecuteNonQuery();
        //        Verificador = cmd.Parameters["p_Bandera"].Value.ToString();
        //        return cmd;
        //    }


        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }

        //}
        public OracleCommand GenerarOracleCommand(string SP, ref string Verificador, string[] ParametrosIn, object[] Valores, string[] ParametrosOut)
        {

            OracleCommand cmd = new OracleCommand(SP, Cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            for (int i = 0; i < ParametrosIn.Length; i++)
            {
                cmd.Parameters.Add(ParametrosIn[i], OracleType.VarChar).Value = Valores[i];
            }

            for (int i = 0; i < ParametrosOut.Length; i++)
            {
                cmd.Parameters.Add(ParametrosOut[i], OracleType.VarChar, 1024).Direction = ParameterDirection.Output;
            }


            try
            {
                if (trans != null) cmd.Transaction = trans;
                if (trans == null) Cnn.Open();
                cmd.ExecuteNonQuery();
                Verificador = cmd.Parameters["p_bandera"].Value.ToString();
                return cmd;
            }


            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
        public OracleCommand GenerarOracleCommand(string SP, string[] ParametrosIn, object[] Valores, string[] ParametrosOut)
        {

            OracleCommand cmd = new OracleCommand(SP, Cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            for (int i = 0; i < ParametrosIn.Length; i++)
            {
                cmd.Parameters.Add(ParametrosIn[i], OracleType.VarChar).Value = Valores[i];
            }

            for (int i = 0; i < ParametrosOut.Length; i++)
            {
                cmd.Parameters.Add(ParametrosOut[i], OracleType.VarChar, 1024).Direction = ParameterDirection.Output;
            }


            try
            {
                if (trans != null) cmd.Transaction = trans;
                if (trans == null) Cnn.Open();
                cmd.ExecuteNonQuery();

                return cmd;
            }


            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
        public OracleCommand GenerarOracleCommand_NonQuery(string SP, string[] Parametros, object[] Valores)
        {
            try
            {
                functionReturnValue = new OracleCommand(SP, Cnn);
                functionReturnValue.CommandType = CommandType.StoredProcedure;

                if (trans != null) functionReturnValue.Transaction = trans;
                if (trans == null) Cnn.Open();

                if (Parametros != null)
                    for (int i = 0; i <= Parametros.Length - 1; i++)
                        functionReturnValue.Parameters.AddWithValue(Parametros[i], Valores[i]);
                functionReturnValue.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
            return functionReturnValue;
        }
        public OracleCommand GenerarOracleCommand_Imagen(string SP, string[] ParametrosIn, object[] Valores, string[] ParametrosOut, ref string Verificador)
        {
            OracleCommand cmd = new OracleCommand(SP, Cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            for (int i = 0; i < ParametrosIn.Length; i++)
            {
                cmd.Parameters.Add(ParametrosIn[i], OracleType.VarChar).Value = Valores[i];
            }

            for (int i = 0; i < ParametrosOut.Length; i++)
            {
                cmd.Parameters.Add(ParametrosOut[i], OracleType.VarChar, 1024).Direction = ParameterDirection.Output;
            }
            
            cmd.Parameters.Add("p_imagen", OracleType.Blob).Direction = ParameterDirection.Output;

            try
            {
                if (trans != null) cmd.Transaction = trans;
                if (trans == null) Cnn.Open();
                cmd.ExecuteNonQuery();
                Verificador = cmd.Parameters["P_Bandera"].Value.ToString();
                return cmd;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }


        }
        #endregion
        #region ExecuteAdapter
        public OracleCommand GenerarOracleCommandCursor(string SP, ref OracleDataAdapter da, string[] Parametros, object[] Valores)
        {
            try
            {
                functionReturnValue = new OracleCommand(SP, Cnn);
                functionReturnValue.CommandType = CommandType.StoredProcedure;

                if (trans != null) functionReturnValue.Transaction = trans;
                if (trans == null) Cnn.Open();

                if (Parametros != null)
                    for (int i = 0; i <= Parametros.Length - 1; i++)
                        functionReturnValue.Parameters.Add(Parametros[i], OracleType.VarChar).Value = Valores[i];
                functionReturnValue.Parameters.Add("p_registros", OracleType.Cursor).Direction = ParameterDirection.Output;
                da.SelectCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return functionReturnValue;
        }
        #endregion
        #region Limpiar
        public void LimpiarOracleCommand(ref OracleCommand Cmm)
        {
            try
            {
                if (Cmm != null)
                {
                    Cmm.Connection.Close();
                    Cmm.Connection.Dispose();
                    Cmm.Dispose();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
            finally
            {
                if (Cnn.State != System.Data.ConnectionState.Closed)
                {
                    Cnn.Close();
                }
            }
        }
        #endregion
        #endregion
    }

}