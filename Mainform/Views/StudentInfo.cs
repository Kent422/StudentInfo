﻿using DevExpress.XtraEditors;
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

        //this the Object
        public List<Student> students = new List<Student>();
       

     
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(teFirstName.Text) ||
                string.IsNullOrWhiteSpace(teLastName.Text) ||
                string.IsNullOrWhiteSpace(teContactNumber.Text) ||
                string.IsNullOrWhiteSpace(teAddress.Text))
            {
                MessageBox.Show("Please fill out all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Student student = new Student();
            student.FirstName = teFirstName.Text;
            student.MiddleName = teMiddleName.Text;
            student.LastName = teLastName.Text;
            student.ContactNumber = teContactNumber.Text;
            student.Address = teAddress.Text;

            students.Add(student);

            //Where the data stored after adding data
            gcStudent.DataSource = students;

            //Refresh the Grid Control after clicking the add button
            gcStudent.RefreshDataSource();
            ResetField();

        }

        //This method is used to Reste the textbox after clicking the add button
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
            if (gvStudent.FocusedRowHandle >= 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to update this student?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Student student = new Student();
                    student.FirstName = teFirstName.Text;
                    student.MiddleName = teMiddleName.Text;
                    student.LastName = teLastName.Text;
                    student.ContactNumber = teContactNumber.Text;
                    student.Address = teAddress.Text;

                    students[gvStudent.FocusedRowHandle] = student; // Update the selected student
                    gcStudent.RefreshDataSource(); // Refresh the grid to apply changes
                }
            }
            else
            {
                MessageBox.Show("Please select a student to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ResetField();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (gvStudent.FocusedRowHandle >= 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this student?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    students.RemoveAt(gvStudent.FocusedRowHandle);
                    gcStudent.RefreshDataSource();
                }
            }
            else
            {
                MessageBox.Show("Please select a student to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            ResetField();
        }
    }
}