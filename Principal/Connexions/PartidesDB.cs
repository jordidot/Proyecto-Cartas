﻿using Principal.Negoci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySqlConnector;

namespace Principal.Connexions
{
    /// <summary>
    /// Classe PartidesDB
    /// </summary>
    public class PartidesDB
    {
        //Atributs 
        /// <summary>
        /// Quantiat de Partides
        /// </summary>
        public int Quantitat { get; set; }
        /// <summary>
        /// Connexio a la base de dades
        /// </summary>
        public ConnexioDB ConnexioBD { get; set; }
        /// <summary>
        /// Llista de totes les cartes
        /// </summary>
        public Cartes TotesCartes { get; set; }
        /// <summary>
        /// Llista de Totes les partides
        /// </summary>
        public Partides TotesPartides { get; set; }
        /// <summary>
        /// Llista de tots els Usuaris
        /// </summary>
        public Usuaris TotsUsuaris { get; set; }

        //Constructors
        /// <summary>
        /// Constructor Partides DB
        /// </summary>
        /// <param name="cartes">Llista de cartes</param>
        /// <param name="partida">Partida</param>
        /// <param name="usuaris">Llista d'uusaris</param>
        public PartidesDB(Cartes cartes,Partida partida, Usuaris usuaris)
        {
            ConnexioBD = new ConnexioDB();
            this.TotsUsuaris = usuaris;
            this.TotesPartides = new(this.TotsUsuaris);
            this.TotesCartes = cartes;
        }
        //Metodes
        /// <summary>
        /// Mètode de la classe PartidesDB que afegeix una partida a la base de dades.
        /// </summary>
        /// <param name="partida">Classe Partida que conté tota l'informació d'aquesta.</param>
        public void AfegirPartidaBD(Partida partida)
        {
            try
            {
                var comanda = new MySqlCommand("INSERT INTO partides VALUES(" + partida.Id + ",'" + partida.Bot.Nom + "'," + partida.Usuari.Id + ",'" + partida.EstatPartida + "');", ConnexioBD.Connectar());
                comanda.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No s'ha pogut afegir la partida." + ex.Message);
            }
            finally
            {
                ConnexioBD.Connectar().Close();
                MySqlConnection.ClearAllPools();
            }
        }
        /// <summary>
        /// Mètode de la classe PartidesDB que elimina una partida a la base de dades.
        /// </summary>
        /// <param name="partida">Classe Partida que conté tota l'informació d'aquesta.</param>
        public void EliminarPartidaBD(Partida partida)
        {
            try
            {
                var comanda = new MySqlCommand("DELETE FROM partides WHERE id=" + partida.Id, ConnexioBD.Connectar());
                comanda.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No s'ha pogut eliminar la partida." + ex.Message);
            }
            finally
            {
                ConnexioBD.Connectar().Close();
                MySqlConnection.ClearAllPools();
            }
        }
        /// <summary>
        /// Mètode de la classe PartidesDB que recupera les partides de la base de dades.
        /// </summary>
        /// <returns>Retorna una llista de Partida amb l'informació d'aquestes.</returns>
        public List<Partida> RecuperarPartides(Usuari usuari, Cartes cartes)
        {
            List<Partida> partidesList = new List<Partida>();
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM partides;", ConnexioBD.Connectar());
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Bot bot = new(cartes);
                    bot.Nom = reader.GetString(1);
                    Mazos mazos = new();
                    Partida partida = new(reader.GetInt32(0), bot, 1500,usuari,1500,reader.GetString(3));
                    partidesList.Add(partida);
                }
                TotesPartides.LlistaPartides = partidesList;
                this.Quantitat = TotesPartides.LlistaPartides.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ConnexioBD.Connectar().Close();
                MySqlConnection.ClearAllPools();
            }
            return TotesPartides.LlistaPartides;
        }

    }
}
