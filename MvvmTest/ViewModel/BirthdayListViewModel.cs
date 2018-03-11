using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MvvmTest.Services;
using MvvmTest.Views;
using PortableLibrary.Models;
using Xamarin.Forms;
using System.Linq;
using System.Globalization;

namespace MvvmTest.ViewModel
{
    public class BirthdayListViewModel:BaseViewModel
    {

       
        public ObservableCollection<AnniversaryModel> BirthDayList { get; set; }
        public ObservableCollection<AnniversaryModel> GroupList { get; set; }
        public ObservableCollection<BirthdayListModel> Products { get; set; }
        private string _pageTitle;
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

        public string PageTitle
        {
            get { return _pageTitle; }
            set
            {
                _pageTitle = value;
                OnPropertyChanged("PageTitle");
            }
        }

        public BirthdayListViewModel()
        {
            PageTitle = "Birthday List";
            Products = new ObservableCollection<BirthdayListModel>();
            GroupList = new ObservableCollection<AnniversaryModel>();
            ShowOrHidePoducts();
           
        }

        public void ShowOrHidePoducts()
        {
           try
            {
                List<BirthdayListModel> memberList = null;
            Task.Factory.StartNew(() =>
                                  
            {
                ISyncServices syncService = new SyncServices();
                memberList = syncService.GetBirthdayList();

            }).ContinueWith((obj) =>
            {

                    Device.BeginInvokeOnMainThread(() => 
                    {

                        if (memberList != null )
                        {
                            //var sorted = memberList.OrderByDescending(d => Convert.ToDateTime(d.merrageAnyver)).ToList();
                            //sorted.Reverse();
                            ////MvvmTest.Helpers.CommonHelpers.ShowAlert("circular success");
                            foreach (var item in memberList)
                            {
                                //var convertedTime = Convert.ToDateTime(item.merrageAnyver);
                                //var time = convertedTime.ToString("M");
                                //item.merrageAnyver = time;
                                if (!string.Equals(item.merrageAnyver, "0000-00-00"))
                                Products.Add(item);
                            }
                            CreateGroupList();
                            //CircularList = new ObservableCollection<CircularModel>(circularList);
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
                var nestedGroups = from p in Products.OrderByDescending(x => DateTime.Parse(x.merrageAnyver))
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
                            string name = listDates[j].memName.ToString();
                            string mobile = listDates[j].memMobile.ToString();
                            //finalList[i].Dates[j] = new DatesModel {Text= name.ToString()};
                            datesList.Add(new DatesModel { merrageAnyver = DateTime.Parse(date).ToString("M"), memName = name, memMobile = mobile });
                            datesList= datesList.OrderBy(d => DateTime.Parse(d.merrageAnyver).Date)
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
