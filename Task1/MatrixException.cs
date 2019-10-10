using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class MatrixException: Exception
    {
        public MatrixException()
        {

        }
        public MatrixException(string message) : base(message)
        {

        }
    }
}
