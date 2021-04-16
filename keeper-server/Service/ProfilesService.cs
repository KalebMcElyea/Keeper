using System;
using keeper_server.Models;
using keeper_server.Repo;

namespace keeper_server.Service
{
    public class ProfilesService
    {
        private readonly ProfilesRepo _repo;
        public ProfilesService(ProfilesRepo repo)
        {
            _repo = repo;
        }


        internal Profile GetOrCreateProfile(Profile userInfo)
        {
            Profile profile = _repo.GetById(userInfo.Id);
            if (profile == null)
            {
                return _repo.Create(userInfo);
            }
            return profile;
        }

        internal Profile GetProfileById(string id)
        {
            Profile profile = _repo.GetById(id);
            if (profile == null)
            {
                throw new Exception("Invalid Id");
            }
            return profile;
        }


    }
}