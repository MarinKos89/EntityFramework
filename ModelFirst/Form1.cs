using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadatak71
{
    public partial class Form1 : Form
    {
        public AdventureWorksOBPEntities entities = new AdventureWorksOBPEntities();

        public Form1()
        {
            InitializeComponent();
        }

        private void cbKomercijalist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbKomercijalist.SelectedIndex != -1)
            {
                UcitajRacune();
                ClearForm();
            }
        }
        private void UcitajRacune()
        {
            cbRacun.Items.Clear();
            Komercijalist komercijalist = (Komercijalist)cbKomercijalist.SelectedItem;
            cbRacun.Items.AddRange(komercijalist.Racun.Take(10).ToArray());
        }
        private void cbRacun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRacun.SelectedIndex != -1)
            {
                PrikaziKupca();
                PrikaziKarticu();
            }
        }
        private void PrikaziKarticu()
        {
            Racun racun = (Racun)cbRacun.SelectedItem;
            lblInfo.Text = racun.KreditnaKartica.Tip;
        }

        private void PrikaziKupca()
        {
            Racun racun = (Racun)cbRacun.SelectedItem;
            Kupac kupac = racun.Kupac;

            txtIme.Text = kupac.Ime;
            txtPrezime.Text = kupac.Prezime;
            txtEmail.Text = kupac.Email;
            txtTelefon.Text = kupac.Telefon;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Racun racun = (Racun)cbRacun.SelectedItem;
            Kupac kupac = racun.Kupac;

            kupac.Ime = txtIme.Text;
            kupac.Prezime = txtPrezime.Text;
            kupac.Email = txtEmail.Text;
            kupac.Telefon = txtTelefon.Text;
            entities.SaveChanges();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            Racun racun = (Racun)cbRacun.SelectedItem;
            ICollection<Stavka> stavka = racun.Stavka;
            entities.Stavka.RemoveRange(stavka);
            entities.Racun.Remove(racun);
            entities.SaveChanges();
            UcitajRacune();
            ClearForm();
        }

        private void ClearForm()
        {
            txtIme.Text = "";
            txtPrezime.Text = "";
            txtTelefon.Text = "";
            txtEmail.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            UcitajKomercijaliste();
        }

        private void UcitajKomercijaliste()
        {
            cbKomercijalist.Items.Clear();
            cbKomercijalist.Items.AddRange(entities.Komercijalist.ToArray());
        }
    }
}
