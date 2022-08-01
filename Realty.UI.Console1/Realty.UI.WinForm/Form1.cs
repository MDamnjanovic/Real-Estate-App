using Realty.Business;
using Realty.Entities;
using Realty.UI.WinForm.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Realty.UI.WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            CityBsn cityBsn = new CityBsn();
            List<CityEntities> cities = cityBsn.GetAllCities();
            cbCity.ValueMember = "Id";
            cbCity.DisplayMember = "CityName";
            cbCity.DataSource = cities;

            ResidentialAreaBsn residentialAreaBsn = new ResidentialAreaBsn();
            List<ResidentialAreaEntities> areas = residentialAreaBsn.GetAllResidentialAreas();
            cbArea.ValueMember = "Id";
            cbArea.DisplayMember = "ResidentialAreaName";
            cbArea.DataSource = areas;

            //metoda poziva prilikom load-ovanja forme? dataSource none trenutno
        }

        private void cbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResidentialAreaBsn residentialAreaBsn = new ResidentialAreaBsn();
            List<ResidentialAreaEntities> areas = residentialAreaBsn.GetAllAreasFromCity(Convert.ToInt32(cbCity.SelectedValue));
            cbArea.ValueMember = "Id";
            cbArea.DisplayMember = "ResidentialAreaName";
            cbArea.DataSource = areas;

            //refleksija
            //promena datasource,display value member prilikom selekcije postojecih podataka
        }

        private void cbArea_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            RealtyBsn realtyBsn = new RealtyBsn();            
            List<RealtyEntities> realties = realtyBsn.GetAllRealtiesFromArea(Convert.ToInt32(cbArea.SelectedValue));

                lbRealties.ValueMember = "Id";
                lbRealties.DisplayMember = "Characteristics";
                lbRealties.DataSource = realties;
        }

        private void cbArea_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void btnAddRealty_Click(object sender, EventArgs e)
        {
            AddRealtyForm addRealty = new AddRealtyForm();
            addRealty.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            RealtyEntities selectedRealty = new RealtyEntities((RealtyEntities)lbRealties.SelectedItem);
            //da li je dobra praksa ovakvo castovanje 
            
            UpdateRealtyForm updateRealty = new UpdateRealtyForm(selectedRealty);
            updateRealty.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            RealtyEntities selectedRealty = new RealtyEntities((RealtyEntities)lbRealties.SelectedItem);
            RealtyBsn realtyBsn = new RealtyBsn();


        }
    }
}
