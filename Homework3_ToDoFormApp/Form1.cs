using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Homework3_ToDoFormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadTodos();
        }

        private Dictionary<string, CheckBox> todoCheckboxes = new Dictionary<string, CheckBox>();

        private List<string> loadedTodos = new List<string>(); // Keep track of loaded todos

        private void LoadTodos()
        {
            Dictionary<string, bool> todos = TodoManager.LoadTodosFromExcel();            

            foreach (var todo in todos)
            {
                if (!loadedTodos.Contains(todo.Key))
                {
                    CheckBox chkBox = new CheckBox();
                    string checkboxName = $"chk_{Guid.NewGuid()}"; // Generate a unique name for the checkbox
                    chkBox.Name = checkboxName;
                    chkBox.Text = todo.Key;
                    chkBox.Checked = todo.Value;
                    chkBox.CheckedChanged += (s, e) => { UpdateTodoStatus(chkBox.Text, chkBox.Checked); };

                    flowLayoutPanelTodos.Controls.Add(chkBox);

                    todoCheckboxes.Add(checkboxName, chkBox);

                    loadedTodos.Add(todo.Key); 
                }

            }

        }

        private void UpdateTodoStatus(string todoName, bool isChecked)
        {
            bool isFinished = isChecked;
            DateTime? finishingTime = isChecked ? DateTime.Now : (DateTime?)null;
            TodoManager.UpdateTodoStatusInExcel(todoName, isFinished, finishingTime);
        }

        private void btnAddToDo_Click(object sender, EventArgs e)
        {
            string todoName = txtNewToDo.Text;

            if (!loadedTodos.Contains(todoName))
            {
                CheckBox chkBox = new CheckBox();
                string checkboxName = $"chk_{Guid.NewGuid()}";
                chkBox.Name = checkboxName;
                chkBox.Text = todoName;
                chkBox.CheckedChanged += (s, ev) => { UpdateTodoStatus(chkBox.Text, chkBox.Checked); };

                flowLayoutPanelTodos.Controls.Add(chkBox);

                todoCheckboxes.Add(checkboxName, chkBox);

                loadedTodos.Add(todoName); 
            }

            // Save the todo without its finishing status
            TodoManager.AddTodoToExcel(todoName, false);

            // Clear the textbox after adding the todo
            txtNewToDo.Text = string.Empty;

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadTodos();
        }


    }
}
