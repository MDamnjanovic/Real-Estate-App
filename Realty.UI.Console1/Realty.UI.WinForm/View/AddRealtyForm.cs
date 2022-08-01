using Realty.Business;
using Realty.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Realty.UI.WinForm.View
{
    public partial class AddRealtyForm : Form
    {

        public AddRealtyForm()
        {
            InitializeComponent();
        }

        private void AddRealtyForm_Load(object sender, EventArgs e)
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
            cbObjectType.Items.Add("Apartment");
            cbObjectType.Items.Add("House");
            cbSaleRent.Items.Add("Sale");
            cbSaleRent.Items.Add("Rent");
            /* 1.da li napraviti metodu da inicijalizuje u cb opcije ovog tipa(od po nekoliko konstantnih vrednosti)? ako da, gde bi se nalazila metoda
             * 2. da li pisati this radi preglednosti koda
             * click button : 3.da li praviti objekat nekretnine radi provere tipova i preglednosti 
             * ili samo preuzeti vrednosti sa forme i proslediti u parametre u proceduru
             * 4.Regex regex = new Regex(); da li koristiti regex za proveru unosa npr adrese i broja
             * 5.napraviti metodu koja se poziva u btn_Click a proverava da li su uneti svi obavezni podaci i izbaci poruku, obelezi polja koja nisu..?
             * 6.gde bi se nalazila metoda, ukoliko ce se pozivati iz vise razlicitih formi (prosledi se niz vrednosti u parametre)
             * u bsn validacija
             * single object validation solid
             */


        }

        private void cbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResidentialAreaBsn residentialAreaBsn = new ResidentialAreaBsn();
            List<ResidentialAreaEntities> areas = residentialAreaBsn.GetAllAreasFromCity(Convert.ToInt32(cbCity.SelectedValue));
            cbArea.ValueMember = "Id";
            cbArea.DisplayMember = "ResidentialAreaName";
            cbArea.DataSource = areas;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            RealtyAddressBsn realtyAddressBsn = new RealtyAddressBsn();

            RealtyAddressEntities realtyAddressEntities = new RealtyAddressEntities();
            realtyAddressEntities.AddressName = tbAddressName.Text;
            realtyAddressEntities.AddressNumber = tbAddressNumber.Text;
            int residentialAreaId = realtyAddressBsn.IntTryParse(cbArea.SelectedValue.ToString());
            realtyAddressEntities.ResidentialArea.Id = residentialAreaId;
            realtyAddressEntities.UrlLinkMap = null;

            
            int realtyAddressId = realtyAddressBsn.InsertRealtyAddressAndGetId(realtyAddressEntities);

            RealtyBsn realtyBsn = new RealtyBsn();
            RealtyEntities realtyEntities = new RealtyEntities();

            realtyEntities.RealtyAddress.Id = realtyAddressId;
            short squareMeters = realtyBsn.ShortTryParse(tbSquareMeters.Text);
            decimal price = realtyBsn.DecimalTryParse(tbPrice.Text);
            realtyEntities.SquareMeters = squareMeters; 
            realtyEntities.Price = price;
            realtyEntities.ObjectType = cbObjectType.SelectedItem.ToString();
            realtyEntities.SaleOrRent = cbSaleRent.SelectedItem.ToString();
            realtyEntities.ImageFilePath = null;

            realtyBsn.InsertRealty(realtyEntities);
            //MessageBox.Show(realtyEntities.ToString());
            this.Close();
        }
    }
}
