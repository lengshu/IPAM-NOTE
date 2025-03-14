﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPAM_NOTE.DatabaseOperation
{
	internal class DbClass
	{


		public SQLiteConnection connection;


		public DbClass(string dbPath)
		{
			connection = new SQLiteConnection($"Data Source={dbPath};Version=3;");
		}

		public void OpenConnection()
		{
			if (connection.State != System.Data.ConnectionState.Open)
			{
				connection.Open();
			}
		}


		public void CloseConnection()
		{
			if (connection.State != System.Data.ConnectionState.Closed)
			{
				connection.Close();
			}
		}

		public void CreateTable(string query)
		{
			SQLiteCommand command = new SQLiteCommand(query, connection);
			command.ExecuteNonQuery();
		}


		public  SQLiteDataReader ExecuteQuery(string query)
		{
			using (SQLiteCommand command = new SQLiteCommand(query, connection))
			{
				using (SQLiteDataReader reader = command.ExecuteReader())
				{
					return reader;
				}
			}
		}




		// 执行 SQL 查询函数
		static void ExecuteSql(SQLiteConnection connection, string sqlQuery)
		{
			// 创建命令对象
			using (SQLiteCommand command = new SQLiteCommand(sqlQuery, connection))
			{
				try
				{
					// 执行 SQL 命令
					int rowsAffected = command.ExecuteNonQuery();

					// 输出受影响的行数
					Console.WriteLine($"Rows Affected: {rowsAffected}");
				}
				catch (Exception ex)
				{
					// 处理异常
					Console.WriteLine($"Error executing SQL query: {ex.Message}");
				}
			}
		}



		/// <summary>
		/// 查询表中的数据数量，返回数据条数
		/// </summary>
		/// <param name="sql"></param>
		/// <returns></returns>
		public static int ExecuteScalarTableNum(string sql,SQLiteConnection connection)
		{
			
				

				using (SQLiteCommand command = new SQLiteCommand(sql,connection))
				{
					// 使用 ExecuteScalar 获取总行数
					int rowCount = Convert.ToInt32(command.ExecuteScalar());

					return rowCount;

					//MessageBox.Show( GlobalFunction.IpAddressConvert.IpToDecimal(IpTextBox.Text).ToString());

				}


			

		}


		/// <summary>
		/// 异步插入数据
		/// </summary>
		/// <param name="sql"></param>
		/// <returns></returns>
		public async Task InsertDataAsync(string sql)
		{
			using (connection)
			{
				await connection.OpenAsync();

				using (SQLiteCommand command = connection.CreateCommand())
				{
					
					command.CommandText = sql;

					// 异步执行插入操作
					await command.ExecuteNonQueryAsync();
				}
			}
		}


	}
}
