﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

using Newtonsoft.Json;

namespace Al.Config
{
    /// <summary>
    /// Application interface to access config in JSON format.
    /// This class dependences on JSON.NET open source library.
    /// </summary>
    public class ConfigJson
    {
        private String m_strConfigFullPath = null;
        
        /// <summary> 
        /// Constructor.
        /// Every instance is depended on a config file.
        /// </summary>
        /// <param name="strConfigFullPath">The full path of the configuration file.</param>
        public ConfigJson(String strConfigFullPath)
        {
            m_strConfigFullPath = strConfigFullPath;
        }

        public void setConfig<T>(T root)
        {
            String strJson = null;

            //  Translate object ot JSON string
            strJson = JsonConvert.SerializeObject(root, Formatting.Indented);
            
            //  Write in config file.
            StreamWriter sw = new StreamWriter(m_strConfigFullPath);
            sw.Write(strJson);
            sw.Close();
        }

        public T getConfig<T>()
        {
            T objJson;
            String strJson;

            //  Read config file.
            StreamReader sr = new StreamReader(m_strConfigFullPath);
            strJson = sr.ReadToEnd();
            sr.Close();

            //  Translate to object
            objJson = JsonConvert.DeserializeObject<T>(strJson);

            return objJson;
        }
    }
}
