
namespace MouseXButtonDisabler
{
    partial class Form_main
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_main));
            this.button_Active = new System.Windows.Forms.Button();
            this.notifyIcon_main = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // button_Active
            // 
            this.button_Active.BackColor = System.Drawing.Color.DimGray;
            this.button_Active.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Active.ForeColor = System.Drawing.SystemColors.Control;
            this.button_Active.Location = new System.Drawing.Point(12, 13);
            this.button_Active.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Active.Name = "button_Active";
            this.button_Active.Size = new System.Drawing.Size(260, 135);
            this.button_Active.TabIndex = 0;
            this.button_Active.Text = "Active";
            this.button_Active.UseVisualStyleBackColor = false;
            this.button_Active.Click += new System.EventHandler(this.button_Active_Click);
            // 
            // notifyIcon_main
            // 
            this.notifyIcon_main.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon_main.Icon")));
            this.notifyIcon_main.Text = "X Button Disabler";
            this.notifyIcon_main.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_main_MouseDoubleClick);
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.button_Active);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form_main";
            this.Opacity = 0.9D;
            this.Text = "X Button Disabler";
            this.Resize += new System.EventHandler(this.Form_main_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Active;
        private System.Windows.Forms.NotifyIcon notifyIcon_main;
    }
}

