﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dersis
{
    public partial class AcilanDersler : Form
    {
        public AcilanDersler()
        {
            InitializeComponent();
        }

        NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Username=postgres;password=1234;database=dersis");
        private void btnDersKayitlariGeri_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Hide();
        }

        private void AcilanDersler_Load(object sender, EventArgs e)
        {
            string query = "SELECT d.DersKodu, d.DersAdi, dn.DonemAdi " +
                "FROM Dersler d " +
                "INNER JOIN Donemler dn ON d.DonemID = dn.DonemID";

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            dgwAcilanDersler.DataSource = dt;
        }
    }
}
