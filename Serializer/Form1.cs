using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serializer
{
    public partial class Form1 : Form
    {
        int personNum = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowPerson(1);
            personNum++;
        }

        private void ShowPerson(int personNum)
        {
            Person person = Person.Deserialize(personNum);
            if (person!= null)
            {
                textBox1.Text = person.Name;
                textBox2.Text = person.Address;
                textBox3.Text = person.Phone;
            } else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Person Person = new Person();
            Person.Name = textBox1.Text;
            Person.Address = textBox2.Text;
            Person.Phone = textBox3.Text;
            Person.Serialize();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ShowPerson(++personNum);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (personNum > 0)
            {
                ShowPerson(--personNum);
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            ShowPerson(1);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {

        }
    }
}
