using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _7domashkawpf.serviceinfo
{
    
    internal class ServiceInfo
    {
        private readonly string Path;

        public ServiceInfo(string path)
        {
            Path = path;
        }
        public BindingList<AllINfoWorkers> LoadList()
        {   
            var fileExist = File.Exists(Path);
            if (!fileExist)
            {
                File.CreateText(Path).Dispose();
                return new BindingList<AllINfoWorkers>();
            }
            using (var reader = File.OpenText(Path))
            {
                var filetext = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<AllINfoWorkers>>(filetext);
            }
        }
        public void SaveList(object _allINfoWorkers)
        {
            using (StreamWriter SW = File.CreateText(Path))
            {
                string output = JsonConvert.SerializeObject(_allINfoWorkers);
                SW.Write(output);
            }

        }
        
    }
}
