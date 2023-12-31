﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Preventimark
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int[] NumeroGagnants;

        public MainWindow()
        {
            InitializeComponent();
            NumeroGagnants = NumeroGagnant();
        }

        private int[] NumeroGagnant()
        {
            Random random = new Random();
            return Enumerable.Range(1, 50).OrderBy(x => random.Next()).Take(5).ToArray();
        }

        private void NumInput1_Copy2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c))
                {
                    e.Handled = true; 
                    break;
                }
            }
        }



        private void VerifNombre(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textboxage.Text) || string.IsNullOrEmpty(textboxprenom.Text) || string.IsNullOrEmpty(textboxnom.Text))
            {
                MessageBox.Show("Veuillez renseigner toutes vos informations", "Erreur champs", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            int age;
            if (int.TryParse(textboxage.Text, out age))
            {
                if (string.IsNullOrEmpty(textboxage.Text) || string.IsNullOrEmpty(textboxprenom.Text) || string.IsNullOrEmpty(textboxnom.Text) || (age < 18))
                {
                    MessageBox.Show("Il faut être majeur pour jouer", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    int[] Numeros = new int[5];
                    try
                    {
                        Numeros[0] = int.Parse(grille_1.Text);
                        Numeros[1] = int.Parse(grille_2.Text);
                        Numeros[2] = int.Parse(grille_3.Text);
                        Numeros[3] = int.Parse(grille_4.Text);
                        Numeros[4] = int.Parse(grille_5.Text);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Renseigner votre grille", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    Array.Sort(Numeros);

                    if (Numeros.SequenceEqual(NumeroGagnants))
                    {
                        resultatlabel.Text = "Bravo !";
                    }
                    else
                    {
                        resultatlabel.Text = "Perdu";
                        grilleGagnante.Text = "Numéro gagnant : " + string.Join(", ", NumeroGagnants);
                    }

                    // Réinitialiser les numéros gagnants pour un nouveau tirage
                    NumeroGagnants = NumeroGagnant();
                }
            }
        }
    }
}
            
               