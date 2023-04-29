using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.ComponentModel;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace PrisonerAnalysis
{
    public partial class Main : Form
    {
        private int newSortColumn;
        private ListSortDirection newColumnDirection = ListSortDirection.Ascending;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Main_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                    List<Prisoner> prisoners = new List<Prisoner>();
                    prisoners = File.ReadAllLines(files[0])
                                           .Skip(3)
                                           .SkipLast(2)
                                           .Select(v => Prisoner.FromCsv(v))
                                           .Where(p => p.BookingDate.HasValue).ToList();

                    dataGridView.DataSource = new SortableBindingList<Prisoner>(prisoners);

                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.Automatic;
                        if (column.Name != "PREAfinished")
                            column.ReadOnly = true;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("File format was incorrect. " + ex.Message, "Error Found");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex].SortMode != DataGridViewColumnSortMode.NotSortable)
            {
                if (e.ColumnIndex == newSortColumn)
                {
                    if (newColumnDirection == ListSortDirection.Ascending)
                        newColumnDirection = ListSortDirection.Descending;
                    else
                        newColumnDirection = ListSortDirection.Ascending;
                }

                newSortColumn = e.ColumnIndex;

                switch (newColumnDirection)
                {
                    case ListSortDirection.Ascending:
                        dataGridView.Sort(dataGridView.Columns[newSortColumn], ListSortDirection.Ascending);
                        break;
                    case ListSortDirection.Descending:
                        dataGridView.Sort(dataGridView.Columns[newSortColumn], ListSortDirection.Descending);
                        break;
                }

                if (newColumnDirection == ListSortDirection.Ascending)
                {
                    dataGridView.Columns[newSortColumn].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                }
                else
                {
                    dataGridView.Columns[newSortColumn].HeaderCell.SortGlyphDirection = SortOrder.Descending;
                }
            }
        }

        private void dataGridView_DataSourceChanged(object sender, EventArgs e)
        {
            ColorMe();
        }

        private void ColorMe()
        {
            int thirtyDays = 0;
            int seventyTwoHours = 0;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (Convert.ToInt32(row.Cells["HoursInPrison"].Value) > 72)
                {
                    row.DefaultCellStyle.BackColor = Color.LightBlue;

                    seventyTwoHours++;
                }
                if (Convert.ToInt32(row.Cells["DayInPrison"].Value) > 30)
                {
                    row.DefaultCellStyle.BackColor = Color.LightYellow;
                    //  row.Cells["DayInPrison"].Style.BackColor = Color.Red;
                    thirtyDays++;
                }
            }
            dataGridView.Columns["HoursInPrison"].Visible = false;

            lblThirtyDays.Text = thirtyDays.ToString();
            lblSeventyTwoHours.Text = seventyTwoHours.ToString();
        }

        private void dataGridView_Sorted(object sender, EventArgs e)
        {
            ColorMe();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var total = 0;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (Convert.ToBoolean(row.Cells["PREAfinished"].EditedFormattedValue) == true)
                {
                    total++;
                }
            }
            decimal ThirtyDays = Convert.ToDecimal(lblThirtyDays.Text);
            decimal PREAperc = Convert.ToDecimal(total) / ThirtyDays;
            label4.Text = (Math.Round(PREAperc*100, 2)).ToString();
        }

 
    }

}