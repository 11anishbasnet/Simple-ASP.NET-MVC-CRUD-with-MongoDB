using System.Collections.Generic;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MongoDb.Models.Repo
{


    public class UserRepository
    {
        private readonly MongoDBContext _context;

        public UserRepository(MongoDBContext context)
        {
               _context = context;
        }

        public List<User> GetAllUsers()
        {
            return _context.YourCollection.Find(user => true).ToList();
        }

        public User GetUserById(string id)
        {
            return _context.YourCollection.Find(user => user.Id == id).FirstOrDefault();
        }

        public void AddUser(User user)
        {
            _context.YourCollection.InsertOne(user);
        }

        public void UpdateUser(User updatedUser)
        {
            _context.YourCollection.ReplaceOne(user => user.Id == updatedUser.Id, updatedUser);
        }

        public void DeleteUser(string id)
        {
            _context.YourCollection.DeleteOne(user => user.Id == id);
        }
    }

}
