
namespace VincentTran.JudgeAPI
{
	public class ResultSubmit
	{
		public string stdout { get; set; }
		public float time { get; set; }
		public int memory { get; set; }
		public string stderr { get; set; }
		public string token { get; set; }
		public string compile_output { get; set; }
		public string message { get; set; }
		public JudgeStatus status { get; set; }
		public override string ToString() => Newtonsoft.Json.JsonConvert.SerializeObject(this);
	}
}
