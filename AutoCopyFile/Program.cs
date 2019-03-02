using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCopyFile
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            //List<String> _listFiles = 
        }

        protected List<String> GetFile(String _prmPath)
        {
            List<String> _result = new List<string>();
            try
            {
                DirectoryInfo d = new DirectoryInfo(_prmPath);//Assuming Test is your Folder
                FileInfo[] Files = d.GetFiles("*.*"); //Getting Text files
                string str = "";
                foreach (FileInfo file in Files)
                {
                    str = str + ", " + file.Name;
                }
            }
            catch(Exception ex)
            {

            }
            return _result;
        }
    }
}
