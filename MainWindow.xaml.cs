﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;
using System.Threading.Tasks;
namespace DemoHttpClient_Slot1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    readonly HttpClient client = new HttpClient();
    private void btnClear_Click(object sender, RoutedEventArgs e)
    {
        txtContent.Text= string.Empty;
    }


    private void btnClose_Click(object sender, RoutedEventArgs e) => Close();

    private async void btnViewHTML_Click(object sender, RoutedEventArgs e)
    {
        string uri = txtURL.Text;
        try
        {
            string respondBody = await client.GetStringAsync(uri);
            txtContent.Text = respondBody.Trim();
        }
        catch (HttpRequestException ex)
        {
            MessageBox.Show($"Message : {ex.Message}");
        }

    }
}
