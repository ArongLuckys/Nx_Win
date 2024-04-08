using NXOpen;
using NXOpen.UF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Arong_Nx;
using System;
using NXOpen;
using NXOpen.BlockStyler;

namespace Nx_Win
{
	public partial class Form1 : Form
	{
		public static string value;
		public static double[] point = new double[3];

		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Arong_Nx.Arong_Nx_Characteristic arong_Nx_Assemble = new Arong_Nx_Characteristic();
			string[] catalog = { textBox2.Text, textBox3.Text, textBox4.Text };
			arong_Nx_Assemble.Box(catalog, point);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			zdd thezdd = null;
			try
			{
				thezdd = new zdd();
				// The following method shows the dialog immediately
				thezdd.Show();
			}
			catch (Exception ex)
			{
				//---- Enter your exception handling code here -----
				MessageBox.Show("error1");
			}
			finally
			{
				if (thezdd != null)
					thezdd.Dispose();
				thezdd = null;
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			textBox1.Text = value;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			NXOpen.UI.GetUI().MenuBarManager.ApplicationSwitchRequest("UG_APP_DRAFTING");
		}
	}
}

