using DatabaseRedactorUI.Controllers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DatabaseRedactorUI
{
    public partial class Form1 : Form
    {
        private ConnectionController connectionController;
        private JsonParseController jsonParseController;

        private int indexId = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.MouseMove += DataGridView1_MouseMove;
            dataGridView1.MouseDown += DataGridView1_MouseDown;
            dataGridView1.DragDrop += DataGridView1_DragDrop;
            dataGridView1.DragOver += DataGridView1_DragOver;

            portBox.Maximum = uint.MaxValue;
            portBox.Minimum = uint.MinValue;
            jsonParseController = new JsonParseController();

            LoadConnection();
        }

        //db-golang
        //table

        private void connection_Click(object sender, EventArgs e)
        {
            //TODO : Проверка входных данных
            connectionController = new ConnectionController(adressBox.Text, (uint)portBox.Value, databaseBox.Text, tableBox.Text);//"https://461e33af8aa9.ngrok.io/");
            ConnectionAsync();
            SaveConnection();
        }

        /// <summary>
        /// Сохранени подулючения
        /// </summary>
        private void SaveConnection()
        {
            var formatter = new BinaryFormatter();

            using (var file = new FileStream("connection.bin", FileMode.OpenOrCreate))
            {
                formatter.Serialize(file, connectionController);
            }
        }

        /// <summary>
        /// Загрузка сохранненого подключения
        /// </summary>
        private void LoadConnection()
        {
            var formatter = new BinaryFormatter();

            using (var file = new FileStream("connection.bin", FileMode.OpenOrCreate))
            {
                if (file.Length > 0)
                {
                    var connection = formatter.Deserialize(file) as ConnectionController;
                    
                    adressBox.Text = connection.Address;
                    databaseBox.Text = connection.Database;
                    tableBox.Text = connection.Table;
                    portBox.Value = connection.Port;
                }
            }
        }

        /// <summary>
        /// Асинхронний метод для підключення до бази даних
        /// </summary>
        private async void ConnectionAsync()
        {
            var res = await Task.Run(Connection);
            FillData(res);
        }

        /// <summary>
        /// Метод для підключення до бази даних
        /// </summary>
        private JObject Connection()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();

            values.Add("bd_name", connectionController.Database);
            values.Add("table_name", connectionController.Table);

            try
            {
                return jsonParseController.ParseJSON(connectionController.GetConnection(values));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return new JObject();
        }

        /// <summary>
        /// Заповнення DataGreedView даними
        /// </summary>
        /// <param name="jsonValues">Об'єкт Json із данними для заповнення</param>
        private void FillData(JObject jsonValues)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            var en = jsonValues.GetEnumerator();

            while (en.MoveNext())
            {
                var index = dataGridView1.Columns.Add(en.Current.Key, en.Current.Key);

                if (en.Current.Key.ToLower() == "id")
                {
                    dataGridView1.Columns[index].DisplayIndex = 0;
                    indexId = dataGridView1.Columns[index].Index;
                }

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

        /// <summary>
        /// Отправка данных таблицы на сервер
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendData(object sender, EventArgs e)
        {
            Dictionary<string, List<object>> dict = new Dictionary<string, List<object>>();
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                List<object> list = new List<object>();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                        list.Add(row.Cells[col.Name].Value);
                }
                dict.Add(col.Name, list);
            }

            connectionController.PostConnection(jsonParseController.SerializeData(dict));
        }

        #region Перетаскування

        private Rectangle dragBoxFromMouseDown;
        private int rowIndexFromMouseDown;
        private int rowIndexOfItemUnderMouseToDrop;

        private void DataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty &&
                !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    // Proceed with the drag and drop, passing in the list item.                    
                    DragDropEffects dropEffect = dataGridView1.DoDragDrop(
                          dataGridView1.Rows[rowIndexFromMouseDown],
                          DragDropEffects.Move);
                }
            }
        }

        private void DataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            rowIndexFromMouseDown = dataGridView1.HitTest(e.X, e.Y).RowIndex;

            if (rowIndexFromMouseDown != -1)
            {
                // Remember the point where the mouse down occurred. 
                // The DragSize indicates the size that the mouse can move 
                // before a drag event should be started.                
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDown = new Rectangle(
                          new Point(
                            e.X - (dragSize.Width / 2),
                            e.Y - (dragSize.Height / 2)),
                      dragSize);
            }
            else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void DataGridView1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void DataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.
            Point clientPoint = dataGridView1.PointToClient(new Point(e.X, e.Y));

            // Get the row index of the item the mouse is below. 
            rowIndexOfItemUnderMouseToDrop = dataGridView1.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            if (dataGridView1.Rows.Count - 1 == rowIndexOfItemUnderMouseToDrop) return;

            // If the drag operation was a move then remove and insert the row.
            if (e.Effect == DragDropEffects.Move && rowIndexOfItemUnderMouseToDrop != -1)
            {
                int maxIndex = Math.Max(rowIndexFromMouseDown, rowIndexOfItemUnderMouseToDrop);
                int minIndex = Math.Min(rowIndexFromMouseDown, rowIndexOfItemUnderMouseToDrop);
                List<object> list = new List<object>();

                for (int i = minIndex; i <= maxIndex; i++)
                    list.Add(dataGridView1.Rows[i].Cells[indexId].Value);
               

                DataGridViewRow rowToMove = e.Data.GetData(typeof(DataGridViewRow)) as DataGridViewRow;
                dataGridView1.Rows.RemoveAt(rowIndexFromMouseDown);
                dataGridView1.Rows.Insert(rowIndexOfItemUnderMouseToDrop, rowToMove);

                for (int i = minIndex, j = 0; i <= maxIndex; i++, j++)
                    dataGridView1.Rows[i].Cells[indexId].Value = list[j];
            }
        }
        #endregion

    }
}
