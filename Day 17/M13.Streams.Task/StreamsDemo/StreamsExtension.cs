using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Linq;

namespace StreamsDemo
{
    // C# 6.0 in a Nutshell. Joseph Albahari, Ben Albahari. O'Reilly Media. 2015
    // Chapter 15: Streams and I/O
    // Chapter 6: Framework Fundamentals - Text Encodings and Unicode
    // https://msdn.microsoft.com/ru-ru/library/system.text.encoding(v=vs.110).aspx

    public static class StreamsExtension
    {

        #region Public members

        #region TODO: Implement by byte copy logic using class FileStream as a backing store stream .

        /// <summary>
        /// Implement by byte copy logic using class FileStream as a backing store stream
        /// </summary>
        /// <param name="sourcePath">Input file</param>
        /// <param name="destinationPath">Output file</param>
        /// <returns>Number of bytes written</returns>
        public static int ByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            using (FileStream fileStream = File.OpenRead(sourcePath))
            {
                byte[] array = new byte[fileStream.Length];
                fileStream.Read(array, 0, array.Length);
                using (FileStream writeStream = new FileStream(destinationPath, FileMode.Create))
                {
                    writeStream.Write(array, 0, array.Length);
                    return (int)writeStream.Position;
                }
            }
        }

        #endregion

        #region TODO: Implement by byte copy logic using class MemoryStream as a backing store stream.

        /// <summary>
        /// Implement by byte copy logic using class MemoryStream as a backing store stream
        /// </summary>
        /// <param name="sourcePath">Input file</param>
        /// <param name="destinationPath">Output file</param>
        /// <returns>Number of bytes written</returns>
        public static int InMemoryByByteCopy(string sourcePath, string destinationPath)
        {
            // TODO: step 1. Use StreamReader to read entire file in string
            string fileContent = null;
            using (StreamReader reader = new StreamReader(sourcePath, Encoding.GetEncoding(1251)))
            {
                fileContent = reader.ReadToEnd();
            }
            // TODO: step 2. Create byte array on base string content - use  System.Text.Encoding class
            byte[] array = Encoding.Unicode.GetBytes(fileContent);

            // TODO: step 3. Use MemoryStream instance to read from byte array (from step 2)
            MemoryStream memoryStream = new MemoryStream(array.Length);
            memoryStream.Write(array,0,array.Length);

            // TODO: step 4. Use MemoryStream instance (from step 3) to write it content in new byte array
            byte[] array2 = memoryStream.GetBuffer();

            // TODO: step 5. Use Encoding class instance (from step 2) to create char array on byte array content
            char[] charArray = Encoding.Unicode.GetChars(array2);

            // TODO: step 6. Use StreamWriter here to write char array content in new file
                using (StreamWriter writer = new StreamWriter(destinationPath, false, Encoding.GetEncoding(1251)))
                {
                    int counter = 0;
                    foreach (char symbol in charArray)
                    {
                        writer.Write(symbol);
                        counter++;
                    }
                    return counter;
                }
        }

        #endregion

        #region TODO: Implement by block copy logic using FileStream buffer.

        /// <summary>
        /// Implement by block copy logic using FileStream buffer
        /// </summary>
        /// <param name="sourcePath">Input file</param>
        /// <param name="destinationPath">Output file</param>
        /// <returns>Number of bytes written</returns>
        public static int ByBlockCopy(string sourcePath, string destinationPath)
        {
            using (FileStream fileStream = File.OpenRead(sourcePath))
            {
                byte[] array = new byte[fileStream.Length];
                fileStream.Read(array, 0, array.Length);
                using (FileStream writeStream = new FileStream(destinationPath, FileMode.Create))
                {
                    writeStream.Write(array, 0, array.Length);
                    return (int)writeStream.Position;
                }
            }
        }

        #endregion

        #region TODO: Implement by block copy logic using MemoryStream.

        /// <summary>
        /// Implement by block copy logic using MemoryStream
        /// </summary>
        /// <param name="sourcePath">Input file</param>
        /// <param name="destinationPath">Output file</param>
        /// <returns>Number of bytes written</returns>
        public static int InMemoryByBlockCopy(string sourcePath, string destinationPath)
        {
            //?????????????????????????????
            InputValidation(sourcePath, destinationPath);
            byte[] array = File.ReadAllBytes(sourcePath);
            int bytes = 0;
            using (MemoryStream memStream = new MemoryStream(array.Length))
            {
                memStream.Write(array, 0, array.Length);
                array[0] = 1;
                array = memStream.GetBuffer();
            }
            File.WriteAllBytes(destinationPath, array);
            return array.Length;
        }

        #endregion

        #region TODO: Implement by block copy logic using class-decorator BufferedStream.

        /// <summary>
        /// Implement by block copy logic using class-decorator BufferedStream
        /// </summary>
        /// <param name="sourcePath">Input file</param>
        /// <param name="destinationPath">Output file</param>
        /// <returns>Number of bytes written</returns>
        public static int BufferedCopy(string sourcePath, string destinationPath)
        {
            using (FileStream reader = new FileStream(sourcePath, FileMode.Open))
            {
                using (BufferedStream buffer = new BufferedStream(reader))
                {
                    byte[] array = new byte[reader.Length];
                    buffer.Read(array, 0, array.Length);
                    File.WriteAllBytes(destinationPath, array);
                    return (int)buffer.Position;
                }
            }
        }

        #endregion

        #region TODO: Implement by line copy logic using FileStream and classes text-adapters StreamReader/StreamWriter

        /// <summary>
        /// Implement by line copy logic using FileStream and classes text-adapters StreamReader/StreamWriter
        /// </summary>
        /// <param name="sourcePath">Input file</param>
        /// <param name="destinationPath">Output file</param>
        /// <returns>Number of lines written</returns>
        public static int ByLineCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            int counter = 0;
            using (StreamReader reader = new StreamReader(sourcePath, Encoding.GetEncoding(1251)))
            {
                string line = null;
                using (StreamWriter writter = new StreamWriter(destinationPath, false, Encoding.GetEncoding(1251)))
                {
                    bool flag = false;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (flag)
                        {
                            writter.WriteLine("");
                        }
                        flag = true;
                        writter.Write(line);
                        counter++;
                    }
                }
            }
            return counter;
        }

        #endregion

        #region TODO: Implement content comparison logic of two files 

        /// <summary>
        /// Compares 2 files
        /// </summary>
        /// <param name="sourcePath">Input file</param>
        /// <param name="destinationPath">Output file</param>
        /// <returns>True - if equal, else otherwise</returns>
        public static bool IsContentEquals(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            byte[] sourceArray=null;
            byte[] destinationArray=null;
            sourceArray = File.ReadAllBytes(sourcePath);
            destinationArray = File.ReadAllBytes(destinationPath);
            return sourceArray.SequenceEqual(destinationArray) && sourceArray.Length == destinationArray.Length;
        }

        #endregion

        #endregion

        #region Private members

        #region TODO: Implement validation logic

        private static void InputValidation(string sourcePath, string destinationPath)
        {
            if (sourcePath==null)
            {
                throw new ArgumentNullException();
            }
            if (destinationPath==null)
            {
                throw new ArgumentNullException();
            }
            using (FileStream stream = new FileStream(sourcePath, FileMode.Open))
            { }
            using (FileStream stream = new FileStream(destinationPath, FileMode.Open))
            { }

        }

        #endregion

        #endregion

    }
}
