﻿using System;
using System.Data.SqlClient;
using ConsoleTables;

namespace NubeFactJson
{
    public class NubeFact
    {
        public String fecha { get; set; }

        public void enviar() {
            SqlConnection conSqlServer = new Connection().initSqlServer();
            if (fecha == null)
            {
                Console.WriteLine("La fecha debe contener un valor");
                return;
            }
            try
            {
                conSqlServer.Open();
                SqlCommand sqlCmd = new SqlCommand("select tipo_comprobante, serie, numero from v_peru_facturas_reporte " +
                                                   "where fecha = @fecha " +
                                                   "and estado = 'False' " +
                                                   "order by serie, numero asc",
                                                   conSqlServer);

                sqlCmd.Parameters.AddWithValue("@fecha", this.fecha);

                SqlDataReader sqlRead = sqlCmd.ExecuteReader();

                var enviarFactura = new Enviar();

                while (sqlRead.Read())
                {
                    //var table = new ConsoleTable("Comprobante",
                                             //"Serie",
                                             //"#",
                                             //"Estado");

                    var generaFactura = new GeneraFactura(sqlRead["tipo_comprobante"].ToString(),
                                                          sqlRead["serie"].ToString(),
                                                          sqlRead["numero"].ToString());
                    
                    var factura = generaFactura.genera();
                    enviarFactura.factura(factura);

                    //table.AddRow(sqlRead["tipo"],
                    //             sqlRead["serie"],
                    //             sqlRead["numero"],
                    //             "Enviado a NubeFact");

                    //table.Write();
                }



                sqlRead.Close();
                conSqlServer.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en el reporte de  facturas" + ex.ToString());
            }
        }

        public void verificar() {
            SqlConnection conSqlServer = new Connection().initSqlServer();
            if (fecha == null)
            {
                Console.WriteLine("La fecha debe contener un valor");
                return;
            }
            try
            {
                conSqlServer.Open();
                SqlCommand sqlCmd = new SqlCommand("select tipo_comprobante, serie, numero from v_peru_facturas_reporte " +
                                                   "where fecha = @fecha " +
                                                   "and estado = 'False' " +
                                                   "order by serie, numero asc",
                                                   conSqlServer);

                sqlCmd.Parameters.AddWithValue("@fecha", this.fecha);

                SqlDataReader sqlRead = sqlCmd.ExecuteReader();

                var enviarFactura = new Enviar();

                while (sqlRead.Read())
                {
                    var table = new ConsoleTable("Comprobante",
                                             "Serie",
                                             "#",
                                             "Estado");

                    var generaFacturaVerificacion = new GeneraFactura(sqlRead["tipo_comprobante"].ToString(),
                                                          sqlRead["serie"].ToString(),
                                                          sqlRead["numero"].ToString(),
                                                          sqlRead["tipo_comprobante"].ToString());

                    var factura = generaFacturaVerificacion.generaVerificacion();
                    enviarFactura.facturaVerificacion(factura);

                    table.AddRow(sqlRead["tipo"],
                                 sqlRead["serie"],
                                 sqlRead["numero"],
                                 "Enviado a NubeFact");

                    table.Write();
                }
                InvoiceConsulta ic = new InvoiceConsulta();
                Console.WriteLine("OBJETO MONTADO");
                Console.WriteLine("obj grabado:" + ic.tipo_de_comprobante.ToString());
                Console.WriteLine("obj grabado:" + ic.serie.ToString());
                Console.WriteLine("obj grabado:" + ic.numero.ToString());
                //Console.WriteLine("obj grabado:" + ic.tipo_de_comprobante.ToString());

                sqlRead.Close();
                conSqlServer.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en el reporte de  facturas" + ex.ToString());
            }        
        }
    }
}
