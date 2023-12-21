﻿using AutoMapper;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.DataAccess.Dynamic;
using Entities.Concretes;

namespace Business.Profiles
{
    public  class AsyncLessonMappingProfile:Profile
    {


         public AsyncLessonMappingProfile() 
        {

            CreateMap<AsyncLesson, CreatedAsyncLessonResponse>().ReverseMap();
            CreateMap<AsyncLesson, CreateAsyncLessonRequest>().ReverseMap();

            CreateMap<AsyncLesson, UpdatedAsyncLessonResponse>().ReverseMap();
            CreateMap<AsyncLesson, UpdateAsyncLessonRequest>().ReverseMap();

            CreateMap<AsyncLesson, DeleteAsyncLessonRequest>().ReverseMap();
            CreateMap<AsyncLesson, DeletedAsyncLessonResponse>().ReverseMap();

            CreateMap<AsyncLesson, GetListAsyncLessonResponse>().ReverseMap();
            CreateMap<Paginate<AsyncLesson>,Paginate<GetListAsyncLessonResponse>>().ReverseMap();




        }
    }
}