using System;
using System.Collections.Generic;
using System.Linq;
using keeper_server.Models;
using keeper_server.Repo;

namespace keeper_server.Service
{
    public class KeepsService
    {
        private readonly KeepsRepo _kRepo;

        public KeepsService(KeepsRepo kRepo)
        {
            _kRepo = kRepo;
        }

        public IEnumerable<Keep> GetAll()
        {
            IEnumerable<Keep> keeps = _kRepo.GetAll();
            return keeps;
        }

        internal Keep GetById(int id)
        {
            Keep keeps = _kRepo.GetById(id);
            if (keeps == null)
            {
                throw new Exception("Invalid Id");
            }
            return keeps;
        }
        internal IEnumerable<Keep> GetKeepsByProfileId(string id)
        {
            IEnumerable<Keep> keeps = _kRepo.GetByCreatorId(id);
            return keeps.ToList().FindAll(r => r.IsPrivate != true);
        }

        public Keep Create(Keep newKeep)
        {
            newKeep.Id = _kRepo.Create(newKeep);
            return newKeep;
        }

        internal Keep Edit(Keep editData, string userId)
        {
            Keep original = GetById(editData.Id);
            if (original.CreatorId != userId) { throw new Exception("Access Denied: Cannot Edit a Restaurant You did not Create"); }
            editData.Name = editData.Name == null ? original.Name : editData.Name;
            editData.Description = editData.Description == null ? original.Description : editData.Description;

            return _kRepo.Edit(editData);
        }


        internal object Delete(int id, string userId)
        {
            Keep original = GetById(id);
            if (original.CreatorId != userId) { throw new Exception("Access Denied: Cannot Delete a Keep You did not Create"); }
            _kRepo.Remove(id);
            return "successfully deleted";
        }

        internal IEnumerable<Keep> GetKeepsByAccountId(string id)
        {
            return _kRepo.GetByCreatorId(id);
        }
    }
}