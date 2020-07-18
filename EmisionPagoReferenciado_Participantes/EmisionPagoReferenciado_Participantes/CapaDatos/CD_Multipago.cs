using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.IO;
using CapaEntidad;

#region Hecho por
//Nombre:      Melissa Alejandra Rodríguez González
//Correo:      melissargz@hotmail.com
//Institución: Unach
#endregion

namespace CapaDatos
{
    public class CD_Multipago
    {
        public void InsertarMultipago_Transaccion(ref MultiPago ObjMultipago, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {


                string[] ParametrosIn = {"p_origen",
                                        "p_account",
                                        "p_order",
                                        "p_reference",
                                        "p_node",
                                        "p_concept",
                                        "p_amount",
                                        "p_currency",
                                        "p_paymentmethod",
                                        "p_paymentmethodcomplete",
                                        "p_response",
                                        "p_responsecomplete",
                                        "p_responsemsg",
                                        "p_responsemsgcomplete",
                                        "p_authorization",
                                        "p_authorizationcomplete",
                                        "p_pan",
                                        "p_pancomplete",
                                        "p_date",
                                        "p_signature",
                                        "p_customername",
                                        "p_promo_msi",
                                        "p_bankcode",
                                        "p_saleid",
                                        "p_sale_historyid",
                                        "p_trx_historyid",
                                        "p_trx_historyidcomplete",
                                        "p_bankname",
                                        "p_folio",
                                        "p_cardholdername",
                                        "p_cardholdernamecomplete",
                                        "p_authorization_mp1",
                                        "p_phone",
                                        "p_email",
                                        "p_promo",
                                        "p_promo_msi_bank",
                                        "p_securepayment",
                                        "p_cardtype",
                                        "p_id_ficha_bancaria",
                                        "p_carrera"};
                object[] Valores = { ObjMultipago.Origen,ObjMultipago.Account,
                                      ObjMultipago.Order,
                                      ObjMultipago.Reference,
                                      ObjMultipago.Node,ObjMultipago.Concept,
                                      ObjMultipago.Amount,ObjMultipago.Currency,ObjMultipago.PaymentMethod,ObjMultipago.PaymentMethodComplete,
                                      ObjMultipago.Response,ObjMultipago.ResponseComplete,ObjMultipago.Responsemsg,ObjMultipago.ResponseMsgComplete,
                                      ObjMultipago.Authorization,ObjMultipago.AuthorizationComplete,ObjMultipago.Pan,ObjMultipago.PanComplete,
                                      ObjMultipago.Date,ObjMultipago.Signature,ObjMultipago.Customername,ObjMultipago.Promo_Msi,ObjMultipago.Bankcode,
                                      ObjMultipago.Saleid,ObjMultipago.Sale_Historyid,ObjMultipago.Trx_Historyid,ObjMultipago.Trx_Historyidcomplete,
                                      ObjMultipago.Bankname,ObjMultipago.Folio,ObjMultipago.Cardholdername,"","",ObjMultipago.Phone,ObjMultipago.Email,ObjMultipago.Promo,ObjMultipago.Promo_msi_bank,
                                      ObjMultipago.Securepayment,ObjMultipago.Cardtype,ObjMultipago.IdFichaBancaria,ObjMultipago.Carrera
            };
                string[] ParametrosOut ={                                        
                                          "p_BANDERA","p_Id_Factura"
                };

                Cmd = CDDatos.GenerarOracleCommand("INS_MULTIPAGOS_TRANSACCION", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                ObjMultipago.Id_Fact = Convert.ToInt32(Cmd.Parameters["p_Id_Factura"].Value);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmd);
            }
        }
    }
}
