using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace NewGame4.Users
{
    public class UserModel
    {
        private Dictionary<string, IUserUnitModel> _users = new Dictionary<string, IUserUnitModel>();
        public Dictionary<string, string> emails = new Dictionary<string, string>();
        public void Serialize(ServerContext context)
        {
            foreach (var user in _users.Values)
            {
                var command = new SqlCommand("")
                {
                    Connection = context.BdConnection.Connection
                };
                
                if (user.IsNew)
                {
                    user.IsNew = false;
                    command.CommandText = $"INSERT INTO users(name, user_id, is_authorisation, second_name, email, password, session) VALUES('{user.Name}', '{user.UserId}', '{user.IsAuthorisation}', '{user.SecondName}', '{user.Email}', '{user.Password}', '{user.Session}')";
                    command.ExecuteNonQuery();
                }
                else
                {
                    try
                    {
                        using (SqlCommand command1 = context.BdConnection.Connection.CreateCommand())
                        {
                            command1.CommandText = $"UPDATE users SET session = @session WHERE user_id = @userId";
                            command1.Parameters.Add("@session", SqlDbType.NVarChar).Value = user.Session;
                            command1.Parameters.Add("@userId", SqlDbType.NVarChar).Value = user.UserId;
                            command1.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
        }

        public void Deserialize(ServerContext context)
        {
            var command = new SqlCommand("")
            {
                Connection = context.BdConnection.Connection
            };
            
            command.CommandText = $"SELECT * FROM users";
            var userReader = command.ExecuteReader();
            while (userReader.Read())
            {
                var user = new UserUnitModel()
                {
                    UserId = userReader.GetString("user_id"),
                    Name = userReader.GetString("name"),
                    SecondName = userReader.GetString("second_name"),
                    Email = userReader.GetString("email"),
                    Password = userReader.GetString("password"),
                    Session = userReader.GetString("session")
                };
                _users.Add(user.UserId, user);
                emails.Add(user.Email, user.UserId);
            }
            userReader.Close();
        }

        public IUserUnitModel Get(string id)
        {
            return _users[id];
        }

        public bool Contains(string id)
        {
            return _users.ContainsKey(id);
        }

        public void Add(string id, IUserUnitModel user)
        {
            _users.Add(user.UserId, user);
            emails.Add(user.Email, user.UserId);
        }
    }
}