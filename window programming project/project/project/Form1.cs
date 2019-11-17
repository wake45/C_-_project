using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace project
{
    public partial class Form1 : Form
    {
        NumberArray numberArray = new NumberArray(); //Number클래스를 가지고 있는 NumberArray클래스 객체 생성
        Number Num; //Number클래스 변수
        int count = 0; //저장되어 있는 연락처의 개수를 셀 변수

        public Form1()
        {
            InitializeComponent();
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e) //toolstrip메뉴의 새로만들기 버튼
        {   //리스트뷰와 텍스트 박스에 있는 모든 내용을 초기화
            NametextBox.Text = "";
            PhoneNumbertextBox.Text = "";
            BirthDaytextBox.Text = "";
            RelationtextBox.Text = "";
            EmailtextBox.Text = "";
            AddresstextBox.Text = "";
            listView1.Items.Clear();
            count = 0;
            toolStripStatusLabel.Text = "총 연락처의 개수 : " + count;
        }

        private void NewStripButton_Click(object sender, EventArgs e) //메뉴의 새로만들기 버튼
        {   //리스트뷰와 텍스트 박스에 있는 모든 내용을 초기화
            NametextBox.Text = "";
            PhoneNumbertextBox.Text = "";
            BirthDaytextBox.Text = "";
            RelationtextBox.Text = "";
            EmailtextBox.Text = "";
            AddresstextBox.Text = "";
            listView1.Items.Clear();
            count = 0;
            toolStripStatusLabel.Text = "총 연락처의 개수 : " + count;
        }

        private void OpentoolStripButton_Click(object sender, EventArgs e) //toolstrip메뉴의 새로만들이 버튼
        {
            OpenFileDialog OFD = new OpenFileDialog(); //파일오픈에 필요한 dialog객체 생성
            OFD.Filter = "텍스트 파일(*.txt)|*.txt|모든 파일(*.*)|*.*"; //볼 파일만 나오게함
            OFD.FilterIndex = 1; //필터 인덱스 설정
            OFD.RestoreDirectory = true; //이전의 선택한 디렉터리로 복원가능
            OFD.Multiselect = true; //여러대상 선택가능

            DialogResult dr = OFD.ShowDialog(); //파일오픈 dialog창 띄우기
            try
            {
                if (dr == DialogResult.OK) //파일이 선택되면
                {
                    listView1.Items.Clear(); //리스트뷰 초기화
                    FileStream f = new FileStream(OFD.FileName, FileMode.Open);   // open형식으로 파일 열기
                    BinaryFormatter bf = new BinaryFormatter();
                    numberArray = (NumberArray)bf.Deserialize(f);    //deserialize
                    for (int i = 0; i < numberArray.Count; i++) //numberArray에 들어가있는 배열 크기만큼 반복
                    {
                        ListViewItem item = new ListViewItem(numberArray[i].Name); //파일에 저장되어있는 정보를 numberArray 각각의 자리에 대입
                        item.SubItems.Add(numberArray[i].PhoneNumber);
                        item.SubItems.Add(numberArray[i].Address);
                        item.SubItems.Add(numberArray[i].Birthday);
                        item.SubItems.Add(numberArray[i].Relation);
                        item.SubItems.Add(numberArray[i].Email);
                        count++;
                        listView1.Items.Add(item); //리스트 뷰에 표시
                    }
                    f.Close();     // 파일닫기
                }
            }
            catch (SerializationException se) //연락처 저장이 안되어 있을 경우
            {
                MessageBox.Show("연락처 저장을 먼저 하세요","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            toolStripStatusLabel.Text = "총 연락처의 개수 : " + count;
        }

        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();   //파일오픈에 필요한 dialog객체 생성
            OFD.Filter = "텍스트 파일(*.txt)|*.txt|모든 파일(*.*)|*.*";   //볼 파일만 나오게함
            OFD.FilterIndex = 1; //필터 인덱스 설정
            OFD.RestoreDirectory = true; //이전의 선택한 디렉터리로 복원가능
            OFD.Multiselect = true;  //여러대상 선택가능

            DialogResult dr = OFD.ShowDialog();  //파일오픈 dialog창 띄우기
            try
            {
                if (dr == DialogResult.OK)  //파일이 선택되면
                {
                    listView1.Items.Clear(); //리스트뷰 초기화
                    FileStream f = new FileStream(OFD.FileName, FileMode.Open);   // open형식으로 파일 열기
                    BinaryFormatter bf = new BinaryFormatter();
                    numberArray = (NumberArray)bf.Deserialize(f);    //deserialize
                    for (int i = 0; i < numberArray.Count; i++) //numberArray에 들어가있는 배열 크기만큼 반복
                    {
                        ListViewItem item = new ListViewItem(numberArray[i].Name);  //파일에 저장되어있는 정보를 numberArray 각각의 자리에 대입
                        item.SubItems.Add(numberArray[i].PhoneNumber);
                        item.SubItems.Add(numberArray[i].Birthday);
                        item.SubItems.Add(numberArray[i].Relation);
                        item.SubItems.Add(numberArray[i].Email);
                        item.SubItems.Add(numberArray[i].Address);
                        count++;
                        listView1.Items.Add(item);  //리스트 뷰에 표시
                    }
                    f.Close();     // 파일닫기
                }
            }
            catch (SerializationException se) //연락처 저장이 안되어 있을 경우
            {
                MessageBox.Show("연락처 저장을 먼저 하세요", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            toolStripStatusLabel.Text = "총 연락처의 개수 : " + count;
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog SFD = new SaveFileDialog();  //파일저장 dialog 객체생성

                for (int i = 0; i < listView1.Items.Count; i++) //numberArray에 들어가있는 배열 크기만큼 반복
                {
                    Num = new Number(listView1.Items[i].SubItems[0].Text, listView1.Items[i].SubItems[1].Text, //리스트 뷰의 내용을 num변수에 저장
                                     listView1.Items[i].SubItems[2].Text, listView1.Items[i].SubItems[3].Text,
                                     listView1.Items[i].SubItems[4].Text, listView1.Items[i].SubItems[5].Text);
                    numberArray[numberArray.Count++] = Num; //numberarray배열에 인덱스를 증가시키면서 num저장
                }
                SFD.Filter = "텍스트 파일(*.txt)|*.txt|모든 파일(*.*)|*.*"; //볼 파일 필터
                SFD.FilterIndex = 1; //필터 인덱스 저장
                SFD.RestoreDirectory = true;  //이전의 선택한 디렉터리로 복원가능
                DialogResult dr = SFD.ShowDialog(); //파일저장 dialog 창 띄우기
                if (dr == DialogResult.OK) //저장 버튼 눌렀을 경우
                {
                    FileStream fs = new FileStream(SFD.FileName, FileMode.Create);  //파일저장 바이트단위 접근
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, numberArray);
                    fs.Flush();
                    fs.Close(); //파일닫기
                }
            }
            catch (NullReferenceException ne)  //연락처 추가가 안되어 있을 경우
            {
                
            }
        }

        private void SavetoolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog SFD = new SaveFileDialog();  //파일저장 dialog 객체생성

                for (int i = 0; i < listView1.Items.Count; i++) //numberArray에 들어가있는 배열 크기만큼 반복
                {
                    Num = new Number(listView1.Items[i].SubItems[0].Text, listView1.Items[i].SubItems[1].Text, //리스트 뷰의 내용을 num변수에 저장
                                     listView1.Items[i].SubItems[2].Text, listView1.Items[i].SubItems[3].Text,
                                     listView1.Items[i].SubItems[4].Text, listView1.Items[i].SubItems[5].Text);
                    numberArray[numberArray.Count++] = Num; //numberarray배열에 인덱스를 증가시키면서 num저장
                }
                SFD.Filter = "텍스트 파일(*.txt)|*.txt|모든 파일(*.*)|*.*"; //볼 파일 필터
                SFD.FilterIndex = 1; //필터 인덱스 저장
                SFD.RestoreDirectory = true;  //이전의 선택한 디렉터리로 복원가능
                DialogResult dr = SFD.ShowDialog(); //파일저장 dialog 창 띄우기
                if (dr == DialogResult.OK) //저장 버튼 눌렀을 경우
                {
                    FileStream fs = new FileStream(SFD.FileName, FileMode.Create);  //파일저장 바이트단위 접근
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, numberArray);
                    fs.Flush();
                    fs.Close(); //파일닫기
                }
            }
            catch (NullReferenceException ne)  //연락처 추가가 안되어 있을 경우
            {
               
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e) //종료버튼 실행
        {
            this.Close(); //실행 종료
        }

        private void FontToolStripMenuItem_Click(object sender, EventArgs e) //폰트 dialog사용해서 폰트 변경
        {
            FontDialog FD = new FontDialog();
            FD.ShowDialog();
            this.Font = FD.Font;
        }

        private void PrintToolStripMenuItem_Click(object sender, EventArgs e) //인쇄 dialog사용해서 인쇄
        {
            PrintDialog PD = new PrintDialog();
            PrinterSettings printer = new PrinterSettings();
            PrintDocument pd = new PrintDocument();
            PD.PrinterSettings = printer;
            PD.Document = pd;

            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

            DialogResult dr = PD.ShowDialog();
            if (dr == DialogResult.OK)
            {
                pd.Print();
            }
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {    // Print키
            string txt = "test.txt";
            Font printFont = new Font("Arial", 10, FontStyle.Regular);
            e.Graphics.DrawString(txt, printFont, Brushes.Black, 10, 10);
        }

        private void button1_Click(object sender, EventArgs e) //사진파일 불러오기
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.ShowDialog();
            pictureBox1.Image = Image.FromFile(OFD.FileName);
        }

        private void button2_Click(object sender, EventArgs e) //수정 버튼
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                ListViewItem.ListViewSubItemCollection subItem = item.SubItems; //입력된 정보로 리스트뷰 정보 수정
                subItem[0].Text = NametextBox.Text;
                subItem[1].Text = PhoneNumbertextBox.Text;
                subItem[2].Text = AddresstextBox.Text;
                subItem[3].Text = BirthDaytextBox.Text;
                subItem[4].Text = RelationtextBox.Text;
                subItem[5].Text = EmailtextBox.Text;
                MessageBox.Show("수정되었습니다!","Notice",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                NametextBox.Text = "";
                PhoneNumbertextBox.Text = "";
                BirthDaytextBox.Text = "";
                RelationtextBox.Text = "";
                EmailtextBox.Text = "";
                AddresstextBox.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e) //입력된 정보 리스트뷰에 추가
        {
            String name = NametextBox.Text;
            String phoneNumber = PhoneNumbertextBox.Text;   
            String birthDay = BirthDaytextBox.Text;
            String group = RelationtextBox.Text;
            String Email = EmailtextBox.Text;
            String homeNumber = AddresstextBox.Text;

            System.Windows.Forms.ListViewItem listViewItem = new System.Windows.Forms.ListViewItem(new String[] { name, phoneNumber, homeNumber, birthDay, group, Email });
            listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[]{
                listViewItem});
            NametextBox.Text = "";
            PhoneNumbertextBox.Text = "";
            BirthDaytextBox.Text = "";
            RelationtextBox.Text = "";
            EmailtextBox.Text = "";
            AddresstextBox.Text = "";
            count++;
            toolStripStatusLabel.Text = "총 연락처의 개수 : " + count; //연락처의 개수 증가
            MessageBox.Show("추가되었습니다!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void toolStripStatusLabel_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selItems = listView1.SelectedItems;
            foreach (ListViewItem item in selItems)
            {
                listView1.Items.Remove(item);
                count--;
                toolStripStatusLabel.Text = "총 연락처의 개수 : " + count; //연락처의 개수 감소
                MessageBox.Show("삭제되었습니다!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);  
            }  
        }

        private void button5_Click(object sender, EventArgs e) //인쇄 버튼 실행
        {
            PrintDialog PD = new PrintDialog();
            PrinterSettings printer = new PrinterSettings();
            PrintDocument pd = new PrintDocument();
            PD.PrinterSettings = printer;
            PD.Document = pd;

            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

            DialogResult dr = PD.ShowDialog();
            if (dr == DialogResult.OK)
            {
                pd.Print();
            }
        }

        private void button6_Click(object sender, EventArgs e) //정보검색 버튼실행
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
