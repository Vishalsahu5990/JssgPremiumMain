using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MvvmTest.Services;
using PortableLibrary.Models;
using Xamarin.Forms;

namespace MvvmTest.ViewModel
{
    public class BloodGroupViewModel:BaseViewModel
    {
        public ObservableCollection<BloodGroupModel> MemberList { get; set; }
        public ObservableCollection<BloodGroupModel> BirthDayList { get; set; }
        public ObservableCollection<BloodGroupModel> GroupList { get; set; }
        private string _pageTitle;

        public string PageTitle
        {
            get { return _pageTitle; }
            set
            {
                _pageTitle = value;
                OnPropertyChanged("PageTitle");
            }
        }
        public BloodGroupViewModel()
        {
            PageTitle = "Blood Group List";
            GroupList = new ObservableCollection<BloodGroupModel>();
            MemberList = new ObservableCollection<BloodGroupModel>();
            ShowOrHidePoducts();
        }
        public void ShowOrHidePoducts()
        {
            try
            {
                List<BloodGroupModel> memberList = null;
                Task.Factory.StartNew(() =>
                {
                    ISyncServices syncService = new SyncServices();
                    memberList = syncService.GetBloodGroupList();

                }).ContinueWith((obj) =>
                {
                    Device.BeginInvokeOnMainThread(() => 
                    {
                        if (memberList != null)
                        {
                            // var sorted = memberList.OrderBy(d => Convert.ToDateTime(d.memBG)).ToList();


                            foreach (var item in memberList)
                            {
                                if(!string.IsNullOrEmpty(item.memBG))
                                MemberList.Add(item);
                            }
                            //CircularList = new ObservableCollection<CircularModel>(circularList);
                        }  
                        CreateGroupList();
                    });

                });
            }
            catch (Exception ex)
            {

            }
        }
        private void CreateGroupList()
        {
            List<BloodGroupModel> finalList = new List<BloodGroupModel>();
            try
            {
                var nestedGroups = from p in MemberList.OrderByDescending(x => x.memBG)
                                                       group p by p.memBG into yg
                                   select new
                                   {
                                       Year = yg.Key,
                                       BloodGroups = from o in yg
                        group o by o.memBG into mg
                                                select new
                                                {
                                                    bloodGroup = mg.Key,
                                                    Items = mg.Select(x => x)
                                                }
                                   };

                foreach (var groupedYear in nestedGroups)
                {
                    var listMonth = groupedYear.BloodGroups.ToList();
                    for (int i = 0; i < listMonth.Count; i++)
                    {
                        var datesList = new List<DatesModel>();
                       
                        string _group = listMonth[i].bloodGroup;

                        //finalList[i] = new ItemModel{Text=month};

                        var listDates = listMonth[i].Items.ToList();
                        for (int j = 0; j < listDates.Count; j++)
                        {
                           
                            string name = listDates[j].memName.ToString();
                            string mobile = listDates[j].memMobile.ToString();
                            //finalList[i].Dates[j] = new DatesModel {Text= name.ToString()};
                            datesList.Add(new DatesModel { memName = name, memMobile = mobile });
                            datesList = datesList.OrderBy(d => d.memName)
                                             .Select(x => x).ToList();
                        }
                        finalList.Add(new BloodGroupModel { BloodGroup = _group, groupList = datesList, ListHeight = datesList.Count * 60 });
                    }
                }
                if (!ReferenceEquals(finalList, null))
                {
                    var sorted = finalList.OrderBy(d => d.BloodGroup)
                                          .Select(x => x).ToList();
                    foreach (var item in sorted)
                    {
                        //item.merrageAnyver = DateTime.Parse(item.merrageAnyver).ToString("M");
                        GroupList.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
