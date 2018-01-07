﻿using System;
using System.Data.SqlClient;

namespace NubeFactJson
{
    public class GrabarRespuesta
    {
        String tipoComprobante;
        String serie;
        String numero;
        Respuesta respuesta;

        public GrabarRespuesta(string tipoComprobante, string serie, string numero, Respuesta respuesta)
        {            
            this.tipoComprobante = tipoComprobante;
            this.serie = serie;
            this.numero = numero;
            this.respuesta = respuesta;
        }

        public void borrarGrabar () {
            SqlConnection conSqlServer = new Connection().initSqlServer();
            try
            {
                conSqlServer.Open();

                SqlCommand sqlCmdDelete = new SqlCommand("delete peru_respuesta " +
                                                         "where tipo = @tipo " +
                                                         "and serie = @serie " +
                                                         "and numero = @numero", conSqlServer);

                sqlCmdDelete.Parameters.AddWithValue("@tipo", this.tipoComprobante);
                sqlCmdDelete.Parameters.AddWithValue("@serie", this.serie);
                sqlCmdDelete.Parameters.AddWithValue("@numero", this.numero);

                sqlCmdDelete.ExecuteNonQuery();

                SqlCommand sqlCmdInsert = new SqlCommand("INSERT INTO peru_respuesta " +
                                                         "(tipo, serie, numero, enlace, aceptada_por_sunat, sunat_description, sunat_note, sunat_responsecode, sunat_soap_error, pdf_zip_base64, xml_zip_base64, cdr_zip_base64, cadena_para_codigo_qr, codigo_hash, enlace_del_pdf, enlace_del_xml, enlace_del_cdr) " +
                                                         "VALUES(" +
                                                         "@tipo, " +
                                                         "@serie, " +
                                                         "@numero, " +
                                                         "@enlace, " +
                                                         "@aceptada_por_sunat, " +
                                                         "@sunat_description, " +
                                                         "@sunat_note, " +
                                                         "@sunat_responsecode, " +
                                                         "@sunat_soap_error, " +
                                                         "@pdf_zip_base64, " +
                                                         "@xml_zip_base64, " +
                                                         "@cdr_zip_base64, " +
                                                         "@cadena_para_codigo_qr, " +
                                                         "@codigo_hash, " +
                                                         "@enlace_del_pdf, " +
                                                         "@enlace_del_xml, " +
                                                         "@enlace_del_cdr)",
                                                         conSqlServer);
                
                sqlCmdInsert.Parameters.AddWithValue("@tipo", this.tipoComprobante);
                sqlCmdInsert.Parameters.AddWithValue("@serie", this.serie);
                sqlCmdInsert.Parameters.AddWithValue("@numero", this.numero);
                sqlCmdInsert.Parameters.AddWithValue("@enlace", this.respuesta.url);
                sqlCmdInsert.Parameters.AddWithValue("@aceptada_por_sunat", this.respuesta.aceptada_por_sunat);
                sqlCmdInsert.Parameters.AddWithValue("@sunat_description", this.respuesta.sunat_description);
                sqlCmdInsert.Parameters.AddWithValue("@sunat_note", this.respuesta.sunat_note);
                sqlCmdInsert.Parameters.AddWithValue("@sunat_responsecode", this.respuesta.sunat_responsecode);
                sqlCmdInsert.Parameters.AddWithValue("@sunat_soap_error", this.respuesta.sunat_soap_error);
                sqlCmdInsert.Parameters.AddWithValue("@pdf_zip_base64", this.respuesta.pdf_zip_base64);
                sqlCmdInsert.Parameters.AddWithValue("@xml_zip_base64", this.respuesta.xml_zip_base64);
                sqlCmdInsert.Parameters.AddWithValue("@cdr_zip_base64", this.respuesta.cdr_zip_base64);
                sqlCmdInsert.Parameters.AddWithValue("@cadena_para_codigo_qr", this.respuesta.cadena_para_codigo_qr);
                sqlCmdInsert.Parameters.AddWithValue("@codigo_hash", this.respuesta.codigo_hash);
                sqlCmdInsert.Parameters.AddWithValue("@enlace_del_pdf", this.respuesta.enlace_del_pdf);
                sqlCmdInsert.Parameters.AddWithValue("@enlace_del_xml", this.respuesta.enlace_del_xml);
                sqlCmdInsert.Parameters.AddWithValue("@enlace_del_cdr", this.respuesta.enlace_del_cdr);


                sqlCmdInsert.ExecuteNonQuery();


                conSqlServer.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al grabar la Respuesta" + ex.ToString());
            }
        }

        Boolean existe() {
            SqlConnection conSqlServer = new Connection().initSqlServer();
            int count = 0;
            try
            {
                conSqlServer.Open();
                SqlCommand sqlCmd = new SqlCommand("select count(*) as count from peru_respuesta " +
                                                   "where tipo = @tipo " +
                                                   "and serie = @serie " +
                                                   "and numero = @numero", conSqlServer);
                
                sqlCmd.Parameters.AddWithValue("@tipoComprobante", this.tipoComprobante);
                sqlCmd.Parameters.AddWithValue("@serie", this.serie);
                sqlCmd.Parameters.AddWithValue("@numero", this.numero);

                SqlDataReader sqlRead = sqlCmd.ExecuteReader();

                while (sqlRead.Read())
                {
                    count = int.Parse(sqlRead["count"].ToString());
                }
                if (count > 0) {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al verificar la Respuesta" + ex.ToString());
            }
            return false;
        }
    }
}
