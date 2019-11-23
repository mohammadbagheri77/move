using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace move
{
    class cash
    {
        private string File_path;
        private string File_Directory;
        StreamReader ReaderObj;
        StreamWriter WriterObj;
        public cash(string FileName, string Get_FileDirectory)
        {
            File_Directory = Directory.GetCurrentDirectory() + "\\" + Get_FileDirectory;
            File_path = File_Directory + "\\" + FileName;

        }
        /// <summary>
        /// A good  function to write a text to file
        /// </summary>
        /// <param name="TextToWrite">text to write in a file</param>
        /// <param name="CreateFileNotExist">create a file or folder if not exist</param>
        /// <returns> 1 if done ,-1 if file not exist and not allow to create,-2 if cannot write in a file </returns>
        public int Write_ToFile(string TextToWrite, bool CreateFileNotExist = true)
        {     //پوشه در آدرس وجود دارد 
            if (Directory.Exists(File_Directory))
            //فایل در پوشه هست
            {
                if (File.Exists(File_path))
                {
                    WriterObj = new StreamWriter(File_path);
                    WriterObj.WriteLine(TextToWrite);
                    WriterObj.Close();
                    return 1;
                }
                else //ساخت فایل در پوشه
                {
                    if (CreateFileNotExist)
                    {
                        File.Create(File_path);
                        WriterObj = new StreamWriter(File_path);
                        WriterObj.WriteLine(TextToWrite);
                        WriterObj.Close();
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            else //پوشه در آدرس وجود ندارد 
            {
                if (CreateFileNotExist)
                {
                    Directory.CreateDirectory(File_Directory);
                    File.Create(File_path);
                    WriterObj = new StreamWriter(File_path);
                    WriterObj.WriteLine(TextToWrite);
                    WriterObj.Close();
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            return 0;
        }
        /// <summary>
        /// This Method Append a text to a file .
        /// </summary>
        /// <param name="TextToAppend">text to append </param>
        /// <returns></returns>
        public int Append_ToFile(string TextToAppend)
        {
            if (Directory.Exists(File_Directory))
            {
                if (File.Exists(File_path))
                {
                    WriterObj = new StreamWriter(File_path, true);
                    WriterObj.WriteLine(TextToAppend);
                    WriterObj.Close();
                    return 1;
                }
                else
                {
                    return -2;
                }
            }
            else
            {
                return -1;
            }

        }
        /// <summary>
        /// This Method Reads All Line Of A  File .
        /// </summary>
        /// <returns>The File Text</returns>
        public string TextFromFile()
        {
            string result = "";
            if (File.Exists(File_path))
            {
                ReaderObj = new StreamReader(File_path);
                result = ReaderObj.ReadToEnd();
                ReaderObj.Close();
                return result;
            }

            return result = "";
        }
    }
}
