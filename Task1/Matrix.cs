using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Task1
{
    public class Matrix: IXmlSerializable
    {
        private double[,] data;
        public int Rows { get; set; }
        public int Columns { get; set; }
        public Matrix() {}
        public Matrix(double[,] data)
        {
            Rows = data.GetLength(0);
            Columns = data.GetLength(1);

            this.data = new double[Rows, Columns];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                    this.data[i, j] = data[i, j];
            }
        }
        public Matrix(int sizeN, int sizeM)
        {
            this.data = new double[sizeN, sizeM];
            Rows = sizeN;
            Columns = sizeM;
        }
        public double this [int i, int j]
        {
            get
            {
                return data[i, j];
            }
            set
            {
                data[i, j] = value;
            }
        }
        public static Matrix operator + (Matrix left, Matrix right)
        {
            if (left.Rows != right.Rows || left.Columns != right.Columns)
                throw new Exception("Matrices of different dimensions");

            Matrix result = new Matrix(left.Rows, right.Columns);

            for (int i = 0; i < result.Rows; i++)
            {
                for (int j = 0; j < result.Columns; j++)
                    result[i, j] = left[i, j] + right[i, j];
            }

            return result;
        }
        public static Matrix operator - (Matrix left, Matrix right)
        {
            if (left.Rows != right.Rows || left.Columns != right.Columns)
                throw new Exception("Different size of matrix");

            Matrix result = new Matrix(left.Rows, right.Columns);

            for (int i = 0; i < result.Rows; i++)
            {
                for (int j = 0; j < result.Columns; j++)
                    result[i, j] = left[i, j] - right[i, j];
            }

            return result;
        }
        public static Matrix operator * (Matrix left, Matrix right)
        {
            if(left.Columns != right.Rows)
                throw new Exception("Matrices are`t consistent");

            Matrix result = new Matrix(left.Rows, right.Columns);
            for(int i =0; i< left.Rows; i++)
            {
                for(int j =0; j< right.Columns; j++)
                {
                    for(int k =0; k< right.Rows; k++)
                    result[i, j] += left[i, k] * right[k, j];
                }
            }

            return result;
        }
        public void WriteXml(XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("matrix");
            xmlWriter.WriteAttributeString("rows", Rows.ToString());
            xmlWriter.WriteAttributeString("columns", Columns.ToString());

            for (int row = 0; row < Rows; ++row)
            {
                xmlWriter.WriteStartElement("row");
                for (int column = 0; column < Columns; ++column)
                {
                    xmlWriter.WriteElementString("column",
                        data[row, column].ToString());
                }
                xmlWriter.WriteEndElement();
            }
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
            Console.WriteLine("Matrix is serialized");
        }
        public void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();//("matrix");

            var rows = XmlConvert.ToInt32(reader.GetAttribute("rows"));
            var columns = XmlConvert.ToInt32(reader.GetAttribute("columns"));

            data = new double[rows, columns];
            reader.Read();

            for (int row = 0; row < rows; ++row)
            {
                reader.Read();
                for (int column = 0; column < columns; ++column)
                {
                    data[row, column] = reader.ReadElementContentAsInt("column", "");
                }
                reader.ReadEndElement();
            }

            Console.WriteLine("Matrix is read");
        }
        public XmlSchema GetSchema()
        {
            return (null);
        }
        public void Print()
        {
            for(int i =0; i< this.Rows; ++i)
            {
                for(int j=0; j< this.Columns; ++j)
                    Console.Write(data[i,j] + " ");
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
