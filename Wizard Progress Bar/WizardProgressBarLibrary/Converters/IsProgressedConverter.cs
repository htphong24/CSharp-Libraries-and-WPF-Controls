using System;
using System.Windows.Data;
using System.Windows.Controls;
using System.Windows;

namespace WizardProgressBarLibrary.Converters
{
    public class IsProgressedConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((values[0] is ContentPresenter &&
                 values[1] is int
                )
                == false
            )
                return Visibility.Collapsed;

            var checkNextItem = System.Convert.ToBoolean(parameter.ToString());
            var contentPresenter = values[0] as ContentPresenter;
            var progress = (int) values[1];
            var itemsControl = ItemsControl.ItemsControlFromItemContainer(contentPresenter);
            var index = itemsControl.ItemContainerGenerator.IndexFromContainer(contentPresenter);
            
            if (checkNextItem == true)
                index++;
            
            var wizardProgressBar = itemsControl.TemplatedParent as WizardProgressBar;
            var percent = (int) (((double) index / wizardProgressBar.Items.Count) * 100);

            return percent < progress ? Visibility.Visible : Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
