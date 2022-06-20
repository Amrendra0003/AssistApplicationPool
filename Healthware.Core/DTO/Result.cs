using System.Collections.Generic;

namespace Healthware.Core.DTO
{

	public class Result : Result<object>
	{
		public new Result AddError(string message)
		{
			base.AddError(message);
			return this;
		}
	}

	public class  Result<T>
	{
		public Result()
		{
			Errors = new List<string>();
		}

	    public Result(T data) : this()
	    {
	        Data = data;
	    }

	    public T Data { get; set; }
		public bool WasSuccessful => Errors.isNullOrEmpty();
		public List<string> Errors { get; }
		public string NextAction { get; set; }

		public Result<T> AddError(string message)
		{
			Errors.Add(message);
			return this;
		}
	}	
}