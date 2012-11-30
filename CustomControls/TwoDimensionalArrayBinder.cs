using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomControls
{
    public class TwoDimensionalArrayBinder : WrapPanel
    {
        public static readonly DependencyProperty _arrayProperty;

        public object[,] Array
        {
            get { return base.GetValue(_arrayProperty) as object[,]; }
            set
            {
                base.SetValue(_arrayProperty, value);
                DrawArray(Array);
            }
        }

        private void DrawArray(object[,] array)
        {
            this.Children.Clear();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    var textbox = new TextBox();
                    textbox.Text = array[i, j].ToString();
                    this.Children.Add(textbox);
                }
            }
        }

        static TwoDimensionalArrayBinder()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TwoDimensionalArrayBinder), new FrameworkPropertyMetadata(typeof(TwoDimensionalArrayBinder)));
            _arrayProperty = DependencyProperty.Register("Array", typeof(object[,]), typeof(object[,]));
        }
    }
}