using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XO.Utilities;

namespace XO
{
    public partial class MainPage : ContentPage
    {
        public static string XName = "X";
        public static string OName = "O";
        public int OWins = 0;
        public int XWins = 0;
        public static string XO = "X";
        List<Button> btns = new List<Button>();
        private readonly IShowToast _toast;

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

            btns.Add(new Button());

            #region Top Row
            btns.Add(btnUL);
            btns.Add(btnU);
            btns.Add(btnUR);
            #endregion

            #region middle
            btns.Add(btnL);
            btns.Add(btnC);
            btns.Add(btnR);
            #endregion

            #region bottom row
            btns.Add(btnDL);
            btns.Add(btnD);
            btns.Add(btnDR);
            #endregion

            #endregion

            _toast = DependencyService.Get<IShowToast>();
        }

        #region Buttons
        private void BtnReset_Clicked(object sender, EventArgs e)
        {
            OWins = 0;
            XWins = 0;

            lblScore.Text = $"   {XWins} : {OWins}";
        }

        private void Clear()
        {
            foreach (Button btn in btns)
            {
                btn.Text = "";
            }
        }

        private void Setlblnbt()
        {
            if (XO == "X")
            {
                lblNbt.Text = XName + " نوبت";
            }
            else
            {
                lblNbt.Text = OName + " نوبت";
            }
        }

        private void BtnRestart_Clicked(object sender, EventArgs e)
        {
            XO = "X";
            Clear();
            Setlblnbt();
        }

        private bool Insert(Button btn)
        {
            if (btn.Text == null || btn.Text == "")
            {
                btn.Text = XO;
                ChangeXO();
                return true;
            }
            else
            {
                //Toast.MakeText(this, "نمیتوانید وارد کنید", ToastLength.Short).Show();
                _toast.ShowShort("نمیتوانید وارد کنید");
                return false;
            }
        }

        private void ChangeXO()
        {
            if (XO == "X")
            {
                XO = "O";
            }
            else
            {
                XO = "X";
            }
            if (lblNbt != null)
            {
                Setlblnbt();
            }
        }

        private void Winner()
        {
            ChangeXO();
            //Toast.MakeText(this, $"{XO} برنده!! ", ToastLength.Long).Show();
            _toast.ShowLong($"{XO} برنده!! ");
            Clear();

            if (XO == "X")
            {
                XWins++;
            }
            else
            {
                OWins++;
            }

            XO = "X";
            Setlblnbt();

            lblScore.Text = $"   {XWins} : {OWins}";

        }

        private bool IsFull()
        {
            foreach (Button btn in btns)
            {
                if (btn.Text == null || btn.Text == "")
                {
                    return false;
                }
            }
            return true;
        }

        private void MakeComputerMove()
        {
            int ComMove = ComputerMove();
            bool isWin = false;

            if (ComMove > 10)
            {
                ComMove = ComMove / 11;
                isWin = true;
            }

            Insert(btns[ComMove]);

            if (isWin)
            {
                Winner();
            }
            if (IsFull())
            {
                //if (MessageBox.Show("پر شد! آیا دوباره بازی میکنید؟", "توجه!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                //    XO = "X";
                //    Clear();
                //    Setlblnbt(lblnbt);
                //}

                //Toast.MakeText(this, "تمام شد!!", ToastLength.Long).Show();
                _toast.ShowLong("تمام شد!!");
            }
        }

