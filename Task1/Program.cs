using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Julia\source\repos\Task1\Matrix.xml";

            //double[,] array = { { 1, 2 }, { 1, 1 }};
            //double[,] array2 = { { 1, 2, 4 }, { 2, 1,5 } };
            //Matrix matrix = new Matrix(array);
            //Matrix matrix2 = new Matrix (array2);
            //Matrix result = matrix + matrix;
            //result.Print();
            //result = matrix - matrix;
            //result.Print();
            //result = matrix * matrix2;
            //result.Print();

            //XmlWriter xmlWriter = XmlWriter.Create(path);
            //result.WriteXml(xmlWriter);
            //XmlReader xmlReader = XmlReader.Create(path);
            //matrix2.ReadXml(xmlReader);
            //matrix2.Print();

            Polynom polynom = new Polynom(1, 0, 3, 4);
            Polynom polynom1 = new Polynom ( 2, 0, 4 );

            Polynom result1 = polynom1 - polynom;
            result1.Print();
            result1 = polynom1 - polynom;
            result1.Print();
            result1 = polynom1 * polynom;
            result1.Print();
        }
    }
}
