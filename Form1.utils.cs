using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FunctionSubsitution
{
    public class Config
    {
        public string profile_path = "";
        public string csv_file_path = "";
        public string name = "";
        public Dictionary<string, double> constants = new Dictionary<string, double>();
        public Dictionary<string, int> mapping_table = new Dictionary<string, int>();
        public string funcStr = "";
        public string output_file_name = "";

        private bool error = false;
        public bool Error
        {
            get { return error; }
            set { error = value; }
        }
    }

    public partial class Form1
    {
        public DataTable table = new DataTable();

        public void update_profile_names()
        {   
            ProfileCb.Items.Clear();

            var dinfo = new DirectoryInfo("profiles");
            var files = dinfo.EnumerateFiles("*.json");
            foreach (var f in files)
            {
                ProfileCb.Items.Add(f.Name);
            }
        }

        public void read_profile(string file)
        {
            using(var sreader = new StreamReader(file))
            {
                var str = sreader.ReadToEnd();
                JObject json = JObject.Parse(str);

                config.Error = false;

                config.name = json["name"].ToString();
                if(string.IsNullOrEmpty(config.name))
                {
                    MessageBox.Show("Parse Error: Could not found name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    config.Error = true;
                    return;
                }

                config.constants.Clear();
                foreach(JProperty j in json["constants"])
                {   
                    string value = j.Value.ToString();
                    if(string.IsNullOrEmpty(value))
                    {
                        MessageBox.Show("Parse Error: Could not found constant's value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        config.Error = true;
                        return;
                    }

                    config.constants.Add(j.Name, Double.Parse(j.Value.ToString()));
                }

                JArray jarr = (JArray)json["variables"];
                config.mapping_table.Clear();
                foreach (var v in jarr)
                {
                    string key = v.ToString();
                    if(string.IsNullOrEmpty(key))
                    {
                        MessageBox.Show("Parse Error: Could not found variables", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        config.Error = true;
                        return;
                    }

                    if(config.mapping_table.ContainsKey(key))
                    {
                        MessageBox.Show(
                            "Profile Error: duplicated variable is not allowed",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );
                        config.Error = true;
                        return;
                    }

                    config.mapping_table.Add(v.ToString(), -1);
                }

                config.funcStr = json["function"].ToString();
                if(string.IsNullOrEmpty(config.funcStr))
                {
                    MessageBox.Show("Parse Error: Could not found function", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    config.Error = true;
                    return;
                }

            }
        }

        async Task<int> update_function_img()
        {
            if (string.IsNullOrEmpty(config.funcStr)) return 1;
            if (string.IsNullOrEmpty(config.name)) return 1;
            if (Core.make_funcImg(config.funcStr, $"caches/{config.name}.png", 12, 130) != 0) return 1;
            
            var bytes = File.ReadAllBytes($"caches/{config.name}.png");
            var ms = new MemoryStream(bytes);
            var img = Image.FromStream(ms);
            FunctionPic.Image = img;
            return 0;
        }


        int read_csv(string file)
        {
            using(StreamReader sr = new StreamReader(file))
            {
                table.Clear();
                table = new DataTable();

                string line = sr.ReadLine();
                string[] col_names = line.Split(',');
                if(col_names.Count() != col_names.Distinct().Count())
                {
                    MessageBox.Show("Dupilicated name of column is not allowed");
                    return 1;
                }

                foreach(string col in col_names) table.Columns.Add(col);

                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    string[] data = line.Split(',');
                    table.Rows.Add(data);
                }

                dataGridView1.DataSource = table;
                return 0;
            }
        }

        
    }
}