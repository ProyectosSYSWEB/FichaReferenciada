using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports;

#region Hecho por
//Nombre:      Melissa Alejandra Rodríguez González
//Correo:      melissargz@hotmail.com
//Institución: Unach
#endregion


namespace EmisionPagoReferenciado
{
    public partial class VisualizadorCrystal : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {


            String cverep = Convert.ToString(Request.QueryString["cverep"]);
            String Nombre = Convert.ToString(Request.QueryString["Nombre"]);
            String Referencia = Convert.ToString(Request.QueryString["Referencia"]);
            Double Importe = Convert.ToDouble(Request.QueryString["Importe"]);
            String Vigencia = Convert.ToString(Request.QueryString["Vigencia"]);
            String Concepto = Convert.ToString(Request.QueryString["Concepto"]);
            String Matricula = Convert.ToString(Request.QueryString["Matricula"]);
            String Evento = Convert.ToString(Request.QueryString["Evento"]);
            String Observaciones = Convert.ToString(Request.QueryString["Observaciones"]);            
            Int32 idFact = Convert.ToInt32(Request.QueryString["idFact"]);
            Int32 idFicha = Convert.ToInt32(Request.QueryString["idFicha"]);

            String Reporte = "";
            if (cverep == "1")
            {
                rptPDF("\\Reportes\\Ficha_Referenciada.rpt", Nombre, Referencia, Importe, Vigencia, Concepto, Observaciones);
            }
            else if (cverep == "2")
            {
                rptPDF2("\\Reportes\\Inf_Ficha_Referenciada.rpt", Evento, Matricula);
            }
            else if (cverep == "3")
            {
                Reporte = "Reportes\\RepComprobanteFiscal.rpt";
                object[] Valores = { idFact };
                rptReporte_FE(Reporte, Valores);
            }
            else if (cverep == "4")
                rptPDFAdjunto("\\Reportes\\Ficha_Referenciada.rpt", Nombre, Referencia, Importe, Vigencia, Concepto, Observaciones);
            else if (cverep == "5")
            {
                Reporte = "Reportes\\rptFicha_Referenciada.rpt";
                object[] v1 = { idFicha, Observaciones };
                rptPDF_Ingresos(Reporte, v1, "Ficha Referenciada");
            }
            else if (cverep == "REP_SIAE")
            {
                Reporte = "Reportes\\Ficha_Referenciada_SIAE.rpt";
                object[] v1 = { idFicha };
                rptPDF_Ingresos(Reporte, v1, "Ficha Referenciada");
            }
        }
        private void rptPDF_Ingresos(String Reporte, object[] Parametros, string NombreReporte)
        {
            System.Web.UI.Page p = new System.Web.UI.Page();
            CrystalDecisions.CrystalReports.Engine.ReportDocument report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);

