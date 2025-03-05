using DevExpress.XtraEditors;
using Mainform.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mainform.Views
{
    public partial class StudentInfo : DevExpress.XtraEditors.XtraForm
    {
        public StudentInfo()
        {
            InitializeComponent();
        }

        public List<Student> students = new List<Student>();
       

     
        private void AddBtn_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.FirstName = teFirstName.Text;
            student.MiddleName = teMiddleName.Text;
            student.LastName = teLastName.Text;
            student.ContactNumber = teContactNumber.Text;
            student.Address = teAddress.Text;

            students.Add(student);
            gcStudent.DataSource = students;
            gcStudent.RefreshDataSource();
            ResetField();

        }

       private void ResetField()
        {
            teFirstName.Text = string.Empty;
            teMiddleName.Text = string.Empty;
            teLastName.Text = string.Empty;
            teContactNumber.Text = string.Empty;
            teAddress.Text = string.Empty;
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.FirstName = teFirstName.Text;
            student.MiddleName = teMiddleName.Text;
            student.LastName = teLastName.Text;
            student.ContactNumber = teContactNumber.Text;
            student.Address = teAddress.Text;

            gcStudent.DataSource = students;
            students[gvStudent.FocusedRowHandle] = student;
            gcStudent.RefreshDataSource();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}