using AutoMapper;
using EmployeeCrud.DAL;
using EmployeeCrud.Models;
using EmployeeCrud.Utils;
namespace EmployeeLayer.DAL
{
    public class Mapper
    {
        public static IMapper ViewMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeInsert>()
                    .ForMember(dest => dest.BranchID, opt => opt.MapFrom(src => (int)src.BranchID));

                cfg.CreateMap<Employee, EmployeeInsert>()
                    .ForMember(dest => dest.DepartmentID, opt => opt.MapFrom(src => (int)src.DepartmentID));

                cfg.CreateMap<Branch, BranchInsert>()
                    .ForMember(dest => dest.DepartmentID, opt => opt.MapFrom(src => (int)src.DepartmentID));

                cfg.CreateMap<Department, DepartmentInsert>()
                    .ForMember(dest => dest.DepartmentID, opt => opt.MapFrom(src => (int)src.DepartmentID));
            });

            var mapper = config.CreateMapper();
            return mapper;
        }
        public static IMapper InsertMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeInsert, Employee>();


                cfg.CreateMap<BranchInsert, Branch>();


                cfg.CreateMap<DepartmentInsert, Department>();
            });

            var mapper = config.CreateMapper();
            return mapper;
        }
        public static IMapper UpdateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeInsert, Employee>()
                    .ForMember(dest => dest.EmployeeID, opt => opt.MapFrom(src => src.EmployeeID));

                cfg.CreateMap<BranchInsert, Branch>()
                    .ForMember(dest => dest.BranchID, opt => opt.MapFrom(src => src.BranchID));

                cfg.CreateMap<DepartmentInsert, Department>()
                   .ForMember(dest => dest.DepartmentID, opt => opt.MapFrom(src => src.DepartmentID));
            });

            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}
