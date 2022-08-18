﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Escola2
{
    /// <summary>
    /// Lógica interna para MessageBoxError.xaml
    /// </summary>
    public partial class MessageBoxError : Window
    {
        public MessageBoxError(string errorMessage, string boxName)
        {
            InitializeComponent();
            MessageBox.Show(errorMessage, boxName);
        }

    }
}