                for (int i = 0; i <= Parametros.Length - 1; i++)
                    report.SetParameterValue(i, Parametros[i]);

                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "ingresos";
                connectionInfo.Password = "unach09";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, NombreReporte);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CR_Reportes.ReportSource = report;
                report.Close();
                report.Dispose();
                CR_Reportes.Dispose();
            }
        }

        private void rptPDFReferencia(String Reporte, String Nombre, String Referencia)
        {
            System.Web.UI.Page p = new System.Web.UI.Page();
            CrystalDecisions.CrystalReports.Engine.ReportDocument report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

            try
            {

                // ConnectionInfo connectionInfo = new ConnectionInfo();
                //string J = System.AppDomain.CurrentDomain.BaseDirectory + Reporte;
                report.Load(p.Server.MapPath("~") + Reporte);
                //report.Load(System.AppDomain.CurrentDomain.BaseDirectory + Reporte);                
                report.SetParameterValue(0, Referencia);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "FichaReferenciada-" + Nombre.Substring(0, 15));

            }
            catch (Exception ex)
            {

            }
            finally
            {

                CR_Reportes.ReportSource = report;
                report.Close();
                report.Dispose();
                CR_Reportes.Dispose();
            }
        }
        private void rptReporte_FE(String Reporte, object[] Valores)
        {
            System.Web.UI.Page p = new System.Web.UI.Page();
            CrystalDecisions.CrystalReports.Engine.ReportDocument report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                for (int i = 0; i <= Valores.Length - 1; i++)
                    report.SetParameterValue(i, Valores[i]);
                
                report.PrintOptions.PaperSize = PaperSize.PaperLetter;
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "felectronica";
                connectionInfo.Password = "unach09";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "RepComprobanteFiscal");
                CR_Reportes.ReportSource = report;
                report.Close();
                report.Dispose();
            }
            catch (Exception ex)
            {

            }
            finally
            {

                //report.Close();
                //report.Dispose();

                CR_Reportes.Dispose();
            }
        }
        private void rptPDF(String Reporte, String Nombre, String Referencia, Double Importe, String Vigencia, String Concepto, String Observaciones)
        {
            System.Web.UI.Page p = new System.Web.UI.Page();
            CrystalDecisions.CrystalReports.Engine.ReportDocument report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
               
            try
            {

               // ConnectionInfo connectionInfo = new ConnectionInfo();
                //string J = System.AppDomain.CurrentDomain.BaseDirectory + Reporte;
                report.Load(p.Server.MapPath("~") + Reporte);
                //report.Load(System.AppDomain.CurrentDomain.BaseDirectory + Reporte);
                report.SetParameterValue(0, Nombre);
                report.SetParameterValue(1, Referencia);
                report.SetParameterValue(2, Importe);
                report.SetParameterValue(3, Vigencia);
                report.SetParameterValue(4, Concepto);
                report.SetParameterValue(5, Observaciones);
                report.PrintOptions.PaperSize = PaperSize.PaperLetter;
                //connectionInfo.ServerName = "ucad";
                //connectionInfo.UserID = "ingresos";
                //connectionInfo.Password = "unach09";
                //SetDBLogonForReport(connectionInfo, report);
                //string archivo = p.Server.MapPath("~") + "/ArchivoReferencia/Referencia - " + Referencia + ".PDF";
                //report.ExportToDisk(ExportFormatType.PortableDocFormat, archivo); // "FichaReferenciada-" + Nombre.Substring(0, 15));
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Referencia - " + Referencia);
                
            }
            catch (Exception ex)
            {

            }
            finally
            {

                CR_Reportes.ReportSource = report;
                report.Close();
                report.Dispose();
                CR_Reportes.Dispose();
            }
        }
        private void rptPDFAdjunto(String Reporte, String Nombre, String Referencia, Double Importe, String Vigencia, String Concepto, String Observaciones)
        {
            System.Web.UI.Page p = new System.Web.UI.Page();
            CrystalDecisions.CrystalReports.Engine.ReportDocument report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

            try
            {

                // ConnectionInfo connectionInfo = new ConnectionInfo();
                //string J = System.AppDomain.CurrentDomain.BaseDirectory + Reporte;
                report.Load(p.Server.MapPath("~") + Reporte);
                //report.Load(System.AppDomain.CurrentDomain.BaseDirectory + Reporte);
                report.SetParameterValue(0, Nombre);
                report.SetParameterValue(1, Referencia);
                report.SetParameterValue(2, Importe);
                report.SetParameterValue(3, Vigencia);
                report.SetParameterValue(4, Concepto);
                report.SetParameterValue(5, Observaciones);
                report.PrintOptions.PaperSize = PaperSize.PaperLetter;
                //connectionInfo.ServerName = "ucad";
                //connectionInfo.UserID = "ingresos";
                //connectionInfo.Password = "unach09";
                //SetDBLogonForReport(connectionInfo, report);
                string archivo = p.Server.MapPath("~") + "/ArchivoReferencia/Referencia - " + Referencia + ".PDF";
                //report.SaveAs(archivo);
                report.ExportToDisk(ExportFormatType.PortableDocFormat, archivo); // "FichaReferenciada-" + Nombre.Substring(0, 15));
                //report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Referencia - " + Referencia);

            }
            catch (Exception ex)
            {

            }
            finally
            {

                CR_Reportes.ReportSource = report;
                report.Close();
                report.Dispose();
                CR_Reportes.Dispose();
            }
        }
        private void rptPDF2(String Reporte, string Evento, string Matricula)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                System.Web.UI.Page p = new System.Web.UI.Page();
                CrystalDecisions.CrystalReports.Engine.ReportDocument report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                report.Load(p.Server.MapPath("~") + Reporte);
                report.SetParameterValue(0, Matricula);
                report.SetParameterValue(1, Evento);
                report.PrintOptions.PaperSize = PaperSize.PaperLetter;
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "ingresos";
                connectionInfo.Password = "unach09";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "FichaReferenciada");
                CR_Reportes.ReportSource = report;
                report.Close();
                report.Dispose();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                //CR_Reportes.ReportSource = report;
              
                CR_Reportes.Dispose();
            }
        }        
        private void SetDBLogonForReport(ConnectionInfo connectionInfo, ReportDocument reportDocument)
        {
            try
            {
                Tables tables = reportDocument.Database.Tables;

                foreach (CrystalDecisions.CrystalReports.Engine.Table table in tables)
                {
                    TableLogOnInfo tableLogonInfo = table.LogOnInfo;
                    tableLogonInfo.ConnectionInfo = connectionInfo;
                    table.ApplyLogOnInfo(tableLogonInfo);
                }

            }
            catch (Exception ex)
            {
            }
        }
   
    }
}