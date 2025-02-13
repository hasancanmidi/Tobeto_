﻿using AutoMapper;
using Business.Abstract;
using Business.DTOs.Users;
using Business.Rules;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete;

public class UserManager : IUserService
{
    private readonly IUserDal _userDal;
    private readonly IMapper _mapper;
    private readonly UserBusinessRules _userBusinessRules;


    public UserManager(IUserDal userDal, IMapper mapper, UserBusinessRules userBusinessRules)
    {
        _userDal = userDal;
        _mapper = mapper;
        _userBusinessRules = userBusinessRules;
    }
    public async Task<DeletedUserResponse> Delete(Guid id)
    {
        User? user = await _userDal.GetAsync(u => u.Id == id);
        await _userDal.DeleteAsync(user);
        DeletedUserResponse deletedUserResponse = _mapper.Map<DeletedUserResponse>(user);
        return deletedUserResponse;
    }

    public async Task<IPaginate<GetListUserResponse>> GetListAsync(PageRequest pageRequest)
    {
        var data = await _userDal.GetListAsync(include: l => l
            .Include(l => l.Address)
            .Include(l => l.Address.City)
            .Include(l => l.Address.Country)
            .Include(l => l.Address.Town),
                     index: pageRequest.PageIndex,
                     size: pageRequest.PageSize);

        var result = _mapper.Map<Paginate<GetListUserResponse>>(data);
        return result;
    }

    public async Task<UpdatedUserResponse> Update(UpdateUserRequest updateUserRequest)
    {
        await _userBusinessRules.VerifyTCKN(updateUserRequest);
        User? user = await _userDal.GetAsync(u => u.Id == updateUserRequest.Id);
        _mapper.Map(updateUserRequest, user);

        User userUpdated = await _userDal.UpdateAsync(user);

        UpdatedUserResponse updatedUserResponse = _mapper.Map<UpdatedUserResponse>(userUpdated);

        return updatedUserResponse;
    }


    public async Task<UserAuth> Add(UserAuth userAuth)
    {
        User user = _mapper.Map<User>(userAuth);
        User userCreated = await _userDal.AddAsync(user);
        UserAuth userAuthMap = _mapper.Map<UserAuth>(userCreated);
        return userAuthMap;
    }

    public async Task<UserAuth> GetByMail(string email)
    {
        var result = await _userDal.GetAsync(u => u.Email == email);
        UserAuth userAuth = _mapper.Map<UserAuth>(result);
        return userAuth;
    }
}
