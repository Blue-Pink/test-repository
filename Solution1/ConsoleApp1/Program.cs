// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using RestSharp;

Stopwatch stopwatch=new();
stopwatch.Start();
Thread.Sleep(50);
var th2 = new Thread(Test5200)
{
    IsBackground = true
};
th2.Start();
var th3 = new Thread(Test5300)
{
    IsBackground = true
};
th3.Start();
Test5100();
stopwatch.Stop();
string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
    stopwatch.Elapsed.Hours, stopwatch.Elapsed.Minutes, stopwatch.Elapsed.Seconds,
    stopwatch.Elapsed.Milliseconds / 10);
Console.WriteLine(elapsedTime);

static void Test5100()
{
    var client = new RestClient("http://localhost:5100/t/saascrmplatformdev/api/dynamic/new_alynx_test_entity/SaveAndFetch");
    client.Timeout = -1;
    var request = new RestRequest(Method.POST);
    client.UserAgent = "apifox/1.0.0 (https://www.apifox.cn)";
    request.AddHeader("Authorization", "Bearer eyJhbGciOiJSUzI1NiIsInR5cCIgOiAiSldUIiwia2lkIiA6ICJ5VGdiUEpzdk5pdFRIQ254SGNCRGlVX0Q5QzlUaXZxRUM5TlRrTzZRUmZBIn0.eyJleHAiOjE2NTI2ODQ3OTksImlhdCI6MTY1MjY3NzU5OSwiYXV0aF90aW1lIjoxNjUyNjc3NTk5LCJqdGkiOiI5ODQxMDE3YS0zZTYxLTQ5OWEtOTc1NC0xYTEzMDhiY2NlNWYiLCJpc3MiOiJodHRwOi8vMTkyLjE2OC43LjE2NDo4MDgxL2F1dGgvcmVhbG1zL3NhYXNjcm1wbGF0Zm9ybWRldiIsImF1ZCI6WyJyZWFsbS1tYW5hZ2VtZW50IiwiYWNjb3VudCJdLCJzdWIiOiJmMmFlZTgyMi04OGVjLTRmMTUtYTQ2NS01NGZiOWQ2NzhlM2MiLCJ0eXAiOiJCZWFyZXIiLCJhenAiOiJjcm0iLCJub25jZSI6IjVlZWYyMDVlLTc4NmMtNGQ0OC04ODNjLWZlNGQzNmNmMTJiNiIsInNlc3Npb25fc3RhdGUiOiI3YWM5ODIzYy01YjM1LTRiYTAtYmMzMi00M2ZkOTljMzExZjEiLCJhY3IiOiIxIiwiYWxsb3dlZC1vcmlnaW5zIjpbImh0dHA6Ly8xOTIuMTY4LjcuMTY0OjUwODgiLCIqIl0sInJlc291cmNlX2FjY2VzcyI6eyJyZWFsbS1tYW5hZ2VtZW50Ijp7InJvbGVzIjpbInZpZXctaWRlbnRpdHktcHJvdmlkZXJzIiwidmlldy1yZWFsbSIsIm1hbmFnZS1pZGVudGl0eS1wcm92aWRlcnMiLCJpbXBlcnNvbmF0aW9uIiwicmVhbG0tYWRtaW4iLCJjcmVhdGUtY2xpZW50IiwibWFuYWdlLXVzZXJzIiwicXVlcnktcmVhbG1zIiwidmlldy1hdXRob3JpemF0aW9uIiwicXVlcnktY2xpZW50cyIsInF1ZXJ5LXVzZXJzIiwibWFuYWdlLWV2ZW50cyIsIm1hbmFnZS1yZWFsbSIsInZpZXctZXZlbnRzIiwidmlldy11c2VycyIsInZpZXctY2xpZW50cyIsIm1hbmFnZS1hdXRob3JpemF0aW9uIiwibWFuYWdlLWNsaWVudHMiLCJxdWVyeS1ncm91cHMiXX0sImFjY291bnQiOnsicm9sZXMiOlsibWFuYWdlLWFjY291bnQiLCJtYW5hZ2UtYWNjb3VudC1saW5rcyIsInZpZXctcHJvZmlsZSJdfX0sInNjb3BlIjoib3BlbmlkIGVtYWlsIHByb2ZpbGUiLCJzaWQiOiI3YWM5ODIzYy01YjM1LTRiYTAtYmMzMi00M2ZkOTljMzExZjEiLCJlbWFpbF92ZXJpZmllZCI6ZmFsc2UsInByZWZlcnJlZF91c2VybmFtZSI6ImFkbWluaXN0cmF0b3IiLCJlbWFpbCI6IjE3MzYzOTY3NzRAcXEuY29tIn0.O8vq-7qjYfZZtiFF8UIe7K1Msy4NddQchIoZQeQd71GyLsVc20O6FOVMbNHt3KVnD6oaIZeMvdGO4rToKejzsed7KxwRjMrWxOtMnko_bq2JYuJggRbvl01m55LF3Ee7yYSV2er1NwlbK4ibkmMxmZhqXPU11NPitcFMoEStBL8byDhA6FGgHToyJ_gbcutWokl-bkrmbV-Y1UKb_KQI-xhsFl9JCF8W4dup75We4OX-vagSvcZnb6OlX4Ag2oF04qQk0Tx5rLL6wobV-NbGpvFDkWIlNjJW8cGrj7C8PjMBMcdrZOzLD0frVwj3P0HYxJof4bEe75IzUcQguMJqgQ");
    var body = @"{}";
    request.AddParameter("text/plain", body, ParameterType.RequestBody);
    for (int i = 0; i < 500; i++)
    {
        IRestResponse response = client.Execute(request);
        Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()?.Name + ":" + response.Content.Substring(response.Content.IndexOf("new_name", StringComparison.Ordinal), 40));
        Thread.Sleep(0);
    }

}

