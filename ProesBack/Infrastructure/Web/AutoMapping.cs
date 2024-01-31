using AutoMapper;
using ProesBack.Domain.Entities;
using ProesBack.Services;
using ProesBack.ViewModels;

namespace ProesBack.Infrastructure.Web
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<LoginViewModel, Login>();
            CreateMap<Login, LoginViewModel>();
            CreateMap<UserViewModel, User>();
            CreateMap<User, UserViewModel>();
            CreateMap<NotificationViewModel, Notification>();
            CreateMap<Notification, NotificationViewModel>();
            CreateMap<UserCourseViewModel, UserCourse>();
            CreateMap<UserCourse, UserCourseViewModel>();
            CreateMap<CourseViewModel, Course>();
            CreateMap<Course, CourseViewModel>();
            CreateMap<AssignmentViewModel, Assignment>();
            CreateMap<Assignment, AssignmentViewModel>();
        }
    }
}
