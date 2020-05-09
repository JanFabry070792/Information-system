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
    public partial class FormMain : Form
    {
        SqlConnection MyConn;
        SqlDataAdapter MyAdapter, MyAdapter2, MyAdapter3, MyAdapter4, MyAdapter5, MyAdapter6, MyAdapter7, MyAdapter8, MyAdapter9;
        SqlCommand sql;
        string pripojenie = "Data Source=JANCI-NOTEBOOK;Initial Catalog=BakalarkaLogFirma;Integrated Security=True;";
        public FormMain()
        {
            InitializeComponent();
            MyConn = new SqlConnection();
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["FormLogin"];
            string typ_uctu = ((FormLogin)f).tb_Typ_Uctu.Text;

            if (typ_uctu == "Admin")
            {
                tabControl1.TabPages.Remove(Zakaznici);
                tabControl1.TabPages.Remove(Kurieri);
                tabControl1.TabPages.Remove(Objednavky);
                tabControl1.TabPages.Remove(Reklamacie);
                tabControl1.TabPages.Remove(Faktury);
                tabControl1.TabPages.Remove(Partneri);
            }
            else if (typ_uctu == "Manazer")
            {
                tabControl1.TabPages.Remove(UzivatelskePrava);
                tabControl1.TabPages.Remove(Zakaznici);
                tabControl1.TabPages.Remove(Objednavky);
                tabControl1.TabPages.Remove(Kurieri);
            }
            else if (typ_uctu == "Dispecer")
            {
                tabControl1.TabPages.Remove(Reklamacie);
                tabControl1.TabPages.Remove(UzivatelskePrava);
                tabControl1.TabPages.Remove(Faktury);
                tabControl1.TabPages.Remove(Partneri);
            }

            SqlConnection MyConn = new SqlConnection(pripojenie);
            MyConn.Open();
            string select = "select Username,Upassword,Typ_Uctu from Uzivatel ";
            MyAdapter = new SqlDataAdapter(select, MyConn);
            MyAdapter2 = new SqlDataAdapter(select, MyConn);
            MyAdapter3 = new SqlDataAdapter(select, MyConn);
            MyAdapter4 = new SqlDataAdapter(select, MyConn);
            MyAdapter5 = new SqlDataAdapter(select, MyConn);
            MyAdapter6 = new SqlDataAdapter(select, MyConn);
            MyAdapter7 = new SqlDataAdapter(select, MyConn);
            MyAdapter8 = new SqlDataAdapter(select, MyConn);
            MyAdapter9 = new SqlDataAdapter(select, MyConn);
            MyAdapter.Fill(ds_Uzivatelia, "Uzivatel");
            dgw_Uzivatelia.DataSource = ds_Uzivatelia.Tables["Uzivatel"];
            cb_Evidoval_Kuriera.DataSource = ds_Uzivatelia.Tables["Uzivatel"];
            cb_Evidoval_Kuriera.DisplayMember = "Username";
            cb_Evidoval_Objednavky.DataSource = ds_Uzivatelia.Tables["Uzivatel"];
            cb_Evidoval_Objednavky.DisplayMember = "Username";
            cb_Uzivatel_Reklamacie.DataSource = ds_Uzivatelia.Tables["Uzivatel"];
            cb_Uzivatel_Reklamacie.DisplayMember = "Username";





            select = "select ID_Odosielatel,Meno,Priezvisko,Ulica,Mesto,PSC,Telefon from Odosielatel";
            MyAdapter6 = new SqlDataAdapter(select, MyConn);
            MyAdapter6.Fill(ds_Odosielatel, "Odosielatel");
            dgw_Odosielatel.DataSource = ds_Odosielatel.Tables["Odosielatel"];
            cb_ID_Odosielatel.DataSource = ds_Odosielatel.Tables["Odosielatel"];
            cb_ID_Odosielatel.DisplayMember = "ID_Odosielatel";
            tb_Odosielatel_Objednavky.DataSource = ds_Odosielatel.Tables["Odosielatel"];
            tb_Odosielatel_Objednavky.DisplayMember = "ID_Odosielatel";


            select = "select ID_Prijemca,Meno,Priezvisko,Ulica,Mesto,PSC,Telefon from Prijemca";
            MyAdapter7 = new SqlDataAdapter(select, MyConn);
            MyAdapter7.Fill(ds_Prijemca, "Prijemca");
            dgw_Prijemca.DataSource = ds_Prijemca.Tables["Prijemca"];
            cb_ID_Prijemca.DataSource = ds_Prijemca.Tables["Prijemca"];
            cb_ID_Prijemca.DisplayMember = "ID_Prijemca";
            tb_Prijemca_Objednavky.DataSource = ds_Prijemca.Tables["Prijemca"];
            tb_Prijemca_Objednavky.DisplayMember = "ID_Prijemca";
            


            MyAdapter5.Fill(ds_Zamestnanec, "Uzivatel");
            cb_Zamestnanec_Uzivatel.DataSource = ds_Zamestnanec.Tables["Uzivatel"];
            cb_Zamestnanec_Uzivatel.DisplayMember = "Username";
            select = "select x.ID_Zamestnanec,x.Meno,x.Priezvisko,x.Datum_Narodenia,x.Narodnost,x.Ulica,x.Mesto,x.Pozicia,x.Telefon, " +
                "x.Email,x.Uzivatel_Username from Zamestnanec x, Uzivatel y where x.Uzivatel_Username = y.Username";
            MyAdapter5 = new SqlDataAdapter(select, MyConn);
            MyAdapter5.Fill(ds_Zamestnanec, "Zamestnanec");
            dgw_Zamestnanec.DataSource = ds_Zamestnanec.Tables["Zamestnanec"];
            cb_ID_Zamestnanec.DataSource = ds_Zamestnanec.Tables["Zamestnanec"];
            cb_ID_Zamestnanec.DisplayMember = "ID_Zamestnanec";
            cb_Zamestnanec_Kurier.DataSource = ds_Zamestnanec.Tables["Zamestnanec"];
            cb_Zamestnanec_Kurier.DisplayMember = "ID_Zamestnanec";
    

            MyAdapter4.Fill(ds_Vozidlo, "Uzivatel");
            cb_Vozidlo_Username.DataSource = ds_Vozidlo.Tables["Uzivatel"];
            cb_Vozidlo_Username.DisplayMember = "Username";
            select = "select x.ID_Vozidlo,x.SPZ,x.Typ,x.Znacka,x.Cena,x.Uzivatel_Username from Vozidlo x, Uzivatel o where Uzivatel_Username = o.Username";
            MyAdapter4 = new SqlDataAdapter(select, MyConn);
            MyAdapter4.Fill(ds_Vozidlo, "Vozidlo");
            dgw_Vozidlo.DataSource = ds_Vozidlo.Tables["Vozidlo"];
            cb_ID_Vozidlo_Kurier.DataSource = ds_Vozidlo.Tables["Vozidlo"];
            cb_ID_Vozidlo_Kurier.DisplayMember = "ID_Vozidlo";



            MyAdapter3.Fill(ds_Kurier, "Uzivatel");
            select = "select a.ID_Kurier,a.Cislo_Trasy,a.Vozidlo_ID_Vozidlo,a.Uzivatel_Username,a.Zamestnanec_ID_Zamestnanec from Kurier a, Vozidlo b, Uzivatel c, Zamestnanec d where a.Vozidlo_ID_Vozidlo=b.ID_Vozidlo AND a.Uzivatel_Username=c.Username AND a.Zamestnanec_ID_Zamestnanec=d.ID_Zamestnanec";
            MyAdapter3 = new SqlDataAdapter(select, MyConn);
            MyAdapter3.Fill(ds_Kurier, "Kurier");
            dgw_Kurier.DataSource = ds_Kurier.Tables["Kurier"];
            cb_Zamestnanec_Kurier_ID.DataSource = ds_Kurier.Tables["Kurier"];
            cb_Zamestnanec_Kurier_ID.DisplayMember = "ID_Kurier";
            cb_ID_Kurier_Objednavka.DataSource = ds_Kurier.Tables["Kurier"];
            cb_ID_Kurier_Objednavka.DisplayMember = "ID_Kurier";



            MyAdapter9.Fill(ds_Objednavky, "Objednavky");
            select = "select a.ID_Objednavka,a.Cena,a.Hmotnost,a.Pocet_Balikov,a.Datum_Prijatia,a.Datum_Dorucenia,a.Stav,a.Kurier_ID_Kurier," +
                "a.Uzivatel_Username,a.Prijemca_ID_Prijemca,a.Odosielatel_ID_Odosielatel from Objednavka a, Kurier b, Uzivatel c, Prijemca d, Odosielatel e " +
                "where a.Kurier_ID_Kurier=b.ID_Kurier AND a.Uzivatel_Username=c.Username AND a.Prijemca_ID_Prijemca=d.ID_Prijemca AND a.Odosielatel_ID_Odosielatel = e.ID_Odosielatel";
            MyAdapter9 = new SqlDataAdapter(select, MyConn);
            MyAdapter9.Fill(ds_Objednavky, "Objednavka");
            dgw_Objednavky.DataSource = ds_Objednavky.Tables["Objednavka"];
            cb_ID_Objednavky.DataSource = ds_Objednavky.Tables["Objednavka"];
            cb_ID_Objednavky.DisplayMember = "ID_Objednavka";
            cb_ID_Objednavky_Reklamacie.DataSource = ds_Objednavky.Tables["Objednavka"];
            cb_ID_Objednavky_Reklamacie.DisplayMember = "ID_Objednavka";



            MyAdapter2.Fill(ds_Reklamacie, "Uzivatel");
            select = "select a.ID_Reklamacia,a.Datum_Podania,a.Stav,a.Predmet,a.Uzivatel_Username,a.Objednavka_ID_Objednavka from " +
                "Reklamacia a, Uzivatel b, Objednavka c where a.Uzivatel_Username=b.Username AND a.Objednavka_ID_Objednavka = c.ID_Objednavka";
            MyAdapter2 = new SqlDataAdapter(select, MyConn);
            MyAdapter2.Fill(ds_Reklamacie, "Reklamacia");
            dgw_Reklamacie.DataSource = ds_Reklamacie.Tables["Reklamacia"];
            cb_ID_Reklamacie.DataSource = ds_Reklamacie.Tables["Reklamacia"];
            cb_ID_Reklamacie.DisplayMember = "ID_Reklamacia";



        }

        private void btn_Pridaj_Uzivatela_Click(object sender, EventArgs e)
        {
            SqlConnection MyConn = new SqlConnection(pripojenie);
            MyConn.Open();
            string insert = "insert into Uzivatel(Username,Upassword,Typ_Uctu) values('" + tb_Meno_Uzivatela.Text + "','" + tb_Heslo_Uzivatela.Text + "','" + cb_Prava_Uzivatela.Text + "')";
            sql = new SqlCommand(insert, MyConn);
            sql.ExecuteNonQuery();
            ds_Uzivatelia.Tables["Uzivatel"].Clear();
            MyAdapter.Fill(ds_Uzivatelia, "Uzivatel");
            dgw_Uzivatelia.DataSource = ds_Uzivatelia.Tables["Uzivatel"];

            cb_Zamestnanec_Uzivatel.DataSource = ds_Uzivatelia.Tables["Uzivatel"];
            cb_Zamestnanec_Uzivatel.DisplayMember = "Username";
        }
        private void btn_Edituj_Uzivatela_Click(object sender, EventArgs e)
        {
            SqlConnection MyConn = new SqlConnection(pripojenie);
            MyConn.Open();
            string update = "UPDATE Uzivatel SET Username = '" + tb_Meno_Uzivatela.Text + "', " +
                "Upassword = '" + tb_Heslo_Uzivatela.Text + "', " +
                "Typ_Uctu = '" + cb_Prava_Uzivatela.Text + "' WHERE Username =  '" + tb_Meno_Uzivatela.Text + "'";

            sql = new SqlCommand(update, MyConn);
            sql.ExecuteNonQuery();
            ds_Uzivatelia.Tables["Uzivatel"].Clear();
            MyAdapter.Fill(ds_Uzivatelia, "Uzivatel");
            dgw_Uzivatelia.DataSource = ds_Uzivatelia.Tables["Uzivatel"];
        }
        private void btn_Zmaz_Uzivatela_Click(object sender, EventArgs e)
        {
            SqlConnection MyConn = new SqlConnection(pripojenie);
            MyConn.Open();
            string delete = "delete from Uzivatel where Username='" + tb_Meno_Uzivatela.Text + "';" +
                "delete from Zamestnanec where Uzivatel_Username='" + cb_Zamestnanec_Uzivatel.Text + "';" +
                "delete from Objednavka where Uzivatel_Username='" + cb_Evidoval_Objednavky.Text + "';" +
                "delete from Vozidlo where Uzivatel_Username='" + cb_Vozidlo_Username.Text + "';" +
                "delete from Kurier where Uzivatel_Username='" + cb_Evidoval_Kuriera.Text + "';" +
                "delete from Reklamacia where Uzivatel_Username='" + cb_Uzivatel_Reklamacie.Text + "';";
            sql = new SqlCommand(delete, MyConn);
            sql.ExecuteNonQuery();
            ds_Uzivatelia.Tables["Uzivatel"].Clear();
            MyAdapter.Fill(ds_Uzivatelia, "Uzivatel");
            dgw_Uzivatelia.DataSource = ds_Uzivatelia.Tables["Uzivatel"];
        }
        private void dgw_Uzivatelia_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgw_Uzivatelia.SelectedRows.Count > 0)
            {
                tb_Meno_Uzivatela.Text = dgw_Uzivatelia.SelectedRows[0].Cells["Username"].Value.ToString();
                tb_Heslo_Uzivatela.Text = dgw_Uzivatelia.SelectedRows[0].Cells["Upassword"].Value.ToString();
                cb_Prava_Uzivatela.Text = dgw_Uzivatelia.SelectedRows[0].Cells["Typ_Uctu"].Value.ToString();

            }
        }
        private void btn_Pridaj_Zamestnanca_Click(object sender, EventArgs e)
        {
            SqlConnection MyConn = new SqlConnection(pripojenie);
            MyConn.Open();
            string insert = "insert into Zamestnanec(ID_Zamestnanec,Meno,Priezvisko,Datum_Narodenia,Narodnost,Ulica,Mesto,Pozicia,Telefon,Email,Uzivatel_Username) values (next value for sekZamestnanec,'" + tb_Meno_Zamestnanca.Text + "','" + tb_Priezvisko_Zamestnanca.Text + "','" + dtp_Datum_Narodenia_Z.Text + "','" + tb_Narodnost_Zamestnanca.Text + "','" + tb_Ulica_Zamestnanca.Text + "','" + tb_Mesto_Zamestnanca.Text + "','" + cb_Pozicia_Zamestnanca.Text + "','" + tb_Telefon_Zamestnanca.Text + "','" + tb_Email_Zamestnanca.Text + "','" + cb_Zamestnanec_Uzivatel.Text + "') ";
            sql = new SqlCommand(insert, MyConn);
            sql.ExecuteNonQuery();
            ds_Zamestnanec.Tables["Zamestnanec"].Clear();
            MyAdapter5.Fill(ds_Zamestnanec, "Zamestnanec");
            dgw_Zamestnanec.DataSource = ds_Zamestnanec.Tables["Zamestnanec"];
        }
        private void btn_Edituj_Zamestnanca_Click(object sender, EventArgs e)
        {
            SqlConnection MyConn = new SqlConnection(pripojenie);
            MyConn.Open();
            string update = "UPDATE Zamestnanec SET Meno = '" + tb_Meno_Zamestnanca.Text + "', " +
                "Priezvisko = '" + tb_Priezvisko_Zamestnanca.Text + "', " +
                "Datum_Narodenia = '" + dtp_Datum_Narodenia_Z.Text + "', " +
                "Narodnost = '" + tb_Narodnost_Zamestnanca.Text + "', " +
                "Ulica = '" + tb_Ulica_Zamestnanca.Text + "', " +
                "Mesto = '" + tb_Mesto_Zamestnanca.Text + "', " +
                "Pozicia = '" + cb_Pozicia_Zamestnanca.Text + "', " +
                "Telefon = '" + tb_Telefon_Zamestnanca.Text + "', " +
                "Email = '" + tb_Email_Zamestnanca.Text + "', " +
                "Uzivatel_Username = '" + cb_Zamestnanec_Uzivatel.Text + "' WHERE ID_Zamestnanec =  '" + cb_ID_Zamestnanec.Text + "'";

            sql = new SqlCommand(update, MyConn);
            sql.ExecuteNonQuery();
            ds_Zamestnanec.Tables["Zamestnanec"].Clear();
            MyAdapter5.Fill(ds_Zamestnanec, "Zamestnanec");
            dgw_Zamestnanec.DataSource = ds_Zamestnanec.Tables["Zamestnanec"];



        }
        private void btn_Zmaz_Zamestnanca_Click(object sender, EventArgs e)
        {
            SqlConnection MyConn = new SqlConnection(pripojenie);
            MyConn.Open();
            string delete = "delete from Zamestnanec where ID_Zamestnanec='" + cb_ID_Zamestnanec.Text + "'; " +
                "delete from Kurier where Zamestnanec_ID_Zamestnanec='" + cb_ID_Zamestnanec.Text + "';";
            sql = new SqlCommand(delete, MyConn);
            sql.ExecuteNonQuery();
            ds_Zamestnanec.Tables["Zamestnanec"].Clear();
            MyAdapter5.Fill(ds_Zamestnanec, "Zamestnanec");
            dgw_Zamestnanec.DataSource = ds_Zamestnanec.Tables["Zamestnanec"];
        }
        private void dgw_Zamestnanec_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgw_Zamestnanec.SelectedRows.Count > 0)
            {
                tb_Meno_Zamestnanca.Text = dgw_Zamestnanec.SelectedRows[0].Cells["Meno"].Value.ToString();
                tb_Priezvisko_Zamestnanca.Text = dgw_Zamestnanec.SelectedRows[0].Cells["Priezvisko"].Value.ToString();
                dtp_Datum_Narodenia_Z.Text = dgw_Zamestnanec.SelectedRows[0].Cells["Datum_Narodenia"].Value.ToString();
                tb_Narodnost_Zamestnanca.Text = dgw_Zamestnanec.SelectedRows[0].Cells["Narodnost"].Value.ToString();
                tb_Ulica_Zamestnanca.Text = dgw_Zamestnanec.SelectedRows[0].Cells["Ulica"].Value.ToString();
                tb_Mesto_Zamestnanca.Text = dgw_Zamestnanec.SelectedRows[0].Cells["Mesto"].Value.ToString();
                cb_Pozicia_Zamestnanca.Text = dgw_Zamestnanec.SelectedRows[0].Cells["Pozicia"].Value.ToString();
                tb_Telefon_Zamestnanca.Text = dgw_Zamestnanec.SelectedRows[0].Cells["Telefon"].Value.ToString();
                tb_Email_Zamestnanca.Text = dgw_Zamestnanec.SelectedRows[0].Cells["Email"].Value.ToString();
                cb_Zamestnanec_Uzivatel.Text = dgw_Zamestnanec.SelectedRows[0].Cells["Uzivatel_Username"].Value.ToString();

            }
        }
        private void btn_Pridaj_Prijemcu_Click(object sender, EventArgs e)
        {
            SqlConnection MyConn = new SqlConnection(pripojenie);
            MyConn.Open();
            string insert = "insert into Prijemca(ID_Prijemca,Meno,Priezvisko,Ulica,Mesto,PSC,Telefon) values (next value for sekPrijemca,'" + tb_Meno_Prijemcu.Text + "','" + tb_Priezvisko_Prijemcu.Text + "','" + tb_Ulica_Prijemca.Text + "','" + tb_Mesto_Prijemca.Text + "','" + tb_PSC_Prijemcu.Text + "','" + tb_Telefon_Prijemcu.Text + "') ";
            sql = new SqlCommand(insert, MyConn);
            sql.ExecuteNonQuery();
            ds_Prijemca.Tables["Prijemca"].Clear();
            MyAdapter7.Fill(ds_Prijemca, "Prijemca");
            dgw_Prijemca.DataSource = ds_Prijemca.Tables["Prijemca"];
        }
        private void btn_Editovat_Prijemcu_Click(object sender, EventArgs e)
        {
            SqlConnection MyConn = new SqlConnection(pripojenie);
            MyConn.Open();
            string update = "UPDATE Prijemca SET Meno = '" + tb_Meno_Prijemcu.Text + "', " +
                "Priezvisko = '" + tb_Priezvisko_Prijemcu.Text + "', " +
                "Ulica = '" + tb_Ulica_Prijemca.Text + "', " +
                "Mesto = '" + tb_Mesto_Prijemca.Text + "', " +
                "PSC = '" + tb_PSC_Prijemcu.Text + "', " +
                "Telefon = '" + tb_Telefon_Prijemcu.Text + "' WHERE ID_Prijemca =  '" + cb_ID_Prijemca.Text + "'";

            sql = new SqlCommand(update, MyConn);
            sql.ExecuteNonQuery();
            ds_Prijemca.Tables["Prijemca"].Clear();
            MyAdapter7.Fill(ds_Prijemca, "Prijemca");
            dgw_Prijemca.DataSource = ds_Prijemca.Tables["Prijemca"];
        }
        private void btn_Zmazat_Prijemcu_Click(object sender, EventArgs e)
        {
            SqlConnection MyConn = new SqlConnection(pripojenie);
            MyConn.Open();
            string delete = "delete from Prijemca where ID_Prijemca='" + cb_ID_Prijemca.Text + "'";
            sql = new SqlCommand(delete, MyConn);
            sql.ExecuteNonQuery();
            ds_Prijemca.Tables["Prijemca"].Clear();
            MyAdapter7.Fill(ds_Prijemca, "Prijemca");
            dgw_Prijemca.DataSource = ds_Prijemca.Tables["Prijemca"];
        }
        private void dgw_Prijemca_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgw_Prijemca.SelectedRows.Count > 0)
            {
                tb_Meno_Prijemcu.Text = dgw_Prijemca.SelectedRows[0].Cells["Meno"].Value.ToString();
                tb_Priezvisko_Prijemcu.Text = dgw_Prijemca.SelectedRows[0].Cells["Priezvisko"].Value.ToString();
                tb_Ulica_Prijemca.Text = dgw_Prijemca.SelectedRows[0].Cells["Ulica"].Value.ToString();
                tb_Mesto_Prijemca.Text = dgw_Prijemca.SelectedRows[0].Cells["Mesto"].Value.ToString();
                tb_PSC_Prijemcu.Text = dgw_Prijemca.SelectedRows[0].Cells["PSC"].Value.ToString();
                tb_Telefon_Prijemcu.Text = dgw_Prijemca.SelectedRows[0].Cells["Telefon"].Value.ToString();

            }
        }
        private void btn_Pridaj_Odosielatela_Click(object sender, EventArgs e)
        {
            SqlConnection MyConn = new SqlConnection(pripojenie);
            MyConn.Open();
            string insert = "insert into Odosielatel(ID_Odosielatel,Meno,Priezvisko,Ulica,Mesto,PSC,Telefon) values (next value for sekOdosielatel,'" + tb_Meno_Odosielatel.Text + "','" + tb_Priezvisko_Odosielatel.Text + "','" + tb_Ulica_Odosielatel.Text + "','" + tb_Mesto_Odosielatel.Text + "','" + tb_PSC_Odosielatel.Text + "','" + tb_Telefon_Odosielatela.Text + "') ";
            sql = new SqlCommand(insert, MyConn);
            sql.ExecuteNonQuery();
            ds_Odosielatel.Tables["Odosielatel"].Clear();
            MyAdapter6.Fill(ds_Odosielatel, "Odosielatel");
            dgw_Odosielatel.DataSource = ds_Odosielatel.Tables["Odosielatel"];
        }
        private void btn_Edituj_Odosielatela_Click(object sender, EventArgs e)
        {
            SqlConnection MyConn = new SqlConnection(pripojenie);
            MyConn.Open();
            string update = "UPDATE Odosielatel SET Meno = '" + tb_Meno_Odosielatel.Text + "', " +
                "Priezvisko = '" + tb_Priezvisko_Odosielatel.Text + "', " +
                "Ulica = '" + tb_Ulica_Odosielatel.Text + "', " +
                "Mesto = '" + tb_Mesto_Odosielatel.Text + "', " +
                "PSC = '" + tb_PSC_Odosielatel.Text + "', " +
                "Telefon = '" + tb_Telefon_Odosielatela.Text + "' WHERE ID_Odosielatel =  '" + cb_ID_Odosielatel.Text + "'";

            sql = new SqlCommand(update, MyConn);
            sql.ExecuteNonQuery();
            ds_Odosielatel.Tables["Odosielatel"].Clear();
            MyAdapter6.Fill(ds_Odosielatel, "Odosielatel");
            dgw_Odosielatel.DataSource = ds_Odosielatel.Tables["Odosielatel"];
        }
        private void btn_Zmazat_odosielatela_Click(object sender, EventArgs e)
        {
            SqlConnection MyConn = new SqlConnection(pripojenie);
            MyConn.Open();
            string delete = "delete from Odosielatel where ID_Odosielatel='" + cb_ID_Odosielatel.Text + "'";
            sql = new SqlCommand(delete, MyConn);
            sql.ExecuteNonQuery();
            ds_Odosielatel.Tables["Odosielatel"].Clear();
            MyAdapter6.Fill(ds_Odosielatel, "Odosielatel");
            dgw_Odosielatel.DataSource = ds_Odosielatel.Tables["Odosielatel"];
        }
        private void dgw_Odosielatel_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgw_Odosielatel.SelectedRows.Count > 0)
            {
                tb_Meno_Odosielatel.Text = dgw_Odosielatel.SelectedRows[0].Cells["Meno"].Value.ToString();
                tb_Priezvisko_Odosielatel.Text = dgw_Odosielatel.SelectedRows[0].Cells["Priezvisko"].Value.ToString();
                tb_Ulica_Odosielatel.Text = dgw_Odosielatel.SelectedRows[0].Cells["Ulica"].Value.ToString();
                tb_Mesto_Odosielatel.Text = dgw_Odosielatel.SelectedRows[0].Cells["Mesto"].Value.ToString();
                tb_PSC_Odosielatel.Text = dgw_Odosielatel.SelectedRows[0].Cells["PSC"].Value.ToString();
                tb_Telefon_Odosielatela.Text = dgw_Odosielatel.SelectedRows[0].Cells["Telefon"].Value.ToString();

            }
        }
        private void btn_Pridaj_Objednavku_Click(object sender, EventArgs e)
        {
            SqlConnection MyConn = new SqlConnection(pripojenie);
            MyConn.Open();
            string insert = "insert into Objednavka(ID_Objednavka,Cena,Hmotnost,Pocet_Balikov,Datum_Prijatia,Datum_Dorucenia,Stav,Kurier_ID_Kurier," +
                "Uzivatel_Username,Prijemca_ID_Prijemca,Odosielatel_ID_Odosielatel) values (next value for sekObjednavka, '" + tb_Cena_Objednavky.Text + "', " +
                "'" + tb_Hmotnost_Objednavky.Text + "','" + num_Pocet_Balikov.Text + "','" + dt_DP_Objednavky.Text + "','" + dt_DD_Objednavky.Text + "', " +
                "'" + cb_Stav_Objednavky.Text + "','" + cb_ID_Kurier_Objednavka.Text + "','" + cb_Evidoval_Objednavky.Text + "','" + tb_Prijemca_Objednavky.Text + "','" + tb_Odosielatel_Objednavky.Text + "') ";

            sql = new SqlCommand(insert, MyConn);
            sql.ExecuteNonQuery();
            ds_Objednavky.Tables["Objednavka"].Clear();
            MyAdapter9.Fill(ds_Objednavky, "Objednavka");
            dgw_Objednavky.DataSource = ds_Objednavky.Tables["Objednavka"];
        }
        private void btn_Zmazat_Objednavku_Click(object sender, EventArgs e)
        {
            SqlConnection MyConn = new SqlConnection(pripojenie);
            MyConn.Open();
            string delete = "delete from Objednavka where ID_Objednavka='" + cb_ID_Objednavky.Text + "';";
            sql = new SqlCommand(delete, MyConn);
            sql.ExecuteNonQuery();
            ds_Objednavky.Tables["Objednavka"].Clear();
            MyAdapter9.Fill(ds_Objednavky, "Objednavka");
            dgw_Objednavky.DataSource = ds_Objednavky.Tables["Objednavka"];
        }
        private void btn_Editovat_Objednavku_Click(object sender, EventArgs e)
        {
            SqlConnection MyConn = new SqlConnection(pripojenie);
            MyConn.Open();
            string update = "UPDATE Objednavka SET Cena = '" + tb_Cena_Objednavky.Text + "', " +
                "Hmotnost = '" + tb_Hmotnost_Objednavky.Text + "', " +
                "Pocet_Balikov = '" + num_Pocet_Balikov.Text + "', " +
                "Datum_Prijatia = '" + dt_DP_Objednavky.Text + "', " +
                "Datum_Dorucenia = '" + dt_DD_Objednavky.Text + "', " +
                "Stav = '" + cb_Stav_Objednavky.Text + "', " +
                "Kurier_ID_Kurier = '" + cb_ID_Kurier_Objednavka.Text + "', " +
                "Uzivatel_Username = '" + cb_Evidoval_Objednavky.Text + "', " +
                "Prijemca_ID_Prijemca = '" + tb_Prijemca_Objednavky.Text + "', " +
                "Odosielatel_ID_Odosielatel = '" + tb_Odosielatel_Objednavky.Text + "' WHERE ID_Kurier = '" + cb_ID_Objednavky.Text + "'";

            sql = new SqlCommand(update, MyConn);
            sql.ExecuteNonQuery();
            ds_Objednavky.Tables["Objednavka"].Clear();
            MyAdapter3.Fill(ds_Kurier, "Objednavka");
            dgw_Objednavky.DataSource = ds_Kurier.Tables["Objednavka"];
        }
        private void dgw_Objednavky_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgw_Objednavky.SelectedRows.Count > 0)
            {
                tb_Cena_Objednavky.Text = dgw_Objednavky.SelectedRows[0].Cells["Cena"].Value.ToString();
                tb_Hmotnost_Objednavky.Text = dgw_Objednavky.SelectedRows[0].Cells["Hmotnost"].Value.ToString();
                num_Pocet_Balikov.Text = dgw_Objednavky.SelectedRows[0].Cells["Pocet_Balikov"].Value.ToString();
                dt_DP_Objednavky.Text = dgw_Objednavky.SelectedRows[0].Cells["Datum_Prijatia"].Value.ToString();
                dt_DD_Objednavky.Text = dgw_Objednavky.SelectedRows[0].Cells["Datum_Dorucenia"].Value.ToString();
                cb_Stav_Objednavky.Text = dgw_Objednavky.SelectedRows[0].Cells["Stav"].Value.ToString();
                cb_ID_Kurier_Objednavka.Text = dgw_Objednavky.SelectedRows[0].Cells["Kurier_ID_Kurier"].Value.ToString();
                cb_Evidoval_Objednavky.Text = dgw_Objednavky.SelectedRows[0].Cells["Uzivatel_Username"].Value.ToString();
                tb_Prijemca_Objednavky.Text = dgw_Objednavky.SelectedRows[0].Cells["Prijemca_ID_Prijemca"].Value.ToString();
                tb_Odosielatel_Objednavky.Text = dgw_Objednavky.SelectedRows[0].Cells["Odosielatel_ID_Odosielatel"].Value.ToString();

            }
        }
        private void btn_Pridaj_Kuriera_Click(object sender, EventArgs e)
        {
            SqlConnection MyConn = new SqlConnection(pripojenie);
            MyConn.Open();
            string insert = "insert into Kurier(ID_Kurier,Cislo_Trasy,Vozidlo_ID_Vozidlo,Uzivatel_Username,Zamestnanec_ID_Zamestnanec) values (next value for sekKurier, '" + num_Kurier_Cislo_Trasy.Value + "','" + cb_ID_Vozidlo_Kurier.Text + "','" + cb_Evidoval_Kuriera.Text + "','" + cb_Zamestnanec_Kurier.Text + "') ";

            sql = new SqlCommand(insert, MyConn);
            sql.ExecuteNonQuery();
            ds_Kurier.Tables["Kurier"].Clear();
            MyAdapter3.Fill(ds_Kurier, "Kurier");
            dgw_Kurier.DataSource = ds_Kurier.Tables["Kurier"];
        }
        private void btn_Edituj_Kuriera_Click(object sender, EventArgs e)
        {
            SqlConnection MyConn = new SqlConnection(pripojenie);
            MyConn.Open();
            string update = "UPDATE Kurier SET Cislo_Trasy = '" + num_Kurier_Cislo_Trasy.Text + "', " +
                "Vozidlo_ID_Vozidlo = '" + cb_ID_Vozidlo_Kurier.Text + "', " +
                "Uzivatel_Username = '" + cb_Evidoval_Kuriera.Text + "', " +
                "Zamestnanec_ID_Zamestnanec = '" + cb_Zamestnanec_Kurier.Text + "' WHERE ID_Kurier = '" + cb_Zamestnanec_Kurier_ID.Text + "'";

            sql = new SqlCommand(update, MyConn);
            sql.ExecuteNonQuery();
            ds_Kurier.Tables["Kurier"].Clear();
            MyAdapter3.Fill(ds_Kurier, "Kurier");
            dgw_Kurier.DataSource = ds_Kurier.Tables["Kurier"];
        }
        private void btn_Zmaz_Kuriera_Click(object sender, EventArgs e)
        {
            SqlConnection MyConn = new SqlConnection(pripojenie);
            MyConn.Open();
            string delete = "delete from Kurier where ID_Kurier='" + cb_Zamestnanec_Kurier_ID.Text + "'";
            sql = new SqlCommand(delete, MyConn);
            sql.ExecuteNonQuery();
            ds_Kurier.Tables["Kurier"].Clear();
            MyAdapter3.Fill(ds_Kurier, "Kurier");
            dgw_Kurier.DataSource = ds_Kurier.Tables["Kurier"];
        }
        private void dgw_Kurier_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgw_Kurier.SelectedRows.Count > 0)
            {
                num_Kurier_Cislo_Trasy.Text = dgw_Kurier.SelectedRows[0].Cells["Cislo_Trasy"].Value.ToString();
                cb_ID_Vozidlo_Kurier.Text = dgw_Kurier.SelectedRows[0].Cells["Vozidlo_ID_Vozidlo"].Value.ToString();
                cb_Evidoval_Kuriera.Text = dgw_Kurier.SelectedRows[0].Cells["Uzivatel_Username"].Value.ToString();
                cb_Zamestnanec_Kurier.Text = dgw_Kurier.SelectedRows[0].Cells["Zamestnanec_ID_Zamestnanec"].Value.ToString();

            }
        }
        private void btn_Pridaj_Vozidlo_Click(object sender, EventArgs e)
        {

            SqlConnection MyConn = new SqlConnection(pripojenie);
            MyConn.Open();
            string insert = "insert into Vozidlo(ID_Vozidlo,SPZ,Typ,Znacka,Cena,Uzivatel_Username) values (next value for sekVozidlo,'" + tb_SPZ.Text + "','" + cb_Typ_Vozidla.Text + "','" + tb_Znacka.Text + "','" + tb_Cena_Vozidla.Text + "','" + cb_Vozidlo_Username.Text + "') ";
            sql = new SqlCommand(insert, MyConn);
            sql.ExecuteNonQuery();
            ds_Vozidlo.Tables["Vozidlo"].Clear();
            MyAdapter4.Fill(ds_Vozidlo, "Vozidlo");
            dgw_Vozidlo.DataSource = ds_Vozidlo.Tables["Vozidlo"];
        }
        private void btn_Editovat_Vozidlo_Click(object sender, EventArgs e)
        {
            SqlConnection MyConn = new SqlConnection(pripojenie);
            MyConn.Open();
            string update = "UPDATE Vozidlo SET SPZ = '" + tb_SPZ.Text + "', " +
                "Typ = '" + cb_Typ_Vozidla.Text + "', " +
                "Znacka = '" + tb_Znacka.Text + "', " +
                "Cena = '" + tb_Cena_Vozidla.Text + "', " +
                "Uzivatel_Username = '" + cb_Vozidlo_Username.Text + "' WHERE ID_Vozidlo =  '" + cb_ID_Vozidlo.Text + "'";

            sql = new SqlCommand(update, MyConn);
            sql.ExecuteNonQuery();
            ds_Vozidlo.Tables["Vozidlo"].Clear();
            MyAdapter4.Fill(ds_Vozidlo, "Vozidlo");
            dgw_Vozidlo.DataSource = ds_Vozidlo.Tables["Vozidlo"];
        }
        private void btn_Zmazat_Vozidlo_Click(object sender, EventArgs e)
        {
            SqlConnection MyConn = new SqlConnection(pripojenie);
            MyConn.Open();
            string delete = "delete from Vozidlo where ID_Vozidlo='" + cb_ID_Vozidlo.Text + "'";
            sql = new SqlCommand(delete, MyConn);
            sql.ExecuteNonQuery();
            ds_Vozidlo.Tables["Vozidlo"].Clear();
            MyAdapter4.Fill(ds_Vozidlo, "Vozidlo");
            dgw_Vozidlo.DataSource = ds_Vozidlo.Tables["Vozidlo"];
        }
        private void dgw_Vozidlo_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgw_Vozidlo.SelectedRows.Count > 0)
            {
                tb_SPZ.Text = dgw_Vozidlo.SelectedRows[0].Cells["SPZ"].Value.ToString();
                cb_Typ_Vozidla.Text = dgw_Vozidlo.SelectedRows[0].Cells["Typ"].Value.ToString();
                tb_Znacka.Text = dgw_Vozidlo.SelectedRows[0].Cells["Znacka"].Value.ToString();
                tb_Cena_Vozidla.Text = dgw_Vozidlo.SelectedRows[0].Cells["Cena"].Value.ToString();
                cb_Vozidlo_Username.Text = dgw_Vozidlo.SelectedRows[0].Cells["Uzivatel_Username"].Value.ToString();

            }
        }
        private void btn_Pridaj_Reklamaciu_Click(object sender, EventArgs e)
        {

            SqlConnection MyConn = new SqlConnection(pripojenie);
            MyConn.Open();
            string insert = "insert into Reklamacia(ID_Reklamacia,Datum_Podania,Stav,Predmet,Uzivatel_Username, Objednavka_ID_Objednavka) " +
                "values (next value for sekReklamacia, '" + dtp_Reklamacia.Text + "','" + cb_Predmet_Reklamacie.Text + "', " +
                "'" + cb_Stav_Reklamacie.Text + "','" + cb_Uzivatel_Reklamacie.Text + "','" + cb_ID_Objednavky_Reklamacie.Text + "') ";

            sql = new SqlCommand(insert, MyConn);
            sql.ExecuteNonQuery();
            ds_Reklamacie.Tables["Reklamacia"].Clear();
            MyAdapter2.Fill(ds_Reklamacie, "Reklamacia");
            dgw_Reklamacie.DataSource = ds_Reklamacie.Tables["Reklamacia"];
        }
        private void btn_Editovat_Reklamaciu_Click(object sender, EventArgs e)
        {

            SqlConnection MyConn = new SqlConnection(pripojenie);
            MyConn.Open();
            string update = "UPDATE Reklamacia SET Datum_Podania  = '" + dtp_Reklamacia.Text + "', " +
                "Stav = '" + cb_Stav_Reklamacie.Text + "', " +
                "Predmet = '" + cb_Predmet_Reklamacie.Text + "', " +
                "Uzivatel_Username = '" + cb_Uzivatel_Reklamacie.Text + "', " +
                "Objednavka_ID_Objednavka = '" + cb_ID_Objednavky_Reklamacie.Text + "' WHERE ID_Reklamacia = '" + cb_ID_Reklamacie.Text + "'";

            sql = new SqlCommand(update, MyConn);
            sql.ExecuteNonQuery();
            ds_Reklamacie.Tables["Reklamacia"].Clear();
            MyAdapter2.Fill(ds_Reklamacie, "Reklamacia");
            dgw_Reklamacie.DataSource = ds_Reklamacie.Tables["Reklamacia"];
        }

        private void btn_Zmazat_Reklamaciu_Click(object sender, EventArgs e)
        {
            SqlConnection MyConn = new SqlConnection(pripojenie);
            MyConn.Open();
            string delete = "delete from Reklamacia where ID_Reklamacia='" + cb_ID_Reklamacie.Text + "';";
            sql = new SqlCommand(delete, MyConn);
            sql.ExecuteNonQuery();
            ds_Reklamacie.Tables["Reklamacia"].Clear();
            MyAdapter2.Fill(ds_Reklamacie, "Reklamacia");
            dgw_Reklamacie.DataSource = ds_Reklamacie.Tables["Reklamacia"];
        }

        private void dgw_Reklamacie_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgw_Reklamacie.SelectedRows.Count > 0)
            {
                dtp_Reklamacia.Text = dgw_Reklamacie.SelectedRows[0].Cells["Datum_Podania"].Value.ToString();
                cb_Stav_Reklamacie.Text = dgw_Reklamacie.SelectedRows[0].Cells["Stav"].Value.ToString();
                cb_Predmet_Reklamacie.Text = dgw_Reklamacie.SelectedRows[0].Cells["Predmet"].Value.ToString();
                cb_Uzivatel_Reklamacie.Text = dgw_Reklamacie.SelectedRows[0].Cells["Uzivatel_Username"].Value.ToString();
                cb_ID_Objednavky_Reklamacie.Text = dgw_Reklamacie.SelectedRows[0].Cells["Objednavka_ID_Objednavka"].Value.ToString();

            }
        }






















    }
}
