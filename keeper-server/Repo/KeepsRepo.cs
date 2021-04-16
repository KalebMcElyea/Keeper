using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keeper_server.Models;

namespace keeper_server.Repo
{
    public class KeepsRepo
    {
        private readonly IDbConnection _db;

        public KeepsRepo(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Keep> GetAll()
        {
            string sql = @"
       SELECT 
       keep.*,
       profile.* 
       FROM keeps keep
       JOIN profiles profile ON keep.creatorId = profile.id;";
            return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
            {
                keep.Creator = profile; return keep;
            }, splitOn: "id");
        }

        internal Keep GetById(int id)
        {
            string sql = @"
       SELECT 
       keep.*,
       profile.* 
       FROM keeps keep
       JOIN profiles profile ON keep.creatorId = profile.id
       WHERE keep.id = @id;";
            return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
            {
                keep.Creator = profile; return keep;
            }, new { id }, splitOn: "id").FirstOrDefault();
        }

        internal IEnumerable<Keep> GetByCreatorId(string id)
        {
            string sql = @"
      SELECT 
      k.*,
      profile.*
      FROM keeps k
      JOIN profiles profile ON k.creatorId = profile.id
      WHERE k.creatorId = @id;";
            return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
            {
                keep.Creator = profile;
                return keep;
            }, new { id }, splitOn: "id");
        }

        internal int Create(Keep newKeep)
        {
            string sql = @"
            INSERT INTO keeps
            (name, creatorId, description, img)
            VALUES
            (@Name, @CreatorId, @Description, @Img);
            SELECT LAST_INSERT_ID()";
            return _db.ExecuteScalar<int>(sql, newKeep);
        }

        internal Keep Edit(Keep editData)
        {
            string sql = @"
            UPDATE keeps
            SET 
            name = @Name,
            description = @Description
            WHERE id = @Id;";
            _db.Execute(sql, editData);
            return editData;
        }

        internal void Remove(int id)
        {
            string sql = "DELETE FROM keeps WHERE id = @id LIMIT 1";
            _db.Execute(sql, new { id });
        }
    }
}