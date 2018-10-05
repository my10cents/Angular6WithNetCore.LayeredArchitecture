using Acme.Api.Models;
using Acme.Business.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acme.Api.AppConfig
{
    public partial class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Enrollment, EnrollmentOut>().ReverseMap();
            CreateMap<Course, CourseOut>().ReverseMap();
            CreateMap<Student, StudentOut>().ReverseMap();
            CreateMap(typeof(List<>), typeof(List<>)).ConvertUsing(typeof(ConvertList<,>));
        }

        public class ConvertList<TIn, TOut> : ITypeConverter<List<TIn>, List<TOut>>
        {
            public List<TOut> Convert(List<TIn> source, List<TOut> destination, ResolutionContext context)
            {
                return source.ConvertAll(x => context.Mapper.Map<TOut>(x));
            }
        }

    }
}
