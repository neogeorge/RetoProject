using AutoMapper;
using Newtonsoft.Json;
using System;
using Reto.Class;

namespace Reto.Models
{
    public class AutoMapperConfig
    {
        public static void Init()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<BackendFileLogProfile>();
                x.AddProfile<BackendGroupProfile>();
                x.AddProfile<BackendLogProfile>();
                x.AddProfile<BackendLoginLogProfile>();
                x.AddProfile<BackendMenuProfile>();
                x.AddProfile<BackendPermissionProfile>();
                x.AddProfile<BackendUserProfile>();
            });
        }

        #region BackendFileLogProfile
        private class BackendFileLogProfile : Profile
        {
            protected override void Configure()
            {
                base.Configure();
                #region Table: Group
                Mapper.CreateMap<DataBase.BackendFileLog, BackendFileLog>().IgnoreAllNonExisting().ReverseMap();
                #endregion
            }
        }
        #endregion

        #region BackendGroupProfile
        private class BackendGroupProfile : Profile
        {
            protected override void Configure()
            {
                base.Configure();
                #region Table: Group
                Mapper.CreateMap<DataBase.BackendGroup, BackendGroup>().IgnoreAllNonExisting().ReverseMap();
                #endregion
            }
        }
        #endregion

        #region BackendLogProfile
        private class BackendLogProfile : Profile
        {
            protected override void Configure()
            {
                base.Configure();
                #region Table: Group
                Mapper.CreateMap<DataBase.BackendLog, BackendLog>()
                    .ForMember(item => item.Status, source => source.MapFrom(db => (LogStatus)db.Status)); //db to class
                Mapper.CreateMap<BackendLog, DataBase.BackendLog>()
                    .ForMember(db => db.Status, source => source.MapFrom(item => (Byte)item.Status)); //class to db
                #endregion
            }
        }
        #endregion

        #region BackendLoginLogProfile
        private class BackendLoginLogProfile : Profile
        {
            protected override void Configure()
            {
                base.Configure();
                #region Table: BackendLoginLog
                Mapper.CreateMap<DataBase.BackendLoginLog, BackendLoginLog>() 
                    .ForMember(item => item.Status, source => source.MapFrom(db => (LoginStatus)db.Status)); //db to class
                Mapper.CreateMap<BackendLoginLog, DataBase.BackendLoginLog>()
                    .ForMember(db => db.Status, source => source.MapFrom(item => (Byte)item.Status)); //class to db
                #endregion
            }
        }
        #endregion

        #region BackendMenuProfile
        private class BackendMenuProfile : Profile
        {
            protected override void Configure()
            {
                base.Configure();
                #region Table: Group
                Mapper.CreateMap<DataBase.BackendMenu, BackendMenu>()
                    .ForMember(item => item.Status, source => source.MapFrom(db => (DefaultStatus)db.Status));
                #endregion
            }
        }
        #endregion

        #region BackendPermissionProfile
        private class BackendPermissionProfile : Profile
        {
            protected override void Configure()
            {
                base.Configure();
                #region Table: Group
                Mapper.CreateMap<DataBase.BackendPermission, BackendPermission>().IgnoreAllNonExisting().ReverseMap();
                #endregion
            }
        }
        #endregion

        #region BackendUserProfile
        private class BackendUserProfile : Profile
        {
            protected override void Configure()
            {
                base.Configure();
                #region Table: BackendUser
                Mapper.CreateMap<DataBase.BackendUser, BackendUser>()
                    .ForMember(item => item.Status, source => source.MapFrom(db => (DefaultStatus)db.Status));
                #endregion
            }
        }
        #endregion
    }
}
