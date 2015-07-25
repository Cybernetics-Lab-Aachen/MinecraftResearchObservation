namespace MinecraftResearchObservation
{
	partial class BaseInformation
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button buttonDestinationFolder;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.TextBox textBoxMetaInformation;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBoxMinecraftServer;
		private System.Windows.Forms.TextBox textBoxRCONPassword;
		
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.buttonDestinationFolder = new System.Windows.Forms.Button();
			this.textBoxMetaInformation = new System.Windows.Forms.TextBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxMinecraftServer = new System.Windows.Forms.TextBox();
			this.textBoxRCONPassword = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.buttonDestinationFolder, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.textBoxMetaInformation, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.buttonOK, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.label4, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.textBoxMinecraftServer, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.textBoxRCONPassword, 1, 3);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 6;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(617, 241);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(302, 60);
			this.label1.TabIndex = 0;
			this.label1.Text = "1. Please select the destination folder";
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(311, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(303, 60);
			this.label2.TabIndex = 1;
			this.label2.Text = "2. Please provide some meta information";
			// 
			// buttonDestinationFolder
			// 
			this.buttonDestinationFolder.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonDestinationFolder.Location = new System.Drawing.Point(3, 63);
			this.buttonDestinationFolder.Name = "buttonDestinationFolder";
			this.buttonDestinationFolder.Size = new System.Drawing.Size(302, 34);
			this.buttonDestinationFolder.TabIndex = 2;
			this.buttonDestinationFolder.Text = "Select destionation folder";
			this.buttonDestinationFolder.UseVisualStyleBackColor = true;
			this.buttonDestinationFolder.Click += new System.EventHandler(this.ButtonDestinationFolderClick);
			// 
			// textBoxMetaInformation
			// 
			this.textBoxMetaInformation.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxMetaInformation.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxMetaInformation.Location = new System.Drawing.Point(311, 63);
			this.textBoxMetaInformation.Name = "textBoxMetaInformation";
			this.textBoxMetaInformation.Size = new System.Drawing.Size(303, 32);
			this.textBoxMetaInformation.TabIndex = 4;
			this.textBoxMetaInformation.Text = "Experiment B, Sample 001";
			// 
			// buttonOK
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.buttonOK, 2);
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonOK.Location = new System.Drawing.Point(3, 203);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(611, 34);
			this.buttonOK.TabIndex = 3;
			this.buttonOK.Text = "5. Start the program";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.ButtonOKClick);
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(3, 100);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(302, 60);
			this.label3.TabIndex = 5;
			this.label3.Text = "3. Please provide the IP address for the Minecraft server";
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(311, 100);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(303, 60);
			this.label4.TabIndex = 6;
			this.label4.Text = "4. Please provide the Minecraft RCON server\'s password";
			// 
			// textBoxMinecraftServer
			// 
			this.textBoxMinecraftServer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxMinecraftServer.Font = new System.Drawing.Font("Arial", 15.75F);
			this.textBoxMinecraftServer.Location = new System.Drawing.Point(3, 163);
			this.textBoxMinecraftServer.Name = "textBoxMinecraftServer";
			this.textBoxMinecraftServer.Size = new System.Drawing.Size(302, 32);
			this.textBoxMinecraftServer.TabIndex = 7;
			this.textBoxMinecraftServer.Text = "127.0.0.1";
			// 
			// textBoxRCONPassword
			// 
			this.textBoxRCONPassword.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxRCONPassword.Font = new System.Drawing.Font("Arial", 15.75F);
			this.textBoxRCONPassword.Location = new System.Drawing.Point(311, 163);
			this.textBoxRCONPassword.Name = "textBoxRCONPassword";
			this.textBoxRCONPassword.PasswordChar = '*';
			this.textBoxRCONPassword.Size = new System.Drawing.Size(303, 32);
			this.textBoxRCONPassword.TabIndex = 8;
			this.textBoxRCONPassword.Text = "123456";
			// 
			// BaseInformation
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(617, 241);
			this.ControlBox = false;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BaseInformation";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "BaseInformation";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}
	}
}