static void Test5200()
{
    var client = new RestClient("http://localhost:5200/t/saascrmplatformdev/api/dynamic/new_alynx_test_entity/SaveAndFetch");
    client.Timeout = -1;
    var request = new RestRequest(Method.POST);
    client.UserAgent = "apifox/1.0.0 (https://www.apifox.cn)";
    request.AddHeader("Authorization", "Bearer eyJhbGciOiJSUzI1NiIsInR5cCIgOiAiSldUIiwia2lkIiA6ICJ5VGdiUEpzdk5pdFRIQ254SGNCRGlVX0Q5QzlUaXZxRUM5TlRrTzZRUmZBIn0.eyJleHAiOjE2NTI2ODQ3OTksImlhdCI6MTY1MjY3NzU5OSwiYXV0aF90aW1lIjoxNjUyNjc3NTk5LCJqdGkiOiI5ODQxMDE3YS0zZTYxLTQ5OWEtOTc1NC0xYTEzMDhiY2NlNWYiLCJpc3MiOiJodHRwOi8vMTkyLjE2OC43LjE2NDo4MDgxL2F1dGgvcmVhbG1zL3NhYXNjcm1wbGF0Zm9ybWRldiIsImF1ZCI6WyJyZWFsbS1tYW5hZ2VtZW50IiwiYWNjb3VudCJdLCJzdWIiOiJmMmFlZTgyMi04OGVjLTRmMTUtYTQ2NS01NGZiOWQ2NzhlM2MiLCJ0eXAiOiJCZWFyZXIiLCJhenAiOiJjcm0iLCJub25jZSI6IjVlZWYyMDVlLTc4NmMtNGQ0OC04ODNjLWZlNGQzNmNmMTJiNiIsInNlc3Npb25fc3RhdGUiOiI3YWM5ODIzYy01YjM1LTRiYTAtYmMzMi00M2ZkOTljMzExZjEiLCJhY3IiOiIxIiwiYWxsb3dlZC1vcmlnaW5zIjpbImh0dHA6Ly8xOTIuMTY4LjcuMTY0OjUwODgiLCIqIl0sInJlc291cmNlX2FjY2VzcyI6eyJyZWFsbS1tYW5hZ2VtZW50Ijp7InJvbGVzIjpbInZpZXctaWRlbnRpdHktcHJvdmlkZXJzIiwidmlldy1yZWFsbSIsIm1hbmFnZS1pZGVudGl0eS1wcm92aWRlcnMiLCJpbXBlcnNvbmF0aW9uIiwicmVhbG0tYWRtaW4iLCJjcmVhdGUtY2xpZW50IiwibWFuYWdlLXVzZXJzIiwicXVlcnktcmVhbG1zIiwidmlldy1hdXRob3JpemF0aW9uIiwicXVlcnktY2xpZW50cyIsInF1ZXJ5LXVzZXJzIiwibWFuYWdlLWV2ZW50cyIsIm1hbmFnZS1yZWFsbSIsInZpZXctZXZlbnRzIiwidmlldy11c2VycyIsInZpZXctY2xpZW50cyIsIm1hbmFnZS1hdXRob3JpemF0aW9uIiwibWFuYWdlLWNsaWVudHMiLCJxdWVyeS1ncm91cHMiXX0sImFjY291bnQiOnsicm9sZXMiOlsibWFuYWdlLWFjY291bnQiLCJtYW5hZ2UtYWNjb3VudC1saW5rcyIsInZpZXctcHJvZmlsZSJdfX0sInNjb3BlIjoib3BlbmlkIGVtYWlsIHByb2ZpbGUiLCJzaWQiOiI3YWM5ODIzYy01YjM1LTRiYTAtYmMzMi00M2ZkOTljMzExZjEiLCJlbWFpbF92ZXJpZmllZCI6ZmFsc2UsInByZWZlcnJlZF91c2VybmFtZSI6ImFkbWluaXN0cmF0b3IiLCJlbWFpbCI6IjE3MzYzOTY3NzRAcXEuY29tIn0.O8vq-7qjYfZZtiFF8UIe7K1Msy4NddQchIoZQeQd71GyLsVc20O6FOVMbNHt3KVnD6oaIZeMvdGO4rToKejzsed7KxwRjMrWxOtMnko_bq2JYuJggRbvl01m55LF3Ee7yYSV2er1NwlbK4ibkmMxmZhqXPU11NPitcFMoEStBL8byDhA6FGgHToyJ_gbcutWokl-bkrmbV-Y1UKb_KQI-xhsFl9JCF8W4dup75We4OX-vagSvcZnb6OlX4Ag2oF04qQk0Tx5rLL6wobV-NbGpvFDkWIlNjJW8cGrj7C8PjMBMcdrZOzLD0frVwj3P0HYxJof4bEe75IzUcQguMJqgQ");
    var body = @"{}";
    request.AddParameter("text/plain", body, ParameterType.RequestBody);
    for (int i = 0; i < 500; i++)
    {
        IRestResponse response = client.Execute(request);
        Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()?.Name + ":" + response.Content.Substring(response.Content.IndexOf("new_name", StringComparison.Ordinal),40));
        Thread.Sleep(0);
    }
}

