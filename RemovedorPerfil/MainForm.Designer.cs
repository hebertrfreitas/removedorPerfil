/*
 * Created by SharpDevelop.
 * User: V7BA
 * Date: 10/06/2015
 * Time: 09:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace RemovedorPerfil
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.CheckedListBox checkedListBoxPerfisMicro;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnMarcarTodos;
		private System.Windows.Forms.Button btnDesmarcarTodos;
		private System.Windows.Forms.Button BtnRemoverPerfis;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtBoxLog;
		private System.Windows.Forms.Label label3;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.checkedListBoxPerfisMicro = new System.Windows.Forms.CheckedListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnMarcarTodos = new System.Windows.Forms.Button();
			this.btnDesmarcarTodos = new System.Windows.Forms.Button();
			this.BtnRemoverPerfis = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.txtBoxLog = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// checkedListBoxPerfisMicro
			// 
			this.checkedListBoxPerfisMicro.CheckOnClick = true;
			this.checkedListBoxPerfisMicro.FormattingEnabled = true;
			this.checkedListBoxPerfisMicro.Location = new System.Drawing.Point(34, 43);
			this.checkedListBoxPerfisMicro.Name = "checkedListBoxPerfisMicro";
			this.checkedListBoxPerfisMicro.Size = new System.Drawing.Size(123, 274);
			this.checkedListBoxPerfisMicro.TabIndex = 0;
			this.checkedListBoxPerfisMicro.SelectedIndexChanged += new System.EventHandler(this.CheckedListBoxPerfisMicroSelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(34, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(123, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "PERFIS DO MICRO";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// btnMarcarTodos
			// 
			this.btnMarcarTodos.Location = new System.Drawing.Point(196, 44);
			this.btnMarcarTodos.Name = "btnMarcarTodos";
			this.btnMarcarTodos.Size = new System.Drawing.Size(108, 23);
			this.btnMarcarTodos.TabIndex = 2;
			this.btnMarcarTodos.Text = "Marcar todos";
			this.btnMarcarTodos.UseVisualStyleBackColor = true;
			this.btnMarcarTodos.Click += new System.EventHandler(this.BtnMarcarTodosClick);
			// 
			// btnDesmarcarTodos
			// 
			this.btnDesmarcarTodos.Location = new System.Drawing.Point(196, 74);
			this.btnDesmarcarTodos.Name = "btnDesmarcarTodos";
			this.btnDesmarcarTodos.Size = new System.Drawing.Size(108, 23);
			this.btnDesmarcarTodos.TabIndex = 3;
			this.btnDesmarcarTodos.Text = "Desmarcar todos";
			this.btnDesmarcarTodos.UseVisualStyleBackColor = true;
			this.btnDesmarcarTodos.Click += new System.EventHandler(this.BtnDesmarcarTodosClick);
			// 
			// BtnRemoverPerfis
			// 
			this.BtnRemoverPerfis.Location = new System.Drawing.Point(196, 104);
			this.BtnRemoverPerfis.Name = "BtnRemoverPerfis";
			this.BtnRemoverPerfis.Size = new System.Drawing.Size(108, 23);
			this.BtnRemoverPerfis.TabIndex = 4;
			this.BtnRemoverPerfis.Text = "Remover Perfis";
			this.BtnRemoverPerfis.UseVisualStyleBackColor = true;
			this.BtnRemoverPerfis.Click += new System.EventHandler(this.BtnRemoverPerfisClick);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(339, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(123, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "LOG DE EVENTOS";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtBoxLog
			// 
			this.txtBoxLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtBoxLog.Location = new System.Drawing.Point(339, 43);
			this.txtBoxLog.Multiline = true;
			this.txtBoxLog.Name = "txtBoxLog";
			this.txtBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtBoxLog.Size = new System.Drawing.Size(433, 274);
			this.txtBoxLog.TabIndex = 6;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(34, 346);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(280, 23);
			this.label3.TabIndex = 7;
			this.label3.Text = "Desenvolvido pelo suporte avançado do Service Desk 2";
			this.label3.Click += new System.EventHandler(this.Label3Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(843, 388);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtBoxLog);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.BtnRemoverPerfis);
			this.Controls.Add(this.btnDesmarcarTodos);
			this.Controls.Add(this.btnMarcarTodos);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.checkedListBoxPerfisMicro);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "Removedor de Perfil SA SD2";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
