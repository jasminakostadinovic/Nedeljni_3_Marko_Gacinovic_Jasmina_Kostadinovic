using Cookbook.Validations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookbook.Model
{
	class DataAccess
    {
		public bool IsCorrectUser(string userName, string password)
		{
			try
			{
				using (var conn = new CookbookEntities())
				{
					var user = conn.tblUserDatas.FirstOrDefault(x => x.Username == userName);

					if (user != null)
					{
						var passwordFromDb = conn.tblUserDatas.First(x => x.Username == userName).Password;
						return SecurePasswordHasher.Verify(password, passwordFromDb);
					}
					return false;
				}
			}
			catch (Exception)
			{
				return false;
			}
		}

		internal tblUserData LoadUserByUsername(string userName)
		{
			try
			{
				using (var conn = new CookbookEntities())
				{
					return conn.tblUserDatas.FirstOrDefault(x => x.Username == userName);
				}
			}
			catch (Exception)
			{
				return null;
			}
		}

		internal List<tblRecipe> LoadRecipes()
		{
			try
			{
				using (var conn = new CookbookEntities())
				{
					if (conn.tblRecipes.Any())
						return conn.tblRecipes.ToList();
					return new List<tblRecipe>();
				}
			}
			catch (Exception)
			{
				return new List<tblRecipe>();
			}
		}

		internal bool IsUniqueUsername(string username)
		{
			using (var conn = new CookbookEntities())
			{
				return !conn.tblUserDatas.Any(x => x.Username == username);
			}
		}
		internal bool TryAddNewUserData(tblUserData userData)
		{
			try
			{
				using (var conn = new CookbookEntities())
				{
					conn.tblUserDatas.Add(userData);
					conn.SaveChanges();
					return true;
				}
			}
			catch (Exception)
			{
				return false;
			}
		}

		internal bool TryAddNewRecipe(tblRecipe recipe)
		{
			try
			{
				using (var conn = new CookbookEntities())
				{
					conn.tblRecipes.Add(recipe);
					conn.SaveChanges();
					return true;
				}
			}
			catch (Exception)
			{
				return false;
			}
		}

		internal bool TryUpdateRecipe(tblRecipe updatedRecipe)
		{
			try
			{
				using (var conn = new CookbookEntities())
				{
					var recipeToUpdate = conn.tblRecipes.FirstOrDefault(x => x.RecipeID == updatedRecipe.RecipeID);
					if (recipeToUpdate != null)
					{
						recipeToUpdate.Name = updatedRecipe.Name;
						recipeToUpdate.PersonsCount = updatedRecipe.PersonsCount;
						recipeToUpdate.Type = updatedRecipe.Type;
						conn.SaveChanges();
						return true;
					}
					return false;
				}
			}
			catch (Exception)
			{
				return false;
			}
		}

		internal bool TryRemoveRecipe(int recipeId)
		{
			try
			{
				using (var conn = new CookbookEntities())
				{
					var recipeToRemove = conn.tblRecipes.FirstOrDefault(x => x.RecipeID == recipeId);

					if (recipeToRemove != null)
					{
						conn.tblRecipes.Remove(recipeToRemove);
						conn.SaveChanges();
						return true;
					}
					return false;
				}
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
