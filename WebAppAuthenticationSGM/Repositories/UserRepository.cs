using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using WebAppAuthenticationSGM.Models;

namespace WebAppAuthenticationSGM.Repositories
{
    public class UserRepository
    {
        private readonly IMongoCollection<User> _users;
        public UserRepository(ISgmAuthenticationDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.SgmCollectionName);
        }
        //public static User Get(string username, string password){
        //    var users = new List<User>();
        //    users.Add(new User {Id = 1, Login = "joao", Password = "joao", Role = "gerente"});
        //    users.Add(new User {Id = 1, Login = "manoel", Password = "manoel", Role = "analista"});
        //    return users.Where(x => x.Login.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        //}
        public User Get(string username, string password) => 
            _users.Find<User>(user => user.Login.ToLower() == username.ToLower() && user.Password == password).FirstOrDefault();

        public User Get(string id) =>
            _users.Find<User>(user => user.Id == id).FirstOrDefault();

        public User Create(User User)
        {
            _users.InsertOne(User);
            return User;
        }

        public void Update(string id, User UserIn) =>
            _users.ReplaceOne(User => User.Id == id, UserIn);

        public void Remove(User UserIn) =>
            _users.DeleteOne(User => User.Id == UserIn.Id);

        public void Remove(string id) =>
            _users.DeleteOne(User => User.Id == id);

    }
}