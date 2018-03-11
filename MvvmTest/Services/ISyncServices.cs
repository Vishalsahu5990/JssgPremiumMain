using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Models;
using PortableLibrary.Models;

namespace MvvmTest.Services
{
    public interface ISyncServices
    {
        List<LoginModel> ValidateUser(string userId,string password);
        List<CircularModel> GetCircular();
        List<BearersModel> GetBearers();
        BearersModel GetBearerDetails(string bearerId);
        List<GroupIntroModel> GetGroupIntro();
        List<MemberModel> GetMembers();
        List<TirthModel> GetjainTirth();
        List<ImportantModel> GetImpNumbers();
        List<PanchangModel> GetPanchang();
        List<ChokadiyaModel> GetChoghadiya();
        List<SliderModel> GetSliderImages();
        List<MembersDetailsModel> GetMemberDetails(string memberId);
        List<SliderModel> GetFooterSliderImages();
        List<GalleryModel> GetGallery();
        List<GalleryModel> GetGalleryDetails(string galleryId);
        List<NewsModel> GetNews();
        List<WeeklyUpdatesModel> GetWeeklyUpdates();
        List<BirthdayListModel> GetBirthdayList();
        List<AnniversaryModel> GetAnniversaryList();
        List<BloodGroupModel> GetBloodGroupList();
        List<ChangePasswordModel> ChangePassword(string oldPassword, string newPassword);
        bool SendFeedback(string subj, string sugestion);
        bool ForgotPassword(string mobileNo);
        List<NotificationModel> GetAllNotification();
    }
}
