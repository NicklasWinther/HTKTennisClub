using HTKTennisClub.GUI.UserControls;
using HTKTennisClub.GUI.ViewModels;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HTKTennisClub.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MemberViewModel memberViewModel { get; set; } = new MemberViewModel();
        public MainWindow()
        {
            InitializeComponent();
            detailsUserControl.Content = new MemberUserControl(memberViewModel);
        }


        private void MemberTab_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!(detailsUserControl.Content is MemberUserControl))
            {
                detailsUserControl.Content = new MemberUserControl(memberViewModel);

            }
        }

        private void FieldTab_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!(detailsUserControl.Content is FieldUserControl))
            {
                detailsUserControl.Content = new FieldUserControl();

            }
        }
    }
}
