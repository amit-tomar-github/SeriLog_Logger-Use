using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serilog;
namespace SeriLog_Logger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GlobalVariable.SetLog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Log.Information("Message is coming from static method");
            GlobalVariable.LogObj.Information("Welcome to my logger");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalVariable.LogObj.Warning("This is warning buddy");
                Showerror();
            }
            catch (Exception ex)
            {
                GlobalVariable.LogObj.Error(ex, "Exception occured");
                GlobalVariable.LogDB.Error(ex, "Exception occured");
            }
        }
        private void Showerror()
        {
            throw new Exception("here is the excepiton");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GlobalVariable.LogObj.Information("Go to second form");
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log.CloseAndFlush();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GlobalVariable.LogDB.Information("hi this is db information");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GlobalVariable.LogFileDB.Information("hello file and db");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var ex = new Exception("Error occured");
            Log.Warning(ex + "source" + ex.Source + "--" + ex.StackTrace, "This is warning");
            Log.Warning($"Hey buddy{ex.Message}");
        }
    }
}
