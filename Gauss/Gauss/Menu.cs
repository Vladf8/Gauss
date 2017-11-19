using System;
using System.Collections;
using System.ComponentModel.Design;
using System.IO;

namespace Gauss
{
    public class Input
    {
        
        public static void Menu()
        {
            int  result;
            string PointOfMenu;
            bool check;
            Console.WriteLine("Choose one point of menu:");
            Console.WriteLine("1) Input matrix from file" +
                              "\n2) Input matrix by hand" + 
                              " \n3) Quit");
            PointOfMenu = Console.ReadLine();
            check = Int32.TryParse(PointOfMenu, out result);

            if (check)
            {
                input(result);
            }
            else
            {
                Console.WriteLine("Wrong input");
                Menu();
            }
        }

        public static void input(int PointOfMenu)
        {   
            
            //double [] X = new double[B.Length];
            switch (PointOfMenu)
            {
                    
                    case 2:    
                        Gauss.InputMt( );
                        break;
                    case 1:
                        
                        Gauss.file();
                        break;
                    case 3:
                        System.Environment.Exit(0);
                        break;
                    default: 
                        Menu();
                        break;
            }       
        }

        

        public static void output(double[] X, int size)
        {
            for (int i = 0; i <= size - 1; i++) {
                //Console.WriteLine ("\n");
                Console.WriteLine("x"+i+"= "+X[i]);
            }
            Menu();
        }

        
    }
}