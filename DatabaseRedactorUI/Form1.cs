using DatabaseRedactorUI.Controllers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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

            values.Add("bd_name", "db-golang");
            values.Add("table_name", "table");

            try
            {
                return jsonParseController.ParseJSON("{\"cost\":[14,12,41,53],\"id\":[1,2,3,4],\"name\":[24,124,123,12]}");//connectionController.GetConnection(values));
                //MessageBox.Show(json.ToString());

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
