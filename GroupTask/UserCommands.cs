using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace GroupTask
{
    public static class UserCommands
    {
        static UserCommands()
        {
            SaveCommand = new RoutedUICommand("Some", "SaveCommand", typeof(UserCommands));
            LoadCommand = new RoutedUICommand("Some", "LoadCommand", typeof(UserCommands));
        }

        public static RoutedCommand SaveCommand { get; private set; }
        public static RoutedCommand LoadCommand { get; private set; }
    }
}
