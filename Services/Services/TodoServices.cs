using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Domain.Emtities;
using Domain.Wrapper;
using Npgsql;

namespace Services.Services
{
    public class TodoServices
    {
        private string _connectionString;
        public TodoServices()
        {
            _connectionString = "Server = 127.0.0.1; Port = 5433; Database = Todo; User Id = postgres; Password = 45sD67ghone;";
        }
        public async Task<Response<Todo>> AddTodo(Todo todo)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                string sql = $"INSERT INTO Todo( TaskName , Status) VALUES (@TaskName , @Status) RETURNING id";
                try
                {
                    var result = await connection.ExecuteScalarAsync<int>(sql, new { todo.TaskName, todo.Status });
                    todo.Id = result;
                    return new Response<Todo>(todo);
                }
                catch (Exception ex)
                {
                    return new Response<Todo>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
                }
            }
        }
        public async Task<Response<List<Todo>>> GetTodo()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                string sql = $"SELECT * FROM Todo";
                try
                {
                    var result = await connection.QueryAsync<Todo>(sql);
                    return new Response<List<Todo>>(result.ToList());
                }
                catch (Exception ex)
                {
                    return new Response<List<Todo>>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
                }
            }
        }

        public async Task<Response<Todo>> UpdateTodo(Todo todo)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                string sql = "UPDATE Todo Set TaskName = @TaskName , Status = @Status WHERE Todo.Id = @Id";
                try
                {
                    var result = await connection.ExecuteScalarAsync<Todo>(sql, new { todo.TaskName, todo.Status, todo.Id });
                    return new Response<Todo>(todo);
                }
                catch (Exception ex)
                {
                    return new Response<Todo>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
                }
            }
        }

        public async Task<Response<string>> DeleteTodo(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                var sql = "DELETE FROM Todo WHERE Todo.id = @id";
                try
                {
                    var result = await connection.ExecuteAsync(sql, new { id });
                    return new Response<string>(result.ToString());
                }
                catch (Exception ex)
                {
                    return new Response<string>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
                }
            }
        }
        public async Task<Response<List<TodoDto>>> GetTodoWithStatusName()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                string sql = $"SELECT * FROM Todo ";
                try
                {
                    var result = await connection.QueryAsync<TodoDto>(sql);
                    
                    return new Response<List<TodoDto>>(result.ToList());
                }
                catch (Exception ex)
                {
                    return new Response<List<TodoDto>>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
                }
            }
        }

    }
}

