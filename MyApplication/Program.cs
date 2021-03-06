﻿using System.Linq;

namespace MyApplication
{
	internal static class Program
	{
		static Program()
		{
		}

		[System.STAThread]
		internal static void Main()
		{
			// **************************************************
			System.Windows.Forms.Application.EnableVisualStyles();
			System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new LoginForm());
            // **************************************************
            // **************************************************
            // **************************************************
            // **************************************************
            Models.DatabaseContext databaseContext = null;

			try
			{
				databaseContext =
					new Models.DatabaseContext();

                // **************************************************
                // **************************************************

                // **************************************************
                //var users =
                //	databaseContext.Users
                //	.ToList()
                //	;

                //int userCount = users.Count;
                // **************************************************

                // **************************************************
                //int userCount =
                //    databaseContext.Users
                //    .Count();
                // **************************************************

                // **************************************************
                bool hasAnyUser =
					databaseContext.Users
					.Any();
				// **************************************************

				if (hasAnyUser == false)
				{
					Models.User adminUser = new Models.User
					{
						IsAdmin = true,
						IsActive = true,

						Username = "Dariush",
						Password = "1234512345",
						FullName = "Mr. Dariush Tasdighi"
					};

					databaseContext.Users.Add(adminUser);

					databaseContext.SaveChanges();
				}
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);

				return;
			}
			finally
			{
				if (databaseContext != null)
				{
					databaseContext.Dispose();
					databaseContext = null;
				}
			}
            // **************************************************
            // **************************************************
            // **************************************************

            // **************************************************
            //         System.Windows.Forms.Application.Run(new LoginForm());

            //         #region Runing Startup Form and then Disposing!
            //         LoginForm startupForm = new LoginForm();

            //System.Windows.Forms.Application.Run(startupForm);

            //if (startupForm != null)
            //{
            //	if (startupForm.IsDisposed == false)
            //	{
            //		startupForm.Dispose();
            //	}

            //	startupForm = null;
            //}
            //#endregion /Runing Startup Form and then Disposing!
            // **************************************************
            #region Solotion(2)
            System.Windows.Forms.Application.Run(Infrastructure.Utility.LoginForm);
            System.Windows.Forms.Application.Run(Infrastructure.Utility.RegisterForm);
            #endregion Solotion(2)

        }
    }
}
