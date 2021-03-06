using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using NLog;
using NLog.Web;
using System;

namespace NLogDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // 读取指定位置的配置文件
            var logger = NLogBuilder.ConfigureNLog("XmlConfig/nlog.config").GetCurrentClassLogger();

            try
            {
                logger.Info("Init Main");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Stopped program because of exception");
            }
            finally
            {
                LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                // 配置使用NLog
                .UseNLog();
    }
}
