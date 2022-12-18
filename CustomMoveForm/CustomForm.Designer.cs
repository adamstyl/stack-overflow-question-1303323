namespace CustomMoveForm
{
	partial class CustomForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}

			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.moveButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// moveButton
			// 
			this.moveButton.Location = new System.Drawing.Point(2, 2);
			this.moveButton.Name = "moveButton";
			this.moveButton.Size = new System.Drawing.Size(75, 23);
			this.moveButton.TabIndex = 0;
			this.moveButton.Text = "Move";
			this.moveButton.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(72, 37);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(291, 145);
			this.label1.TabIndex = 1;
			this.label1.Text = "Instructions to seafarers:\r\n- Click on Move to start moving the window (obviously" + ")\r\n- Left mouse down to park the window\r\n- Mid mouse down to cancel the operatio" + "n\r\n";
			// 
			// CustomForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(400, 250);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.moveButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "CustomForm";
			this.Text = "Custom Form";
			this.ResumeLayout(false);
		}

		private System.Windows.Forms.Label label1;

		private System.Windows.Forms.Button moveButton;

		#endregion

	}
}
