using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TelephoneDirectory.DAL.ORM.Context;
using TelephoneDirectory.DAL.ORM.Entity;

namespace TelephoneDirectory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ProjectContext db = new ProjectContext();
        
        public void Cleaner()
        {
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }

                if (item is MaskedTextBox)
                {
                    item.Text = "";
                }
            }

            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }

                if (item is MaskedTextBox)
                {
                    item.Text = "";
                }
            }

            foreach (Control item in groupBox3.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }

            }

            foreach (Control item in groupBox5.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        public void BringList()
            {
            dataGridView1.DataSource = db.AppUsers.Where(x => x.Status == DAL.ORM.Enum.Status.Active || x.Status == DAL.ORM.Enum.Status.Updated).ToList();
            }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AppUser user = new AppUser();

            user.FirstName = txtAddFirstName.Text;
            user.LastName = txtAddLastName.Text;
            user.PhoneNumber = maskedTextBoxAdd.Text;

            db.AppUsers.Add(user);
            db.SaveChanges();

            BringList();
            Cleaner();
        }

        int id;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUpdateFirstName.Text = dataGridView1.CurrentRow.Cells["FirstName"].Value.ToString();
            txtUpdateLastName.Text = dataGridView1.CurrentRow.Cells["LastName"].Value.ToString();
            maskedTextBoxUpdate.Text = dataGridView1.CurrentRow.Cells["PhoneNumber"].Value.ToString();
            id = int.Parse(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
            txtDeleteUser.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            AppUser user = db.AppUsers.FirstOrDefault(x => x.ID == id);

            user.FirstName = txtUpdateFirstName.Text;
            user.LastName = txtUpdateLastName.Text;
            user.PhoneNumber = maskedTextBoxUpdate.Text;

            user.Status = DAL.ORM.Enum.Status.Updated;

            db.SaveChanges();

            BringList();
            Cleaner();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            AppUser user = db.AppUsers.FirstOrDefault(x => x.ID == id);
            user.Status = DAL.ORM.Enum.Status.Deleted;

            db.SaveChanges();

            BringList();
            Cleaner();

        }

        private void btnFindPerson_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.AppUsers.Where(x => x.Status == DAL.ORM.Enum.Status.Active && x.Status == DAL.ORM.Enum.Status.Updated && x.FirstName == txtFindUser.Text).Select(y => new
            {
                y.ID,
                y.FirstName,
                y.LastName
            }).ToList();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BringList();
        }
    }
}
