using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Reflection;

namespace Week3Assignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Week3 : ControllerBase
    {

        [HttpPost(Name = "StdDevSample")]
        public ActionResult<List<string>> IntListWork(List<int> lint)
        {
            try
            {
                double count = 0;
                double sum = 0;
                List<string> result = new List<string>();

                LogObject(lint);

                lint.OrderBy(a => a).ToList();

                for (int i = 0; i < lint.Count; i++)
                {
                    sum += lint[i];
                    count++;
                    if (count < 2)
                    {
                        result.Add("Elements: 1, List too small");
                    }
                    else
                    {
                        result.Add($"Elements: {count}, Current Standard Deviation: {StandardDeviation(lint.GetRange(0, i + 1))}");
                    }

                }
                return Ok(result);
            } catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        static double StandardDeviation(List<int> sample)
        {
            double count = sample.Count;

            double mean = sample.Average(i => (double)i);
            double stdsum = 0;

            // getting the sum of each number divided by the mean.
            foreach (int i in sample)
            {
                stdsum += Math.Pow(i - mean, 2);
            }

            return Math.Sqrt(stdsum / (count - 1));
        }

        static void LogObject(List<int> input)
        {
            foreach (int i in input)
            {
                Console.WriteLine(i.ToString());
            }
        }
    }
}