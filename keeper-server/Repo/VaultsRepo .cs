using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keeper_server.Models;

namespace keeper_server.Repo
{
    public class VaultsRepo
    {
        private readonly IDbConnection _db;

        public VaultsRepo(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Vault> GetAll()
        {
            string sql = @"
       SELECT 
       v.*,
       p.* 
       FROM vaults v
       JOIN profiles p ON v.creatorId = p.id;";
            return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
            {
                vault.Creator = profile; return vault;
            }, splitOn: "id");
        }

        internal Vault GetById(int id)
        {
            string sql = @"
       SELECT 
       v.*,
       p.* 
       FROM vaults v
       JOIN profiles p ON v.creatorId = p.id
       WHERE v.id = @id;";
            return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
            {
                vault.Creator = profile; return vault;
            }, new { id }, splitOn: "id").FirstOrDefault();
        }

        internal IEnumerable<Vault> GetByCreatorId(string id)
        {
            string sql = @"
      SELECT 
      v.*,
      profile.*
      FROM vaults v
      JOIN profiles profile ON v.creatorId = profile.id
      WHERE v.creatorId = @id;";
            return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
            {
                vault.Creator = profile;
                return vault;
            }, new { id }, splitOn: "id");
        }



        internal int Create(Vault newV)
        {
            string sql = @"
            INSERT INTO vaults
            (name, description, creatorId, isPrivate)
            VALUES
            (@Name, @Description, @CreatorId, @IsPrivate);
            SELECT LAST_INSERT_ID()";
            return _db.ExecuteScalar<int>(sql, newV);
        }

        internal Vault Edit(Vault editData)
        {
            string sql = @"
            UPDATE vaults
            SET 
            name = @Name,
            description = @Description
            WHERE id = @Id;";
            _db.Execute(sql, editData);
            return editData;
        }


        internal void Remove(int id)
        {
            string sql = "DELETE FROM vaults WHERE id = @id LIMIT 1";
            _db.Execute(sql, new { id });
        }


    }
}