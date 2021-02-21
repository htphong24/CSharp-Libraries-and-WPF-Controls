using System;
using System.Windows.Data;
using System.Windows.Controls;
using System.Windows.Markup;

namespace WizardProgressBarLibrary.Converters
{
    public class IsLastItemConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var contentPresenter = value as ContentPresenter;
            var itemsControl = ItemsControl.ItemsControlFromItemContainer(contentPresenter);

            if (itemsControl is null)
                return false;

            var index = itemsControl.ItemContainerGenerator.IndexFromContainer(contentPresenter);

            return (index == (itemsControl.Items.Count - 1));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        public IsLastItemConverter()
        {
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
