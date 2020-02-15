using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public class KeyAndIVSaver
    {
        public bool ByteArrayToFile(string fileName, byte[] byteArray)
        {
            try
            {
                fileName = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase) + @"\KeysAndIV\" + fileName;
                fileName = fileName.Substring(6);
                Directory.CreateDirectory(Path.GetDirectoryName(fileName));
                using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(byteArray, 0, byteArray.Length);
                    return true;
                }
                // echivalent la File.WriteAllBytes(fileName,byteArray);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in process: ", ex);
                return false;
            }
        }
        public byte[] FileToByteArray(string fileName)
        {
            try
            {
                fileName = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase) + @"\KeysAndIV\" + fileName;
                fileName = fileName.Substring(6);
                Directory.CreateDirectory(Path.GetDirectoryName(fileName));
                return File.ReadAllBytes(fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in process: ", ex);
                return null;
            }
        }
    }
}
