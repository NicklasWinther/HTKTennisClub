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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HTKTennisClub.GUI.UserControls
{
    /// <summary>
    /// Interaction logic for MemberUserControl.xaml
    /// </summary>
    public partial class MemberUserControl : UserControl
    {
        MemberViewModel vm;
        public MemberUserControl(MemberViewModel vm)
        {
            this.vm = vm;
            InitializeComponent();
            vm.NewMember.BirthDate = DateTime.Today;
            DataContext = vm;
        }

        private void AddMemberButton_Click(object sender, RoutedEventArgs e)
        {
            vm.CreateMember();
        }

        private void MemberDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vm.SelectedMember = MemberDataGrid.SelectedItem as Member;
            EditButton.IsEnabled = true;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            new EditMemberWindow(new Member(){
                Id = vm.SelectedMember.Id,
                Firstname = vm.SelectedMember.Firstname,
                Lastname = vm.SelectedMember.Lastname,
                Address = vm.SelectedMember.Address,
                PhoneNumber = vm.SelectedMember.PhoneNumber,
                BirthDate = vm.SelectedMember.BirthDate,
                Email = vm.SelectedMember.Email,
                Active = vm.SelectedMember.Active
            }
                ).ShowDialog();
                
            vm.Members = new MemberRepository().GetAllMembers();
            EditButton.IsEnabled = false;
        }

        
    }
}
