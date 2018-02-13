
namespace VincentTran.JudgeAPI
{
	public class DetailSubmit
	{
		public string source_code { get; set; }
		public int language_id { get; set; }
		public int number_of_runs { get; set; }
		public string stdin { get; set; }
		public string expected_output { get; set; }
		public float cpu_time_limit { get; set; }
		public float cpu_extra_time { get; set; }
		public int wall_time_limit { get; set; }
		public long memory_limit { get; set; }
		public long stack_limit { get; set; }
		public int max_processes_and_or_threads { get; set; }
		public bool enable_per_process_and_thread_time_limit { get; set; }
		public bool enable_per_process_and_thread_memory_limit { get; set; }
		public long max_file_size { get; set; }
		public DetailSubmit DefaultSumit(string src,int langID,string input,string output)
			=> new DetailSubmit()
			{
				source_code = src,
				language_id = langID,
				number_of_runs = 1,
				stdin = input,
				expected_output = output,
				cpu_time_limit = (float)2,
				cpu_extra_time = (float)0.5,
				wall_time_limit = 5,
				memory_limit = 128000,
				stack_limit = 64000,
				max_processes_and_or_threads = 30,
				enable_per_process_and_thread_time_limit = false,
				enable_per_process_and_thread_memory_limit = false,
				max_file_size = 1024
			};
	}
}
