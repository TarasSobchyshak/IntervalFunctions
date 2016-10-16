using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace IntervalFunctions.App.Controls
{
    public partial class Menu : UserControl
    {
        public ObservableCollection<Models.MenuItem> MenuItems
        {
            get { return (ObservableCollection<Models.MenuItem>)GetValue(MenuItemsProperty); }
            set { SetValue(MenuItemsProperty, value); }
        }

        public static readonly DependencyProperty MenuItemsProperty = DependencyProperty
            .Register(
            nameof(MenuItems),
            typeof(ObservableCollection<Models.MenuItem>),
            typeof(Menu),
            new PropertyMetadata(
                new ObservableCollection<Models.MenuItem>(),
                new PropertyChangedCallback(OnMenuItemsChanged)
                )
            );

        private static void OnMenuItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        public Menu()
        {
            InitializeComponent();
        }
    }
}
