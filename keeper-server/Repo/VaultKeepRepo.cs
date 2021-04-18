using System;
using System.Data;
using Dapper;
using keeper_server.Models;

namespace keeper_server.Repo
{
    public class VaultKeepRepo
    {
        private readonly IDbConnection _db;

        public VaultKeepRepo(IDbConnection db)
        {
            _db = db;
        }

        internal VaultKeep Create(VaultKeep newVaultKeep)
        {
            string sql = @"INSERT INTO vaultkeeps
            (vaultId, keepId, creatorId)
            VALUES
            (@VaultId, @KeepId, @CreatorId);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newVaultKeep);
            newVaultKeep.Id = id;
            return newVaultKeep;
        }

        internal VaultKeep GetKeepById(int keepId)
        {
            string sql = @"SELECT * FROM vaultkeeps WHERE keepId = @keepId;";
            return _db.QueryFirstOrDefault<VaultKeep>(sql, new { keepId });
        }

        internal VaultKeep Delete(int id)
        {
            string sql = "DELETE FROM vaultkeeps WHERE id = @id LIMIT 1;";
            return _db.QueryFirstOrDefault<VaultKeep>(sql, new { id });
        }

        internal VaultKeep GetById(int id)
        {
            string sql = @"SELECT * FROM vaultkeeps WHERE id = @id;";
            return _db.QueryFirstOrDefault<VaultKeep>(sql, new { id });
        }
    }
}
