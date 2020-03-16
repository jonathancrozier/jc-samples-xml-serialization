using JC.Samples.XmlSerialization.Extensions;
using JC.Samples.XmlSerialization.Models;
using System;

namespace JC.Samples.XmlSerialization
{
    /// <summary>
    /// Main Program class.
    /// </summary>
    class Program
    {
        #region Methods

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("Serializing todo to XML string...");
            Console.WriteLine();

            // Create a todo and serialize it to a string.
            var todo = new Todo { Id = 1, Title = "Buy milk", UserId = 1 };

            string xml = todo.ToXmlString();

            // Output a display heading.
            string todoOutputMessage = "Todo as XML string";

            Console.WriteLine(todoOutputMessage);
            Console.WriteLine("".PadLeft(todoOutputMessage.Length, '='));
            Console.WriteLine();

            // Output the XML string.
            Console.WriteLine(xml);

            // Inform the user that the program has completed.
            Console.WriteLine();
            Console.WriteLine("Press any key to exit");

            Console.ReadKey();
        }

        #endregion
    }
}