﻿using Principal.Connexions;
using Principal.Negoci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Principal
{
    /// <summary>
    /// Lógica de interacción para AfegirMazoExtend.xaml
    /// </summary>
    public partial class AfegirMazoExtend : Window
    {
        private Cartes cartes;
        private Usuari usuari;
        private int id;
        private AfegirUnNouMazo finestra;
        public Cartes TotesCartes { get; set; }
        public Usuaris TotsUsuaris { get; set; }
        public Partides TotesPartides { get; set; }
        public Habilitats TotesHabilitats { get; set; }
        public AfegirMazoExtend(Cartes cartes,Usuari usuari, int id, AfegirUnNouMazo finestra,Cartes totesCartes, Habilitats habilitats, Partides partides, Usuaris usuaris)
        {
            InitializeComponent();
            this.TotesCartes = totesCartes;
            this.TotesHabilitats = habilitats;
            this.TotesPartides = partides;
            this.TotsUsuaris = usuaris;
            this.cartes = cartes;
            this.usuari = usuari;
            this.id = id;
            this.finestra = finestra;
        }
        public Usuari Usuari
        {
            get { return this.usuari; }
            set { this.usuari = value; }
        }
        public Cartes Cartes
        {
            get { return this.cartes; }
            set { this.cartes = value; }
        }
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        private void btnAfegirNouMazoExtend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Habilitats habilitats = new();
                Mazo mazo = new(this.Id, this.Cartes, txtBoxNomMazo.Text, this.Usuari);
                this.Usuari.Mazos.LlistaMazos.Clear();
                this.Usuari.Mazos.LlistaMazos.Add(mazo);
                if (this.Usuari.Mazos.LlistaMazos.Count == 1)
                {
                    MazosDB afegir = new();
                    afegir.EliminarMazoUsuariBD(Usuari);
                    afegir.AfegirMazoBD(this.Usuari.Mazos.LlistaMazos[0]);
                }
                MessageBox.Show("Mazo afegit correctament.");
                Home home = new(this.usuari,TotesCartes, this.TotesHabilitats, this.TotesPartides, this.TotsUsuaris);
                this.finestra.Close();
                this.Close();
                home.Show();
               
            }catch(Exception ex)
            {
                MessageBox.Show("No s'ha pogut afegir el mazo.");
                AfegirUnNouMazo finestraNova = new(this.usuari, cartes,this.TotesHabilitats, this.TotesPartides, this.TotsUsuaris);
                this.finestra.Close();
                this.Close();
                finestraNova.Show();
                
            }
            
        }
    }
}
