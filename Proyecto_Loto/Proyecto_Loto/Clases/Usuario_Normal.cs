﻿using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Loto.Clases
{
    public static class Usuario_Normal
    {
        public static MySqlConnection Conexion;
        public static MySqlCommand cmd;
        public static MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
        public static ArrayList Conexiones = new ArrayList();

        public static string Conectar()
        {
            try
            {
                builder.Server = "localhost";
                builder.Port = 3306;
                builder.UserID = "root";
                builder.Password = "agente86";
                builder.Database = "loto";
                Conexion = new MySqlConnection(builder.ToString());
                Conexion.Open();

                return "Se conecto la base de datos";
            }
            catch (Exception e)
            {

                return "No se conecto la base de datos";
            }
        }

        public static string Desconectar()
        {
            try
            {
                Conexion.Close();

                return "Se cerro la base de datos";
            }
            catch (Exception e)
            {
                return "No se cerro la base de datos";
            }
            finally
            {

            }
        }

        public static float consultar_ganancias_usuario_normal(int id_usuario)
        {
            string consulta = "select MONTO_PAGADO, MONTO_APUESTA, COMISIONVENTA, COMISIONPARTICIPACION" +
                " from tb_usuario A, tb_ticket B, tb_comision C" +
                " where A.id_usuario = B.id_usuario" +
                " and A.id_usuario = C.id_usuario" +
                " and B.fecha_hora <= C.fechafin" +
                " and B.fecha_hora >= C.fechainicio" +
                " and A.id_usuario = " + id_usuario;

            try
            {
                cmd = new MySqlCommand(consulta, Conexion);
                MySqlDataReader myReader = cmd.ExecuteReader();

                float total_ganado = 0;
                float total_apostado = 0;
                float totalganancias = 0;
                float totalperdidas = 0;
                float comisionventa = 0;
                float comisionparticipacion = 0;

                while (myReader.Read())
                {
                    total_ganado = myReader.GetFloat(0);
                    total_apostado = myReader.GetFloat(1);
                    comisionventa = myReader.GetFloat(2);
                    comisionparticipacion = myReader.GetFloat(3);

                    if (total_apostado > total_ganado)
                        totalganancias += (total_apostado - total_ganado) * comisionventa / 100;
                    else if (total_ganado > total_apostado)
                        totalperdidas += (total_ganado - total_apostado) * comisionparticipacion / 100;
                }

                myReader.Close();

                if (totalganancias > totalperdidas)
                    return totalganancias - totalperdidas;

                return 0;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public static float consultar_perdidas_usuario_normal(int id_usuario)
        {
            string consulta = "select MONTO_PAGADO, MONTO_APUESTA, COMISIONVENTA, COMISIONPARTICIPACION" +
                " from tb_usuario A, tb_ticket B, tb_comision C" +
                " where A.id_usuario = B.id_usuario" +
                " and A.id_usuario = C.id_usuario" +
                " and B.fecha_hora <= C.fechafin" +
                " and B.fecha_hora >= C.fechainicio" +
                " and A.id_usuario = " + id_usuario;

            try
            {
                cmd = new MySqlCommand(consulta, Conexion);
                MySqlDataReader myReader = cmd.ExecuteReader();

                float total_ganado = 0;
                float total_apostado = 0;
                float totalganancias = 0;
                float totalperdidas = 0;
                float comisionventa = 0;
                float comisionparticipacion = 0;

                while (myReader.Read())
                {
                    total_ganado = myReader.GetFloat(0);
                    total_apostado = myReader.GetFloat(1);
                    comisionventa = myReader.GetFloat(2);
                    comisionparticipacion = myReader.GetFloat(3);

                    if (total_apostado > total_ganado)
                        totalganancias += (total_apostado - total_ganado) * comisionventa / 100;
                    else if (total_ganado > total_apostado)
                        totalperdidas += (total_ganado - total_apostado) * comisionparticipacion / 100;
                }

                myReader.Close();

                if (totalperdidas > totalganancias)
                    return totalperdidas - totalganancias;

                return 0;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public static float consultar_ganancias_usuario_normal_fecha(int id_usuario, string fecha)
        {
            string consulta = "select MONTO_PAGADO, MONTO_APUESTA, COMISIONVENTA, COMISIONPARTICIPACION" +
                " from tb_usuario A, tb_ticket B, tb_comision C" +
                " where A.id_usuario = B.id_usuario" +
                " and A.id_usuario = C.id_usuario" +
                " and B.fecha_hora <= C.fechafin" +
                " and B.fecha_hora >= C.fechainicio" +
                " and A.id_usuario = " + id_usuario +
                " and B.fecha_hora >= \"" + fecha + "\"";

            try
            {
                cmd = new MySqlCommand(consulta, Conexion);
                MySqlDataReader myReader = cmd.ExecuteReader();

                float total_ganado = 0;
                float total_apostado = 0;
                float totalganancias = 0;
                float totalperdidas = 0;
                float comisionventa = 0;
                float comisionparticipacion = 0;

                while (myReader.Read())
                {
                    total_ganado = myReader.GetFloat(0);
                    total_apostado = myReader.GetFloat(1);
                    comisionventa = myReader.GetFloat(2);
                    comisionparticipacion = myReader.GetFloat(3);

                    if (total_apostado > total_ganado)
                        totalganancias += (total_apostado - total_ganado) * comisionventa / 100;
                    else if (total_ganado > total_apostado)
                        totalperdidas += (total_ganado - total_apostado) * comisionparticipacion / 100;
                }

                myReader.Close();

                if (totalganancias > totalperdidas)
                    return totalganancias - totalperdidas;

                return 0;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public static float consultar_perdidas_usuario_normal_fecha(int id_usuario, string fecha)
        {
            string consulta = "select MONTO_PAGADO, MONTO_APUESTA, COMISIONVENTA, COMISIONPARTICIPACION" +
                " from tb_usuario A, tb_ticket B, tb_comision C" +
                " where A.id_usuario = B.id_usuario" +
                " and A.id_usuario = C.id_usuario" +
                " and B.fecha_hora <= C.fechafin" +
                " and B.fecha_hora >= C.fechainicio" +
                " and A.id_usuario = " + id_usuario +
                " and B.fecha_hora >= \"" + fecha + "\"";

            try
            {
                cmd = new MySqlCommand(consulta, Conexion);
                MySqlDataReader myReader = cmd.ExecuteReader();

                float total_ganado = 0;
                float total_apostado = 0;
                float totalganancias = 0;
                float totalperdidas = 0;
                float comisionventa = 0;
                float comisionparticipacion = 0;

                while (myReader.Read())
                {
                    total_ganado = myReader.GetFloat(0);
                    total_apostado = myReader.GetFloat(1);
                    comisionventa = myReader.GetFloat(2);
                    comisionparticipacion = myReader.GetFloat(3);

                    if (total_apostado > total_ganado)
                        totalganancias += (total_apostado - total_ganado) * comisionventa / 100;
                    else if (total_ganado > total_apostado)
                        totalperdidas += (total_ganado - total_apostado) * comisionparticipacion / 100;
                }

                myReader.Close();

                if (totalperdidas > totalganancias)
                    return totalperdidas - totalganancias;

                return 0;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public static float consultar_ganancias_usuario_normal_fecha_juego(int id_usuario, string fecha, int id_juego)
        {
            string consulta = "select tb_ticket.MONTO_PAGADO, tb_ticket.MONTO_APUESTA, tb_comision.COMISIONVENTA, tb_comision.COMISIONPARTICIPACION " +
                "from tb_usuario_sorteo_item, tb_item, tb_juego, tb_usuario, tb_ticket, tb_comision " +
                "where tb_juego.ID_JUEGO = tb_item.ID_JUEGO " +
                "and tb_usuario.ID_USUARIO = tb_comision.ID_USUARIO " +
                "and tb_ticket.ID_USUARIO = tb_usuario.ID_USUARIO " +
                "and tb_usuario.ID_USUARIO = tb_usuario_sorteo_item.ID_USUARIO " +
                "and tb_ticket.fecha_hora <= tb_comision.fechafin " +
                "and tb_ticket.fecha_hora >= tb_comision.fechainicio " +
                "and tb_usuario_sorteo_item.ID_ITEM = tb_item.ID_ITEM " +
                "and tb_usuario.ID_USUARIO = " + id_usuario +
                " and tb_ticket.FECHA_HORA >= \"" + fecha + "\" " +
                "and tb_juego.ID_JUEGO = " + id_juego;

            try
            {
                cmd = new MySqlCommand(consulta, Conexion);
                MySqlDataReader myReader = cmd.ExecuteReader();

                float total_ganado = 0;
                float total_apostado = 0;
                float totalganancias = 0;
                float totalperdidas = 0;
                float comisionventa = 0;
                float comisionparticipacion = 0;

                while (myReader.Read())
                {
                    total_ganado = myReader.GetFloat(0);
                    total_apostado = myReader.GetFloat(1);
                    comisionventa = myReader.GetFloat(2);
                    comisionparticipacion = myReader.GetFloat(3);

                    if (total_apostado > total_ganado)
                        totalganancias += (total_apostado - total_ganado) * comisionventa / 100;
                    else if (total_ganado > total_apostado)
                        totalperdidas += (total_ganado - total_apostado) * comisionparticipacion / 100;
                }

                myReader.Close();

                if (totalganancias > totalperdidas)
                    return totalganancias - totalperdidas;

                return 0;
            }
            catch (Exception e)
            {
                return -1;
            }

        }

        public static float consultar_perdidas_usuario_normal_fecha_juego(int id_usuario, string fecha, int id_juego)
        {
            string consulta = "select tb_ticket.MONTO_PAGADO, tb_ticket.MONTO_APUESTA, tb_comision.COMISIONVENTA, tb_comision.COMISIONPARTICIPACION " +
                "from tb_usuario_sorteo_item, tb_item, tb_juego, tb_usuario, tb_ticket, tb_comision " +
                "where tb_juego.ID_JUEGO = tb_item.ID_JUEGO " +
                "and tb_usuario.ID_USUARIO = tb_comision.ID_USUARIO " +
                "and tb_ticket.ID_USUARIO = tb_usuario.ID_USUARIO " +
                "and tb_usuario.ID_USUARIO = tb_usuario_sorteo_item.ID_USUARIO " +
                "and tb_ticket.fecha_hora <= tb_comision.fechafin " +
                "and tb_ticket.fecha_hora >= tb_comision.fechainicio " +
                "and tb_usuario_sorteo_item.ID_ITEM = tb_item.ID_ITEM " +
                "and tb_usuario.ID_USUARIO = " + id_usuario +
                " and tb_ticket.FECHA_HORA >= \"" + fecha + "\" " +
                "and tb_juego.ID_JUEGO = " + id_juego;

            try
            {
                cmd = new MySqlCommand(consulta, Conexion);
                MySqlDataReader myReader = cmd.ExecuteReader();

                float total_ganado = 0;
                float total_apostado = 0;
                float totalganancias = 0;
                float totalperdidas = 0;
                float comisionventa = 0;
                float comisionparticipacion = 0;

                while (myReader.Read())
                {
                    total_ganado = myReader.GetFloat(0);
                    total_apostado = myReader.GetFloat(1);
                    comisionventa = myReader.GetFloat(2);
                    comisionparticipacion = myReader.GetFloat(3);

                    if (total_apostado > total_ganado)
                        totalganancias += (total_apostado - total_ganado) * comisionventa / 100;
                    else if (total_ganado > total_apostado)
                        totalperdidas += (total_ganado - total_apostado) * comisionparticipacion / 100;
                }

                myReader.Close();

                if (totalperdidas > totalganancias)
                    return totalperdidas - totalganancias;

                return 0;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public static float consultar_ganancias_usuario_hijo_fecha_juego(int id_usuario, string fecha, int id_juego)
        {
            MySqlConnectionStringBuilder Builder = new MySqlConnectionStringBuilder();
            Builder.Server = "localhost";
            Builder.Port = 3306;
            Builder.UserID = "root";
            Builder.Password = "agente86";
            Builder.Database = "loto";

            MySqlConnection conexion = new MySqlConnection(Builder.ToString());
            conexion.Open();

            Conexiones.Add(conexion);

            string consulta = "select U.id_usuario" +
                " from tb_usuario U" +
                " where U.id_usuariopadre = " + id_usuario;

            try
            {
                cmd = new MySqlCommand(consulta, conexion);
                MySqlDataReader myReader = cmd.ExecuteReader();

                float suma = 0;

                while (myReader.Read())
                {
                    suma += consultar_ganancias_usuario_normal_fecha_juego(myReader.GetInt16(0), fecha, id_juego) +
                        consultar_ganancias_usuario_hijo_fecha_juego(myReader.GetInt16(0), fecha, id_juego);
                }
                Conexiones.Clear();
                return suma;
            }
            catch
            {
                return -1;
            }

        }

        public static float consultar_perdidas_usuario_hijo_fecha_juego(int id_usuario, string fecha, int id_juego)
        {
            MySqlConnectionStringBuilder Builder = new MySqlConnectionStringBuilder();
            Builder.Server = "localhost";
            Builder.Port = 3306;
            Builder.UserID = "root";
            Builder.Password = "agente86";
            Builder.Database = "loto";

            MySqlConnection conexion = new MySqlConnection(Builder.ToString());
            conexion.Open();

            Conexiones.Add(conexion);

            string consulta = "select U.id_usuario" +
                " from tb_usuario U" +
                " where U.id_usuariopadre = " + id_usuario;

            try
            {
                cmd = new MySqlCommand(consulta, conexion);
                MySqlDataReader myReader = cmd.ExecuteReader();

                float suma = 0;

                while (myReader.Read())
                {
                    suma += consultar_perdidas_usuario_normal_fecha_juego(myReader.GetInt16(0), fecha, id_juego) +
                        consultar_perdidas_usuario_hijo_fecha_juego(myReader.GetInt16(0), fecha, id_juego);
                }
                Conexiones.Clear();
                return suma;
            }
            catch
            {
                return -1;
            }

        }
    }
}