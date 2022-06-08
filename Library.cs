using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace SchoolProject
{
    public abstract class Library
    {
        public void AddBook(int pageCount, string title, string isbn)
        {

            InsertBook(pageCount, title, isbn);
        }

        private void InsertBook (int pageCount, string title, string isbn)
        {
           
                var insertQuery = "dbo.InsertIntoBooks @pageCount, @title, @isbn";
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("StoreDB")))
                {
                    connection.Execute(insertQuery, new { pageCount = pageCount, title = title, isbn = isbn });

                }
            } 
           

            
        
        public void RemoveBook(int bookId)
        {
            DeleteBook(bookId);
        }
    

        private void DeleteBook(int bookId)
        {
        var insertPersonQuery = "dbo.DeleteBook @bookId";
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("StoreDB")))
        {
            connection.Execute(insertPersonQuery, new { bookId = bookId });

        }

    }
        public void AddAuthor(string firstName, string lastName)
        {
            InsertAuthor(firstName, lastName);
        }

        private void InsertAuthor(string firstName, string lastName)
        {
            try
            {
                var insertPersonQuery = "dbo.InsertAuthor @firstName, @lastName";
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("StoreDB")))
                {
                    connection.Execute(insertPersonQuery, new { firstName = firstName, lastName = lastName });

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Already inserted");
            }
        }

        public void AddBookAuthor(int bookId, int authorId)
        {
            InsertBookAuthor(bookId, authorId);
        }

        private void InsertBookAuthor(int bookId, int authorId)
        {
            try
            {
                var insertPersonQuery = "dbo.InsertBookAuthor @bookId, @authorId";
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("StoreDB")))
                {
                    connection.Execute(insertPersonQuery, new { bookId = bookId, authorId = authorId });

                }
            } catch (Exception ex)
            {
                Console.WriteLine("Already inserted");
            }
        }


        public void AddGenre(string genre)
        {
            InsertGenre(genre);
        }

        private void InsertGenre(string genre)
        {
            try
            {
                var insertPersonQuery = "dbo.InsertGenre @genre";
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("StoreDB")))
                {
                    connection.Execute(insertPersonQuery, new { genre = genre });

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Already Inserted");
            }
        }
        public void AddBookGenre(int bookId, int genreId)
        {
            InsertBookGenre(bookId, genreId);
        }

        private void InsertBookGenre(int bookId, int genreId)
        {
            var insertPersonQuery = "dbo.InsertBookGenre @bookId, @genreId";
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("StoreDB")))
            {
                connection.Execute(insertPersonQuery, new { bookId = bookId, genreId = genreId });

            }
        }


    }
}
