using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    class Polynom
    {
        private double[] coefficients;
        public int Degree { get; private set;}
        public Polynom(params double[] data)
        {
            Degree = data.Length - 1;
            coefficients = new double[data.Length];
            for(int i =0; i<= Degree; i++)
            {
                coefficients[i] = data[i];
            }
        }
        public Polynom(int length)
        {
            Degree = length;
            coefficients = new double[length+1];
        }
        public double this [int index]
        {
            get
            {
                return coefficients[index];
            }
            set
            {
                coefficients[index] = value;
            }
        }
        public static Polynom operator + (Polynom left, Polynom right)
        {
            int newLength = Math.Min(left.Degree, right.Degree);

            for (int i = Math.Min(left.Degree, right.Degree); i >= 0; i--)
            {
                if (left[i] + right[i] == 0 && newLength > 0)
                    newLength--;
                else
                    break;
            }

            Polynom result = new Polynom(Math.Max(left.Degree, right.Degree));

            for (int i = 0; i <= result.Degree; ++i)
            {
                double a = 0;
                double b = 0;

                if (i <= left.Degree)
                {
                    a = left[i];
                }

                if (i <= right.Degree)
                {
                    b = right[i];
                }
                result[i] = a + b;
            }
            return result;
        }
        public static Polynom operator - (Polynom left, Polynom right)
        {
            int newLength = Math.Min(left.Degree, right.Degree);

            for(int i = Math.Min(left.Degree, right.Degree); i >= 0; i--)
            {
                if (left[i] - right[i] ==0 && newLength>0)
                    newLength--;
                else
                    break;
            }
            Polynom result = new Polynom(newLength);

            for (int i = 0; i <= result.Degree; ++i)
            {
                double a =0;
                double b = 0;

                if (i <= left.Degree)
                {
                    a = left[i];
                }

                if (i <= right.Degree)
                {
                    b = right[i];
                }

                result[i] = a-b;
            }
            return result;
        }
        public static Polynom operator * (Polynom left, Polynom right)
        {
            Polynom result = new Polynom(left.Degree + right.Degree);

            for(int i =0; i<= left.Degree; ++i)
            {
                for(int j =0; j<= right.Degree; j++)
                {
                    result[i + j] += left[i] * right[j];
                }
            }

            return result;
        }
        public void Print()
        {
            if(this.Degree==0 || this.coefficients[0]!=0)
            Console.Write(this.coefficients[0]);

            for(int i =1; i<= this .Degree; i++)
            {
                if (this.coefficients[i] == 0) continue;

                if(this.coefficients[i] <0)
                    Console.Write(" " + this.coefficients[i] + "x^" + i);
                else
                Console.Write(" + " + this.coefficients[i] +"x^" + i);
            }
            Console.WriteLine();
        }
    }
}
