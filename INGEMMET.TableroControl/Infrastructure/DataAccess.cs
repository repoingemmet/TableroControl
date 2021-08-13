using INGEMMET.TableroControl.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace INGEMMET.TableroControl.Infrastructure
{
    public class DataAccess
    {
        //ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
        //Metodo         : ListarDatosGenericos
        //Creado por     : Anderson Ruiz (21/03/2017)
        //ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
        /// <summary>
        /// Lista los datos de la tabla ged_m_lista
        /// </summary>
        /// <param name="tipo">Parámetro de filtro</param>
        /// <returns></returns>
        public List<TablaGenerica> ListarDatosGenericos(string tipo)
        {
            List<TablaGenerica> lisQuery = null;
            Database Db = DatabaseFactory.CreateDatabase();
            string sSql = @"SELECT tipo,
                                codigo,
                                descripcion,
                                detalle,
                                adicional,
                                adicional2, 
                                adicional3 
                                FROM ged_m_lista c 
                              WHERE c.tipo = :IN_TIPO 
                              AND indicador_activo='A' 
                              ORDER BY orden ASC";
            using (DbCommand dbcommand = Db.GetSqlStringCommand(sSql))
            {
                Db.AddInParameter(dbcommand, "IN_TIPO", DbType.String, tipo);
                using (IDataReader dtrQuery = Db.ExecuteReader(dbcommand))
                {
                    lisQuery = new List<TablaGenerica>();
                    while (dtrQuery.Read())
                    {
                        TablaGenerica entQuery = new TablaGenerica();
                        entQuery.tipo = (string)dtrQuery["TIPO"].ToString();
                        entQuery.codigo = (string)dtrQuery["CODIGO"].ToString();
                        entQuery.descripcion = (string)dtrQuery["DESCRIPCION"].ToString();
                        entQuery.detalle = (string)dtrQuery["DETALLE"].ToString();
                        entQuery.adicional = (string)dtrQuery["ADICIONAL"].ToString();
                        entQuery.adicional2 = (string)dtrQuery["ADICIONAL2"].ToString();
                        entQuery.adicional3 = (string)dtrQuery["ADICIONAL3"].ToString();
                        lisQuery.Add(entQuery);
                    }
                }
            }
            return lisQuery;
        }


        //ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
        //Metodo         : GetListMenu
        //Creado por     : Anderson Ruiz (31/10/2017)
        //ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
        /// <summary>
        /// Listado del menú del tablero de control
        /// </summary>
        /// <returns></returns> 
        public List<TablaGenerica> GetListMenu()
        {
            List<TablaGenerica> lisQuery = null;
            Database db = DatabaseFactory.CreateDatabase();
            using (DbCommand dbCommand = db.GetStoredProcCommand("PACK_DBA_TABCONTROL.P_LIST_MENUTABLERO", new object[1]))
            {
                using (IDataReader dtrQuery = db.ExecuteReader(dbCommand))
                {
                    try
                    {
                        lisQuery = new List<TablaGenerica>();
                        while (dtrQuery.Read())
                        {
                            TablaGenerica entQuery = new TablaGenerica();
                            entQuery.tipo = (string)dtrQuery["TIPO"].ToString();
                            entQuery.codigo = (string)dtrQuery["CODIGO"].ToString();
                            entQuery.descripcion = (string)dtrQuery["DESCRIPCION"].ToString();
                            entQuery.detalle = (string)dtrQuery["DETALLE"].ToString();
                            entQuery.adicional = (string)dtrQuery["ADICIONAL"].ToString();
                            entQuery.adicional2 = (string)dtrQuery["ADICIONAL2"].ToString();
                            entQuery.adicional3 = (string)dtrQuery["CODIGO_PADRE"].ToString();
                            lisQuery.Add(entQuery);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
            return lisQuery;
        }
    }
}