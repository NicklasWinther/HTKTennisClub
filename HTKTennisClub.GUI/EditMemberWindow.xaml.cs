using HTKTennisClub.DAL;
using HTKTennisClub.Entities;
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
using System.Windows.Shapes;

namespace HTKTennisClub.GUI
{
    /// <summary>
    /// Interaction logic for EditMemberWindow.xaml
    /// </summary>
    public partial class EditMemberWindow : Window
    { Member editedMember;
        public EditMemberWindow(Member member)
        {
            editedMember = member;
            InitializeComponent();
            DataContext = editedMember;
        }

        private void UpdateMemberButton_Click(object sender, RoutedEventArgs e)
        {
            new MemberRepository().UpdateMember(editedMember);
            Close();
        }
    }
}
