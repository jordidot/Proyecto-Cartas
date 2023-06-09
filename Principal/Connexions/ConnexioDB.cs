﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySqlConnector;
using Newtonsoft.Json;

namespace Principal.Connexions
{
    /// <summary>
    /// Classe ConnexioDB
    /// </summary>
    public class ConnexioDB
    {
        //Atributs
        /// <summary>
        /// Nom de la Base de dades
        /// </summary>
        public string NomBD { get; set; }
        /// <summary>
        /// Nom de l'usuari de la BD
        /// </summary>
        public string UsuariBD { get; set; }
        /// <summary>
        /// Contrasenya de l'usuari de la BD
        /// </summary>
        public string ContrasenyaBD { get; set; }
        /// <summary>
        /// Ip o direccio del host de la BD
        /// </summary>
        public string DireccioHost { get; set; }

        //Constructors
        //Assigno totes les dades amb el paràmetres que obtinc.
        /// <summary>
        /// Constructor Connexio DB
        /// </summary>
        public ConnexioDB()
        {
            StreamReader json = new StreamReader("database.json");
            ConnexioJSON connexio = JsonConvert.DeserializeObject<ConnexioJSON>(json.ReadToEnd());
            this.ContrasenyaBD = connexio.Password;
            this.DireccioHost = connexio.Host;
            this.NomBD = connexio.Database;
            this.UsuariBD = connexio.User;
        }
        //Mètodes
        /// <summary>
        /// Mètode de la classe ConnexioBD que obre la conexió amb la base de dades.
        /// </summary>
        /// <returns>Retorna un MYsqlConnection amb la connexió oberta.</returns>
        public MySqlConnection Connectar()
        {
            string connectar = "Server=" + this.DireccioHost + ";User ID=" + this.UsuariBD + ";Password=" + this.ContrasenyaBD + ";Database=" + this.NomBD;
            var connexio = new MySqlConnection(connectar);
            connexio.Open();
            return connexio;
        }
    }
    public class ConnexioJSON
    {
        public string Host { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
    }
}