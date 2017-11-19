using System;
using System.IO;


namespace Gauss
{
    public class Gauss
    {
        public static void file( )
        {
            int size;
            string fileName,line;
            string[] line2;
            char[] charr = new char[] {' '};
            string file1, file ;
            Console.WriteLine("Input file name: ");
            file1 = Console.ReadLine();
            file = Directory.GetCurrentDirectory(); 
            file = file + @"\" + file1;
            Console.WriteLine(file);
            
            if (File.Exists(file))
            {
                StreamReader reader1 = new StreamReader(file);
                line = reader1.ReadLine();
                line2 = line.Split(charr);
                size = line2.Length;
                double[,] A= new double[size,size];
                double[] B= new double[size];
                StreamReader reader = new StreamReader(file);
                for (int i = 0; i <= size ; i++)
                {
                    line = reader.ReadLine();
                    line2 = line.Split(charr);
                    for (int j = 0; j < size; j++)
                    {
                        if (i == size)
                        {
                            B[j] = Convert.ToDouble(line2[j]);
                        }
                        else
                        {
                            A[i, j] = Convert.ToDouble(line2[j]);
                        }
                    }

                }
                gauss(A,B);
            }
            else
            {
                Console.WriteLine("File not exist");
                global::Gauss.Input.Menu();
            }
            
        }
        
        public static int InputSize()
        {
            bool check;
            string inputstr;
            int size;
            Console.WriteLine("Input size: ");
            inputstr = Console.ReadLine();
            check = Int32.TryParse(inputstr, out size);
            if (check && size > 0)
            {
                return size;
            }
            else
            {
                Console.WriteLine("Wrong input");
                global::Gauss.Input.Menu();
            }
            return 0;
        }

        public static double CheckInput()
        {
            bool check;
            string inputstr;
            double number;
            inputstr = Console.ReadLine();
            check= Double.TryParse(inputstr, out number);
            if (check)
            {
                return number;
            }
            else
            {
                Console.WriteLine("Wrong input");
               InputMt();
            }
            return 0;
        }
           
        public static void InputMt( )
        {
            int size=InputSize();
            /*Console.WriteLine ("Input size: ");
            size = Convert.ToInt32(Console.ReadLine());*/
            
            double[,] A= new double[size,size];
            double[] B= new double[size];
        for (int i=0;i<size;i++){
            Console.Write("input the ");
            Console.Write(i+1);
            Console.Write(" line: ");
        for (int j=0;j<size; j++){
            A[i, j] = CheckInput();
            
        }
       }
    Input(size,B , A );
        }

    public static void Input(int size, double[] B, double[,] A){
    
        Console.WriteLine("Input row of free members:  ");
        for(int i=0;i<size; i++){
            B[i]=Convert.ToDouble(Console.ReadLine());
        }
        gauss(A, B);
    }

    public static void gauss(double[,] A, double[] B){
        double[] X= new double[B.Length];
        var count = B.Length;
        double koef;
    // число неизвестных = число уравнений
    // решение системы: прямой ход
    
        for (int i = 0; i <= count - 2; i++){// этот цикл для исключения столбцов истрок, которые уже не нужны
    
            for (int j = i+1; j <= count-1 ; j++){// для того, чтобы пройтись по всем строкам с неизменным главным элементом
                if (A[i,i]!=0)
                {
                    koef = -1*(A[j,i]/A[i,i]);
                    for (int k = i ; k <= count - 1; k++){ // считает коэффиценты построчно
                        A[j, k] += A[i, k] * koef;
                    }
                    B[j] += B[i] * koef;
                }
                
            }
        }
        //Нахождение определителя
        double det=1;
        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                if (i==j)
                {
                    det *= A[i,j];
                }
            } 
        }

        if (det==0 )
        {
            Console.WriteLine("equation doesn't have solution ");
            global::Gauss.Input.Menu();
        }
    // Треугольная матрица
    
        for(int i=0; i<count; i++){
            for (int j = 0; j < count; j++){
                Console.Write("{0,10:f3}", A[i, j]); 
            }
            Console.WriteLine();
        }
        for (int e = 0; e < count; e++){
            Console.WriteLine(B[e]);
        }
        Console.Write("det= ");
        Console.Write(det);
        Console.Write("\n");
    // решение системы: обратный ход
    
        X[count - 1] = B[count - 1] / A[count - 1, count - 1];
        for (int j = count-2; j >= 0; j--){
            double sum = 0;
            for (int k = count-1; k >= j; k--){
                sum+= A[j,k]*X[k];
            }
            X[j] = (B[j] - sum)/A[j,j];
        }
       global::Gauss.Input.output(X, count);
        
    }
    }
}