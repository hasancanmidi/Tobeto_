﻿using AutoMapper;
using Business.Abstract;
using Business.Dtos.Requests;
using Business.DTOs.Responses;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class UserManager : IUserService
{
    IUserDal _userDal;
    IMapper _mapper;
   

    public UserManager(IUserDal userDal, IMapper mapper)
    {
        _userDal = userDal;
        _mapper = mapper;
    }

    public  async Task<DTOs.Responses.CreatedUserResponse> Add(CreateUserRequest createUserRequest)
    {

        User user = _mapper.Map<User>(createUserRequest);

        User userCreated = await _userDal.AddAsync(user);

        CreatedUserResponse createUserResponse = _mapper.Map<CreatedUserResponse>(userCreated);

        return createUserResponse;

    }



    public async Task<DeletedUserResponse> Delete(DeleteUserRequest deleteUserRequest)
    {

        User user = _mapper.Map<User>(deleteUserRequest);

        User userDeleted = await _userDal.DeleteAsync(user);
       
        DeletedUserResponse deletedUserResponse = _mapper.Map<DeletedUserResponse>(userDeleted);
        
        return deletedUserResponse;

    }


    {
        User user = _mapper.Map<User>(createUserRequest);
        User createdUser = await _userDal.AddAsync(user);
        CreatedUserResponse createdUserResponse = _mapper.Map<CreatedUserResponse>(createdUser);
        return createdUserResponse;



        var data = await _userDal.GetListAsync(include: l => l.Include(l => l.Address),
               index: pageRequest.PageIndex,
               size: pageRequest.PageSize);

        var result = _mapper.Map<Paginate<GetListUserResponse>>(data);
        return result;


    }

    public async Task<UpdatedUserResponse> Update(UpdateUserRequest updateUserRequest)
    {



        User user = _mapper.Map<User>(updateUserRequest);

        User userUpdated = await _userDal.UpdateAsync(user);

        UpdatedUserResponse updatedUserResponse = _mapper.Map<UpdatedUserResponse>(userUpdated);

        return updatedUserResponse;




    }

  

    }

        public async Task<DeletedUserResponse> Delete(DeleteUserRequest deleteUserRequest)
    {
        User user = _mapper.Map<User>(deleteUserRequest);
        User deletedUser = await _userDal.AddAsync(user);
        DeletedUserResponse deletedUserResponse = _mapper.Map<DeletedUserResponse>(deletedUser);
        return deletedUserResponse;
    }

    public async Task<IPaginate<GetListUserResponse>> GetListAsync(PageRequest pageRequest)
    {
        var data = await _userDal.GetListAsync(include: a => a.Include(a => a.Address),
              index: pageRequest.PageIndex,
              size: pageRequest.PageSize);

        var result = _mapper.Map<Paginate<GetListUserResponse>>(data);
        return result;
    }

    public async Task<UpdatedUserResponse> Update(UpdateUserRequest updateUserRequest)
    {
        User user = _mapper.Map<User>(updateUserRequest);
        User updatedUser = await _userDal.AddAsync(user);
        UpdatedUserResponse updatedUserResponse = _mapper.Map<UpdatedUserResponse>(updatedUser);
        return updatedUserResponse;
    }


}