        private int ComputerMove()
        {
            #region Check Can Win?
            for (int i = 1; i <= 9; i++)
            {
                if (btns[i].Text == null || btns[i].Text == "")
                {
                    switch (i)
                    {
                        case 1:
                            {
                                if ((btns[2].Text == btns[3].Text && btns[2].Text == XO) || (btns[5].Text == btns[9].Text && btns[5].Text == XO) || (btns[4].Text == btns[7].Text && btns[7].Text == XO))
                                {
                                    return (i * 11);
                                }

                                break;
                            }
                        case 2:
                            {
                                if ((btns[1].Text == btns[3].Text && btns[1].Text == XO) || (btns[5].Text == btns[8].Text && btns[5].Text == XO))
                                {
                                    return (i * 11);

                                }
                                break;
                            }
                        case 3:
                            {
                                if ((btns[2].Text == btns[1].Text && btns[2].Text == XO) || (btns[6].Text == btns[9].Text && btns[6].Text == XO) || (btns[5].Text == btns[7].Text && btns[7].Text == XO))
                                {
                                    return (i * 11);

                                }
                                break;
                            }
                        case 4:
                            {
                                if ((btns[1].Text == btns[7].Text && btns[1].Text == XO) || (btns[5].Text == btns[6].Text && btns[5].Text == XO))
                                {
                                    return (i * 11);

                                }
                                break;
                            }
                        case 5:
                            {
                                if ((btns[9].Text == btns[1].Text && btns[1].Text == XO) || (btns[7].Text == btns[3].Text && btns[7].Text == XO) || (btns[8].Text == btns[2].Text && btns[2].Text == XO) || (btns[4].Text == btns[6].Text && btns[6].Text == XO))
                                {
                                    return (i * 11);

                                }
                                break;
                            }
                        case 6:
                            {
                                if ((btns[9].Text == btns[3].Text && btns[3].Text == XO) || (btns[5].Text == btns[4].Text && btns[5].Text == XO))
                                {
                                    return (i * 11);

                                }
                                break;
                            }
                        case 7:
                            {
                                if ((btns[4].Text == btns[1].Text && btns[1].Text == XO) || (btns[5].Text == btns[3].Text && btns[5].Text == XO) || (btns[8].Text == btns[9].Text && btns[8].Text == XO))
                                {
                                    return (i * 11);

                                }
                                break;
                            }
                        case 8:
                            {
                                if ((btns[7].Text == btns[9].Text && btns[7].Text == XO) || (btns[5].Text == btns[2].Text && btns[5].Text == XO))
                                {
                                    return (i * 11);

                                }
                                break;
                            }
                        case 9:
                            {
                                if ((btns[6].Text == btns[3].Text && btns[6].Text == XO) || (btns[5].Text == btns[1].Text && btns[5].Text == XO) || (btns[8].Text == btns[7].Text && btns[7].Text == XO))
                                {
                                    return (i * 11);

                                }
                                break;
                            }


                    }
                }
            }
            #endregion

            #region Check Can user win and stop user
            for (int i = 1; i <= 9; i++)
            {
                if (btns[i].Text == null || btns[i].Text == "")
                {
                    ChangeXO();

                    switch (i)
                    {
                        case 1:
                            {
                                if ((btns[2].Text == btns[3].Text && btns[2].Text == XO) || (btns[5].Text == btns[9].Text && btns[5].Text == XO) || (btns[4].Text == btns[7].Text && btns[7].Text == XO))
                                {
                                    ChangeXO();

                                    return (i);
                                }

                                ChangeXO();
                                break;
                            }
                        case 2:
                            {
                                if ((btns[1].Text == btns[3].Text && btns[1].Text == XO) || (btns[5].Text == btns[8].Text && btns[5].Text == XO))
                                {
                                    ChangeXO();

                                    return (i);

                                }
                                ChangeXO();
                                break;
                            }
                        case 3:
                            {
                                if ((btns[2].Text == btns[1].Text && btns[2].Text == XO) || (btns[6].Text == btns[9].Text && btns[6].Text == XO) || (btns[5].Text == btns[7].Text && btns[7].Text == XO))
                                {
                                    ChangeXO();

                                    return (i);

                                }
                                ChangeXO();
                                break;
                            }
                        case 4:
                            {
                                if ((btns[1].Text == btns[7].Text && btns[1].Text == XO) || (btns[5].Text == btns[6].Text && btns[5].Text == XO))
                                {
                                    ChangeXO();

                                    return (i);

                                }
                                ChangeXO();
                                break;
                            }
                        case 5:
                            {
                                if ((btns[9].Text == btns[1].Text && btns[1].Text == XO) || (btns[7].Text == btns[3].Text && btns[7].Text == XO) || (btns[8].Text == btns[2].Text && btns[2].Text == XO) || (btns[4].Text == btns[6].Text && btns[6].Text == XO))
                                {
                                    ChangeXO();

                                    return (i);

                                }
                                ChangeXO();
                                break;
                            }
                        case 6:
                            {
                                if ((btns[9].Text == btns[3].Text && btns[3].Text == XO) || (btns[5].Text == btns[4].Text && btns[5].Text == XO))
                                {
                                    ChangeXO();

                                    return (i);

                                }
                                ChangeXO();
                                break;
                            }
                        case 7:
                            {
                                if ((btns[4].Text == btns[1].Text && btns[1].Text == XO) || (btns[5].Text == btns[3].Text && btns[5].Text == XO) || (btns[8].Text == btns[9].Text && btns[8].Text == XO))
                                {
                                    ChangeXO();

                                    return (i);

                                }
                                ChangeXO();
                                break;
                            }
                        case 8:
                            {
                                if ((btns[7].Text == btns[9].Text && btns[7].Text == XO) || (btns[5].Text == btns[2].Text && btns[5].Text == XO))
                                {
                                    ChangeXO();

                                    return (i);

                                }
                                ChangeXO();
                                break;
                            }
                        case 9:
                            {
                                if ((btns[6].Text == btns[3].Text && btns[6].Text == XO) || (btns[5].Text == btns[1].Text && btns[5].Text == XO) || (btns[8].Text == btns[7].Text && btns[7].Text == XO))
                                {
                                    ChangeXO();

                                    return (i);

                                }
                                ChangeXO();
                                break;
                            }
                    }
                }
            }
            #endregion

            #region center
            if (btns[5].Text == null || btns[5].Text == "")
            {
                return 5;
            }
            #endregion

            #region corners
            foreach (int j in new int[] { 3, 7, 9, 1 })
            {
                if (btns[j].Text == null || btns[j].Text == "")
                {
                    return j;
                }
            }
            #endregion

            foreach (int j in new int[] { 4, 8, 2, 6 })
            {
                if (btns[j].Text == null || btns[j].Text == "")
                {
                    return j;
                }
            }

            return 0;
        }

