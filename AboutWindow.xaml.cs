﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace IPAM_NOTE
{
	/// <summary>
	/// AboutWindow.xaml 的交互逻辑
	/// </summary>
	public partial class AboutWindow : Window
	{
		public AboutWindow()
		{
			InitializeComponent();
		}

		private void AboutWindow_OnLoaded(object sender, RoutedEventArgs e)
		{
			
		}

		private void IpamNote_OnMouseDown(object sender, MouseButtonEventArgs e)
		{
			Process.Start("https://github.com/yaobus/IPAM-NOTE.git");
		}

		private void Sipam_OnMouseDown(object sender, MouseButtonEventArgs e)
		{
			Process.Start("https://github.com/yaobus/SIPAM.git");
		}
	}
}
