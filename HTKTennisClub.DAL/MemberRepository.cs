using HTKTennisClub.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTKTennisClub.DAL
{
    public class MemberRepository : BaseRepository
    {
        public List<Member> GetAllMembers()
        {
            string sql =
                $"SELECT * FROM Members ORDER BY Active DESC";
            return HandleData(ExecuteQuery(sql));
        }

        private List<Member> HandleData(DataTable dataTable)
        {
            List<Member> members= new List<Member>();

            if (dataTable is null)
                return members;

            foreach (DataRow row in dataTable.Rows)
            {
                Member member = new Member()
                {
                    Id = (int)row["Id"],
                    Firstname = (string)row["Firstname"],
                    Lastname = (string)row["Lastname"],
                    Address = (string)row["Address"],
                    Email = (string)row["Email"],
                    PhoneNumber= (string)row["PhoneNumber"],
                    BirthDate = (DateTime)row["BirthDate"],
                    Active = Convert.ToBoolean(row["Active"]),
                };
                members.Add(member);
            }
            return members;
        }

        public int CreateMember(Member member)
        {
            string sql =
                $"INSERT INTO Members (Firstname, Lastname, Address, PhoneNumber, Email, BirthDate, Active) " +
                $"VALUES ('{member.Firstname}', '{member.Lastname}', '{member.Address}', '{member.PhoneNumber}', '{member.Email}', '{member.BirthDate.ToString("yyyy-MM-dd")}', 1)";

            return ExecuteNonQuery(sql);
        }

        public int UpdateMember(Member member)
        {
               string sql = $"UPDATE Members " +
                      $"SET Firstname = '{member.Firstname}', Lastname = '{member.Lastname}', Address = '{member.Address}', Email = '{member.Email}', PhoneNumber = '{member.PhoneNumber}', Active = '{Convert.ToInt32(member.Active)}' " +
                      $"WHERE Id = {member.Id}";

            return ExecuteNonQuery(sql);
        }
    }
}
