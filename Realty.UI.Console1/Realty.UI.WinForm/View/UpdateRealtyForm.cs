using Realty.Business;
using Realty.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Realty.UI.WinForm.View
{
    public partial class UpdateRealtyForm : Form
    {
        RealtyEntities realty;
        public UpdateRealtyForm(RealtyEntities selectedRealty)
        {
            InitializeComponent();
            this.realty = selectedRealty;
            MessageBox.Show(realty.ToString());
        }

    }
}
