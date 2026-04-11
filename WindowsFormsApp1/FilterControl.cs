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
    public partial class FilterControl : UserControl
    {
        private FilterWrap filter;
        public FilterWrap Filter
        {
            get
            {
                return filter;
            }
            set
            {
                if (value == null) return;
                filter = value;
                cf_label.Text = Filter.Cutoff.ToString("f2");
                cf_pot.Value = (Math.Log(Filter.Cutoff / 440) / Math.Log(2) / 6 + 1) / 2;
                q_label.Text = Filter.Q.ToString("f2");
                q_pot.Value = (Filter.Q + 1) / 2;
            }
        }
        public FilterControl()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            Filter.Type = (FilterWrap.FilterType)comboBox1.SelectedIndex;
        }

        private void cf_pot_ValueChanged(object sender, EventArgs e)
        {
            Filter.SetProperty("Cutoff", cf_pot.Value * 2 - 1); 
            cf_label.Text = Filter.Cutoff.ToString("f2");
        }

        private void q_pot_ValueChanged(object sender, EventArgs e)
        {
            Filter.SetProperty("Q", q_pot.Value);
            q_label.Text = Filter.Q.ToString("f2");
        }
    }
}
