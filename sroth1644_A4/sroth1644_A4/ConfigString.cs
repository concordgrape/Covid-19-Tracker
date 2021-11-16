/*
 * FILE             :   ConfigString.cs
 * PROJECT          :   Assignment-04: Data Visualization
 * PROGRAMMER       :   Sky Roth
 * FIRST VERSION    :   November 11, 2021
 * DESCRIPTION      :   This file will read the config file and find the connection string and CSV file path
 */




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;

namespace sroth1644_A4
{
    class ConfigString
    {
        public string getConnString()
        {
            return ConfigurationManager.AppSettings.Get("connectionString");
        }

        public string getFilePath()
        {
            return ConfigurationManager.AppSettings.Get("filePath");
        }
    }
}
