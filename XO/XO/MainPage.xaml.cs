using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XO
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            #region Define Buttons
            btnUL.Clicked += BtnUL_Clicked;
            btnU.Clicked += BtnU_Clicked;
            btnUR.Clicked += BtnUR_Clicked;

            btnL.Clicked += BtnL_Clicked;
            btnC.Clicked += BtnC_Clicked;
            btnR.Clicked += BtnR_Clicked;

            btnDL.Clicked += BtnDL_Clicked;
            btnD.Clicked += BtnD_Clicked;
            btnDR.Clicked += BtnDR_Clicked;

            btnRestart.Clicked += BtnRestart_Clicked;
            btnReset.Clicked += BtnReset_Clicked;
            #endregion
        }

        private void BtnReset_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnRestart_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnDR_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnD_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnDL_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnR_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnC_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnL_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnUR_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnU_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnUL_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
