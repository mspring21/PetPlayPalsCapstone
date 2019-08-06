﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    public class PetSqlDAO : IPetDAO
    {
        private readonly string connectionString;

        public PetSqlDAO (string connectionString)
        {
            this.connectionString = connectionString;
        }


        public int AddPet(Pets pet)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    //TODO: Finish this query
                    conn.Open();

                    string sql = $"Insert Into Pets Values (@userId, @name, @type, @personality, @weight, @breed, @age, @photo); Select @@Identity ";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@userId", pet.UserId);
                    cmd.Parameters.AddWithValue("@type", pet.Type);
                    cmd.Parameters.AddWithValue("@personality", pet.Personality);
                    cmd.Parameters.AddWithValue("@weight", pet.Weight);
                    cmd.Parameters.AddWithValue("@breed", pet.Breed);
                    cmd.Parameters.AddWithValue("@age", pet.Age);
                    cmd.Parameters.AddWithValue("@photo", pet.Photo);
                    cmd.Parameters.AddWithValue("@name", pet.Name);

                    int Id = Convert.ToInt32(cmd.ExecuteScalar());

                    return Id;

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }


        public IList<Pets> GetAllPets(int userId)
        {
            IList<Pets> list = new List<Pets>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = $"Select * from Pets where userId = @userId";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@userId", userId);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Pets pet = new Pets();

                        pet.Id = Convert.ToInt32(rdr["id"]);
                        pet.Name = Convert.ToString(rdr["name"]);
                        pet.Personality = Convert.ToString(rdr["personality"]);
                        pet.Photo = Convert.ToString(rdr["photo"]);
                        pet.Type = Convert.ToString(rdr["type"]);
                        pet.UserId = Convert.ToInt32(rdr["userId"]);
                        pet.Weight = Convert.ToInt32(rdr["weight"]);
                        pet.Breed = Convert.ToString(rdr["breed"]);
                        pet.Age = Convert.ToInt32(rdr["age"]);

                        list.Add(pet);
                    
                    }

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return list;
        }

    }
}
