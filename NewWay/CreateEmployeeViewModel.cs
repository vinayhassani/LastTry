using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;

namespace NewWay
{
    public class CreateEmployeeViewModel
    {
        private Employee _emp { get; set; }
        public Employee emp
        {
            get { return _emp; }
            set
            {
                _emp = value;
                b.NotifyPropertyChanged("emp");
            }
        }

        Baseclass b = new Baseclass();

        public CreateEmployeeViewModel()
        {
            emp = new Employee();
            emplist = new ObservableCollection<Employee>();
            getdata();

        }

        private ICommand _SaveCommand { get; set; }
        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                {
                    _SaveCommand = new DelegateCommand(Save, () => CanSave);
                }
                return _SaveCommand;

            }
        }
        private ICommand _EditCommand { get; set; }
        public ICommand EditCommand
        {
            get
            {
                if (_EditCommand == null)
                {
                    _EditCommand = new DelegateCommand(Edit, () => CanEdit);
                }
                return _EditCommand;
            }
        }
        private ICommand _DeleteCommand { get; set; }
        public ICommand DeleteCommand
        {
            get
            {
                if (_DeleteCommand == null)
                {
                    _DeleteCommand = new DelegateCommand(Delete, () => CanDelete);
                }
                return _DeleteCommand;
            }
        }

        public bool CanSave
        {
            get
            {
                return !string.IsNullOrEmpty(emp.ID) && !string.IsNullOrEmpty(emp.FirstName);

            }
        }
        public bool CanEdit
        {
            get
            {
                return !string.IsNullOrEmpty(emp.ID) && !string.IsNullOrEmpty(emp.FirstName);

            }
        }
        public bool CanDelete
        {
            get
            {
                return !string.IsNullOrEmpty(emp.ID) && !string.IsNullOrEmpty(emp.FirstName);

            }
        }
        string connectionString =
          @"Data Source=localhost;Initial Catalog=Student;Integrated Security=True";
        public void Save()
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "INSERT INTO Users(ID,FirstName,Address)VALUES(@ID,@FirstName,@Address)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", emp.ID);
            cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmd.Parameters.AddWithValue("@Address", emp.Address);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

                // mw.dataGrid1.Items.Add(emp);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
            MessageBox.Show("Data Saved Successfully");
            emplist.Add(emp);
        }
        public void Edit()
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Update Users set FirstName=@FirstName ,Address=@Address where ID=@ID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", emp.ID);
            cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmd.Parameters.AddWithValue("@Address", emp.Address);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {

                con.Close();
            }
            MessageBox.Show("Data Updated Successfully");
            emplist.Add(emp);
            emplist.RemoveAt(0);

        }
        public void Delete()
        {
            MainWindow mw = new MainWindow();

            SqlConnection con = new SqlConnection(connectionString);
            string query = "DELETE from Users WHERE ID=@ID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", emp.ID);
            // cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
            //  cmd.Parameters.AddWithValue("@Address", emp.Address);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {

                con.Close();
            }
            MessageBox.Show("Data Deleted Successfully");
            emplist.Remove(emp);

        }

        public void getdata()
        {
            SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=Student;Integrated Security=True");
            string query = "SELECT ID,FirstName,Address  from Users";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Users");
            DataColumn id = new DataColumn("ID");
            DataColumn FirstName = new DataColumn("FirstName");
            DataColumn Address = new DataColumn("Address");
            dt.Columns.Add(id);
            dt.Columns.Add(FirstName);
            dt.Columns.Add(Address);
            da.Fill(dt);
            emplist.Add(emp);
            emplist.Remove(emp);

            con.Close();
        }


        private ObservableCollection<Employee> _emplist { get; set; }
        public ObservableCollection<Employee> emplist
        {
            get { return _emplist; }
            set
            {
                _emplist = value;
                b.NotifyPropertyChanged("emplist");
            }
        }

        //private IList<Employee> _list { get; set; }
        //public IList<Employee> list
        //{
        //    get { return _list; }
        //    set
        //    {
        //        _list = value;
        //        b.NotifyPropertyChanged("list");
        //    }
        //}



    }
}
