﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using QA_Test_Json.Models;

namespace QA_Test_Json.Services
{
    public class JsonFileReader
    {
        public static List<Question> ReadJson(string JsonFileName) 
        {
            using(var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<List<Question>>(jsonFileReader.ReadToEnd());
            }
        }
    }
}
