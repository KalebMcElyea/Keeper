using System;
using keeper_server.Models;
using keeper_server.Repo;

namespace keeper_server.Service
{
    public class VaultKeepsService
    {
        private readonly VaultKeepRepo _valKeepRepo;

        public VaultKeepsService(VaultKeepRepo valKeepRepo)
        {
            _valKeepRepo = valKeepRepo;
        }

        internal VaultKeep Create(VaultKeep newVaultKeep)
        {
            VaultKeep current = _valKeepRepo.GetKeepById(newVaultKeep.KeepId);
            if (current == null)
            {
                return _valKeepRepo.Create(newVaultKeep);
            }
            else
            {
                throw new SystemException("You already made a vault like this");
            }
        }

        internal VaultKeep Delete(int id, string userInfoId)
        {
            VaultKeep current = _valKeepRepo.GetById(id);
            if (current == null)
            {
                throw new SystemException("Invalid Id... The vaultkeep doesn't exist");
            }
            if (current.CreatorId != userInfoId)
            {
                throw new SystemException("You can't delete something you didn't create");
            }
            _valKeepRepo.Delete(id);
            return current;

        }
    }
}
