using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CriticsClubServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public List<club> GetAllClubs()
        {
            CriticsClubDataDataContext db = new CriticsClubDataDataContext();
            var clubs = new List<club>();

            using (db)
            {
                var result = db.clubs.ToList();
                result.ForEach(c =>
                {
                    clubs.Add(c);
                });
            }
            return clubs;
        }
        public List<book> GetAllBooks()
        {
            CriticsClubDataDataContext db = new CriticsClubDataDataContext();
            var books = new List<book>();

            using (db)
            {
                var result = db.books.ToList();
                result.ForEach(b =>
                {
                    books.Add(b);
                });
            }

            return books;

        }
        public List<user> GetAllUsers()
        {
            CriticsClubDataDataContext db = new CriticsClubDataDataContext();
            var users = new List<user>();

            using (db)
            {
                var result = db.users.ToList();
                result.ForEach(b =>
                {
                    users.Add(b);
                });
            }

            return users;
        }
        public List<user> GetAllUsersInClub(string club_id)
        {
            CriticsClubDataDataContext db = new CriticsClubDataDataContext();

            var users = new List<user>();

            using (db)
            {
                var members = db.users.Where(u => u.club_id == Int32.Parse(club_id)).ToList();
                members.ForEach(m =>
                {
                    users.Add(m);
                });
            }

            return users;

           



        }
        public List<book> GetAllBooksPerClub(string club_id)
        {
            CriticsClubDataDataContext db = new CriticsClubDataDataContext();
            var books = new List<book>();

            using (db)
            {
                var meetings = db.meetings.Where(m => m.club_id == Int32.Parse(club_id)).ToList();
                meetings.ForEach(m =>
                {
                    books.Add(db.books.Where(b => b.book_id == m.book_id).FirstOrDefault());
                });

            }
            return books;
        }
        book IService1.GetBookDiscussed(string meeting_id)
        {
            CriticsClubDataDataContext db = new CriticsClubDataDataContext();
            meeting meeting1 = db.meetings.Where(m => m.meeting_id == Int32.Parse(meeting_id)).FirstOrDefault();
            book book1 = db.books.Where(b => b.book_id == meeting1.book_id).FirstOrDefault();
            return book1;

        }
        public List<meeting> GetAllMeetings()
        {
            CriticsClubDataDataContext db = new CriticsClubDataDataContext();
            return db.meetings.ToList();
        }
    }
}

