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
    public partial class SignUp : Form
    {
        int check_name;
        int check_id;
        int check_pwd;

        public SignUp()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            check_name = 0;
            check_id = 0;
            check_pwd = 0;
        }


        private void CheckName_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Server = localhost; Database = rank; Uid = root; Pwd = programRobot128!;");
            con.Open();



            string CompQuery_name = "SELECT COUNT(*) as cnt FROM account_info WHERE name = @Name";

            using (MySqlCommand com = new MySqlCommand(CompQuery_name, con))
            {
                com.Parameters.AddWithValue("@Name", textBox1.Text);

                using (MySqlDataReader CompReader_name = com.ExecuteReader())
                {
                    try
                    {
                        while (CompReader_name.Read())
                        {
                            int count = Convert.ToInt32(CompReader_name["cnt"]);

                            if (count != 0)
                                MessageBox.Show("이미 사용 중인 이름입니다.");
                            else
                            {
                                label6.Text = "사용 가능한 이름입니다!";
                                label6.ForeColor = Color.Green;
                                check_name = 1;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            con.Close();
        }

        private void CheckId_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Server = localhost; Database = rank; Uid = root; Pwd = programRobot128!;");
            con.Open();

            string CompQuery_Id = "SELECT COUNT(*) as cnt FROM account_info WHERE id = @ID";

            using (MySqlCommand com = new MySqlCommand(CompQuery_Id, con))
            {
                com.Parameters.AddWithValue("@ID", textBox2.Text);

                using (MySqlDataReader CompReader_Id = com.ExecuteReader())
                {
                    try
                    {
                        while (CompReader_Id.Read())
                        {
                            int count = Convert.ToInt32(CompReader_Id["cnt"]);

                            if (count != 0)
                                MessageBox.Show("이미 사용 중인 아이디입니다.");
                            else
                            {
                                label8.Text = "사용 가능한 아이디입니다!";
                                label8.ForeColor = Color.Green;
                                check_id = 1;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            con.Close();
        }

        private void CheckPwd_Click(object sender, EventArgs e)
        {
            //비밀번호 일치 확인
            //
            string pwd_comp1 = textBox3.Text;
            string pwd_comp2 = textBox4.Text;

            if (pwd_comp1.Equals(pwd_comp2) == true)
            {
                label7.Text = "일치합니다!";
                label7.ForeColor = Color.Green;
                check_pwd = 1;
            }
            else
            {
                label7.Text = "일치하지않습니다.\n다시 확인해주세요";
                textBox4.Focus();
            }
        }

        private void btSignUp_Click(object sender, EventArgs e)
        {
            if (check_name == 1 && check_id == 1 && check_pwd == 1)
            {
                if (checkBox1.Checked == true)
                {
                    try
                    {
                        MySqlConnection con = new MySqlConnection("Server = localhost; Database = rank; Uid = root; Pwd = programRobot128!");

                        con.Open();

                        string insertQuery = "INSERT INTO account_info (name, id, pwd) VALUES('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "');";

                        MySqlCommand com = new MySqlCommand(insertQuery, con);

                        if (com.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show(textBox1.Text + "님의 가입을 환영합니다.\r아이디 : " + textBox2.Text);

                            con.Close();

                            Close();
                        }

                        else
                        {
                            MessageBox.Show("다시 확인해주세요.");
                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("정보 제공 동의에 체크해주세요.");
                }
            }
            else if (check_name == 0)
            {
                MessageBox.Show("이름을 다시 확인하세요.");
                textBox1.Focus();
            }
            else if (check_id == 0)
            {
                MessageBox.Show("아이디를 다시 확인하세요.");
                textBox2.Focus();
            }
            else if (check_pwd == 0)
            {
                MessageBox.Show("비밀번호를 다시 확인하세요.");
                textBox4.Focus();
            }
        }
    }
}
