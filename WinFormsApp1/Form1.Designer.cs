
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public enum Movement
    {
        left,
        top,
        right,
        down,

    }
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1860, 943);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            Random random = new Random();
            SetInterval(() => MoveCursor(Movement.down), TimeSpan.FromSeconds(random.Next(5, 10)));
            SetInterval(() => MoveCursor(Movement.right), TimeSpan.FromSeconds(random.Next(5, 10)));
            SetInterval(() => MoveCursor(Movement.left), TimeSpan.FromSeconds(random.Next(5, 10)));
            SetInterval(() => MoveCursor(Movement.right), TimeSpan.FromSeconds(random.Next(5, 10)));
            SetInterval(() => MoveCursor(Movement.top), TimeSpan.FromSeconds(random.Next(5, 10)));
            Thread.Sleep(TimeSpan.FromMinutes(500));
        }

        public static async Task SetInterval(Action action, TimeSpan timeout)
        {
            await Task.Delay(timeout).ConfigureAwait(false);

            action();

            SetInterval(action, timeout);
        }
        public void MoveCursor(Movement move)
        {
            try
            {
                // Set the Current cursor, move the cursor's Position,
                // and set its clipping rectangle to the form. 
                Random random = new Random();
                this.Cursor = new Cursor(Cursor.Current.Handle);
                switch (move)
                {
                    case Movement.left:
                        //Cursor.Position = new Point(Cursor.Position.X - random.Next(500, 600), Cursor.Position.Y - random.Next(500, 600));
                        Cursor.Position = new Point(random.Next(3000), random.Next(1000));
                        break;
                    case Movement.top:
                        Cursor.Position = new Point(random.Next(3000), random.Next(1000));
                        break;
                        
                    case Movement.right:
                        // Cursor.Position = new Point(Cursor.Position.X + random.Next(200, 250), Cursor.Position.Y + random.Next(200, 250));
                        Cursor.Position = new Point(random.Next(3000), random.Next(1000));
                        break;
                       
                    case Movement.down:
                        //Cursor.Position = new Point(Cursor.Position.X + random.Next(500, 600), Cursor.Position.Y + random.Next(500, 600));
                        Cursor.Position = new Point(random.Next(3000), random.Next(1000));
                        break;
                     
                    default:
                        Cursor.Position = new Point(random.Next(5000), random.Next(1000));
                        break;
                    
                }

                Cursor.Clip = new Rectangle(this.Location, this.Size);

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        #endregion
    }
   
}

