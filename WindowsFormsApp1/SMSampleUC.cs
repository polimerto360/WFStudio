using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFStudio
{
    public partial class SMSampleUC : UserControl
    {
        public SampleMapper mapper;
        public int NoteSt;
        public SMSampleUC(SampleMapper m, int noteSt)
        {
            InitializeComponent();
            mapper = m;
            NoteSt = noteSt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mapper.samplebuffer.Remove(NoteSt);
            Parent.Controls.Remove(this);
        }
    }
}
