using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP3404Session1
{
    /// <summary>
    /// InvalidStringException - This is the exception that will be ran if the string path is invalid
    /// </summary>
    internal class InvalidStringException : Exception
    {
        /// <summary>
        /// Constructor of the exception to be ran
        /// </summary>
        /// <param name="message"> The message to be displayed to the user </param>
        public InvalidStringException(string message) : base(message) { }
    }
}
