using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;


namespace BookStore
{
    
    public partial class MainWindow : Window
    {
        public SqlConnection connect;
        private void connection()
        {
            string connStr = @"Data Source=DESKTOP-L7GST1A; Initial Catalog=BookStoreLite; Integrated Security=True";
            connect = new SqlConnection(connStr);
            connect.Open();

        }
        public MainWindow()
        {
            InitializeComponent();
            connection();
        }

        private void view(string query, string table)
        {
            //LINQ для bit

            SqlCommand cmd = new SqlCommand(query, connect);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable(table);
            da.Fill(dt);

            datagrid.ItemsSource = null;
            datagrid.ItemsSource = dt.DefaultView;



        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            view("exec view_books", "Books");
           // datagrid.Columns[1].Header = "Номер полиса";

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Image newImage = Image.FromFile("SampImag.jpg");
        }
    }
}
