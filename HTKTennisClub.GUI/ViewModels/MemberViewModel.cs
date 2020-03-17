using HTKTennisClub.DAL;
using HTKTennisClub.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTKTennisClub.GUI.ViewModels
{
    public class MemberViewModel : INotifyPropertyChanged
    {
        private List<Member> members = new List<Member>();
        private Member newMember = new Member();
        private Member selectedMember;

        public Member NewMember
        {
            get { return newMember; }
            set
            {
                newMember = value;
                OnPropertyChanged(nameof(NewMember));
            }
        }

        public List<Member> Members
        {
            get
            {
                return new MemberRepository().GetAllMembers();
            }
            set
            {
                members = value;
                OnPropertyChanged(nameof(Members));
            }
        }

        public Member SelectedMember
        {
            get { return selectedMember; }
            set { selectedMember = value; }
        }

        public void CreateMember()
        {
            new MemberRepository().CreateMember(NewMember);
            newMember = new Member();
            OnPropertyChanged(nameof(Members));
            OnPropertyChanged(nameof(newMember));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
