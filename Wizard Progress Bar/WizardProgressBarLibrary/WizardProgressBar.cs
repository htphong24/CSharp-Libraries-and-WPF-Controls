using System.Windows;
using System.Windows.Controls;

namespace WizardProgressBarLibrary
{
    public class WizardProgressBar : ItemsControl
    {
        #region Dependency Properties

        public static readonly DependencyProperty ProgressProperty = DependencyProperty.Register(
            "Progress",
            typeof(int),
            typeof(WizardProgressBar),
            new FrameworkPropertyMetadata(0, null, CoerceProgress)
        );

        private static object CoerceProgress(DependencyObject target, object value)
        {
            var wizardProgressBar = (WizardProgressBar) target;

            var progress = (int) value;
            if (progress < 0)
                progress = 0;
            else if (progress > wizardProgressBar.Items.Count)
                progress = wizardProgressBar.Items.Count;

            if (wizardProgressBar.Items.Count == 0)
                return 0;

            return 100 * progress / wizardProgressBar.Items.Count;
        }

        #endregion // Dependency Properties

        static WizardProgressBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WizardProgressBar), new FrameworkPropertyMetadata(typeof(WizardProgressBar)));
        }

        public WizardProgressBar()
        {
        }

        #region Properties

        public int Progress
        {
            get => (int) GetValue(ProgressProperty);
            set => SetValue(ProgressProperty, value);
        }

        #endregion // Properties
    }
}