        #endregion

        #region Main Buttons

        private void BtnDR_Clicked(object sender, EventArgs e)
        {
            bool CanComputerMove = Insert(btnDR);

            if ((btnC.Text == btnUL.Text && btnUL.Text == btnDR.Text) || (btnR.Text == btnUR.Text && btnUR.Text == btnDR.Text) || (btnD.Text == btnDL.Text && btnDL.Text == btnDR.Text))
            {
                Winner();

            }
            if (OName == "O" && CanComputerMove)
            {
                MakeComputerMove();
            }
            if (IsFull())
            {
                //if (MessageBox.Show("پر شد! آیا دوباره بازی میکنید؟", "توجه!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                //    btnRe_Click(sender, e);
                //}
                //Toast.MakeText(this, "تمام شد!!", ToastLength.Long).Show();
                _toast.ShowLong("تمام شد!!");
            }
        }

        private void BtnD_Clicked(object sender, EventArgs e)
        {
            bool CanComputerMove = Insert(btnD);

            if ((btnC.Text == btnU.Text && btnU.Text == btnD.Text) || (btnDL.Text == btnDR.Text && btnDR.Text == btnD.Text))
            {
                Winner();

            }
            if (OName == "O" && CanComputerMove)
            {
                MakeComputerMove();
            }
            if (IsFull())
            {
                //if (MessageBox.Show("پر شد! آیا دوباره بازی میکنید؟", "توجه!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                //    btnRe_Click(sender, e);
                //}
                //Toast.MakeText(this, "تمام شد!!", ToastLength.Long).Show();

                _toast.ShowLong("تمام شد!!");

            }
        }

        private void BtnDL_Clicked(object sender, EventArgs e)
        {
            bool CanComputerMove = Insert(btnDL);

            if ((btnC.Text == btnUR.Text && btnUR.Text == btnDL.Text) || (btnL.Text == btnUL.Text && btnL.Text == btnDL.Text) || (btnD.Text == btnDR.Text && btnD.Text == btnDL.Text))
            {
                Winner();

            }
            if (OName == "O" && CanComputerMove)
            {
                MakeComputerMove();
            }
            if (IsFull())
            {
                //if (MessageBox.Show("پر شد! آیا دوباره بازی میکنید؟", "توجه!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                //    btnRe_Click(sender, e);
                //}

                //Toast.MakeText(this, "تمام شد!!", ToastLength.Long).Show();
                _toast.ShowLong("تمام شد!!");

            }
        }

        private void BtnR_Clicked(object sender, EventArgs e)
        {
            bool CanComputerMove = Insert(btnR);

            if ((btnC.Text == btnL.Text && btnR.Text == btnL.Text) || (btnUR.Text == btnDR.Text && btnUR.Text == btnR.Text))
            {
                Winner();

            }
            if (OName == "O" && CanComputerMove)
            {
                MakeComputerMove();
            }
            if (IsFull())
            {
                //if (MessageBox.Show("پر شد! آیا دوباره بازی میکنید؟", "توجه!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                //    btnRe_Click(sender, e);
                //}

                //Toast.MakeText(this, "تمام شد!!", ToastLength.Long).Show();
                _toast.ShowLong("تمام شد!!");

            }
        }