static void Test5300()
{
    var client = new RestClient("http://localhost:5200/t/saascrmplatformdev/api/dynamic/new_alynx_test_entity/SaveAndFetch");
    client.Timeout = -1;
    var request = new RestRequest(Method.POST);
    client.UserAgent = "apifox/1.0.0 (https://www.apifox.cn)";
    request.AddHeader("Authorization", "Bearer eyJhbGciOiJSUzI1NiIsInR5cCIgOiAiSldUIiwia2lkIiA6ICJ5VGdiUEpzdk5pdFRIQ254SGNCRGlVX0Q5QzlUaXZxRUM5TlRrTzZRUmZBIn0.eyJleHAiOjE2NTI2ODQ3OTksImlhdCI6MTY1MjY3NzU5OSwiYXV0aF90aW1lIjoxNjUyNjc3NTk5LCJqdGkiOiI5ODQxMDE3YS0zZTYxLTQ5OWEtOTc1NC0xYTEzMDhiY2NlNWYiLCJpc3MiOiJodHRwOi8vMTkyLjE2OC43LjE2NDo4MDgxL2F1dGgvcmVhbG1zL3NhYXNjcm1wbGF0Zm9ybWRldiIsImF1ZCI6WyJyZWFsbS1tYW5hZ2VtZW50IiwiYWNjb3VudCJdLCJzdWIiOiJmMmFlZTgyMi04OGVjLTRmMTUtYTQ2NS01NGZiOWQ2NzhlM2MiLCJ0eXAiOiJCZWFyZXIiLCJhenAiOiJjcm0iLCJub25jZSI6IjVlZWYyMDVlLTc4NmMtNGQ0OC04ODNjLWZlNGQzNmNmMTJiNiIsInNlc3Npb25fc3RhdGUiOiI3YWM5ODIzYy01YjM1LTRiYTAtYmMzMi00M2ZkOTljMzExZjEiLCJhY3IiOiIxIiwiYWxsb3dlZC1vcmlnaW5zIjpbImh0dHA6Ly8xOTIuMTY4LjcuMTY0OjUwODgiLCIqIl0sInJlc291cmNlX2FjY2VzcyI6eyJyZWFsbS1tYW5hZ2VtZW50Ijp7InJvbGVzIjpbInZpZXctaWRlbnRpdHktcHJvdmlkZXJzIiwidmlldy1yZWFsbSIsIm1hbmFnZS1pZGVudGl0eS1wcm92aWRlcnMiLCJpbXBlcnNvbmF0aW9uIiwicmVhbG0tYWRtaW4iLCJjcmVhdGUtY2xpZW50IiwibWFuYWdlLXVzZXJzIiwicXVlcnktcmVhbG1zIiwidmlldy1hdXRob3JpemF0aW9uIiwicXVlcnktY2xpZW50cyIsInF1ZXJ5LXVzZXJzIiwibWFuYWdlLWV2ZW50cyIsIm1hbmFnZS1yZWFsbSIsInZpZXctZXZlbnRzIiwidmlldy11c2VycyIsInZpZXctY2xpZW50cyIsIm1hbmFnZS1hdXRob3JpemF0aW9uIiwibWFuYWdlLWNsaWVudHMiLCJxdWVyeS1ncm91cHMiXX0sImFjY291bnQiOnsicm9sZXMiOlsibWFuYWdlLWFjY291bnQiLCJtYW5hZ2UtYWNjb3VudC1saW5rcyIsInZpZXctcHJvZmlsZSJdfX0sInNjb3BlIjoib3BlbmlkIGVtYWlsIHByb2ZpbGUiLCJzaWQiOiI3YWM5ODIzYy01YjM1LTRiYTAtYmMzMi00M2ZkOTljMzExZjEiLCJlbWFpbF92ZXJpZmllZCI6ZmFsc2UsInByZWZlcnJlZF91c2VybmFtZSI6ImFkbWluaXN0cmF0b3IiLCJlbWFpbCI6IjE3MzYzOTY3NzRAcXEuY29tIn0.O8vq-7qjYfZZtiFF8UIe7K1Msy4NddQchIoZQeQd71GyLsVc20O6FOVMbNHt3KVnD6oaIZeMvdGO4rToKejzsed7KxwRjMrWxOtMnko_bq2JYuJggRbvl01m55LF3Ee7yYSV2er1NwlbK4ibkmMxmZhqXPU11NPitcFMoEStBL8byDhA6FGgHToyJ_gbcutWokl-bkrmbV-Y1UKb_KQI-xhsFl9JCF8W4dup75We4OX-vagSvcZnb6OlX4Ag2oF04qQk0Tx5rLL6wobV-NbGpvFDkWIlNjJW8cGrj7C8PjMBMcdrZOzLD0frVwj3P0HYxJof4bEe75IzUcQguMJqgQ");
    var body = @"{}";
    request.AddParameter("text/plain", body, ParameterType.RequestBody);
    for (int i = 0; i < 500; i++)
    {
        IRestResponse response = client.Execute(request);
        Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()?.Name + ":" + response.Content.Substring(response.Content.IndexOf("new_name", StringComparison.Ordinal),40));
        Thread.Sleep(0);
    }
}
