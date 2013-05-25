using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace Visualisator
{
    /// <summary>
    /// INI file tool
    /// </summary>
    class INIfile
    {
        private string          _iniFileName    = "";
        private Hashtable       data            = new Hashtable();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fName">Pach to file name</param>
        public INIfile(string fName)
        {
            OpenSettings(fName);
        }

        //===========================================================
        /// <summary>
        /// Open File to Load Settings
        /// </summary>
        /// <param name="fileName">File Pach</param>
        private void OpenSettings(string fileName)
        {
            string      input   = null;
            _iniFileName        = fileName;
            data.Clear();
            // create a writer and open the file
            try
            {
                TextReader tw = new StreamReader(fileName);
                while ((input = tw.ReadLine()) != null)
                {
                    if (input.Length > 3)
                    {
                        if (input[0] != '#' && input[0] != ';')
                        {
                            string[] result = input.Split(new char[] { '=' });
                            data.Add(result[0].Trim(), result[1].Trim());
                        }
                    }
                }
                tw.Close();         // close the stream
            }
            catch (Exception)
            {
                SaveSettings(_iniFileName);
                OpenSettings(_iniFileName);
            }
        }

        //===========================================================
        /// <summary>
        /// Save Setings
        /// </summary>
        /// <param name="fileName">Pach to file</param>
        private void SaveSettings(string fileName)
        {
            // create a writer and open the file
            TextWriter tw = new StreamWriter(fileName);

            foreach (DictionaryEntry de in data){
                tw.WriteLine("{0}={1}", de.Key, de.Value);
            }

            tw.Close();     // close the stream
        }

        //===========================================================
        /// <summary>
        /// Return value by key
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Value</returns>
        public string getValue(string key)
        {
            if (data.ContainsKey(key))
                return (data[key].ToString());
            
            return ("");
        }

        //===========================================================
        /// <summary>
        /// Set value by key
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="val">new value</param>
        /// <returns>True of success</returns>
        public bool setValue(string key, string val)
        {
            if (data.ContainsKey(key)) {
                data[key] = val;
            } else{
                data.Add(key, val);
            }
            SaveSettings(_iniFileName);
            return (true);
        }

        //===========================================================
        private string _getKey(string line)
        {
            string[] result = line.Split(new char[] { '=' });
            return result[0].Trim(); 
        }

        //===========================================================
        private string _getValue(string line)
        {
            string[] result = line.Split(new char[] { '=' });
            return result[1].Trim(); 
        }
    }
}