        private void BtnC_Clicked(object sender, EventArgs e)
        {
            bool CanComputerMove = Insert(btnC);

            if ((btnU.Text == btnD.Text && btnD.Text == btnC.Text) || (btnR.Text == btnL.Text && btnR.Text == btnC.Text) || (btnUL.Text == btnDR.Text && btnDR.Text == btnC.Text) || (btnUR.Text == btnDL.Text && btnDL.Text == btnC.Text))
            {
                Winner();

            }
            if (OName == "O" && CanComputerMove)
            {
                MakeComputerMove();
            }
            if (IsFull())
            {
                //if (MessageBox.Show("پر شد! آیا دوباره بازی میکنید؟", "توجه!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                //    btnRe_Click(sender, e);
                //}
                //Toast.MakeText(this, "تمام شد!!", ToastLength.Long).Show();

                _toast.ShowLong("تمام شد!!");

            }
        }

        private void BtnL_Clicked(object sender, EventArgs e)
        {
            bool CanComputerMove = Insert(btnL);

            if ((btnC.Text == btnR.Text && btnR.Text == btnL.Text) || (btnUL.Text == btnDL.Text && btnL.Text == btnDL.Text))
            {
                Winner();

            }
            if (OName == "O" && CanComputerMove)
            {
                MakeComputerMove();
            }
            if (IsFull())
            {
                //if (MessageBox.Show("پر شد! آیا دوباره بازی میکنید؟", "توجه!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                //    btnRe_Click(sender, e);
                //}
                //Toast.MakeText(this, "تمام شد!!", ToastLength.Long).Show();
                _toast.ShowLong("تمام شد!!");

            }
        }

        private void BtnUR_Clicked(object sender, EventArgs e)
        {
            bool CanComputerMove = Insert(btnUR);

            if ((btnC.Text == btnDL.Text && btnDL.Text == btnUR.Text) || (btnU.Text == btnUL.Text && btnUL.Text == btnUR.Text) || (btnR.Text == btnDR.Text && btnDR.Text == btnUR.Text))
            {
                Winner();

            }
            if (OName == "O" && CanComputerMove)
            {
                MakeComputerMove();
            }
            if (IsFull())
            {
                //if (MessageBox.Show("پر شد! آیا دوباره بازی میکنید؟", "توجه!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                //    btnRe_Click(sender, e);
                //}
                //Toast.MakeText(this, "تمام شد!!", ToastLength.Long).Show();
                _toast.ShowLong("تمام شد!!");

            }
        }

        private void BtnU_Clicked(object sender, EventArgs e)
        {
            bool CanComputerMove = Insert(btnU);

            if ((btnC.Text == btnD.Text && btnD.Text == btnU.Text) || (btnUL.Text == btnUR.Text && btnUR.Text == btnU.Text))
            {
                Winner();

            }
            if (OName == "O" && CanComputerMove)
            {
                MakeComputerMove();
            }
            if (IsFull())
            {
                //if (MessageBox.Show("پر شد! آیا دوباره بازی میکنید؟", "توجه!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                //    btnRe_Click(sender, e);
                //}
                //Toast.MakeText(this, "تمام شد!!", ToastLength.Long).Show();
                _toast.ShowLong("تمام شد!!");

            }
        }

        private void BtnUL_Clicked(object sender, EventArgs e)
        {
            bool CanComputerMove = Insert(btnUL);


            if ((btnC.Text == btnDR.Text && btnDR.Text == btnUL.Text) || (btnU.Text == btnUR.Text && btnUR.Text == btnUL.Text) || (btnL.Text == btnDL.Text && btnDL.Text == btnUL.Text))
            {
                Winner();

            }

            if (OName == "O" && CanComputerMove)
            {
                MakeComputerMove();
            }
            if (IsFull())
            {
                //if (MessageBox.Show("پر شد! آیا دوباره بازی میکنید؟", "توجه!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                //    btnRe_Click(sender, e);
                //}
                //Toast.MakeText(this, "تمام شد!!", ToastLength.Long).Show();
                _toast.ShowLong("تمام شد!!");

            }
        }
        
        #endregion
    }
}
