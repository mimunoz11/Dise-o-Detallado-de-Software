using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;

namespace Interrogacion_1.Model
{
    class Menu
    {
        public static List<INadeje> SortedList_peliculas { get; set; }
        public static Usuario Usuario { get; set; }
        public Menu(List<INadeje> sorted_list, Usuario user)
        {
            SortedList_peliculas = sorted_list;
            Usuario = user;
        }
        public void Menu_principal()
        {
            bool continuar = true;
            while (continuar)
            {
                Menu_peliculas();
                string pelicula_elegida = Console.ReadLine();
                continuar = Menu_principal_opciones(pelicula_elegida);
            }
        }
        public static bool Menu_principal_opciones(string pelicula_elegida)
        {
            if (Menu.Is_valid(pelicula_elegida)){
                if (!Menu.Sub_menu(pelicula_elegida)){
                    return false;}}
            else if (pelicula_elegida == "exit"){
                return false;}
            else{
                Console.WriteLine("Ingresa una opción valida");}
            return true;
        }
        public static void Menu_peliculas()
        {
            SortedList_peliculas = SortedList_peliculas.OrderByDescending(o => o.Calificacion).ToList();
            for (int i = 1; i <= SortedList_peliculas.Count; i++)
            {
                Console.WriteLine($"{i}. {SortedList_peliculas[i-1].Title} ({Math.Round((double)SortedList_peliculas[i - 1].Calificacion, 2)})"); // arreglo de peliculas, por implementar
            }
        }
        public static bool Is_valid(string id_pelicula)
        {
            for (int i = 1; i <= SortedList_peliculas.Count; i++)
            {
                if (id_pelicula == i.ToString())
                {
                    return true;
                }
            }
            return false;
        }
        public static bool Sub_menu(string pelicula_elegida)
        {
            bool continuar = true;
            while (continuar){
                Console.WriteLine("1. Calificar \n2. Review \n3. Volver");
                SortedList_peliculas[Convert.ToInt32(pelicula_elegida) - 1].Imprimir(Usuario);
                string opcion = Console.ReadLine();
                continuar = Sub_menu_opciones(opcion, pelicula_elegida);
            }
            return true;
        }

        public static bool Sub_menu_opciones(string opcion, string pelicula_elegida)
        {
            if (opcion == "1") {
                Menu.Menu_calificar(pelicula_elegida); }
            else if (opcion == "2") {
                Menu.Menu_review(); }
            else if (opcion == "3") {
                return false; }
            else if (opcion == "exit") {
                Environment.Exit(0); }
            else { Console.WriteLine("Ingresa una opción valida"); }
            return true;
        }

        public static void Menu_calificar(string pelicula_elegida)
        {
            Console.WriteLine("Ingresa un número del 1 al 5");
            string calificacion = Console.ReadLine();
            if (Is_valid_calificacion(calificacion)) {
                Usuario.Evaluar(Convert.ToInt32(calificacion));
                SortedList_peliculas[Convert.ToInt32(pelicula_elegida) - 1].Recalcular_calificacion(Usuario);
            }
        }

        public static void Menu_review()
        {
            Console.WriteLine("No Implementado");
        }
        public static bool Is_valid_calificacion(string calificacion)
        {
            for (int i = 1; i <= 5; i++)
            {
                if (calificacion == i.ToString())
                {
                    // Console.WriteLine(i);
                    return true;
                }
            }
            return false;
        }
    }
}
