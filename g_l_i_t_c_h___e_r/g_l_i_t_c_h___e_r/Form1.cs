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
namespace g_l_i_t_c_h___e_r
{
    
    public partial class Form1 : Form
    {

        string choosenFile;
        public Form1()
        {
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(w_e_l_c_o_m_eH_u_man));
            t.Start();
            System.Threading.Thread.Sleep(2000);
            InitializeComponent();
            t.Abort();
            
        }

        public void w_e_l_c_o_m_eH_u_man()
        {
            Application.Run(new Ethereal_Splash());
        }

        byte[] _globalEther;
        string globalDir;

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pb_bg.Size = Size;
            pb_bg.Location = new Point(-1, -1);
            pb_bg.SendToBack();
            CenterToScreen();
            Activate();
            button3.Visible = false;
            button2.Visible = false;

            ToolStripMenuItem s = new ToolStripMenuItem(
                "ＳＥＩＶ　ＩＭＡＴＪＥ　ークボ .  .  .",
                null,//VIL BE ADDED L8R
                new EventHandler(SubmenuItem_Click));

            contextMenuStrip1.Items.Add(s);
   }
        private void SubmenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("S A V E I N G K . . _--->->___");
            SaveFileDialog _sfd = new SaveFileDialog();

            _sfd.Filter = "Ｂｅｌｏｖｅｄ　ｅｔｈｅｒ　な猿ポ | *.jpg";


            if (_sfd.ShowDialog()==DialogResult.OK)
            {
                var fs = new FileStream(_sfd.FileName, FileMode.Create, FileAccess.Write);

                fs.Write(_globalEther, 0, _globalEther.Length); //append dat shit and create the image
                fs.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
                pictureBox1.Image.Dispose();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                choosenFile = openFileDialog1.FileName;
                export();
            }
            /*
                /DialogResult _dg = MessageBox.Show(
                "Ａｌｓｏ　ａｐｐｅｎｄ　ｔｏ　ｔｅｘｔｂｏｘ？　ス現ぅ加",
                "",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

                if (_dg == DialogResult.Yes)
                {
                    richTextBox1.Visible = true;
                    using (var file = File.Open(openFileDialog1.FileName, FileMode.Open))
                    {
                        int b;
                        int countBytes = 0;
                        int countLines = 0;
                        StringBuilder builtString = new StringBuilder();
                        while ((b = file.ReadByte()) >= 0)
                        {
                            countLines++;
                            label1.SuspendLayout();
                            label1.Text = "Lines:" + countLines;
                            label1.ResumeLayout();

                            string s = b.ToString("X");
                            if (s.Length < 2)
                                s = "0" + s;
                            builtString.Append(s + " ");
                            countBytes++;
                            if (countBytes == 15)
                            {
                                builtString.AppendLine();
                                countBytes = 0;
                            }


                        }
                        richTextBox1.SelectionStart = richTextBox1.TextLength;
                        richTextBox1.SelectedText = builtString.ToString();
                        file.Close();

                    }
                } else
                {
                    label1.Visible = false;
                    richTextBox1.Visible = true;
                }
                // richTextBox1.Text = String.Join("", Array.ConvertAll(x, byteValue => byteValue.ToString()));

                label2.Text = "Finished...";
                button2.Visible = true;
                */
        }
        private void export()
        {
            DirectoryInfo info = Directory.GetParent(choosenFile);
            string parent = info.ToString() + @"\exported_1.bmp";
            globalDir = parent;
            ByteArrayToFile(parent);
        }
        
        private void ByteArrayToFile(string fileName)
        {
            string strPath = Path.GetFullPath(choosenFile);
            BinaryReader binReader = new BinaryReader(File.Open(strPath, FileMode.Open));

            long lfileLength = binReader.BaseStream.Length; // init the buffer
            byte[] btFile = new byte[lfileLength]; //create the damn array

            for (long lIdx = 0; lIdx < lfileLength; lIdx++)
            {
                btFile[lIdx] = binReader.ReadByte();
                
            }
            binReader.Close();
            try
            {
               
                btFile = ImageBend(btFile);
                _globalEther = btFile;
                var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                
                fs.Write(btFile, 0, btFile.Length); //append dat shit and create the image
                fs.Close();

                pictureBox1.Image = Image.FromFile(fileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                button3.Visible = true;
                button2.Visible = true;
                pictureBox1.Visible = true;
            }
            catch{}
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private byte[] ImageBend(byte[] bytemap)
        {
            byte[] _newBytemap = bytemap;
            Random _rnd = new Random();
            int grab_min, grab_max;
            grab_min = Convert.ToInt32(_newBytemap.Length / 2000);
            grab_max = Convert.ToInt32(_newBytemap.Length / 500);

            for (int i = 0; i < 10; i++)
            {
                int grab;
                int grab_index;
                grab_index = _rnd.Next(820, bytemap.Length - grab_max);
                grab = _rnd.Next(_rnd.Next(1, grab_min), _rnd.Next(grab_min + 1, grab_max));
                List<byte> _tmp = new List<byte>();
                for (int j = grab_index; j < grab_index + grab - 1; j++)
                    _tmp.Add(bytemap[j]);

                int insert;
                do
                {
                    insert = _rnd.Next(820, bytemap.Length - grab_max);
                } while (insert == grab_index);

                for (int k = insert; k < insert + grab - 1; k++)
                {
                    _newBytemap[k] = _tmp[0];
                    _tmp.RemoveAt(0);
                }
            }
            return _newBytemap;
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            if (pictureBox1.Image != null)
                pictureBox1.Image.Dispose();

            ByteArrayToFile(globalDir);
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
                pictureBox1.Image.Dispose();
            pictureBox1.Image = null;
            globalDir = "";
            button3.Visible = false;
            pictureBox1.Visible = false;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position);
            }
        }
    }
}
