namespace Homework3_ToDoFormApp
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnAddToDo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNewToDo = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanelTodos = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(1, -2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(627, 362);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnAddToDo);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtNewToDo);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(619, 333);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Add ToDo";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnAddToDo
            // 
            this.btnAddToDo.Location = new System.Drawing.Point(82, 237);
            this.btnAddToDo.Name = "btnAddToDo";
            this.btnAddToDo.Size = new System.Drawing.Size(392, 30);
            this.btnAddToDo.TabIndex = 2;
            this.btnAddToDo.Text = "Add";
            this.btnAddToDo.UseVisualStyleBackColor = true;
            this.btnAddToDo.Click += new System.EventHandler(this.btnAddToDo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(237, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "New ToDo";
            // 
            // txtNewToDo
            // 
            this.txtNewToDo.Location = new System.Drawing.Point(82, 95);
            this.txtNewToDo.Name = "txtNewToDo";
            this.txtNewToDo.Size = new System.Drawing.Size(392, 121);
            this.txtNewToDo.TabIndex = 0;
            this.txtNewToDo.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.flowLayoutPanelTodos);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(619, 333);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ToDos";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(619, 333);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Finished ToDos";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelTodos
            // 
            this.flowLayoutPanelTodos.AutoScroll = true;
            this.flowLayoutPanelTodos.Location = new System.Drawing.Point(59, 42);
            this.flowLayoutPanelTodos.Name = "flowLayoutPanelTodos";
            this.flowLayoutPanelTodos.Size = new System.Drawing.Size(511, 283);
            this.flowLayoutPanelTodos.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 360);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnAddToDo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtNewToDo;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTodos;
    }
}

