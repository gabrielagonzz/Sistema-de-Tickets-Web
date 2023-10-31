using Practica4.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using Practica4.Models;

namespace Practica4.Services
{
    public class Log
    {
        private static string TicketsDirectory = "TicketsReportes";

        public static void GuardarTicket(IReporte incidencia)
        {
            string fileName = $"{incidencia.Usuario}_{DateTime.Now:yyyyMMddHHmmss}.json";
            string filePath = Path.Combine(TicketsDirectory, fileName);

            try
            {
                string ticketJson = Newtonsoft.Json.JsonConvert.SerializeObject(incidencia);
                File.WriteAllText(filePath, ticketJson);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar el ticket: " + ex.Message);
            }
        }

        public static List<Reporte> VerTickets(string tipoUsuario)
        {
            string rutaDirectorio = Path.Combine(TicketsDirectory, tipoUsuario + "s");
            List<Reporte> tickets = new List<Reporte>();

            if (Directory.Exists(rutaDirectorio))
            {
                string[] archivos = Directory.GetFiles(rutaDirectorio);

                foreach (var archivo in archivos)
                {
                    try
                    {
                        string contenido = File.ReadAllText(archivo);
                        var ticket = Newtonsoft.Json.JsonConvert.DeserializeObject<Reporte>(contenido);
                        tickets.Add(ticket);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al ver el ticket: " + ex.Message);
                    }
                }
            }

            return tickets;
        }
    }
}
