using System;
using System.Collections.Generic;
using System.Linq;
using keeper_server.Models;
using keeper_server.Repo;

namespace keeper_server.Service
{

    public class VaultsService
    {
        private readonly VaultsRepo _vRepo;

        public VaultsService(VaultsRepo vRepo)
        {
            _vRepo = vRepo;
        }

        public IEnumerable<Vault> GetAll()
        {
            IEnumerable<Vault> vaults = _vRepo.GetAll();
            return vaults;
        }

        internal Vault GetById(int id)
        {
            Vault data = _vRepo.GetById(id);
            if (data == null)
            {
                throw new Exception("Invalid Id");
            }
            return data;
        }

        public Vault Create(Vault newV)
        {
            newV.Id = _vRepo.Create(newV);
            return newV;
        }

        internal Vault Edit(Vault editData, string userId)
        {
            Vault original = GetById(editData.Id);
            if (original.CreatorId != userId) { throw new Exception("Access Denied: Cannot Edit a Vault You did not Create"); }
            editData.Name = editData.Name == null ? original.Name : editData.Name;
            editData.Description = editData.Description == null ? original.Description : editData.Description;

            return _vRepo.Edit(editData);
        }



        internal string Delete(int id, string userId)
        {
            Vault original = GetById(id);
            if (original.CreatorId != userId) { throw new Exception("Access Denied: Cannot Delete a Vault You did not Create"); }
            _vRepo.Remove(id);
            return "successfully deleted";
        }

        internal IEnumerable<Vault> GetVaultsByProfileId(string id)
        {
            IEnumerable<Vault> vaults = _vRepo.GetByCreatorId(id);
            return vaults.ToList().FindAll(r => r.IsPrivate != true);
        }

        internal IEnumerable<VaultKeeperViewModel> GetByProfileId(string id)
        {
            IEnumerable<VaultKeeperViewModel> vaults = _vRepo.GetVaultsByProfileId(id);
            return vaults.ToList().FindAll(v => v.IsPrivate);
        }

        internal IEnumerable<VaultKeeperViewModel> GetByAccountId(string id)
        {
            return _vRepo.GetVaultsByProfileId(id);
        }
    }
}