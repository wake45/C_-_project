using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace project
{
    public partial class Form2 : Form
    {

        NumberArray numberArray = new NumberArray();

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //찾는 방법을 이름 전화번호 둘중에 골라 정보를 텍스트 박스에 입력하고 전화번호부 파일을 열어 원하는 정보를 메세지 박스로 출력받음
        {
            string temp = textBox1.Text;
            int runOK = 0;

            MessageBox.Show("찾으시려는 연락처 정보가 있는 파일을 열어주세요","Notice",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            if (radioButton1.Checked) //이름으로 찾을경우
            {
                OpenFileDialog OFD = new OpenFileDialog();  //파일 열기 form1의 파일열기와 기능은 같음
                OFD.Filter = "텍스트 파일(*.txt)|*.txt|모든 파일(*.*)|*.*";
                OFD.FilterIndex = 1;
                OFD.RestoreDirectory = true;
                OFD.Multiselect = true;

                DialogResult dr = OFD.ShowDialog();
                try
                {
                    if (dr == DialogResult.OK)
                    {
                        
                        FileStream f = new FileStream(OFD.FileName, FileMode.Open);   // open형식으로 파일 열기
                        BinaryFormatter bf = new BinaryFormatter();
                        numberArray = (NumberArray)bf.Deserialize(f);    //deserialize
                        for (int i = 0; i < numberArray.Count; i++)
                        {
                            if(numberArray[i].Name == temp) //텍스트 박스 내용과 비교하여 맞으면 그 인덱스의 정보 모두 출력
                            {
                                MessageBox.Show("이름 : " + numberArray[i].Name + "\n핸드폰 번호 : " + numberArray[i].PhoneNumber +
                                    "\n주소 : " + numberArray[i].Address + "\n생일 : " + numberArray[i].Birthday + "\n관계 : " + numberArray[i].Relation
                                    + "\nE-mail : " + numberArray[i].Email,"Infomation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                runOK = 999;
                                break;
                            }
                        }

                        if(runOK != 999) //위의 if문이 실행 되지 않았을 경우 실행
                        {
                            MessageBox.Show("연락처를 찾지 못 하였습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        f.Close();     // 파일닫기
                    }
                }
                catch (SerializationException se)
                {
                    MessageBox.Show("연락처 저장을 먼저 하세요");
                }
            }
            else //전화번호로 찾을경우
            {
                OpenFileDialog OFD = new OpenFileDialog();
                OFD.Filter = "텍스트 파일(*.txt)|*.txt|모든 파일(*.*)|*.*";
                OFD.FilterIndex = 1;
                OFD.RestoreDirectory = true;
                OFD.Multiselect = true;

                DialogResult dr = OFD.ShowDialog();
                try
                {
                    if (dr == DialogResult.OK)
                    {

                        FileStream f = new FileStream(OFD.FileName, FileMode.Open);   // open형식으로 파일 열기
                        BinaryFormatter bf = new BinaryFormatter();
                        numberArray = (NumberArray)bf.Deserialize(f);    //deserialize
                        for (int i = 0; i < numberArray.Count; i++)
                        {
                            if (numberArray[i].PhoneNumber == temp)
                            {
                                MessageBox.Show("이름 : " + numberArray[i].Name + " 핸드폰 번호 : " + numberArray[i].PhoneNumber +
                                    " 주소 : " + numberArray[i].Address + " 생일 : " + numberArray[i].Birthday + " 관계 : " + numberArray[i].Relation
                                    + " E-mail : " + numberArray[i].Email,"Infomation",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                                runOK = 999;
                                break;
                            }
                        }

                        if (runOK != 999) //위의 if문이 실행 되지 않았을 경우 실행
                        {
                            MessageBox.Show("연락처를 찾지 못 하였습니다.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                        f.Close();     // 파일닫기
                    }
                }
                catch (SerializationException se)
                {
                    MessageBox.Show("연락처 저장을 먼저 하세요", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
