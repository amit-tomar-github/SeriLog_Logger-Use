using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Serilog;

namespace SeriLog_Logger
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Log.Warning("Again message form form 2 and new method");
            GlobalVariable.LogObj.Information("I am from Form 2 buddy");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<User> list = new List<User> {
                new User{ id=2,name="AMit"},
                new User{ id=2,name="AMit"},
                new User{ id=2,name="AMit"},
                new User{ id=2,name="AMit"},
                new User{ id=2,name="AMit"},
                new User{ id=2,name="AMit"},
                new User{ id=2,name="AMit"},
            };

            var jsonValue = JsonConvert.SerializeObject(list);
            GlobalVariable.LogObj.Information(jsonValue);
        }
    }
}
