using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;

namespace Tele3
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Entities.user32_dbEntities2 Context
        { get; } = new Entities.user32_dbEntities2();

        public static Entities.Tele3_Numbers CurrentUser = null;
    }
}
