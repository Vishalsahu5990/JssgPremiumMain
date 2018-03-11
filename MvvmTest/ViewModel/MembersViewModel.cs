using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmTest.Services;

using PortableLibrary.Models;
using Xamarin.Forms;

namespace MvvmTest.ViewModel
{
    public class MembersViewModel:BaseViewModel
    {
        public ObservableCollection<MemberModel> MemberList { get; set; }
        public ICommand SearchCommand { get; set; }
        private string _pageTitle;
        public ObservableCollection<MemberModel> Items { get; set; }



        public ObservableCollection<MemberModel> FilterItems
        {
            get { return Items; }
            set
            {
                Items = value;
                OnPropertyChanged("Items");
            }
        }

        public string PageTitle
        {
            get { return _pageTitle; }
            set
            {
                _pageTitle = value;
                OnPropertyChanged("PageTitle");
            }
        }
        public MembersViewModel(Views.MembersPage context)
        {
            PageTitle = "Members";
            Items = new ObservableCollection<MemberModel>();
            MemberList = new ObservableCollection<MemberModel>();
            GetMembers();
            context.TextChangedCommand = new Command((val) => SearchItemOnList(val));
        }

        void SearchItemOnList(object obj)
        {
            try
            {
                var text = obj.ToString();
                if (text != null)
                    text = text.ToLower();
                FilterItems = new ObservableCollection<MemberModel>(MemberList.Where((disease) => disease.memName.ToLower().Contains(text)));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void GetMembers()
        {
            List<MemberModel> memberList = null;
            Task.Factory.StartNew(() =>
            {
                ISyncServices syncService = new SyncServices();
                memberList = syncService.GetMembers();

            }).ContinueWith((obj) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (memberList != null)
                    {
                        //MvvmTest.Helpers.CommonHelpers.ShowAlert("circular success");
                        memberList = memberList.OrderBy(x => x.memName).ToList();
                        foreach (var item in memberList)
                        {
                            if (string.IsNullOrEmpty(item.memPhoto))
                                item.memPhoto = "demo";
                            Items.Add(item);

                        }
                        MemberList = Items;
                        //CircularList = new ObservableCollection<CircularModel>(circularList);
                    }
                });
            }); 

        }
    }
}
  