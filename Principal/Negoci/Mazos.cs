﻿using Principal.Connexions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Principal.Negoci
{
    public class Mazos
    {
        //Atributs
        private List<Mazo> llistaMazos;

        //Constructors
        /// <summary>
        /// Constructor buit
        /// </summary>
        public Mazos()
        {
            llistaMazos = new List<Mazo>();
        }
        /// <summary>
        /// Constructor ple
        /// </summary>
        /// <param name="llistaMazos">LLista per emplenar els mazos guardats</param>
        public Mazos(List<Mazo> llistaMazos)
        {
            this.llistaMazos = llistaMazos;
        }
        //Propietat
        /// <summary>
        /// Propietat de mazos
        /// </summary>
        public List<Mazo> LlistaMazos
        {
            get { return llistaMazos; }
            set { llistaMazos = value; }
        }
        //Metodes
        /// <summary>
        ///Metode per afegir mazos
        /// </summary>
        public void AfegirMazo(Mazo m)
        {
            MazosDB mazobd = new MazosDB();
            bool mazoTrobada = false;
            mazobd.RecuperarMazos();
            foreach (Mazo mazo in mazobd.Mazos.LlistaMazos)
            {
                if (m.Id == mazo.Id)
                    mazoTrobada = true;
            }
            if (mazoTrobada)
            {
                MessageBox.Show("L'id es el mateix, no es pot afegir.");
            }
            else
                llistaMazos.Add(m);
        }
        /// <summary>
        /// Metode per eliminar mazo
        /// </summary>
        public void EliminarMazo()
        {

        }
        /// <summary>
        /// Metode per Modificar mazo
        /// </summary>
        public void ModificarMazo()
        {


        }
        public List<Mazo> RecuperarMazos()
        {
            MazosDB mazosdb = new();
            mazosdb.RecuperarMazos();
            return mazosdb.Mazos.LlistaMazos;
        }
    }
}