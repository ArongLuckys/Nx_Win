using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NXOpen;
using NXOpen.BlockStyler;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using NXOpen.UF;
using NXOpen.CAE;

namespace Nx_Win
{
	public class Program
	{
		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		public static extern bool ShowWindow(HandleRef hWnd, int nCmdShow);

		
		private static Session theSession;
		private static UI theUI;
		private static UFSession theUfSession;
		public static Program theProgram;
		public static bool isDisposeCalled;

		public Program()
		{
			try
			{
				if (form == null)
				{
					//MessageBox.Show("null");
				}
				else
				{
					form.Dispose();
					form = null;
				}

				Application.EnableVisualStyles();
				//Application.SetCompatibleTextRenderingDefault(true);

				theSession = Session.GetSession();
				theUI = UI.GetUI();
				theUfSession = UFSession.GetUFSession();
				isDisposeCalled = false;
				
			}
			catch (NXOpen.NXException ex)
			{
				// ---- Enter your exception handling code here -----
				// UI.GetUI().NXMessageBox.Show("Message", NXMessageBox.DialogType.Error, ex.Message);
			}
		}

		public void Dispose()
		{
			try
			{
				if (isDisposeCalled == false)
				{
					//TODO: Add your application code here 
				}
				isDisposeCalled = true;
			}
			catch (NXOpen.NXException ex)
			{
				// ---- Enter your exception handling code here -----
			}
		}
		public static Form1 form;

		public static void Main()
		{
			try
			{
				theProgram = new Program();

				form = new Form1();
				ShowWindow(new HandleRef(null, form.Handle),4);
				theProgram.Dispose();
			}
			catch (Exception ex)
			{
				theUI.NXMessageBox.Show("Block Styler", NXMessageBox.DialogType.Error, ex.ToString());
			}
			finally
			{
				//form.Dispose();
			}
		}

		public static int GetUnloadOption(string arg)
		{
			 return System.Convert.ToInt32(Session.LibraryUnloadOption.Explicitly);
			// return System.Convert.ToInt32(Session.LibraryUnloadOption.Immediately);
			// return System.Convert.ToInt32(Session.LibraryUnloadOption.AtTermination);
		}
	}
}
