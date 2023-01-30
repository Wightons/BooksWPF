using Microsoft.Win32;
using System;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BooksWPF.Controls
{



    public partial class ImagePicker : UserControl
    {
        public double Width
        {
            get { return (double)GetValue(WidthProperty); }
            set { SetValue(WidthProperty, value); }
        }

        public static readonly DependencyProperty WidthProperty =
            DependencyProperty.Register("Width", typeof(double), typeof(ImagePicker), new PropertyMetadata(140.0));




        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(ImagePicker), new PropertyMetadata(string.Empty));

        




        public static readonly RoutedEvent SelectedEvent = EventManager.RegisterRoutedEvent(nameof(Selected),
                                                                                         RoutingStrategy.Bubble,
                                                                                         typeof(RoutedEventHandler),
                                                                                         typeof(ImagePicker));
        public event RoutedEventHandler Selected
        {
            add { AddHandler(SelectedEvent, value); }
            remove { RemoveHandler(SelectedEvent, value); }
        }

        public ImagePicker()
        {
            InitializeComponent();
        }

        private void OnSelect(object sender, RoutedEventArgs e)
        {
            switch (Operation.SelectedValue)
            {
                case "Choose File":
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Files|*.jpg;*.jpeg;*.png";
                    if (openFileDialog.ShowDialog() == true)
                    {
                        Text = openFileDialog.FileName;
                    }
                    break;
                case "From URL":
                    Text = String.Empty;
                    break;
                default:
                    break;
            }
        }
    }
}
