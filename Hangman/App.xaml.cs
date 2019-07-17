/*
* Copyright (c) 2017 Daniel Lascelles, https://github.com/dlascelles
* This code is licensed under The MIT License. See LICENSE file in the project root for full license information.
* License URL: https://github.com/dlascelles/Hangmania/blob/master/LICENSE
*/

using System;
using System.IO;
using System.Windows;

namespace Hangman
{
    public partial class App : Application
    {
        [STAThread]
        public static void Main()
        {
            var application = new App();
            application.InitializeComponent();
            application.Run();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            string mainPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData, Environment.SpecialFolderOption.None), "HangmaniaData");
            try
            {
                Directory.CreateDirectory(mainPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
            try
            {
                if (!File.Exists(Path.Combine(mainPath, "hangmaniadb.sqlite")))
                {
                    File.Copy(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "hangmaniadb.sqlite"), Path.Combine(mainPath, "hangmaniadb.sqlite"));
                }
                if (!File.Exists(Path.Combine(mainPath, "hangmaniadb.sqlite")))
                {
                    MessageBox.Show("Could not find application's data files", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Application.Current.Shutdown();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
        }
    }
}