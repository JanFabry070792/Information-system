using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Jan_Fabry_BakalarskaPraca
{
    public partial class FormLogin : Form
    {
        SqlDataAdapter data;
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection("Data Source=JANCI-NOTEBOOK;Initial Catalog=BakalarkaLogFirma;Integrated Security=True;");

                string str = "select * from Uzivatel where Username =@user and Upassword =@pw";
                var query = "SELECT TOP 1 Typ_Uctu From Uzivatel where Username =@user2 and Upassword =@pw2";
                SqlCommand sql = new SqlCommand(str, con);
                var sql2 = new SqlCommand(query, con);
                con.Open();
                sql.Parameters.AddWithValue("@user", tb_Login.Text);
                sql.Parameters.AddWithValue("@pw", tb_Password.Text);

                sql2.Parameters.AddWithValue("@user2", tb_Login.Text);
                sql2.Parameters.AddWithValue("@pw2", tb_Password.Text);




                var typ_uctu = Convert.ToString(sql2.ExecuteScalar());
                if (String.IsNullOrEmpty(typ_uctu))
                {
                    
                }
                else
                {
                    
                    tb_Typ_Uctu.Text = typ_uctu;
                }


                SqlDataReader Dr = sql.ExecuteReader();


                if (Dr.HasRows == true)
                {
                    MessageBox.Show("OK");
                    this.Hide();
                    FormMain form2 = new FormMain();
                    form2.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Neplatné meno alebo heslo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
