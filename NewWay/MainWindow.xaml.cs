using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace NewWay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new CreateEmployeeViewModel();

        }

        //private void binddatagrid()
        //{
        //    SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=Student;Integrated Security=True");
        //    string query = "SELECT ID,FirstName,Address  from Users";
        //    SqlCommand cmd = new SqlCommand(query, con);
        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable("Users");
        //    DataColumn id = new DataColumn("ID");
        //    DataColumn FirstName = new DataColumn("FirstName");
        //    DataColumn Address = new DataColumn("Address");
        //    dt.Columns.Add(id);
        //    dt.Columns.Add(FirstName);
        //    dt.Columns.Add(Address);
        //    Employee emp = new Employee();
        //    DataRow dr = dt.NewRow();
        //    dr["ID"] = emp.ID;
        //    dr["FirstName"] = emp.FirstName;
        //    dr["Address"] = emp.Address;
        //    dt.Rows.Add(dr);
        //    dt.AcceptChanges();
        //    //da.Fill(dt);
        //    listview.ItemsSource = dt.DefaultView;
        //    //con.Close();
        //}

        private void editbtn_Click(object sender, RoutedEventArgs e)
        {
            txtID.IsReadOnly = true;
            txFirstName.Text = "";
            txtAddress.Text = "";
        }



        private void new_Click(object sender, RoutedEventArgs e)
        {
            txtID.Text = "";
            txFirstName.Text = "";
            txtAddress.Text = "";
        }

        private void listview_Loaded(object sender, RoutedEventArgs e)
        {
            //  binddatagrid();

        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //  binddatagrid();
        }

        private void dataGrid1_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ListView gd = (ListView)sender;
            DataRowView row_select = gd.SelectedItem as DataRowView;
            if (row_select != null)
            {
                txtID.Text = row_select["ID"].ToString();
                txFirstName.Text = row_select["FirstName"].ToString();
                txtAddress.Text = row_select["Address"].ToString();
            }
            //txtID.Text = listview.SelectedIndex.ToString() + 1;
            //txFirstName.Text = listview.SelectedItem.ToString();
            //txtAddress.Text = listview.SelectedValue.ToString();

        }
    }
}

