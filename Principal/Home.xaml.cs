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
    /// Finestra home
    /// </summary>
    public partial class Home : Window
    {
        //Atributs i propietats
        /// <summary>
        /// Usuari logejat.
        /// </summary>
        public Usuari Usuari { get; set; }
        /// <summary>
        /// Totes les cartes
        /// </summary>
        public Cartes TotesCartes { get; set; }
        /// <summary>
        /// Totes les habilitats
        /// </summary>
        public Habilitats TotesHabilitats { get; set; }
        /// <summary>
        /// Totes les partides
        /// </summary>
        public Partides TotesPartides { get; set; }
        /// <summary>
        /// Tots els usuaris
        /// </summary>
        public Usuaris TotsUsuaris { get; set; }

        //Constructors
        /// <summary>
        /// Constrcutor del Home 2 parametres
        /// </summary>
        /// <param name="usuari"></param>
        /// <param name="cartes"></param>
        public Home(Usuari usuari, Cartes cartes)
        {
            InitializeComponent();
            this.TotesCartes = cartes;
            this.Usuari = usuari;
            if (this.Usuari.EsAdministrador == 1) btnAdministracio.Visibility = Visibility.Visible;
            lblTotalPuntsUsuari.Content = this.Usuari.Punts + " Punts";
            lblAliasBenvingut.Content = usuari.Alias;
            imageProfile.Source = new BitmapImage(new Uri(usuari.ImatgePerfil));
        }
        /// <summary>
        /// Constructor del Home ple.
        /// </summary>
        /// <param name="usuari"></param>
        /// <param name="cartes"></param>
        /// <param name="habilitats"></param>
        /// <param name="partides"></param>
        /// <param name="usuaris"></param>
        public Home(Usuari usuari, Cartes cartes, Habilitats habilitats, Partides partides, Usuaris usuaris)
        {
            InitializeComponent();
            this.Usuari = usuari;
            this.TotesCartes = cartes;
            this.TotesPartides = partides;
            this.TotesHabilitats = habilitats;
            this.TotsUsuaris = usuaris;
            if (this.Usuari.EsAdministrador == 1) btnAdministracio.Visibility = Visibility.Visible;
            lblTotalPuntsUsuari.Content = this.Usuari.Punts + " Punts";
            lblAliasBenvingut.Content = usuari.Alias;
            imageProfile.Source = new BitmapImage(new Uri(usuari.ImatgePerfil));
        }
        /// <summary>
        /// Metode que amaga el botó de modificar l'alias de l'usuari i fa visibles els que criden a la classe per modificarlo.
        /// </summary>
        /// <param name="sender">Objecte rebut.</param>
        /// <param name="e">Event intern.</param>
        private void BtnModificarAliasBefore_Click(object sender, RoutedEventArgs e)
        {
            btnModificarAliasBefore.Visibility = Visibility.Hidden;
            txtBoxAliasNouModificar.Text = Usuari.Alias;
            txtBoxAliasNouModificar.Visibility = Visibility.Visible;
            btnModificarAliasAfter.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// Metode que tanca la finestra actual i torna a obrir la del main.
        /// </summary>
        /// <param name="sender">Objecte rebut.</param>
        /// <param name="e">Event intern.</param>
        private void BtnTancarSessioBenvingut_Click(object sender, RoutedEventArgs e)
        {
            if (this.Usuari.Mazos.LlistaMazos.Count == 1)
            {
                MazosDB afegir = new(this.TotesCartes);
                afegir.EliminarMazoUsuariBD(Usuari);
                afegir.AfegirMazoBD(this.Usuari.Mazos.LlistaMazos[0]);
            }
            else
            {
                MazosDB mazos = new(this.TotesCartes);
                mazos.EliminarMazoUsuariBD(Usuari);
            }
            UsuarisDB usuari = new();
            usuari.ModificarUsuari(this.Usuari);
            MainWindow login = new();
            this.Close();
            login.Show();
        }
        /// <summary>
        /// Metode que carrega els Mazos de l'Usuari loggejat un cop carregada la pestanya.
        /// </summary>
        /// <param name="sender">Objecte rebut.</param>
        /// <param name="e">Event intern.</param>
        private void tabItemMazos_Loaded(object sender, RoutedEventArgs e)
        {
            //Miro cuants mazos té l'usuari i depenent dels mazos vaig fent visibles els botons.
            if (Usuari.Mazos.LlistaMazos.Count == 1)
            {
                lblNomMazo1.Content = Usuari.Mazos.LlistaMazos[0].Nom;
                btnAfegirMazoRow1.Visibility = Visibility.Hidden;
                btnEliminarMazoRow1.Visibility = Visibility.Visible;
                //Carta 1 Mazo 1
                listBoxRow1Col1.Items.Add(CrearLabelCarta(Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[0].Nom));
                listBoxRow1Col1.Items.Add(CrearImatgeCarta(Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[0].Imatge));
                listBoxRow1Col1.Items.Add(CrearLabelCartaDescripcio(Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[0].Descripcio));
                listBoxRow1Col1.Items.Add(CrearListBoxHabilitats(Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[0].Habilitats.LListahabilitats, 1));
                //Carta 2 Mazo 1
                listBoxRow1Col2.Items.Add(CrearLabelCarta(Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[1].Nom));
                listBoxRow1Col2.Items.Add(CrearImatgeCarta(Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[1].Imatge));
                listBoxRow1Col2.Items.Add(CrearLabelCartaDescripcio(Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[1].Descripcio));
                listBoxRow1Col2.Items.Add(CrearListBoxHabilitats(Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[1].Habilitats.LListahabilitats, 2));
                //Carta 3 Mazo 1
                listBoxRow1Col3.Items.Add(CrearLabelCarta(Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[2].Nom));
                listBoxRow1Col3.Items.Add(CrearImatgeCarta(Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[2].Imatge));
                listBoxRow1Col3.Items.Add(CrearLabelCartaDescripcio(Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[2].Descripcio));
                listBoxRow1Col3.Items.Add(CrearListBoxHabilitats(Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[2].Habilitats.LListahabilitats, 3));
                //Carta 4 Mazo 1
                listBoxRow1Col4.Items.Add(CrearLabelCarta(Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[3].Nom));
                listBoxRow1Col4.Items.Add(CrearImatgeCarta(Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[3].Imatge));
                listBoxRow1Col4.Items.Add(CrearLabelCartaDescripcio(Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[3].Descripcio));
                listBoxRow1Col4.Items.Add(CrearListBoxHabilitats(Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[3].Habilitats.LListahabilitats, 4));
                //Carta 5 Mazo 1
                listBoxRow1Col5.Items.Add(CrearLabelCarta(Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[4].Nom));
                listBoxRow1Col5.Items.Add(CrearImatgeCarta(Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[4].Imatge));
                listBoxRow1Col5.Items.Add(CrearLabelCartaDescripcio(Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[4].Descripcio));
                listBoxRow1Col5.Items.Add(CrearListBoxHabilitats(Usuari.Mazos.LlistaMazos[0].Cartes.LlistaCartes[4].Habilitats.LListahabilitats, 5));
            }
            else
            {
                btnAfegirMazoRow1.Visibility = Visibility.Visible;
                btnEliminarMazoRow1.Visibility = Visibility.Hidden;
            }
        }
        /// <summary>
        /// Mètode de la finestra Home que crea un objecte Label per posar el nom de la carta.
        /// </summary>
        /// <param name="nom">Li paso el nom de la carta.</param>
        /// <returns>Retorna el Label amb el nom de la carta.</returns>
        public Label CrearLabelCarta(string nom)
        {
            Label nomCarta = new();
            nomCarta.Content = nom;
            nomCarta.HorizontalContentAlignment = HorizontalAlignment.Center;
            return nomCarta;
        }
        /// <summary>
        /// Mètode de la finestra Home que crea un objecte Imatge de la carta.
        /// </summary>
        /// <param name="descripcio">Rep la descripcio de la carta.</param>
        /// <returns>Retorna la Imatge creada amb el BitMapImage.</returns>
        public Label CrearLabelCartaDescripcio(string descripcio)
        {
            Label descripcioCarta = new();
            descripcioCarta.Width = 130;
            descripcioCarta.Content = descripcio;
            descripcioCarta.HorizontalContentAlignment = HorizontalAlignment.Center;
            return descripcioCarta;
        }
        /// <summary>
        /// Mètode de la finestra Home que crea un objecte Imatge de la carta.
        /// </summary>
        /// <param name="path">Rep el path de l'imatge com a parametre.</param>
        /// <returns>Retorna la Imatge creada amb el BitMapImage.</returns>
        public Image CrearImatgeCarta(string path)
        {
            Image imageCarta = new();
            imageCarta.Source = new BitmapImage(new Uri(path));
            imageCarta.Width = 130;
            imageCarta.Height = 130;
            return imageCarta;
        }
        /// <summary>
        /// Mètode de la finestra Home que afegeix les habilitats de les cartes.
        /// </summary>
        /// <param name="habilitats">Llista d'habilitats.</param>
        /// <param name="carta">Id de la carta.</param>
        /// <returns>Retorna un List Box amb les habilitats de la carta.</returns>
        public ListBox CrearListBoxHabilitats(List<Habilitat> habilitats, int carta)
        {
            //Recorro totes les habilitats de totes les cartes i les vaig afegint a cada carta les que li pertoquen.
            ListBox list = new();
            if (carta == 1)
            {
                Label label = new();
                label.Content = habilitats[0].Nom;
                list.Items.Add(label);
                label = new();
                label.Content = habilitats[1].Nom;
                list.Items.Add(label);
                label = new();
                label.Content = habilitats[2].Nom;
                list.Items.Add(label);
                label = new();
                label.Content = habilitats[3].Nom;
                list.Items.Add(label);
            }
            else if (carta == 2)
            {
                Label label = new();
                label.Content = habilitats[4].Nom;
                list.Items.Add(label);
                label = new();
                label.Content = habilitats[5].Nom;
                list.Items.Add(label);
                label = new();
                label.Content = habilitats[6].Nom;
                list.Items.Add(label);
                label = new();
                label.Content = habilitats[7].Nom;
                list.Items.Add(label);
            }
            else if (carta == 3)
            {
                Label label = new();
                label.Content = habilitats[8].Nom;
                list.Items.Add(label);
                label = new();
                label.Content = habilitats[9].Nom;
                list.Items.Add(label);
                label = new();
                label.Content = habilitats[10].Nom;
                list.Items.Add(label);
                label = new();
                label.Content = habilitats[11].Nom;
                list.Items.Add(label);
            }
            else if (carta == 4)
            {
                Label label = new();
                label.Content = habilitats[12].Nom;
                list.Items.Add(label);
                label = new();
                label.Content = habilitats[13].Nom;
                list.Items.Add(label);
                label = new();
                label.Content = habilitats[14].Nom;
                list.Items.Add(label);
                label = new();
                label.Content = habilitats[15].Nom;
                list.Items.Add(label);
            }
            else
            {
                Label label = new();
                label.Content = habilitats[16].Nom;
                list.Items.Add(label);
                label = new();
                label.Content = habilitats[17].Nom;
                list.Items.Add(label);
                label = new();
                label.Content = habilitats[18].Nom;
                list.Items.Add(label);
                label = new();
                label.Content = habilitats[19].Nom;
                list.Items.Add(label);
            }


            list.Width = 130;
            return list;
        }
        /// <summary>
        /// Mètode de la finestra Home que carrega el data grid de la pestanya partides amb les partides de l'usuari.
        /// </summary>
        /// <param name="sender">Objecte rebut.</param>
        /// <param name="e">Event intern.</param>
        private void tabItemPartides_Loaded(object sender, RoutedEventArgs e)
        {
            //Inicialitzo la llista de PartidaLlista que son les dades de cada partida.
            List<PartidaLLista> llistaPartides = new();
            foreach (Partida partida in Usuari.Partides.LlistaPartides)
            {
                //Vaig llegint les partides de l'usuari i creo la classe PartidaLlista amb les dades de la partida.
                PartidaLLista partidaLlista = new();
                partidaLlista.Usuari = Usuari.Alias;
                partidaLlista.Bot = partida.Bot.Nom;
                if (partida.EstatPartida == "Guanyada")
                    partidaLlista.Punts = "400";
                else
                    partidaLlista.Punts = "0";
                partidaLlista.Resultat = partida.EstatPartida;
                llistaPartides.Add(partidaLlista);
            }
            //Introdueixo les partides de l'usuari al data grid.
            dataGridPartides.ItemsSource = llistaPartides;
        }
        /// <summary>
        /// Mètode de la finestra Home que obre la finestra de triar el Mazo, per poder jugar la partida.
        /// </summary>
        /// <param name="sender">Objecte rebut.</param>
        /// <param name="e">Event intern.</param>
        private void BtnPartidaNova_Click(object sender, RoutedEventArgs e)
        {
            if (this.Usuari.Mazos.LlistaMazos.Count == 1)
            {
                Bot bot = new(this.TotesCartes);
                Partida partida = new(Usuari.Partides.Quantitat + 1, bot, 1500, this.Usuari, 1500, "Perduda");
                CampBatalla camp = new(partida, this.TotesCartes, this.TotsUsuaris, this.TotesPartides, this.TotesHabilitats);
                this.Close();
                camp.Show();
            }
            else
            {
                MessageBox.Show("Has de crear el teu mazo abans de poder jugar.");
            }
        }
        /// <summary>
        /// Mètode de la finestra Home que obre la finestra de afegir un nou Mazo.
        /// </summary>
        /// <param name="sender">Objecte rebut.</param>
        /// <param name="e">Event intern.</param>
        private void btnAfegirMazoRow1_Click(object sender, RoutedEventArgs e)
        {
            AfegirUnNouMazo nouMazo = new(this.Usuari, this.TotesCartes,this.TotesHabilitats,this.TotesPartides,this.TotsUsuaris);
            this.Close();
            nouMazo.Show(); 
        }
        /// <summary>
        /// Mètode de la finestra Home que elimina el mazo de l'usuari.
        /// </summary>
        /// <param name="sender">Objecte rebut.</param>
        /// <param name="e">Event intern.</param>
        private void btnEliminarMazoRow1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Usuari.Mazos.LlistaMazos.Remove(Usuari.Mazos.LlistaMazos[0]);
                Usuari.Mazos.EliminarMazo(Usuari.Mazos.LlistaMazos[0]);
                Home home = new(this.Usuari, this.TotesCartes,this.TotesHabilitats, this.TotesPartides, this.TotsUsuaris);
                this.Close();
                home.Show();
            }
            catch (Exception ex)
            {
                Home home = new(this.Usuari, this.TotesCartes, this.TotesHabilitats, this.TotesPartides, this.TotsUsuaris);
                this.Close();
                home.Show();
            }
        }
        /// <summary>
        /// Mètode de la finestra Home que guarda les dades al tancar la finestra.
        /// </summary>
        /// <param name="sender">Objecte rebut.</param>
        /// <param name="e">Event intern.</param>
        private void windowHome_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.Usuari.Mazos.LlistaMazos.Count == 1)
            {
                Mazos afegir = new(this.TotesCartes);
                afegir.EliminarMazoUsuari(Usuari);
                afegir.AfegirMazoBD(this.Usuari.Mazos.LlistaMazos[0]);
            }
            else
            {
                Mazos mazos = new(this.TotesCartes);
                mazos.EliminarMazoUsuari(Usuari);
            }
            Usuaris usuari = new();
            usuari.ModificarUsuari(this.Usuari);
        }
        /// <summary>
        /// Mètode de la finestra Home que activa els botons y modifica l'alias de l'usuari.
        /// </summary>
        /// <param name="sender">Objecte rebut.</param>
        /// <param name="e">Event intern.</param>
        private void btnModificarAliasAfter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Usuaris usuaris = new Usuaris();
                Usuari.Alias = txtBoxAliasNouModificar.Text;
                txtBoxAliasNouModificar.Text = Usuari.Alias;
                txtBoxAliasNouModificar.Visibility = Visibility.Hidden;
                lblAliasBenvingut.Content = Usuari.Alias;
                lblAliasBenvingut.Visibility = Visibility.Visible;
                btnModificarAliasAfter.Visibility = Visibility.Hidden;
                btnModificarAliasBefore.Visibility = Visibility.Visible;
                usuaris.ModificarUsuari(Usuari);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No s'ha modificat l'usuari.");
            }
        }
        /// <summary>
        /// Mètode de la finestra Home que obre la finestra d'Administració i li passa totes les dades.
        /// </summary>
        /// <param name="sender">Objecte rebut.</param>
        /// <param name="e">Event intern.</param>
        private void btnAdministracio_Click(object sender, RoutedEventArgs e)
        {
            Partides partides = new(this.TotsUsuaris);
            Administracio panell = new(this.Usuari, this.TotesCartes, this.TotesPartides, this.TotesHabilitats, this.TotsUsuaris);
            panell.Show();
            this.Close();
        }
        /// <summary>
        /// Mètode de la finestra Home que canvia l'imatge de l'usuari i l'actualitza a la base de dades.
        /// </summary>
        /// <param name="sender">Objecte rebut.</param>
        /// <param name="e">Event intern.</param>
        private void btnCanviarImatge_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                imageProfile.Source = new BitmapImage(new Uri(txtBoxImatgePerfilCanviar.Text));
                this.Usuari.ImatgePerfil = txtBoxImatgePerfilCanviar.Text;
                this.Usuari.CambiarImatge(Usuari);
                txtBoxImatgePerfilCanviar.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("No s'ha pogut actualitzar l'imatge.");
            }
        }
        /// <summary>
        /// Mètode de la finestra Home que al fer click en la pestanya Partides redimensiona el tamany de la finestra.
        /// </summary>
        /// <param name="sender">Objecte rebut.</param>
        /// <param name="e">Event intern.</param>
        private void tabItemPartides_GotFocus(object sender, RoutedEventArgs e)
        {
            this.Width = 500;
            this.Height = 500;
        }
        /// <summary>
        /// Mètode de la finestra Home que al fer click en la pestanya Benvingut redimensiona el tamany de la finestra.
        /// </summary>
        /// <param name="sender">Objecte rebut.</param>
        /// <param name="e">Event intern.</param>
        private void tabItemBenvingut_GotFocus(object sender, RoutedEventArgs e)
        {
            this.Width = 1200;
            this.Height = 700;
        }
        /// <summary>
        /// Mètode de la finestra Home que al fer click en la pestanya Mazos redimensiona el tamany de la finestra.
        /// </summary>
        /// <param name="sender">Objecte rebut.</param>
        /// <param name="e">Event intern.</param>
        private void tabItemMazos_GotFocus(object sender, RoutedEventArgs e)
        {
            this.Width = 1200;
            this.Height = 700;
        }
    }
    //Classe que utilitzo per el Data grid de Partides així hem mostra les següents dades de partides al data grid.
    /// <summary>
    /// Classe per recollir dades en el datagrid de les partides de l'usuari.
    /// </summary>
    public class PartidaLLista
    {
        /// <summary>
        /// Bot contra el que competeix.
        /// </summary>
        public string Bot { get; set; }
        /// <summary>
        /// Usuari contra el que competeix
        /// </summary>
        public string Usuari { get; set; }
        /// <summary>
        /// Resultats de la partida
        /// </summary>
        public string Resultat { get; set; }
        /// <summary>
        /// Punts de la partida
        /// </summary>
        public string Punts { get; set; }
        /// <summary>
        /// Constrcutor de partida llista
        /// </summary>
        public PartidaLLista()
        {
            this.Bot = "";
            this.Resultat = "";
            this.Usuari = "";
            this.Punts = "";
;        }
    }
}
