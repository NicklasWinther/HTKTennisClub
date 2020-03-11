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
                $"SELECT * FROM Members";
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

        public int CreateMember(Member newMember)
        {
            string sql =
                $"INSERT INTO Members (Firstname, Lastname, Address, PhoneNumber, Email, BirthDate, Active) " +
                $"VALUES ('{newMember.Firstname}', '{newMember.Lastname}', '{newMember.Address}', '{newMember.PhoneNumber}', '{newMember.Email}', '{newMember.BirthDate.ToString("yyyy-MM-dd")}', 1)";

            return ExecuteNonQuery(sql);
        }
    }
}
