using Newtonsoft.Json.Linq;
using System.Net;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace FunctionSubsitution
{
    public partial class Form1 : Form
    {
        private Config config = new Config();

        public Form1()
        {
            InitializeComponent();
            this.Text = "Function Substition";

            update_profile_names();
        }


        private async void ProfileCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //profile selection combobox
            if (ProfileCb.SelectedIndex < 0) return;
            config.profile_path = $"profiles/{ProfileCb.SelectedItem as string}";
            read_profile(config.profile_path);
            FunctionTB.Text = config.funcStr;

            //update function img
            Task<int> update_funcImgTask = update_function_img();

            //update constants
            ConstantsLB.Items.Clear();
            foreach (var c in config.constants) ConstantsLB.Items.Add(c.Key);

            //update variables
            VariablesLB.Items.Clear();
            foreach (var v in config.mapping_table) VariablesLB.Items.Add(v.Key);
        }

        private void FileSelectBtn_Click(object sender, EventArgs e)
        {
            //Select Button
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select csv file";
            ofd.Filter = "csv (*.csv) | *.csv; | All (*.*) | *.*;";

            DialogResult result = ofd.ShowDialog();

            //on OK button click
            if (result == DialogResult.OK)
            {
                config.csv_file_path = ofd.FileName; //경로 + 파일명
                FileNameBox.Text = config.csv_file_path;
            }
            else if (result == DialogResult.Cancel)
            {
                return;
            }
            else MessageBox.Show("Error on OpenFileDialog", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            int err = read_csv(config.csv_file_path);
            if (err == 1) return;

            //update column selection list
            ColumnCb.Items.Clear();
            foreach (var col in table.Columns) ColumnCb.Items.Add(col.ToString());

            //clear mapping table
            foreach (string key in config.mapping_table.Keys)
                config.mapping_table[key] = -1;
        }

        private void CaculateBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(config.profile_path))
            {
                MessageBox.Show(
                    "Error: Select profile",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                return;
            }
            else if (string.IsNullOrEmpty(config.csv_file_path))
            {
                MessageBox.Show(
                    "Error: Select csv file",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                return;
            }
            else if (config.Error)
            {
                MessageBox.Show(
                    "Error: Verify your profile and setting",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                return;
            }

            //create_mapping_table
            //mapping table: x:col_index1;y:col_index2;
            StringBuilder sb = new StringBuilder();
            foreach (var item in config.mapping_table)
            {
                if (item.Value < 0)
                {
                    MessageBox.Show(
                        "Select column responsed to variable",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                    return;
                }

                sb.Append(item.Key);
                sb.Append(':');
                sb.Append(item.Value.ToString());
                sb.Append(';');
            }

            //read output column name
            string output_column_name = result_colTB.Text;
            if (string.IsNullOrEmpty(output_column_name))
            {
                MessageBox.Show(
                    "Write name of output column",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                return;
            }

            //기존 column name이랑 중복 안되는지도 체크
            if (ColumnCb.Items.Contains(output_column_name))
            {
                MessageBox.Show(
                    "Duplicated name of column is not allowed",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                return;
            }

            //Choose Output path and name
            using (var dlg = new SaveFileDialog())
            {
                dlg.Title = "Save File";
                dlg.FileName = "result.csv";
                dlg.Filter = "csv file(*.csv)|*.csv;";

                DialogResult result = dlg.ShowDialog();
                if (result == DialogResult.OK) config.output_file_name = dlg.FileName;
                else if (result == DialogResult.Cancel) return;
                else MessageBox.Show("Error on SaveFile", "Error", MessageBoxButtons.OK);
            }

            Core.processing_info info = new Core.processing_info();
            info.profile_path = config.profile_path;
            info.csv_path = config.csv_file_path;
            info.output_col_name = output_column_name;
            info.output_file_name = config.output_file_name;
            info.mapping_table = sb.ToString();
            int err = Core.process_data(ref info);

            /*
            if (err != 0)
            {
                MessageBox.Show(
                    $"profile_path:{info.profile_path}\ncsv_path:{info.csv_path}\noutput_col_name:{info.output_col_name}\noutput_file_name:{info.output_file_name}\nmapping table:{info.mapping_table}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                return;
            } */

            if (err != 0) return;
            MessageBox.Show(
                "success",
                "Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );

        }

        private void ConstantsLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            string key = ConstantsLB.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(key))
                ConstantValueTB.Text = config.constants[key].ToString();
        }

        private void VariablesLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            string key = VariablesLB.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(key))
                ColumnCb.SelectedIndex = config.mapping_table[key];
        }

        private void ColumnCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            string key = VariablesLB.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(key)) return;
            config.mapping_table[key] = ColumnCb.SelectedIndex;
        }

        private void NewProfileBtn_Click(object sender, EventArgs e)
        {
            using (var dlg = new SaveFileDialog())
            {
                dlg.Title = "New Profile";
                dlg.FileName = "NewProfile.json";
                dlg.Filter = "JSON file(*.json)|*.json;";
                dlg.InitialDirectory = Path.GetFullPath("./profiles");
                dlg.RestoreDirectory = true;

                DialogResult result = dlg.ShowDialog();
                if (result != DialogResult.OK) return;

                //NewProfile.json profile 생성
                using (StreamWriter writer = File.CreateText(dlg.FileName))
                {
                    var name = System.IO.Path.GetFileNameWithoutExtension(dlg.FileName);
                    writer.WriteLine("{");
                    writer.WriteLine($"\t\"name\":\"{name}\",");
                    writer.WriteLine("\t\"constants\":{\"a\":2.1, \"b\":3.2},");
                    writer.WriteLine("\t\"variables\":[\"x\", \"y\"],");
                    writer.WriteLine("\t\"function\":\"exp(a*x)+b*y\"");
                    writer.WriteLine("}");
                }
            }

            update_profile_names();
        }

        private async void FunctionUpdateBtn_Click(object sender, EventArgs e)
        {
            string funcStr = FunctionTB.Text;
            if (string.IsNullOrEmpty(funcStr))
            {
                MessageBox.Show(
                    "Write Function",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                return;
            };
            config.funcStr = funcStr;

            Task<int> update_funcImgTask = update_function_img();

            //update json file
            StreamReader reader = new StreamReader(config.profile_path);
            JObject json = JObject.Parse(reader.ReadToEnd());
            json["function"] = config.funcStr;
            reader.Close();

            using (StreamWriter writer = new StreamWriter(config.profile_path))
            {
                writer.Write(json.ToString());
            }

            //clear mapping table
            foreach (string key in config.mapping_table.Keys)
                config.mapping_table[key] = -1;

            MessageBox.Show("Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void ConstantUpdateBtn_Click(object sender, EventArgs e)
        {
            string key = ConstantsLB.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show(
                    "Select Constant on listbox",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                return;
            }

            if (string.IsNullOrEmpty(ConstantValueTB.Text))
            {
                MessageBox.Show(
                    "Write value on textbox",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                return;
            }
            double value = Double.Parse(ConstantValueTB.Text);
            config.constants[key] = value;

            //update json file
            StreamReader reader = new StreamReader(config.profile_path);
            JObject json = JObject.Parse(reader.ReadToEnd());
            reader.Close();
            var constants = json["constants"];
            if (constants == null)
            {
                MessageBox.Show(
                    "JSON Parse Error",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                return;
            }
            constants[key] = value;

            using (StreamWriter writer = new StreamWriter(config.profile_path))
            {
                writer.Write(json.ToString());
            }

        }

        private void ConstantAddBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ConstantKeyTB.Text))
            {
                MessageBox.Show(
                    "Write Constatant on textbox",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                return;
            }
            string key = ConstantKeyTB.Text;

            //이미 존재하는지 확인
            if (config.constants.ContainsKey(key))
            {
                MessageBox.Show(
                    "The constant is already in",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                return;
            }
            config.constants.Add(key, 0);

            //update json file
            StreamReader reader = new StreamReader(config.profile_path);
            JObject json = JObject.Parse(reader.ReadToEnd());
            reader.Close();
            JObject constants = (JObject)json["constants"];
            if (constants == null)
            {
                MessageBox.Show(
                    "JSON Parse Error",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                return;
            }

            constants.Add(key, 0);
            using (StreamWriter writer = new StreamWriter(config.profile_path))
            {
                writer.Write(json.ToString());
            }

            //update listbox
            ConstantsLB.Items.Add(key);

        }

        private void ConstantDelBtn_Click(object sender, EventArgs e)
        {
            string key = ConstantsLB.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show(
                    "Select Constant that will be deledted on listbox",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                return;
            }
            config.constants.Remove(key);

            //update json file
            StreamReader reader = new StreamReader(config.profile_path);
            JObject json = JObject.Parse(reader.ReadToEnd());
            reader.Close();
            JObject constants = (JObject)json["constants"];
            if (constants == null)
            {
                MessageBox.Show(
                    "JSON Parse Error",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                return;
            }
            constants.Remove(key);

            using (StreamWriter writer = new StreamWriter(config.profile_path))
            {
                writer.Write(json.ToString());
            }

            //update listbox
            ConstantsLB.Items.Remove(key);
        }


        private void VariableAddBtn_Click(object sender, EventArgs e)
        {
            string key = VariableKeyTB.Text;
            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show(
                    "Write Variable on textbox",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                return;
            }

            if (config.mapping_table.ContainsKey(key))
            {
                MessageBox.Show(
                    "The variable is already in",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                return;
            }
            config.mapping_table.Add(key, -1);

            //update json file
            StreamReader reader = new StreamReader(config.profile_path);
            JObject json = JObject.Parse(reader.ReadToEnd());
            reader.Close();
            JArray variables = (JArray)json["variables"];
            if (variables == null)
            {
                MessageBox.Show(
                    "JSON Parse Error",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                return;
            }
            variables.Add(key);

            using (StreamWriter writer = new StreamWriter(config.profile_path))
            {
                writer.Write(json.ToString());
            }

            //update listbox
            VariablesLB.Items.Add(key);
        }

        private void VariableDelBtn_Click(object sender, EventArgs e)
        {
            string key = VariablesLB.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show(
                    "Select Variable on listbox",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                return;
            }
            config.mapping_table.Remove(key);

            //update json file
            StreamReader reader = new StreamReader(config.profile_path);
            JObject json = JObject.Parse(reader.ReadToEnd());
            reader.Close();

            if (json["variables"] == null)
            {
                MessageBox.Show(
                    "JSON Parse Error",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                return;
            }

            JArray variables = new JArray();
            foreach (var v in config.mapping_table) variables.Add(v.Key.ToString());
            json["variables"] = variables;
            //JArray로 받아서 Remove하면 에러는 안뜨는데 안지워지는 문제 있음

            using (StreamWriter writer = new StreamWriter(config.profile_path))
            {
                writer.Write(json.ToString());
            }

            //update listbox
            VariablesLB.Items.Remove(key);
        }

    }
}