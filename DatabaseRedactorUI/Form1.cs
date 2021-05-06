using DatabaseRedactorUI.Controllers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseRedactorUI
{
    public partial class Form1 : Form
    {
        private ConnectionController connectionController;
        private JsonParseController jsonParseController;

        private string databaseName;
        private string tableName;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connectionController = new ConnectionController("https://461e33af8aa9.ngrok.io/");
            jsonParseController = new JsonParseController();
        }

        //db-golang
        //table

        private void connection_Click(object sender, EventArgs e)
        {
            databaseName = databaseBox.Text;
            tableName = tableBox.Text;
            ConnectionAsync();
        }

        private async void ConnectionAsync()
        {
            await Task.Run(Connection);
        }

        private void Connection()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();

            values.Add("bd_name", "db-golang");
            values.Add("table_name", "table");

            try
            {
                var json = jsonParseController.ParseJSON(connectionController.GetConnection(values));
                FillData(json);
                //MessageBox.Show(json.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillData(JObject jsonValues)
        {
            var en = jsonValues.GetEnumerator();

            while (en.MoveNext())
            {
                var index = dataGridView1.Columns.Add(en.Current.Key, en.Current.Key);

                if (en.Current.Key.ToLower() == "id")
                    dataGridView1.Columns[index].DisplayIndex = 0;

                while (dataGridView1.Rows.Count <= en.Current.Value.Count())
                {
                    dataGridView1.Rows.Add();
                }
            }

            en = jsonValues.GetEnumerator();

            while (en.MoveNext())
            {
                int i = 0;
                foreach (var item in en.Current.Value)
                {
                    dataGridView1.Rows[i].Cells[en.Current.Key].Value = item;
                    i++;
                }
            }
        }
        
    }
}
