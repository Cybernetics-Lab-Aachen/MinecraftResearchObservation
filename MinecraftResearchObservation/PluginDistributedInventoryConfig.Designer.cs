/*
 * Created by SharpDevelop.
 * User: TSLocal
 * Date: 25.07.2015
 * Time: 20:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MinecraftResearchObservation
{
	partial class PluginDistributedInventoryConfig
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown numericUpDownCountPlayers;
		private System.Windows.Forms.TextBox textBoxItems;
		private System.Windows.Forms.TextBox textBoxRestrictedWorldCommand;
		private System.Windows.Forms.Button buttonOK;
		
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
			this.label3 = new System.Windows.Forms.Label();
			this.numericUpDownCountPlayers = new System.Windows.Forms.NumericUpDown();
			this.textBoxItems = new System.Windows.Forms.TextBox();
			this.textBoxRestrictedWorldCommand = new System.Windows.Forms.TextBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCountPlayers)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.numericUpDownCountPlayers, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.textBoxItems, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.textBoxRestrictedWorldCommand, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.buttonOK, 1, 3);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 166F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(939, 304);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(4, 0);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(461, 40);
			this.label1.TabIndex = 0;
			this.label1.Text = "Destination count players:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(4, 40);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(461, 166);
			this.label2.TabIndex = 1;
			this.label2.Text = "Items to distribute over all player:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(4, 206);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(461, 40);
			this.label3.TabIndex = 2;
			this.label3.Text = "Restricted world command:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// numericUpDownCountPlayers
			// 
			this.numericUpDownCountPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.numericUpDownCountPlayers.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numericUpDownCountPlayers.Location = new System.Drawing.Point(472, 3);
			this.numericUpDownCountPlayers.Maximum = new decimal(new int[] {
			1000,
			0,
			0,
			0});
			this.numericUpDownCountPlayers.Minimum = new decimal(new int[] {
			2,
			0,
			0,
			0});
			this.numericUpDownCountPlayers.Name = "numericUpDownCountPlayers";
			this.numericUpDownCountPlayers.Size = new System.Drawing.Size(464, 32);
			this.numericUpDownCountPlayers.TabIndex = 3;
			this.numericUpDownCountPlayers.Value = new decimal(new int[] {
			2,
			0,
			0,
			0});
			// 
			// textBoxItems
			// 
			this.textBoxItems.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxItems.Location = new System.Drawing.Point(472, 43);
			this.textBoxItems.Multiline = true;
			this.textBoxItems.Name = "textBoxItems";
			this.textBoxItems.Size = new System.Drawing.Size(464, 160);
			this.textBoxItems.TabIndex = 4;
			this.textBoxItems.Text = "minecraft:repeater 50\r\nminecraft:redstone 50";
			// 
			// textBoxRestrictedWorldCommand
			// 
			this.textBoxRestrictedWorldCommand.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxRestrictedWorldCommand.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxRestrictedWorldCommand.Location = new System.Drawing.Point(472, 209);
			this.textBoxRestrictedWorldCommand.Name = "textBoxRestrictedWorldCommand";
			this.textBoxRestrictedWorldCommand.Size = new System.Drawing.Size(464, 32);
			this.textBoxRestrictedWorldCommand.TabIndex = 5;
			this.textBoxRestrictedWorldCommand.Text = "testforblock 134 238 240 minecraft:sandstone";
			// 
			// buttonOK
			// 
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonOK.Location = new System.Drawing.Point(472, 249);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(464, 34);
			this.buttonOK.TabIndex = 6;
			this.buttonOK.Text = "Save and close";
			this.buttonOK.UseVisualStyleBackColor = true;
			// 
			// PluginDistributedInventoryConfig
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(939, 304);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "PluginDistributedInventoryConfig";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Plugin: Distributed inventory configuration";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCountPlayers)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
