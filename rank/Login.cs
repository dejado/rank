using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rank
{
    public partial class Login : Form
    {


        public Login()
        {
            InitializeComponent();
        }
        private void txId_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
                btLogin_Click(sender, e);
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection con = new MySqlConnection("Server = localhost; Database = rank; Uid = root; Pwd = programRobot128!");
                //데이터 베이스 = 스키마명
                //DB 로그인 아이디, 비밀번호

                con.Open();

                int login_status = 0;
                string nickName = string.Empty;
                string loginID = txId.Text;
                string loginPWD = txPwd.Text;

                string selectQuery = "SELECT * FROM account_info WHERE id = \'" + loginID + "\'";

                MySqlCommand SelectCom = new MySqlCommand(selectQuery, con);

                MySqlDataReader userAccount = SelectCom.ExecuteReader();

                while (userAccount.Read())
                {
                    if (loginID == (string)userAccount["id"] && loginPWD == (string)userAccount["pwd"])
                    {
                        login_status = 1;
                        nickName = (string)userAccount["name"];
                    }
                }
                con.Close();

                if(login_status == 1)
                {
                    mainGame game = new mainGame();
                    game.NickName(nickName);
                    game.Show();
                    Hide();
                }
                else if (login_status == 0)
                    MessageBox.Show("아이디와 비밀번호가 일치하지 않습니다.", "로그인 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btSignUp_Click(object sender, EventArgs e)
        {
            SignUp singup = new SignUp();
            singup.ShowDialog();
        }
    }

}
