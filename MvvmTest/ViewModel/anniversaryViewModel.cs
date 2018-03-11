using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using MvvmTest.Services;
using PortableLibrary.Models;
using Xamarin.Forms;

namespace MvvmTest.ViewModel
{
    public class anniversaryViewModel : BaseViewModel
    {
        public ObservableCollection<AnniversaryModel> MemberList { get; set; }
        public ObservableCollection<AnniversaryModel> BirthDayList { get; set; }
        public ObservableCollection<AnniversaryModel> GroupList { get; set; }

        private double _listviewHeight;
        public double ListviewHeight
        {
            get { return _listviewHeight; }
            set
            {
                _listviewHeight = value;
                OnPropertyChanged("ListviewHeight");
            }
        }

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
        public anniversaryViewModel()
        {
            PageTitle = "Anniversary List";
            MemberList = new ObservableCollection<AnniversaryModel>();
            GroupList = new ObservableCollection<AnniversaryModel>();
            ShowOrHidePoducts();
        }
        public void ShowOrHidePoducts()
        {
            try
            {
                List<AnniversaryModel> memberList = null;
                Task.Factory.StartNew(() =>
                {
                    ISyncServices syncService = new SyncServices();
                    memberList = syncService.GetAnniversaryList();

                }).ContinueWith((obj) =>
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        if (memberList != null)
                        {

                            foreach (var item in memberList)
                            {
                                if (!string.Equals(item.merrageAnyver, "0000-00-00"))
                                    MemberList.Add(item);
                            }
                            CreateGroupList();
                        }
                    });
                });

            }
            catch (Exception ex)
            {

            }
        }
        private void CreateGroupList()
        {
            List<AnniversaryModel> finalList = new List<AnniversaryModel>();
            try
            {
                var nestedGroups = from p in MemberList.OrderByDescending(x => DateTime.Parse(x.merrageAnyver))
                                   group p by DateTime.Parse(p.merrageAnyver).Month into yg
                                   select new
                                   {
                                       Year = yg.Key,
                                       Months = from o in yg
                                                group o by DateTime.Parse(o.merrageAnyver).Month into mg
                                                select new
                                                {
                                                    Month = mg.Key,
                                                    Items = mg.Select(x => x)
                                                }
                                   };

                foreach (var groupedYear in nestedGroups)
                {
                    var listMonth = groupedYear.Months.ToList();
                    for (int i = 0; i < listMonth.Count; i++)
                    {
                        var datesList = new List<DatesModel>();
                        string month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(listMonth[i].Month);
                        int _date = listMonth[i].Month;
                        //finalList[i] = new ItemModel{Text=month};

                        var listDates = listMonth[i].Items.ToList();
                        for (int j = 0; j < listDates.Count; j++)
                        {
                            string date = listDates[j].merrageAnyver.ToString();
                            string name=listDates[j].memName.ToString();
                            string mobile = listDates[j].memMobile.ToString();
                            //finalList[i].Dates[j] = new DatesModel {Text= name.ToString()};
                            datesList.Add(new DatesModel { merrageAnyver = DateTime.Parse(date).ToString("M"),memName=name,memMobile=mobile });
                            datesList = datesList.OrderBy(d => DateTime.Parse(d.merrageAnyver).Date)
                                              .Select(x => x).ToList(); 
                        }
                        finalList.Add(new AnniversaryModel { month = month,date=_date, Dates = datesList, ListHeight = datesList.Count * 60 });
                    }
                }
                if (!ReferenceEquals(finalList, null))
                {
                    var sorted = finalList.OrderBy(d => d.date)
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
